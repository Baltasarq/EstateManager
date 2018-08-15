// GestorFincas (c) 2005-2018 Baltasarq MIT License (baltasarq@gmail.com)

namespace EstateManager.UI {
	using System;
	using System.Windows.Forms;
	
	using EstateManager.Core;

	public partial class FilterWindow : Explorer {
		public FilterWindow(Database db,
                            Control owner,
                            Action<string, int, int> processStart,
                            Action<int> processMakeStep,
                            Action processEnd)
            :base( owner )
		{
            this.Db = db;
			this.InitializeComponent();

            this.processStart = processStart;
            this.processMakeStep = processMakeStep;
            this.processEnd = processEnd;

			// Insert filtering fields
			for(int i = 0; i < Search.FieldNames.Length -1; ++i) {
				this.cbFields.Items.Add( Search.FieldNames[ i ] );
			}
			this.cbFields.Text = (string) cbFields.Items[ 0 ];

			// Append all operations
			for (int i = 0; i < Search.OperationNames.Length -1; ++i) {
				this.cbCmpOperations.Items.Add( Search.OperationNames[ i ] );
			}
			this.cbCmpOperations.Text = (string) cbCmpOperations.Items[ 0 ];
		}

		private void OnBtSearchClicked(object sender, EventArgs e)
		{
            try {
                // Create filter
                Search objBusqueda = new Search(
                    cbFields.Text,
                    cbCmpOperations.Text,
                    edValue.Text )
                ;

                // Create filtering environment
                SearchExecution searchExecution = new SearchExecution(
                    this.Db.AllAreas,
                    objBusqueda,
                    this.processStart,
                    this.processMakeStep,
                    this.processEnd
                );

                // Execute filtering
                Area[] areas = searchExecution.Execute();

                // Show filtering results
                FilterResultsWindow resultsSearch = new FilterResultsWindow(
                        objBusqueda.ToString(),
                        areas,
                        this.Owner,
                        this.processStart,
                        this.processMakeStep,
                        this.processEnd )
                ;

                resultsSearch.Show();
            } catch ( UserException exc ) {
                MessageBox.Show( exc.Message, "Error filtrando" );
            }

			return;
		}

		void OnSearchWindowEnter(object sender, EventArgs e)
		{
			this.OnBtSearchClicked( this, null );
		}

		void OnTextBoxKeyPress(object sender, KeyPressEventArgs e)
		{
			if ( e.KeyChar == (char) Keys.Enter ) {
				// Lanzar el buscar
				e.Handled = true;
				this.OnBtSearchClicked( this, null );
			}
		}
        
        public Database Db {
            get; private set;
        }
        
        Action<string, int, int> processStart;
        Action<int> processMakeStep;
        Action processEnd;
	}
}
