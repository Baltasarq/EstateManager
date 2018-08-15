// GestorFincas (c) 2005 Baltasar MIT License (baltasarq@gmail.com)
using System;
using System.Collections;

namespace GestorFincas.Core {
	/// <summary>
	/// El explorador de fincas se encarga de facilitar el acceso a
	/// las fincas. Es decir, recubre la base de datos.
	/// Cada vez que hay un cambio, actualiza a
	/// todos los observadores.
	/// </summary>
	public class ExploradorFincas {
		public ExploradorFincas(BaseDatos b)
		{
			if ( b != null ) {
				if ( !b.estaCargada() ) {
					throw CreateExcNoHayBD();
				}

				// Base de datos abierta, coger datos
				raiz = b.getRaiz();
				listaTotalAreas = b.getListaTotalAreas();
			} else throw CreateExcNoHayBD();
		}

		public Lugar GetRoot()
		{
			return raiz;
		}

		public ArrayList GetListOfAllAreas()
		{
			return listaTotalAreas;
		}
		
		public DBNotOpenException CreateExcNoHayBD()
		{
			return new DBNotOpenException( 
			              "no hay base de datos" 
			       );
		}

		public int GetAreaForName(String nombre)
		{
			int i;

            nombre = nombre.Trim().ToLower();
        
			for(i = 0; i < areasPorNombre.Count; ++i) {
                Area area = areasPorNombre[i] as Area;

				if ( area.getNombre().Trim().ToLower() == nombre ) {
					break;
				}
			}

			return ( i < areasPorNombre.Count ? i : -1 );
		}

		public Area GetAreaForId(string i)
		{
			Area toret = null;

			try {
				int pos = areasPorID.IndexOfKey( i );
				toret = (Area) areasPorID.GetByIndex( pos );
			}
			catch ( Exception ) {
				toret = null;
			}

			return toret;
		}

        private Lugar raiz;
        private ArrayList listaTotalAreas;
        private SortedList areasPorID;
        private SortedList areasPorNombre;
	}
}
