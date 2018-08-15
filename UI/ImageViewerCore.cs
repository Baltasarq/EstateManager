// gF (c) Baltasar 2005-18 MIT License <baltasarq@gmail.com>

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using EstateManager.Core;

namespace EstateManager.UI {
	public partial class ImageViewer : Explorer {
		public ImageViewer(string imageFileName, Area a, Control owner)
            :base( owner )
		{
			this.Area = a;
            this.ImageFileName = imageFileName;

			this.InitializeComponent();

            // Descriptive window title
			this.Text = @"Imagen: " + a.Name;
			if ( this.Area is Estate ) {
                this.Text += @" - "
					+ EstateExplorer.EtqFinca
					+ ( ( this.Area as Estate).IsUrban ? 
							( @" " + EstateExplorer.EtqUrbana ) 
							: @"" )
				;

                if ( ImageFileName.Contains( Database.EtqZona ) ) {
                    this.Text += ' ' + ( '(' 
                              + Database.EtqZona.ToLower()
                              + ')' + ' ' );
                }
			}
            else
            if ( this.Area is Place ) {
                this.Text += @" - " + Area.FormatForPresentation( Database.EtqLugar );
            }

			this.MaximumSize = new Size( this.Owner.Width, this.Owner.Height );
			pictureBox.LoadAsync( imageFileName );
		}

		private void OnLinkShowInfoClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			PlaceExplorerEngine.LaunchExplorerFor( this.Area );
		}

		private void OnPictureBoxLoadProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.progressBar.PerformStep();
		}

        private void OnPictureBoxLoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Size maxSize;
            Size size = MainForm.mainForm.GetWorkspaceSize();
            
            this.progressBar.Visible = false;

            if ( e.Error != null ) {
                pictureBox.Image = pictureBox.ErrorImage;
            } else {
                // Set minimum size
                int tamAltoCliente = (Size.Height - ClientSize.Height) + 15;
                int tamAnchoCliente = (Size.Width - ClientSize.Width) + 5;
                maxSize = new System.Drawing.Size(
                                    pictureBox.Image.Width,
                                    pictureBox.Image.Height
                );

                maxSize.Width += tamAnchoCliente;
                maxSize.Height += tamAltoCliente;
                MaximumSize = maxSize;

                Size = size;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        
        public Area Area {
            get; private set;
        }
        
        public string ImageFileName {
            get; set;
        }
	}
}
