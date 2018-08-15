// GestorFincas (c) 2005 Baltasarq MIT License (baltasarq@gmail.com)

namespace EstateManager.Core {
	using System;
	using System.Collections.Generic;

	public class Place : Area {
		public Place(Place padre, string i, string n)
            :base( padre, i, n )
		{
			estates = new List<Estate>();
			places = new List<Place>();
		}
        
        public override string GetImageName()
        {
            return ( Database.EtqDirImagenes
                   + Database.DirDiv
                   + Database.EtqZona
                   + '_'
                   + Area.NormalizeName( base.GetImageName() )
                   + Database.ExtGraf
            );
        }

		public override string ToString()
        {
			string toret = base.ToString();

			if ( this.places.Count > 0 ) {
                toret = @": ( ";

                string.Join( ",", this.places );
				toret += @") ";
            }
            
            if ( this.estates.Count > 0 ) {
                toret += @": ";
                string.Join( ", ", this.estates );
            }

			if ( estates.Count > 0
			  || places.Count > 0 )
			{
				toret += '.';
			}

			return toret;
		}
        
        public void Insert(Area area)
        {
            if ( area is Place place) {
                this.InsertPlace( place );
            }
            else
            if  ( area is Estate estate ) {
                this.InsertEstate( estate );
            }
            else {
                throw new ArgumentException( "Not a place or estate: " + area );
            }
            
            return;
        }
        
        public void InsertEstate(Estate estate)
        {
            this.estates.Add( estate );
        }
        
        public void InsertPlace(Place place)
        {
            this.places.Add( place );
        }
        
        public void RemoveAllEstates()
        {
            this.estates.Clear();
        }
        
        public void RemoveAllPlaces()
        {
            this.places.Clear();
        }
        
        public void Remove(Area area)
        {
            if ( area is Place place) {
                this.RemovePlace( place );
            }
            else
            if  ( area is Estate estate ) {
                this.RemoveEstate( estate );
            }
            else {
                throw new ArgumentException( "Not a place or estate: " + area );
            }
            
            return;
        }
        
        public void RemovePlace(Place place)
        {
            this.places.Remove( place );
        }
        
        public void RemoveEstate(Estate estate)
        {
            this.estates.Remove( estate );
        }
        
        public Estate[] Estates {
            get {
                return estates.ToArray();
            }
        }
        
        public Place[] Places {
            get {
                return places.ToArray();
            }
        }
        
        public int CountPlaces {
            get {
                return this.places.Count;
            }
        }
        
        public int CountEstates {
            get {
                return this.estates.Count;
            }
        }

        List<Estate> estates;
        List<Place> places;
	}
}
