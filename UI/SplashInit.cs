// GestorFincas (c) 2005 Baltasar MIT License (baltasarq@gmail.com)
using System.Windows.Forms;

namespace EstateManager.UI {
    using System;
    using System.Drawing;
    using System.Diagnostics;

	/// <summary>
	/// Solo visualiza una ventana con un dibujo mientras se carga la base de datos.
	/// </summary>
	public class SplashInit : Form {
		public SplashInit()
		{
			this.Build();			
		}
        
        private void BuildIcons()
        {
            var asm = System.Reflection.Assembly.GetEntryAssembly();
            
            try {
                this.bmpSplash = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.splash.png" ) );
            } catch(Exception e) {
                Debug.WriteLine( "ERROR loading icons: " + e.Message);
            }

            return;
        }
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void Build()
        {
            this.BuildIcons();
        
			this.splashViewer = new PictureBox();
			( (System.ComponentModel.ISupportInitialize) ( this.splashViewer ) ).BeginInit();
			this.SuspendLayout();
			// 
			// splashViewer
			// 
			this.splashViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splashViewer.Image = this.bmpSplash;
			this.splashViewer.Location = new System.Drawing.Point( 0, 0 );
			this.splashViewer.Name = "pictureBox2";
			this.splashViewer.Size = new System.Drawing.Size( 391, 230 );
			this.splashViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.splashViewer.TabIndex = 0;
			this.splashViewer.TabStop = false;
			// 
			// SplashInit
			// 
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size( 391, 230 );
			this.Controls.Add( this.splashViewer );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SplashInit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			( (System.ComponentModel.ISupportInitialize) ( this.splashViewer ) ).EndInit();
			this.ResumeLayout( false );

		}
        
        private PictureBox splashViewer;
        private Bitmap bmpSplash;
	}
}
