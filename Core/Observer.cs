// GestorFincas (c) 2005 Baltasarq MIT License (baltasarq@gmail.com)

namespace EstateManager.Core {
    using System;
    
	/// <summary>
	/// El patron observador. Esta es la clase base de todos
	/// los observadores posibles.
	/// 
	/// Los observadores deben proveer de una forma de ser actualizados y
	/// obligatoriamente deben llamar en alAbandonar()
	/// al observable.eliminaObservador()
	/// </summary>
	public interface Observer {
		/// <summary>
		/// Es llmamado cuando se debe actualizar a un cliente, un observador.
		/// Puede devolver false si el cliente ya ha sido actualizado.
		/// </summary>
		/// <param name="tiempoActualizacion">Momento en el que ocurre</param>
		/// <returns>Verdadero si el cliente se actualiza o no</returns>
	    bool Update(DateTime tiempoActualizacion, Observable.NotificationType tn);

		/// <summary>
		///  Se debe llamar cuando este objeto sea eliminado.
		///  Es obligatorio que llame a observable.eliminaObservador() para dejar
		///  de estar registrado.
		/// </summary>
		void OnStopObserving();
	}
}
