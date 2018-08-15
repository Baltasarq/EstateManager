using System;

namespace EstateManager.Core {
	public class Search {
		public enum Field {
                     Nombre, Id, NombreDeLugar, Remarks, Area, Valor,
			         PrecioVenta, NombreComprador,
					 Poblacion, Provincia, Calle,
                     ReferenciaCatastral,
					 Error
		};

		public static readonly string[] FieldNames = { 
					"Nombre", "Id", "En ", "Observaciones", "Área", "Valor",
					"Precio de venta", "Nombre del comprador",
					"Ciudad", "Provincia", "Calle",
                    "Referencia catastral",
					"Error"
		};

		public enum Operation { 
					 EQ, NEQ, LTE,
			         GTE, LT, GT,
					 Error
		};

		public static readonly string[] OperationNames = { 
					"=", "<>", "<=", ">=", "<", ">", "Error"
		};

		public static string StrFromField(Field campo)
        {
			return FieldNames[ (int) campo ];
		}

		public static string StrFromOperation(Operation op)
        {
			return OperationNames[ (int) op ];
		}

		public string StrFromField()
        {
			return StrFromField( this.FieldToSearchIn );
		}

		public string StrFromOperation()
        {
			return StrFromOperation( this.Comparison );
		}

		public static Field FieldFromStr(string nombreCampo)
		{
			int i = 0;

			for(; i < FieldNames.Length; ++i) {
				if ( nombreCampo == FieldNames[i] ) {
					break;
				}
			}

			return ( i < FieldNames.Length ? (Field) i : Field.Error );
		}

		public static Operation OperationFromStr(string nombreOp)
		{
			int i = 0;

			for ( ; i < OperationNames.Length; ++i ) {
				if ( nombreOp == OperationNames[i] ) {
					break;
				}
			}

			return ( i < OperationNames.Length ? (Operation) i : Operation.Error );
		}

		public Search(string fieldName, string cmpName, string cmpValue)
		{
			// Convert field and comparison strings
			this.FieldToSearchIn = FieldFromStr( fieldName );
			this.Comparison = OperationFromStr( cmpName );

			// The method to compare
			this.DoCompare = this.ComparisonFromOpName( this.Comparison );

			// Convert the value to compare to.
			this.Value = this.CompareValueFromStr( cmpValue );

			if ( this.FieldToSearchIn == Field.Error ) {
                throw this.ErrorInvalidSearch( "campo '" + fieldName +"' no existente" );
            }

            if ( this.Comparison == Operation.Error ) {
                throw this.ErrorInvalidSearch( "'" + cmpName + "': comparación incorrecta" );
            }

			if ( this.Value == null ) {
				throw this.ErrorInvalidSearch( "valor '" + cmpValue 
                                + "' incompatible con '"
                                + fieldName + "'"
                      );
			}
		}

		/// <summary>
		/// Toma una cadena y la convierte en un double si es necesario,
		/// según la comparación.
		///  Necesita que campo ya esté asignado, o no funcionará.
		/// </summary>
		/// <param name="valor">La cadena a convertir a double</param>
		/// <returns>Un objeto, que puede ser la cadena tal cual o un double
		/// </returns>
		object CompareValueFromStr(string valor)
		{
			object toret = valor;

			if ( this.FieldToSearchIn == Field.Area
			  || this.FieldToSearchIn == Field.PrecioVenta
			  || this.FieldToSearchIn == Field.Valor )
			{
				// Convertirlo a un double, si es posible
				try {
					toret = valor.DoubleFromString();
				}
				catch ( Exception ) {
					toret = null;
				}
			}

			return toret;
		}

		public Cmp ComparisonFromOpName(Operation op)
		{
			Cmp toret = null;

			switch ( op ) {
				case Operation.EQ:
					toret = this.CmpEQ;
					break;
				case Operation.NEQ:
					toret = this.CmpNEQ;
    				break;
				case Operation.GT:
					toret = this.CmpGT;
					break;
				case Operation.LT:
					toret = this.CmpLT;
					break;
				case Operation.GTE:
					toret = this.CmpGTE;
					break;
				case Operation.LTE:
					toret = this.CmpLTE;
					break;
			}

			return toret;
		}

		private IncorrectFilterException ErrorInvalidSearch(string msg)
		{
			string val = "";

			if ( Value != null ) {
				val = Value.ToString();
			}

			if ( msg.Length == 0 ) {
				msg = '¿' + StrFromField() + ' ' + StrFromOperation()
						+ val + '?'
				;
			}

			return new IncorrectFilterException( msg );
		}

		public override string ToString()
		{
			return ( 
				  StrFromField()
				  + ' ' + StrFromOperation()
				  + ' ' + Value.ToString() )
			;
		}

		public delegate bool Cmp(Object v1, Object v2);

		bool CmpEQ(Object v1, Object v2)
		/// ComparaIgual cuenta con que el valor v1 sea el del campo original
		/// especialmente para cadenas, que las compara en mayúsculas y al
		/// tamaño del valor invitado.
		{
			bool toret;

			if ( ( v1 is string )
			  && ( v2 is string ) )
			{
				string strV1 = ( v1 as string ).ToUpper();
				string strV2 = ( v2 as string ).ToUpper();

				if ( strV2.Length < strV1.Length ) {
					strV1 = strV1.Substring( 0, strV2.Length );
				}

				toret = ( strV1.CompareTo( strV2 ) == 0 );
			}
			else toret = ( v1.Equals( v2 ) );

			return toret;
		}

		bool CmpNEQ(Object v1, Object v2)
		{
			return !this.CmpEQ( v1, v2 );
		}

		bool CmpLT(Object v1, Object v2)
		{
			bool toret = false;

			if ( v1 is double
			  && v2 is double )
			{
				toret = ( (double) v1 ) < ( (double) v2 );
			}
			else
			if ( v1 is string
			  && v2 is string )
			{
				toret = ( v1 as string ).CompareTo( v2 as string ) < 0;
			}

			return toret;
		}

		bool CmpLTE(Object v1, Object v2)
		{
			return ( this.CmpEQ( v1, v2 ) || this.CmpLT( v1, v2 ) );
		}

		bool CmpGTE(Object v1, Object v2)
		{
			return ( this.CmpEQ( v1, v2 ) || this.CmpGT( v1, v2 ) );
		}

		bool CmpGT(object v1, object v2)
		{
			return ( this.CmpNEQ( v1, v2 ) && ( !this.CmpLT( v1, v2 ) ) );
		}

        /// <summary>
        /// Determines whether an area fulfills the condition.
        /// </summary>
        /// <returns><c>true</c>, if condicion was true for this area, <c>false</c> otherwise.</returns>
        /// <param name="area">The <see cref="Area"/>.</param>
		public bool FulfillsCondition(Area area)
		{
            bool toret = false;
            object orgValue;

            // Area should not be null
            if ( area == null ) {
                goto END;
            }

			// A place is not suitable for certain fields
			if ( IsEstate()
			  && ( area is Place ) )
			{
                goto END;
			}

			// Do the comparison
            if ( FieldToSearchIn == Field.NombreDeLugar ) {
                while ( !toret
                     && area != null )
                {
                    // Take the value
                    orgValue = GetFieldValue( area );

                    // Compare if not nulls present
                    if ( orgValue != null
                      && this.Value != null )
                    {
                        toret = DoCompare( orgValue, Value );
                    }

                    // Next ancestor area
                    if ( !toret ) {
                        area = area.Parent;
                    }
                }

            } else {
                // Tomar el valor
                orgValue = this.GetFieldValue( area );

                // Hacer la comparación si no hay nulos
                if ( orgValue != null
                  && Value != null )
                {
                    toret = this.DoCompare( orgValue, Value );
                }
            }

            END:
            return toret;
		}

		private Object GetFieldValue(Area area)
		{
			Object toret = null;

			if ( !IsEstate() ) {
				switch ( FieldToSearchIn ) {
					case Field.Nombre:
						toret = area.Name;
						break;
					case Field.Remarks:
						toret = area.Remarks;
						break;
					case Field.Id:
						toret = area.Id;
						break;
                    case Field.NombreDeLugar:
                        if ( area.Parent != null )
                                toret = area.Parent.Name;
                        else    toret = null;
                        break;
				}
			}
			else 
			if ( area is Estate )
			{
				Estate f = ( area as Estate );

				switch ( FieldToSearchIn ) {
					case Field.Area:
						toret = f.Extension;
						break;
					case Field.Valor:
						toret = f.Valor;
						break;
                    case Field.ReferenciaCatastral:
                        toret = f.RefCatastral;
                        break;
					case Field.PrecioVenta:
						toret = f.getPrecioDeVenta();
						break;
					case Field.NombreComprador:
						toret = f.getNombreDeComprador();
						break;
					case Field.Poblacion:
						if ( f.getDireccion() != null ) {
							toret = f.getDireccion().City;
						}
						break;
					case Field.Provincia:
						if ( f.getDireccion() != null ) {
							toret = f.getDireccion().Province;
						}
						break;
					case Field.Calle:
						if ( f.getDireccion() != null ) {
							toret = f.getDireccion().Street;
						}
						break;
				}
			}

			return toret;
		}

		bool IsEstate()
		{
			return ( ( (int) FieldToSearchIn ) >= ( (int) Field.Remarks ) );
		}
        
        public Field FieldToSearchIn {
            get; private set;
        }
        
        public Operation Comparison {
            get; private set;
        }
        
        public Object Value {
            get; private set;
        }
        
        public Cmp DoCompare {
            get; private set;
        }
	}
}
