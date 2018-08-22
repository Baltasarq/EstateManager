using System;
using System.Globalization;
using System.Collections.Generic;

namespace EstateManager.Core {
	public class Area : Observable, IEquatable<Area> {
        public Area(Place parent, String id, String name)
        {
            this.owner = parent;
            this.id = NormalizeName( id );
            this.name = SemiNormalizeName( name );
        }
        
        public static string FormatForPresentation(string n)
        {
            string toret = n;

            if ( n.Length > 1 ) {
                toret = n.Substring( 0, 1 ).
                                ToUpper( CultureInfo.CurrentCulture )
                        + n.Substring( 1, n.Length - 1 ).
                                ToLower( CultureInfo.CurrentCulture );
            }

            return toret.Replace( '_', ' ' ).Trim();
        }
        
        public virtual string GetImageName()
        {
            string toret = Id;

            toret.Trim();
            toret.Replace( ' ', '_' );

            return toret;
        }

        /// <summary>
        /// The path to this area will be returned as a list of areas,
        /// being the first one the parent of this, and the last one the root.
        /// </summary>
        /// <returns>A list of areas.</returns>
        public Area[] BuildPath()
        {
            Area a = owner;
            var toret = new List<Area>();

            while ( a != null ) {
                toret.Add( a );
                a = a.owner;
            }

            return toret.ToArray();
        }

        public static string SemiNormalizeName(string nombre)
        {
            string toret = nombre.ToUpper( CultureInfo.CurrentCulture );

            return toret.Replace( ' ', '_' );
        }       

        public static string NormalizeName(string nombre)
        {
            string toret = SemiNormalizeName( nombre );

            toret = toret.Replace( 'Á', 'A' );
            toret = toret.Replace( 'É', 'E' );
            toret = toret.Replace( 'Í', 'I' );
            toret = toret.Replace( 'Ó', 'O' );
            toret = toret.Replace( 'Ú', 'U' );
            toret = toret.Replace( 'Ñ', 'N' );
            toret = toret.Replace( 'Ü', 'U' );
            toret = toret.Replace( 'Ç', 'C' );

            return toret;
        }
        
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            bool toret = false;
            
            if (obj is Area area) {
                toret = ( this.Id == area.Id );
            }
            
            return toret;
        }
        
        public bool Equals(Area a)
        {
            return this.Equals( (object) a );
        }

		public override String ToString()
        {
			string toret = this.Name + '[' + Id + ']';
            
            if ( owner != null ) {
                toret += @" en " + owner.Name;
            }

            return toret;
		}
        
        public Place Parent {
            get { return owner; }
            set { owner = value; Notify(); }
        }

        public String Name {
            get { return name; }
            set { name = value; Notify(); }
        }

        public String Remarks {
            get { return observaciones; }
            set { observaciones = value; Notify(); }
        }

        public String Id {
            get { return id; }
            set { id = value; Notify(); }
        }
        
        string name;
        string id;
        string observaciones;
        Place owner;
	}
}
