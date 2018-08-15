// GestorFincas (c) 2005 Baltasarq MIT License (baltasarq@gmail.com)

namespace EstateManager.Core {
	/// <summary>
	/// UserException es la clase padre de todas las excepciones
	/// </summary>	
	public class UserException : System.ApplicationException
	{
		protected string msgExcTipo;
		   		
   		public UserException(string message)
      		: base(message)
      	{
   			msgExcTipo = "Error de usuario";
     	}
   		
   		public override string Message {
            get {
   			    return msgExcTipo + ' ' + '(' + base.Message + ')' + '.';
   		    }
   	    }
    }

    public class InternalException : UserException {
	    public InternalException(string message)
			: base( message )
		{
			msgExcTipo = "Error Interno";
		}
    }

    public class IncorrectFilterException : InternalException {
	    public IncorrectFilterException(string message)
			: base( message )
		{
			msgExcTipo = "Dato a buscar incorrecto";
		}
	}

	public class NoMemException : UserException {
		public NoMemException(string message)
			: base( message )
		{
			msgExcTipo = "No hay memoria";
		}
	}

    /// <summary>
    /// DBException es el padre de todas las excepciones
    /// relacionadas con la BD
    /// </summary>  
	public class DBException : UserException
	{   		
   		public DBException(string message)
      		: base(message)
      	{
   			msgExcTipo = "Error de base de datos";   			
     	}
	}

	public class DBDuplicatedRegister : DBException {
		public DBDuplicatedRegister(string message)
			: base( message )
		{
			msgExcTipo = "El registro ya existe con esa clave";
		}
	}
	
	public class DBNotOpenException : DBException
	{
   		public DBNotOpenException(string message)
      		: base(message)
      	{
   			msgExcTipo = "Base de datos no abierta";
     	}
	}

	public class DBSintaxXmlException : DBException {
		public DBSintaxXmlException(string message)
			: base( message )
		{
			msgExcTipo = "Error leyendo XML";
		}
	}
}
