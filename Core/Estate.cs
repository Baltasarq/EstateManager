using System;

namespace EstateManager.Core {
	public class Estate : Area {
		public class Address {
			public Address()
			{
				street = door = province = city = "";
				floor = postalCode = streetNumber = 0;
			}

			public Area OwnerArea {
                get; set;
			}

			public int Floor
			{
				get { return floor; }
				set { floor = value; this.Notify(); }
			}

			public string Door
			{
				get { return door; }
				set { door = value; this.Notify(); }
			}

			public string Street
			{
				get { return street; }
				set { street = value; this.Notify(); }
			}

			public int StreetNumber
			{
				get { return streetNumber; }
				set { streetNumber = value; this.Notify(); }
			}

			public string City
			{
				get { return city; }
				set { city = value; this.Notify(); }
			}

			public string Province
			{
				get { return province; }
				set { province = value; Notify(); }
			}

			public int PostalCode
			{
				get { return postalCode; }
				set { postalCode = value; this.Notify(); }
			}

			public override String ToString()
			{
				return Street + @", " + StreetNumber + @", " + Floor + '-' + Door
					   + @", " + postalCode + ' ' + City + ' '
					   + '(' + Province + ')'
				;
			}
             
            void Notify()
            {
                if ( this.OwnerArea != null ) {
                    this.OwnerArea.Notify();
                }
                
                return;
            }            
            
            int floor;
            string door;
            string street;
            int streetNumber;
            int postalCode;
            string province;
            string city;
		}

		public Estate(String i, String n, Place l, double extension)
			: base( l, i, n )
		{
			this.isUrban = false;
			this.extension = extension;
            this.RefCatastral = "";
		}
        
        public String RefCatastral
        {
            get { return refCatastral; }
            set { refCatastral = value; this.Notify(); }
        }
        
        public Boolean IsUrban {
            get {
                return this.isUrban;
            }
            set {
	            this.isUrban = value;
	            this.Notify();
            }
        }

		public override String ToString()
		{
			String toret =base.ToString() + ':' + ' ';

			toret = toret + Convert.ToString( Extension );

			if ( address != null ) {
				toret += ' ';
				toret += '(';
				toret += ' ';
				toret += address.ToString() + ' ' + ')';
			}

			return toret;
		}

		public void fueVendido(string nombre, double precio)
		{
			purchaserName = nombre;
			soldPrice = precio;

			Notify();
		}

		public String getNombreDeComprador()
		{
			return purchaserName;
		}

		public double getPrecioDeVenta()
		{
			return soldPrice;
		}

		internal void ponDireccion(Address d)
		{
			address = d;
			address.OwnerArea = this;

			Notify();
		}

		public Address getDireccion()
		{
			return address;
		}

		public double Valor
		{
			get { return valor; }
			set { valor = value; Notify(); }
		}

		public double Extension
		{
			get { return extension; }
			set { extension = value; Notify(); }
		}

		public void creaDireccionEnBlanco()
		{
			if ( address == null ) {
				address = new Address();
				address.OwnerArea = this;
			}
		}

		public override string GetImageName()
		{
			return ( Database.EtqDirImagenes
                   + Database.DirDiv
				   + Database.EtqFinca
                   + '_'
				   + Area.NormalizeName( base.GetImageName() )
				   + Database.ExtGraf
			);
		}

		public string getNombreImagenFinca()
		{
			return GetImageName();
		}

		public string getNombreImagenZona()
		{
			return ( Database.EtqDirImagenes
                   + Database.DirDiv
				   + Database.EtqZona
                   + '_'
				   + Database.EtqFinca
                   + '_'
				   + Area.NormalizeName( base.GetImageName() )
				   + Database.ExtGraf
			);			
		}

		public bool WasSold()
		{
			return ( soldPrice != 0 );
		}

        public static double cnvtHaMc(double valor)
        {
            return ( valor * 10000 );
        }

        public static double cnvtMcHa(double valor)
        {
            return ( valor / 10000 );
        }
        
        String refCatastral;
        Boolean isUrban;
        double extension;
        double valor;
        String purchaserName;
        double soldPrice;
        Address address;
    }
}
