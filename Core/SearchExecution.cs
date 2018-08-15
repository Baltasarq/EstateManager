// (c) 2005-2018 GestorFincas Baltasar MIT License <baltasarq@gmail.com>

namespace EstateManager.Core {
    using System;
    using System.Collections.Generic;

	public class SearchExecution {
		public SearchExecution(Area[] areas, Search search,
                                Action<string, int, int> processStart,
                                Action<int> processMakeStep,
                                Action processEnd)
		{
			this.AllAreas = areas;
			this.Search = search;
            
            this.processStart = processStart;
            this.processMakeStep = processMakeStep;
            this.processEnd = processEnd;
		}

		public Area[] Execute()
		{
			var toret = new List<Area>();

            this.processStart( 
                        "Buscando...",
                        0, this.AllAreas.Length
            );

            for (int i = 0; i < this.AllAreas.Length; ++i) {
                if ( Search.FulfillsCondition( this.AllAreas[ i ] ) ) {
                    toret.Add( this.AllAreas[ i ] );
                }

                this.processMakeStep( i );
            }

            this.processEnd();
			return toret.ToArray();
		}
        
        public Area[] AllAreas {
            get; private set;
        }
        
        public Search Search {
            get; private set;
        }
        
        private Action<string, int, int> processStart;
        private Action<int> processMakeStep;
        private Action processEnd;
	}
}
