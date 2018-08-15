// GestorFincas (c) 2005 Baltasarq MIT License (baltasarq@gmail.com)

using System;
using System.Collections.Generic;

namespace EstateManager.Core {
	/// <summary>
	/// Cualquier objeto observable debe tener este método
	/// </summary>
	public abstract class Observable
	{
		public enum NotificationType { Eliminate, Update };
		public List<Observer> vObs;
		
		public Observable()
		{
			vObs = new List<Observer>();
		}		
		
		public void InsertObserver(Observer x)
		{
			if ( vObs.IndexOf( x ) == -1 ) {
				vObs.Add( x );
			}
		}

		public void EliminateObserver(Observer x)
		{
			vObs.Remove( x );
		}
        
        /// <summary>
        /// Puede suceder que se actualicen observadores
        /// y se den de baja o de alta.
        /// Es necesario utilizar el boolean pq si hubo actualizacion
        /// no podemos fiarnos del indexado.
        /// </summary>
        public void Notify()
        {
            this.Notify( NotificationType.Update );
        }
		
		public void Notify(NotificationType tn)
		{
			bool thereWasUpdate;

			// Guardar el momento en que se notifica
			DateTime tiempoActualizacion = DateTime.Now;

			do {
				thereWasUpdate = false;

				for ( int i = 0; i < vObs.Count; ++i ) {
					if ( vObs[i].Update( tiempoActualizacion, tn ) ) {
						thereWasUpdate = true;
						break;
					}
				}
			} while ( thereWasUpdate );
            
            return;
		}
	}
}
