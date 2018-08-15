// (c) 2005 GestorFincas Baltasar MIT License <baltasarq@gmail.com>

namespace EstateManager.Core
{
	using System;
	using System.Xml;
	using System.Globalization;
	using System.Collections.Generic;


    /// <summary>
    /// Lleva la base de datos del programa, a partir de un archivo XML
    /// </summary>
    public class Database
    {
        public const string EtqLugar = "LUGAR";
        public const string EtqNombre = "NOMBRE";
        public const string EtqId = "ID";
        public const string EtqMarcaRaiz = "FINCAS";
        public const string EtqFinca = "FINCA";
        public const string EtqArea = "AREA";
        public const string EtqRefCatastral = "REFCATASTRAL";
        public const string EtqTipo = "TIPO";
        public const string EtqUrbana = "URBANA";
        public const string EtqRustica = "RUSTICA";
        public const string EtqObs = "OBSERVACIONES";
        public const string EtqVendido = "VENDIDO";
        public const string EtqPrecio = "PRECIO";
        public const string EtqValor = "VALOR";
        public const string EtqDireccion = "DIRECCION";
        public const string EtqStreet = "CALLE";
        public const string EtqStreetNumber = "NUMERO";
        public const string EtqPostalCode = "CODIGO_POSTAL";
        public const string EtqDoor = "PUERTA";
        public const string EtqFloor = "PISO";
        public const string EtqCity = "POBLACION";
        public const string EtqProvince = "PROVINCIA";
        public const string EtqDirImagenes = "imagenes";
        public const string ExtGraf = ".jpg";
        public const string EtqZona = "ZONA";
        public const string Fich = "fincas.xml";
        public const string ArchivoCopiaSeg = "_copia_seg_";
        public const string PrefijoArchivoCopiaSeg = "acsgf_";
        public const string DirCopiaSeg = "CopiasSeguridadGF";
        public const string EtqCodifISO = "iso-8859-1";
        public const string MascaraSuperficie = "0000000.00000";
        public const int UmbralModificaciones = 50;
        
        public Database(string nombreFich,
                        Action<string, int, int> processStart,
                        Action<int> processMakeStep,
                        Action processEnd)
        {
            this.allAreas = new List<Area>();
            this.areasById = new SortedList<string, Area>();
            this.areasByName = new SortedList<string, Area>();

            this.processStart = processStart;
            this.processMakeStep = processMakeStep;
            this.processEnd = processEnd;

            modif = 0;
            processing = false;

            DirDiv = System.IO.Path.DirectorySeparatorChar;

            if (nombreFich.Length == 0)
                DatabaseFileName = Fich;
            else DatabaseFileName = nombreFich;

            Open();
        }

        public void Update()
        {
            ++modif;
            this.Save();
        }

        public void Save()
        {
            if (modif > UmbralModificaciones)
            {
                this.Sync();
            }
        }

        public void Sync()
        {
            if ( modif > 0 ) {
                XmlDocument xmlDt = new XmlDocument();
                Place[] places = this.Root.Places;
                int numPlaces = places.Length;

                // El nodo desc XML
                XmlNode node = xmlDt.CreateNode(
                                    XmlNodeType.XmlDeclaration,
                                    "xml",
                                    ""
                );
                (node as XmlDeclaration).Encoding = EtqCodifISO;

                xmlDt.AppendChild(node);

                // La raíz de las fincas
                node = xmlDt.CreateNode( XmlNodeType.Element, EtqMarcaRaiz, "" );
                xmlDt.AppendChild( node );

                processing = true;
                this.processStart(
                            "Guardando BD...",
                            0, numPlaces
                );

                for (int i = 0; i < numPlaces; ++i)
                {
                    this.StorePlace( places[ i ], node );
                    this.processMakeStep( i );
                }

                this.processEnd();
                xmlDt.Save(DatabaseFileName);
                this.modif = 0;
                this.processing = false;
            }
        }

        /// <summary>
        /// Stores the id and name, then remarks and sub places.
        /// </summary>
        /// <param name="place">The place to store.</param>
        /// <param name="node">The XML node.</param>
		void StorePlace(Place place, XmlNode node)
        {
            // Create the subnode
            XmlDocument doc = node.OwnerDocument;
            XmlNode subNodo = this.CreateNode(node, EtqLugar, "");

            // Insert all attributes
            this.CreateAttribute( subNodo, EtqId, place.Id );
            this.CreateAttribute( subNodo, EtqNombre, place.Name );

            // Insert remarks, if provided.
            if ( !string.IsNullOrEmpty( place.Remarks ) ) {
                this.CreateNode( subNodo, EtqObs, place.Remarks );
            }

            // Store all estates
            foreach (Estate subEstate in place.Estates)
            {
                this.StoreRealState( subEstate, subNodo );
            }

            // Recursive call for all subplaces
            foreach (Place subPlace in place.Places)
            {
                this.StorePlace( subPlace, subNodo );
            }

            return;
        }

        /// <summary>
        /// Stores the real estate info.
        /// </summary>
        /// <param name="f">The estate.</param>
        /// <param name="nodo">The node to read the info from.</param>
        void StoreRealState(Estate f, XmlNode nodo)
        {
            // Store numbers in the default culture
            System.Globalization.CultureInfo fmt =
                new System.Globalization.CultureInfo( "" )
            ;

            // Crear el subnodo
            XmlNode subNodo = this.CreateNode( nodo, EtqFinca, "" );

            // Insertarle los atributos
            this.CreateAttribute( subNodo, EtqId, f.Id );
            this.CreateAttribute( subNodo, EtqNombre, f.Name );

            // Si hay observaciones, insertarlas
            if ( !string.IsNullOrEmpty( f.Remarks ) ) {
                this.CreateNode( subNodo, EtqObs, f.Remarks );
            }

            // Si hay referencia catastral, insertarla
            if ( !string.IsNullOrEmpty( f.RefCatastral ) ) {
                this.CreateNode( subNodo, EtqRefCatastral, f.RefCatastral );
            }

            // Guardar la superficie
            this.CreateNode(subNodo, EtqArea, f.Extension.ToString(MascaraSuperficie, fmt));

            // Guardar la venta
            if ( f.WasSold() )
            {
                XmlNode nodoAux = CreateNode( subNodo, EtqVendido, "" );
                
                this.CreateAttribute(nodoAux, EtqPrecio, f.getPrecioDeVenta().ToString("F", fmt));
                this.CreateAttribute(nodoAux, EtqNombre, f.getNombreDeComprador());
            }

            // Guardar el valor
            if ( f.Valor != 0 ) {
                this.CreateNode(subNodo, EtqValor, f.Valor.ToString("F", fmt));
            }

            // Guardar la info de urbana
            if ( f.IsUrban ) {
                // Guardar el tipo
                this.CreateNode( subNodo, EtqTipo, EtqUrbana );

                // Guardar la dirección
                if ( f.getDireccion() != null ) {
                    this.StoreAddress( f.getDireccion(), subNodo );
                }
            }
        }

        /// <summary>
        /// Stores the address.
        /// </summary>
        /// <param name="address">Address of the area.</param>
        /// <param name="subNode">Subnode.</param>
        void StoreAddress(Estate.Address address, XmlNode subNode)
        {
            XmlNode addressNode = this.CreateNode( subNode, EtqDireccion, "" );

            // Floor
            this.CreateNode( addressNode, EtqFloor, address.Floor.ToString() );

            // Door
            this.CreateNode( addressNode, EtqDoor, address.Floor.ToString() );

            // Street
            this.CreateNode( addressNode, EtqStreet, address.Street );

            // Street number
            this.CreateNode( addressNode, EtqStreetNumber, address.StreetNumber.ToString() );

            // City
            this.CreateNode( addressNode, EtqCity, address.City );

            // Province
            this.CreateNode( addressNode, EtqProvince, address.Province );

            // Postal code
            this.CreateNode( addressNode, EtqPostalCode, address.PostalCode.ToString() );
        }

        XmlAttribute CreateAttribute(XmlNode nodo, string etq, string valor)
        {
            if (valor == null)
            {
                valor = "";
            }

            XmlAttribute atr = nodo.OwnerDocument.CreateAttribute(etq);
            atr.InnerXml = valor;
            nodo.Attributes.Append(atr);

            return atr;
        }

        XmlNode CreateNode(XmlNode nodo, string etq, string valor)
        {
            XmlNode nodoAux = nodo.OwnerDocument.
                    CreateNode(XmlNodeType.Element, etq, "")
            ;

            nodoAux.InnerText = valor;
            nodo.AppendChild(nodoAux);

            return nodoAux;
        }

        void InsertSortedArea(Area a)
        {
            try {
                areasByName.Add( a.Name, a );
                areasById.Add( a.Id, a );
            }
            catch (Exception)
            {
                throw DuplicatedRegisterError(a);
            }
        }

        Exception DuplicatedRegisterError(Area a)
        {
            return new DBDuplicatedRegister( "duplicado: " + a );
        }

        /// <summary>
        /// Inserts an area. Triggered by the user.
        /// </summary>
        /// <returns>The <see cref="Area"/>.</returns>
        /// <param name="place">The <see cref="Place"/> in which to insert.</param>
        /// <param name="area">The <see cref="Area"/> to insert.</param>
        public Area InsertArea(Place place, Area area)
        {
            place.Insert( area );
            this.allAreas.Add( area );
            this.InsertSortedArea( area );

            place.Notify();

            if ( !processing ) {
                ++this.modif;
                this.Sync();
            }

            return area;
        }

        public void Open()
        {
            this.Root = null;
            this.areasByName.Clear();
            this.areasById.Clear();

            // Cargar el archivo
            this.processing = true;
            XmlDocument xmlDt = new XmlDocument();
            XmlNode nodoRaiz;

            xmlDt.Load( this.DatabaseFileName );

            // Load the root node
            this.CheckXML( xmlDt );
            nodoRaiz = xmlDt.ChildNodes[ 1 ]; // Yep, the second one

            // Create the root node
            this.Root = new Place( null, "__fincas__", EtqMarcaRaiz.ToLower() ) {
                Remarks = "Todas las fincas"
            };

            // Load all areas
            try {
                this.LoadAllAreas( nodoRaiz );
                this.StoreDBCopy( "" );
            }
            catch (Exception)
            {
                this.Root = null;
                throw;
            }
            finally {
                this.modif = 0;
                this.processing = false;
            }
        }

        void CheckXML(XmlDocument doc)
        {
            if ( doc.FirstChild.NodeType != XmlNodeType.XmlDeclaration )
            {
                this.IncorrectLabelError( "no XML mark in document" );
            }

            if ( doc.ChildNodes.Count != 2 )
            {
                this.IncorrectLabelError( "document has more than XML mark and root" );
            }

            if ( doc.ChildNodes[ 1 ].Name.ToUpper() != EtqMarcaRaiz ) {
                this.IncorrectLabelError( "Root is not called '" + EtqMarcaRaiz + '\'' );
            }
            
            return;
        }

        /// <summary>
        /// Reads the whole document, starting from Root.
        /// </summary>
        /// <param name="nodoRaiz">The root node.</param>
		void LoadAllAreas(XmlNode nodoRaiz)
        {
            int numPlaces = nodoRaiz.ChildNodes.Count;

            this.processStart( "Cargar BD...", 0, numPlaces );

            for (int i = 0; i < numPlaces; ++i) {
                XmlNode n = nodoRaiz.ChildNodes[ i ];

                if ( n.Name.ToUpper() != EtqLugar ) {
                    IncorrectLabelError( "Esperando lugar, no: '" + n.Name + '\'' );
                }

                // Estamos en cada uno de los lugares
                this.LoadPlace( this.Root, n );

                this.processMakeStep( i );
            }

            this.processEnd();
        }

        Place LoadPlace(Place parent, XmlNode n)
        {
            string name = "";
            string id = "";
            Place toret = null;

            this.ExtractAttributes( n, ref id, ref name );
            toret = InsertPlace( parent, id, name, "" );

            foreach (XmlNode x in n.ChildNodes) {
                if ( x.Name.ToUpper() == EtqFinca ) {
                    this.LoadEstate( toret, x );
                }
                else
                if ( x.Name.ToUpper() == EtqLugar ) {
                    this.LoadPlace( toret, x );
                }
                else
                if ( x.Name.ToUpper() == EtqObs ) {
                    toret.Remarks = x.InnerText;
                }
            }

            return toret;
        }

        void LoadEstate(Place place, XmlNode n)
        {
            string id = "";
            string name = "";
            string refCatastral = "";
            double area = 0;
            double valor = 0;
            double precioDeVenta = 0;
            string nombreComprador = "";
            bool esUrbana = false;
            string observaciones = "";
            Estate.Address d = null;

            // Load
            ExtractAttributes(n, ref id, ref name);

            foreach (XmlNode x in n.ChildNodes) {
                if ( x.Name.ToUpper() == EtqArea ) {
                    area = Convert.ToDouble( x.InnerText, CultureInfo.InvariantCulture );
                }
                else
                if ( x.Name.ToUpper() == EtqValor ) {
                    valor = Convert.ToDouble(x.InnerText, CultureInfo.InvariantCulture );
                }
                else
                if ( x.Name.ToUpper() == EtqObs ) {
                    observaciones = x.InnerText;
                }
                else
                if ( x.Name.ToUpper() == EtqRefCatastral ) {
                    refCatastral = x.InnerText;
                }
                else
                if ( x.Name.ToUpper() == EtqTipo ) {
                    if ( x.InnerText.ToUpper() == EtqUrbana ) {
                        esUrbana = true;
                    }
                    else
                    if ( x.InnerText.ToUpper() == EtqRustica ) {
                        esUrbana = false;
                    } else {
                        this.IncorrectLabelError(
                            "Tipo de finca no comprendido en "
                            + name + '(' + id + ')'
                        );
                    }
                }
                else
                if ( x.Name.ToUpper() == EtqVendido ) {
                    foreach (XmlNode nv in x.Attributes) {
                        if ( nv.Name.ToUpper() == EtqNombre ) {
                            nombreComprador = nv.InnerText;
                        }
                        else
                        if ( nv.Name.ToUpper() == EtqPrecio ) {
                            precioDeVenta = Convert.ToDouble( nv.InnerText, CultureInfo.InvariantCulture );
                        }
                        else this.IncorrectLabelError( "info de venta no válida" );
                    }
                }
                else
                if ( x.Name.ToUpper() == EtqDireccion ) {
                    d = new Estate.Address();
                    foreach (XmlNode nd in x.ChildNodes) {
                        if ( nd.Name.ToUpper() == EtqStreetNumber ) {
                            d.StreetNumber = Convert.ToInt32 (nd.InnerText );
                        }
                        else
                        if ( nd.Name.ToUpper() == EtqFloor ) {
                            d.Floor = Convert.ToInt32(nd.InnerText );
                        }
                        else
                        if ( nd.Name.ToUpper() == EtqPostalCode ) {
                            d.PostalCode = Convert.ToInt32(nd.InnerText );
                        }
                        else
                        if ( nd.Name.ToUpper() == EtqDoor ) {
                            d.Door = nd.InnerText;
                        }
                        else
                        if ( nd.Name.ToUpper() == EtqStreet ) {
                            d.Street = nd.InnerText;
                        }
                        else
                        if ( nd.Name.ToUpper() == EtqCity ) {
                            d.City = nd.InnerText;
                        }
                        else
                        if ( nd.Name.ToUpper() == EtqProvince ) {
                            d.Province = nd.InnerText;
                        }
                    }
                }
            }

            Estate f = this.InsertEstate( place, id, name, area );

            f.Valor = valor;
            
            if ( f.IsUrban != esUrbana ) {
                f.IsUrban = esUrbana;
            }
            
            if ( d != null ) {
                f.ponDireccion(d);
            }

            if ( !string.IsNullOrEmpty( refCatastral ) ) {
                f.RefCatastral = refCatastral;
            }

            if ( !string.IsNullOrEmpty( observaciones ) ) {
                f.Remarks = observaciones;
            }

            if ( precioDeVenta > 0.0
              || nombreComprador.Length > 0 )
            {
                f.fueVendido( nombreComprador, precioDeVenta );
            }
        }

        void ExtractAttributes(XmlNode n, ref string id, ref string nombre)
        {
            id = nombre = "";

            foreach (XmlNode x in n.Attributes) {
                if ( x.Name.ToUpper() == EtqNombre ) {
                    nombre = x.InnerText;
                }
                else
                if ( x.Name.ToUpper() == EtqId ) {
                    id = x.InnerText;
                }
            }

            if ( id.Length == 0
              || nombre.Length == 0 )
            {
                this.IncorrectLabelError("se esperaba nombre o id de finca/lugar");
            }
            
            return;
        }

        Estate InsertEstate(Place l, string id, string name, double area)
        {
            Estate toret = null;

            if ( string.IsNullOrEmpty( name )
              || string.IsNullOrEmpty( id ) )
            {
                this.IncorrectLabelError(" sin Id o nombre de lugar..." );
            }

            try {
                // Insert the area in the current place
                toret = new Estate( id, name, l, area );
                this.InsertArea( l, toret );
            }
            catch (UserException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new NoMemException(
                        "creando finca: '" + id + ',' + name + '\'' );
            }

            return toret;
        }

        Place InsertPlace(Place parent, string id, string name, string obs)
        {
            Place toret = null;

            if ( string.IsNullOrEmpty( name )
              || string.IsNullOrEmpty( id ) )
            {
                this.IncorrectLabelError( "sin Id o Nombre de lugar ..." );
            }

            try {
                // Insert it in the records
                toret = new Place(parent, id, name);
                this.InsertArea( parent, toret );

                // Include remarks
                toret.Remarks = obs;
            }
            catch (Exception)
            {
                throw
                    new NoMemException(
                        "creando lugar: '" + id + ',' + ' ' + name + '\''
                    )
                ;
            }

            return toret;
        }

        private void IncorrectLabelError(string p)
        {
            throw new DBSintaxXmlException(p);
        }

        protected Area GetAreaFor(string k, SortedList<string, Area> sl)
        {
            Area toret;

            if ( !sl.TryGetValue( k, out toret ) ) {
                toret = null;
            }

            return toret;
        }

        public Area GetAreaById(string id)
        {
            return this.GetAreaFor( id, areasById );
        }

        public Area GetAreaByName(string name)
        {
            return GetAreaFor( name, areasByName );
        }

        /// <summary>
        /// Calls RemoveEstate() or RemovePlace().
        /// Triggered by the user.
        /// </summary>
        /// <param name="area">The <see cref="Area"/> to remove.</param>
        public void Remove(Area area)
        {
            if ( area is Estate estate ) {
                this.RemoveRealEstate( estate, true );
            } else {
                this.RemovePlace( (Place) area, true);
            }

            ++this.modif;
            this.Sync();
        }

        /// <summary>
        /// Removes a place, removing all its estates and subplaces.
        /// Honors the data structures here.
        /// </summary>
        /// <param name="place">The place to remove</param>
        /// <param name="removeFromParent">Remove from parent or not.</param>
        private void RemovePlace(Place place, bool removeFromParent)
        {
            Place parentPlace = place.Parent;

            // Remove subestates and subplaces
            foreach (Estate f in place.Estates) {
                this.RemoveRealEstate( f, false );
            }

            foreach (Place l in place.Places)
            {
                this.RemovePlace( l, false );
            }

            place.RemoveAllEstates();
            place.RemoveAllPlaces();
            
            // Notify
            place.Notify();
            place.Notify( Observable.NotificationType.Eliminate );

            // Keep all data structures updated
            this.allAreas.Remove( place );
            this.areasById.Remove( place.Id );
            this.areasByName.Remove( place.Name );

            // Remove from parent
            if ( removeFromParent
              && parentPlace != null )
            {
                // Remove
                parentPlace.Remove( place );

                // Update
                parentPlace.Notify();
            }

            return;
        }

        /// <summary>
        /// Eliminates the real estate from all data structures, and its parent.
        /// </summary>
        /// <param name="removeFromParent">Remove it from parent or not.</param>
        private void RemoveRealEstate(Estate estate, bool removeFromParent)
        {
            Place areaPadre = estate.Parent;

            // Notify removing
            estate.Notify( Observable.NotificationType.Eliminate );

            // Remove from data structures
            this.allAreas.Remove( estate );
            this.areasById.Remove( estate.Id );
            this.areasByName.Remove( estate.Name );

            // Remove from parent
            if (removeFromParent
              && areaPadre != null)
            {
                // Remove
                areaPadre.Remove( estate );

                // Update
                areaPadre.Notify();
            }

            return;
        }

        public void StoreDBCopy(string nombre)
        {
            string previousDBName = DatabaseFileName;

            if (nombre.Length == 0)
            {
                nombre = DirCopiaSeg + DirDiv
                            + PrefijoArchivoCopiaSeg
                            + BuildTimeDescriptor(DateTime.Now)
                         + ArchivoCopiaSeg + DatabaseFileName
                ;
            }

            System.IO.Directory.CreateDirectory( DirCopiaSeg );

            this.DatabaseFileName = nombre;
            ++this.modif;
            this.Sync();
            this.DatabaseFileName = previousDBName;
        }

        public static string BuildTimeDescriptor(DateTime t)
        {
            return
                  t.Year.ToString() + '_'
                + t.Month.ToString() + '_'
                + t.Day.ToString() + '_'
                + t.Hour.ToString() + '_'
                + t.Minute.ToString() + '_'
                + t.Second.ToString()
            ;
        }

        internal void UpdateAreaName(Area a)
        {
            // Remove the previous area, if exists
            if ( this.GetAreaByName( a.Name ) == a ) {
                this.areasByName.Remove( a.Name );
            }

            // Update
            this.areasByName.Add( a.Name, a );
        }

        public Place Root {
            get; private set;
        }

        public Area[] AllAreas {
            get {
                return this.allAreas.ToArray();
            }
        }
        
        public int CountAllAreas {
            get {
                return this.allAreas.Count;
            }
        }

        public bool IsLoaded {
            get { return ( this.Root != null ); }
        }

        public string DatabaseFileName {
            get; private set;
        }

        public static char DirDiv
        {
            get; private set;
        }

        int modif;
        bool processing;
        List<Area> allAreas;
        SortedList<string, Area> areasById;
        SortedList<string, Area> areasByName;
        Action<string, int, int> processStart;
        Action<int> processMakeStep;
        Action processEnd;
    }
}
