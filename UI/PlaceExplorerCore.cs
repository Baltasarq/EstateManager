// gF (c) Baltasar 2005-18 MIT License <baltasarq@gmail.com>

using System.Drawing;
using System.Windows.Forms;

using EstateManager.Core;

namespace EstateManager.UI {
	public partial class PlaceExplorer : Explorer {
        public PlaceExplorer(Place l, Database bd, Control panel)
            :base( panel )
        {
            this.Lugar = l;
            this.InitializeComponent();
            this.MinimumSize = new Size( Size.Width, Size.Height );

            this.ExploradorLugar = new PlaceExplorerEngine( this, bd, treeView1, l, PlaceExplorerEngine.Launcher );
        }
        
		public void UpdatePanel()
		{
            Place auxLista = this.Lugar.Parent;
            string listaDePadres = "";

            Text = Area.FormatForPresentation( this.Lugar.Name )
                 + @" - " + Area.FormatForPresentation( Database.EtqLugar )
            ;

            // Build a list with ancestors
            while ( auxLista != null ) {
                listaDePadres += "   "
                                + Area.FormatForPresentation( auxLista.Name )
                                + " \\par"
                ;

                auxLista = auxLista.Parent;
            }

            richTextBox1.Clear();
            richTextBox1.SelectedRtf = "{\\rtf1\\ansi \\b "
              + Area.FormatForPresentation( this.Lugar.Name )
              + " \\par \\par "
              + "En: \\b0 \\par"
              + listaDePadres
              + " \\par \\b Num. de fincas: \\b0 "
              + this.Lugar.CountEstates.ToString()
              + " \\par "
              + "\\b Num. de lugares: \\b0 "
              + this.Lugar.CountPlaces.ToString()
              + " \\par \\par \\i " + this.Lugar.Remarks + " \\i0 }"
            ;

            return;
		}

		private void OnBtShowImageClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ImageViewer visor = new ImageViewer(
                                        this.Lugar.GetImageName(),
                                        this.Lugar,
                                        this.Owner );
			visor.Show();
		}

		private void UILugarClosed(object sender, FormClosedEventArgs e)
		{
            this.OnStopObserving();
		}

        public void OnStopObserving()
        {
            // Actualizar el explorador
            this.ExploradorLugar.OnStopObserving();

            // Actualizar las observaciones
            AreaTreeNode nodo = ( AreaTreeNode )
                MainForm.LocateInTreeView( MainForm.mainForm.EstatesTree, this.Lugar )
            ;

            if ( nodo != null ) {
                nodo.ToolTipText = this.Lugar.Remarks;
            }
        }

		private void OnLinkLabel2Clicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			PlaceExplorerEngine.LaunchExplorerFor( this.Lugar.Parent );
		}

        private void OnLinkLabel3Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeRemarks uim = new ChangeRemarks( this.Lugar );
            uim.ShowDialog();
        }
        
        public Place Lugar {
            get; private set;
        }
        
        public PlaceExplorerEngine ExploradorLugar {
            get; private set;
        }
	}
}
