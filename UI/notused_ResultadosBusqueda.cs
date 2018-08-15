using System;
using System.Windows.Forms;
using System.Collections;

namespace GestorFincas.UI {
	/**
	 * ResultadosBusqueda
	 * Permite listar el resultado de filtro
	 * Doble-click en filas provoca que se lance un explorador con ese lugar.
	*/
	public partial class ResultadosBusqueda : Form {
		public const string EtqResultados = "Resultados";

        private string busqueda;

        public string getCriterioBusqueda()
        {
            return busqueda;
        }

		private ArrayList areas;
		public ArrayList getAreas()
		{
			return areas;
		}

		public ResultadosBusqueda(string b, ArrayList listaAreas)
		{
			DataGridViewRow fila;
			areas = listaAreas;
            busqueda = b;

			InitializeComponent();

			Text = EtqResultados + ':' + ' ' + busqueda;
			MinimumSize = new System.Drawing.Size( Width, Height );
			MdiParent = MainForm.mainForm;

            MainForm.mainForm.StartProcess( 
                        "Recopilando resultados de filtro...",
                        0, listaAreas.Count 
            );

            for (int i = 0; i < listaAreas.Count; ++i) {
                Area a = (Area) listaAreas[ i ];
                MainForm.mainForm.MakeStepProcess( i );

                // Inserta una fila
                dataGridView1.Rows.Add();
                fila = dataGridView1.Rows[ dataGridView1.Rows.Count - 1 ];

                // Inserta los datos a la fila
                // El id
                fila.Cells[ 0 ].Value = a.Id;

                // El nombre
                fila.Cells[ 1 ].Value = a.getNombre();

                // Las observaciones
                fila.Cells[ 3 ].Value = a.Observaciones;

                if ( ( a as Finca ) != null ) {
                    // La superficie
                    fila.Cells[ 2 ].Value = ( a as Finca ).Superficie.ToString();

                    // La direc. postal
                    if ( ( a as Finca ).getDireccion() != null ) {
                        fila.Cells[ 4 ].Value =
                            ( a as Finca ).getDireccion().ToString()
                        ;
                    }
                }
            }

            MainForm.mainForm.EndProcess();

			return;
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if ( e.RowIndex < 0
			  || e.RowIndex >= areas.Count ) {
				throw new InternalException( "Finca no existe" );
			}

			ExploradorLugar.lanzarExplorador( (Area) areas[e.RowIndex] );
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Informe informe = new Informe( areas , busqueda );
            MainForm.mainForm.StartProcess( "Abriendo visor ...", 0, 2 );

            VisorInforme visor = new VisorInforme( informe );
            MainForm.mainForm.MakeStepProcess( 1 );
            visor.Show();

            MainForm.mainForm.EndProcess();
        }
	}
}