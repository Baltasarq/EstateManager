using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EstateManager.Core {
    public class CDGenerator {
        public const string ExtHtml = ".html";
        public const string nombreArchivoIndiceLateral = "lateral.html";
        public const string nombreArchivoGlobal = "index.html";
        public const string DirWebGenerada = "CDgF";

        public CDGenerator(Database bd, string dir,
                            Action<string, int, int> processStart,
                            Action<int> processMakeStep,
                            Action processEnd)
        {
            this.Database = bd;
            this.Dir = dir;
            this.processStart = processStart;
            this.processMakeStep = processMakeStep;
            this.processEnd = processEnd;
        }
        
        public bool IsValid()
        {
            bool toret = false;
            string path = this.Dir;
            
            if ( !string.IsNullOrWhiteSpace( path ) ) {
	            try {
	                path = path.Trim();
	            
	                if ( ( path.Length > 0 )
                      && ( Directory.Exists( this.Dir ) ) )
	                {
                        toret = true;
                        
	                    // Meterle una barra al final si no la tiene
	                    if ( this.Dir[ this.Dir.Length - 1 ] != Path.DirectorySeparatorChar ) {
	                        path += Path.DirectorySeparatorChar;
	                    }
	
	                    // Meterle el directorio del web
	                    path += DirWebGenerada;
	
	                    // Crearlo
	                    Directory.CreateDirectory( path );
	                    path += Path.DirectorySeparatorChar;
	                }
	            }
	            catch ( Exception e ) {
	                MessageBox.Show(
	                    e.Message,
	                    "Error interno",
	                    MessageBoxButtons.OK,
	                    MessageBoxIcon.Error
	                );

                    toret = false;
                }
            }

            this.Dir = path;
            return toret;
        }

        public void Generate()
        {
            try {
                this.GeneratePages();
            }
            catch ( IOException e ) {
                MessageBox.Show(
                    e.Message,
                    "Error de sistema de ficheros",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch ( Exception e ) {
                MessageBox.Show(
                    e.Message,
                    "Error interno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// <ul>Crea todos los ficheros web necesarios:
        ///    <li>Index de toda la web, con marco a la izquierda
        ///    <li>todas las fincas y lugares, para poner de índice a la izquierda
        ///    <li>por cada lugar
        ///    <li>por cada finca
        /// </ul>
        /// </summary>
        private void GeneratePages()
        {	
	        // Generar la de índice global, con sus marcos
	        Stream web = File.Create( this.Dir + nombreArchivoGlobal );
            StreamWriter webGlobal = new StreamWriter( web );

            webGlobal.Write( "<html><head>" );
            webGlobal.Write( "<meta http-equiv=\"Content-Type\" content=\"text/html; "
                                + "charset=UTF-8\">"
            );

            webGlobal.Write( "<title>Fincas</title></head>" );
            webGlobal.Write( "\n<FRAMESET cols=\"33%,*\">" );
            webGlobal.Write( "\n<FRAME name=\"menu\" noresize src=\""
                            + nombreArchivoIndiceLateral
			                + "\" frameborder=1>" )
            ;

            webGlobal.Write( "\n<FRAME name=\"contents\" "
                          + "scrolling=\"yes\" src=\""
			              + Database.EtqLugar
                          + '_'
                          + this.Database.Root.Id
                          + ExtHtml
			              + "\" frameborder=0>"
            );

            webGlobal.Write( "\n</FRAMESET>\n</html>\n" );
            webGlobal.Close();
        	
	        // Generar el índice lateral
            StreamWriter webLateral = GenerateHtmlSkeleton( 
                                this.Dir + nombreArchivoIndiceLateral,
                                "Índice lateral"
            );

            webLateral.Write(
                  "<a href=\""
                + Database.EtqLugar + '_' + this.Database.Root.Id + ExtHtml
                + "\" TARGET=\"contents\">Todas las fincas</a>\n\n"
            );

	        GenerateSideIndex( webLateral, this.Database.Root );
	        webLateral.Write( "\n</body></html>" );
	        webLateral.Close();
        	
	        // Generar todas las de las fincas
            Area[] areas = this.Database.AllAreas;
            this.processStart( "Generar CD ...", 0, areas.Length );

            // Generar todos los lugares
            GeneratePageForPlace( this.Database.Root );

            for( int i = 0; i < areas.Length; ++i) {
                Area area = areas[ i ];
                
                if ( area is Estate estate) {
	                GenerateRealEstatePage( estate );
                } else {
                    GeneratePageForPlace( (Place) area );
                }

                this.processMakeStep( i );
            }
            
            this.processEnd();
        }

        /// <summary>
        ///  Genera recursivamente
        ///  un índice html para colocar como panel izquierdo.
        /// </summary>
        /// <param name="f">El stream donde escribir</param>
        /// <param name="l">El lugar que vamos considerando</param>
        private void GenerateSideIndex(StreamWriter f, Place l)
        {
	        f.Write( "\n<br><ul>" );

            // Poner todas las áreas
            foreach(Place place in l.Places) {
                f.Write( "\n<li><a href=\""
			               + Database.EtqLugar
                           + '_'
                           + place.Id
                           + ExtHtml
			               + "\" target=\"contents\">"
		                   + Area.FormatForPresentation( place.Name ) 
			               + "</a>"
		        );

                if ( place != l ) {
                    GenerateSideIndex( f, (Place) place );
                }
            }

            // Poner todas las fincas
            foreach(Estate finca in l.Estates) {
                f.Write( "\n<li><a href=\""
			               + Database.EtqFinca
                           + '_'
                           + finca.Id
                           + ExtHtml
			               + "\" target=\"contents\">"
		                   + Area.FormatForPresentation( finca.Name ) 
			               + "</a>"
		        );
            }
        	
	        f.Write( "\n</ul>" );
        	
	        return;
        }

        /// <summary>
        /// Genera la web del lugar
        /// </summary>
        /// <param name="l">El lugar en sí.</param>
        private void GeneratePageForPlace(Place l)
        {
	        string fich = this.Database 
	                    + Database.EtqLugar
                        + '_'
                        + l.Id
                        + ExtHtml
	        ;
        	
	        StreamWriter web = GenerateHtmlSkeleton( fich, "Lugar de " 
                                + Area.FormatForPresentation( l.Name )
            );
        	
	        GenerateContentsPlacePage( web, l );
    		
	        web.Write( "\n\n</body>\n</html>\n\n" );
    		
	        web.Close();		
        	
	        return;	
        }

        /// <summary>
        /// Genera el contenido web de un lugar
        /// </summary>
        /// <param name="web">El fichero de la web</param>
        /// <param name="place">El lugar del que volcar la info</param>
        private void GenerateContentsPlacePage(StreamWriter web, Place place)
        {
	        Place lugar = place.Parent;
        	
	        // Poner el título
	        web.Write( "<h1>" );
	        web.Write( Area.FormatForPresentation( place.Name ) );
	        web.Write( "</h1>\n<hr>\n" );
        	
	        // A dónde pertenece ?
	        web.Write( GetWhereIsInfo( lugar ) );
        	
	        // Imagen de zona
	        web.Write( "<center><img src=\"" );
	        web.Write( Path.GetFileName( place.GetImageName() ) );
	        web.Write( "\" ALT=\"imagen correspondiente a la zona\">"
                + "</center>\n<hr>\n\n"
            );
        	
	        // Índice de lugares/parcelas que contiene
	        web.Write( "\n<hr><P><h3>Aquí hay:</h3><P>\n<ul>" );
            foreach(Place subplace in place.Places)
            {
                web.Write( "\n<li>" );
                web.Write( "Lugar de <a href=\"" 
                    + Database.EtqLugar + '_' + subplace.Id + ExtHtml
                    + "\">"
                    + Area.FormatForPresentation( subplace.Name ) 
                );

                web.Write( "</a> conteniendo " 
                    + subplace.CountPlaces.ToString()
                    + " lugare(s) y "
                    + subplace.CountEstates.ToString()
                    + " finca(s)."
                );
            }

            foreach(Estate estate in place.Estates)
            {
                web.Write( "\n<li>" );
                web.Write( "Finca: <a href=\""
                    + Database.EtqFinca + '_' + estate.Id + ExtHtml
                    + "\">"
                    + Area.FormatForPresentation( estate.Name ) 
                );

                web.Write( "</a> de "
                    + Estate.cnvtHaMc( estate.Extension )
                    + " m.c."
                );
            }

	        web.Write( "\n</ul>\n<P>" );

            GenerateFooterForArea( web, place );

            // Copiar archivos
            CopyImages( place );
        }

        /// <summary>
        /// Copies the needed images to the output directory.
        /// </summary>
        /// <param name="a">The <see cref="Area"/> to copy the images for.</param>
        private void CopyImages(Area a)
        {
            string nombreArchivo;

            // Si es una finca, su imagen de zona
            if ( a is Estate ) {
                Estate f = ( Estate ) a;

                if ( File.Exists( f.getNombreImagenZona() ) ) {
                    nombreArchivo =
                        this.Dir
                        + Path.GetFileName( f.getNombreImagenZona() )
                    ;

                    File.Copy( f.getNombreImagenZona(), nombreArchivo );
                }
            }

            // Imagen asociada al área
            if ( File.Exists( a.GetImageName() ) ) {
                nombreArchivo = this.Dir
                                + Path.GetFileName( a.GetImageName() )
                ;

                File.Copy( a.GetImageName(), nombreArchivo );
            }
        }

        /// <summary>
        /// Genera la web para una finca
        /// </summary>
        /// <param name="p">La finca en cuestión.</param>
        private void GenerateRealEstatePage(Estate p)
        {
	        string fich = this.Dir
                        + Database.EtqFinca
                        + '_'
                        + p.Id 
                        + ExtHtml
            ;

	        StreamWriter web = GenerateHtmlSkeleton(
                            fich,
                            "Finca " + Area.FormatForPresentation( p.Name )
            );
        	
            GenerateContentsRealEstatePage( web, p );
            web.Write( "\n\n</body>\n</html>\n\n" );
		    web.Close();

	        return;	
        }

        /// <summary>
        /// Returns the needed HTML to reach its parent places or all
        /// the real estates.
        /// </summary>
        /// <param name="place">The place to research its info for.</param>
        /// <returns>The HTML page, as a string.</returns>
        private string GetWhereIsInfo(Place place)
        {
            var places = new List<Area>();
	        string toret = "";
        	
	        // A dónde pertenece ?	
	        if ( place != null )
	        {
                places.AddRange( place.BuildPath() );
                places.Insert( 0, place );

		        toret = "\n<h2>en ";	
        	
		        foreach (Place l in places) {
                    toret += "<a href=\""
                            + Database.EtqLugar
                            + '_'
                            + l.Id
                            + ExtHtml
                    ;

                    toret += "\">";
			        toret += Area.FormatForPresentation( l.Name );
                    toret += @"</a>";
        			
			        if ( l.Parent != null )
				            toret += ", ";
			        else    toret += "." ;
		        }
		        toret += "</h2>\n<hr>\n";
	        }
        	
	        return toret;
        }

        /// <summary>
        /// Genera el contenido de una Finca
        /// </summary>
        /// <param name="web">El archivo al que volcar la info</param>
        /// <param name="p">La finca de la que volcar la info</param>
        private void GenerateContentsRealEstatePage(StreamWriter web, Estate p)
        {
	        Place lugar;
        	
	        // Poner el título
	        web.Write( "<h1>Finca: " );
	        web.Write( p.Id );
	        web.Write( "</h1>\n<hr>" );
        	
	        // A dónde pertenece ?
            lugar = p.Parent;
            if ( lugar != null ) {
	            web.Write( GetWhereIsInfo( lugar ) );
            }
        	
	        // Imagen de la finca
	        web.Write( "<P><center><img src=\"" );
	        web.Write( Path.GetFileName( p.GetImageName() ) );
	        web.Write( "\" ALT=\"Imagen de la finca\"></center>\n");
        	
	        // Superficie
	        web.Write( "<hr><P>\n<center>Superficie: " );
	        web.Write( Estate.cnvtHaMc( p.Extension ).ToString() );
	        web.Write( "m.c.</center>\n<P>\n\n" );
        	
	        web.Write( "<P><hr>\n<ul>\n" );

	        // Imagen de la zona de la finca
	        web.Write( "<li><a href=\"" );	
	        web.Write( Path.GetFileName( p.getNombreImagenZona() ) );
	        web.Write( "\">Imagen de zona inmediata</a>\n" );
        	
	        // Enlace a zona
            if ( lugar != null ) {
	            web.Write( "<li><a href=\""
                         + Database.EtqLugar
                         + '_'
			             + p.Parent.Id
                         + ExtHtml
			             + "\">Información de la zona</a>\n" 
		            )
	            ;
            }
        	
	        web.Write( "\n</ul>\n<hr>\n<P>\n\n" );

            this.GenerateFooterForArea( web, p );

            CopyImages( p );
        }

        private void GenerateFooterForArea(StreamWriter web, Area p)
        {
            Area lugar = p.Parent;

            // Volver al padre
            if ( lugar != null ) {
                web.Write( "<P><center>Volver a <a href=\"" );
                web.Write( Database.EtqLugar + '_' + lugar.Id + ExtHtml );
                web.Write( "\">" );
                web.Write( Area.FormatForPresentation( lugar.Name ) );
                web.Write( "</a>\n</center>" );
            }

            // Volver a la raiz
            web.Write( "\n\n<P><center>Volver a <a href=\"" );
            web.Write( Database.EtqLugar + '_' + this.Database.Root.Id + ExtHtml );
            web.Write( "\">" );
            web.Write( Area.FormatForPresentation( this.Database.Root.Name ) );
            web.Write( "</a>\n</center>\n\n" );
        }

        /// <summary>
        /// Crea un archivo HTML.
        /// Genera el esquelo inicial de cualquiera de las páginas HTML
        /// a generar.
        /// </summary>
        /// <param name="fich">El nombre del archivo a crear.</param>
        /// <param name="tit">El futuro título de la página</param>
        /// <returns></returns>
        private StreamWriter GenerateHtmlSkeleton(string fich, string tit)
        {
            Stream f = File.Create( fich );
            StreamWriter toret = new StreamWriter( f );

            toret.Write( "<html>\n<head>\n" );
            toret.Write( "<meta http-equiv=\"Content-Type\" content=\"" );
            toret.Write( "text/html; charset=UTF-8\">" );
            toret.Write( "<title>" );
            toret.Write( tit );
            toret.Write( "</title>\n<body bgcolor=\"#C4C4C4\">\n\n" );

            return toret;
        }
        
        public Database Database {
            get; private set;
        }

        public string Dir {
            get; private set;
        }
        
        private Action<string, int, int> processStart;
        private Action<int> processMakeStep;
        private Action processEnd;
    }
}
