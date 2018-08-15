using System;
using System.Windows.Forms;

using EstateManager.Core;

namespace EstateManager.UI {
	public partial class Creator : Form {
		public const bool FINCA = true;
		public const bool LUGAR = false;

		public Creator(Area donde, bool finca)
		{
			MdiParent = MainForm.mainForm;
			InitializeComponent();

			esFinca = finca;

			this.MinimumSize = this.Size;

			// Crear el motor
			xpLugares = new PlaceExplorerEngine(
							null,
							MainForm.mainForm.Db,
							treeView1,
							null,
							PlaceExplorerEngine.Selector
			);
            
            // Seleccionar el que ya está seleccionado
            treeView1.SelectedNode = MainForm.LocateInTreeView( treeView1, donde );
            treeView1.SelectedNode.EnsureVisible();

			// Habilitar la info correspondiente
            textBox4.Text = 0.ToString( textBox4.Mask );
            if ( esFinca ) {
                tabPage2.Enabled = true;
                tabPage3.Enabled = false;
            } else {
                tabPage2.Enabled = false;
                tabPage3.Enabled = true;
            }
		}

		private void OnButton2Click(object sender, EventArgs e)
		/// El botón "Cancelar" es pulsado.
		{
			Close();
		}

		private void OnButton1Click(object sender, EventArgs e)
		/// El botón "crear" es pulsado
		{
			Area area = null;
			Area otra;
			Database bd = MainForm.mainForm.Db;

			// id y nombre requeridos
			if ( textBox1.Text.Length == 0
			  || textBox2.Text.Length == 0 )
			{
				MessageBox.Show(
					"El nombre y el ID son obligatorios",
					"Error",
					MessageBoxButtons.OK
				);

				goto fin;
			}

			// nombre e id deben ser únicos
            textBox2.Text = Area.NormalizeName( textBox2.Text );
            textBox1.Text = Area.NormalizeName( textBox1.Text );

            Application.DoEvents();

			if ( ( otra = bd.GetAreaById( textBox2.Text ) ) != null
			  || ( otra = bd.GetAreaByName( textBox1.Text ) ) != null )
			{
				MessageBox.Show(
					"Otra área (" 
					+ otra
					+ ") ya existe con ese id y/o nombre",
					"Error"
				);

				goto fin;
			}

			// Prepare the place -- maybe is a real estate
			Area elLugar = xpLugares.SelectedArea;

            if ( elLugar == null ) {
                MessageBox.Show(
                        "Debe seleccionar un área.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                );

            }

			if ( elLugar is Estate ) {
				elLugar = ( (Estate) elLugar ).Parent;
			}

			// No crear fincas en toplevel
			if ( esFinca
			  && elLugar == bd.Root ) 
			{
				MessageBox.Show(
					"No es posible crear fincas en el tope de la jerarquía",
					"Atención"
				);

				goto fin;
			}

            try {
			    // Crear el área adecuada
			    if ( !esFinca ) {
				    area = new Place( (Place) elLugar, textBox2.Text, textBox1.Text );

                    // Copiar archivos a imágenes
                    if ( textBox9.Text.Length > 0 ) {
                        SaveImage( textBox9.Text,
                                       ( ( Place ) area ).GetImageName()
                        );
                    }
			    }
			    else {
				    double superficie;

				    // Preparar la superficie
				    try {
					    superficie = textBox4.Text.DoubleFromString();
				    }
				    catch ( Exception ) {
					    superficie = 0;
				    }

				    // Crear la nueva área
                    Estate f = new Estate(
                                    textBox2.Text,
                                    textBox1.Text,
                                    ( Place ) elLugar,
                                    superficie
                    );

                    area = f;

                    // ¿Es urbana?
                    f.IsUrban = checkBox1.Checked;

                    // Copiar archivos a imágenes
                    if ( textBox5.Text.Length > 0 ) {
                        SaveImage( textBox5.Text, f.GetImageName() );
                    }

                    if ( textBox6.Text.Length > 0 ) {
                        SaveImage( textBox6.Text, f.getNombreImagenZona() );
                    }
                }
            }
            catch ( System.IO.IOException err) {
                MessageBox.Show( "Se produjo un error al copiar archivos: " 
                                    + err.ToString()
                );
            }
            catch ( Exception err ) {
                MessageBox.Show( "Error creando área: "
                                    + err.ToString() 
                );
            }

			area.Remarks = textBox3.Text;

			// Cerrar esta ventana
			Close();

			// Insertarla en la base de datos
			bd.InsertArea( (Place) elLugar, area );
			bd.Sync();

			// Crear un visor para la nueva área
			PlaceExplorerEngine.LaunchExplorerFor( area );

			fin:
			return;
		}

        private static void SaveImage(string org, string dest)
        {
            if ( System.IO.File.Exists( org ) ) {
                if ( System.IO.File.Exists( dest ) ) {
                    string nuevoDest = dest
                                    + '_' 
                                    + Database.BuildTimeDescriptor( DateTime.Now )
                                    + ".bak"
                    ;

                    System.IO.File.Move( dest, nuevoDest );

                    MessageBox.Show(
                        "La imagen '" + dest + "' fue encontrada en el repositorio"
                        + " de imágenes, por lo que se renombró antes de copiar la"
                        + " nueva a '" + nuevoDest + '\'' + '.',
                        "Problema copiando imagen al repositorio",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );

                }

                System.IO.File.Copy( org, dest );
            } else {
                MessageBox.Show(
                  "La imagen '" + org + "' no fue encontrada, por lo que tendrá"
                  + " que crearla ud. mismo en '" + dest + '\'' + '.',
                  "Problema copiando imagen al repositorio",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation
              );
            }

            return;
        }

		private void UICreadorShown(object sender, EventArgs e)
		{
			// Hacer que el cursor aparezca en el nombre
			textBox2.Focus();
		}

		private void UICreadorClosed(object sender, FormClosedEventArgs e)
		{
			xpLugares.OnStopObserving();
		}

        private void OnButton3Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            if ( openFileDialog1.ShowDialog( this ) == DialogResult.OK ) {
                if ( sender == button3 ) {
                    textBox5.Text = openFileDialog1.FileName;
                }
                else
                if ( sender == button4 ) {
                    textBox6.Text = openFileDialog1.FileName;
                }
                else
                if ( sender == button5 ) {
                    textBox9.Text = openFileDialog1.FileName;
                }
            }
        }

        private void OnTextBox4MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            EstateExplorer.ShowHelpHowToUseMask();
        }
        
        bool esFinca;
        PlaceExplorerEngine xpLugares;
	}
}