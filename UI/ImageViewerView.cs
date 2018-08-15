// gF (c) Baltasar 2005-18 MIT License <baltasarq@gmail.com>

namespace EstateManager.UI {
	partial class ImageViewer {
		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lnkShowInfo = new System.Windows.Forms.LinkLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize ) ( this.pictureBox ) ).BeginInit();
            this.SuspendLayout();
            // 
            // lnkShowInfo
            // 
            this.lnkShowInfo.AutoSize = true;
            this.lnkShowInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lnkShowInfo.Location = new System.Drawing.Point( 0, 189 );
            this.lnkShowInfo.Name = "linkLabel1";
            this.lnkShowInfo.TabIndex = 1;
            this.lnkShowInfo.TabStop = true;
            this.lnkShowInfo.Text = "Ver info";
            this.lnkShowInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.OnLinkShowInfoClicked );
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(
                                    new System.Windows.Forms.ToolStripItem[] {
                                        this.progressBar });
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.Name = "statusStrip1";
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusBar
            // 
            this.progressBar.Name = "barraProgreso";
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point( 0, 0 );
            this.pictureBox.Name = "pictureBox1";
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.LoadProgressChanged += new System.ComponentModel.ProgressChangedEventHandler( this.OnPictureBoxLoadProgressChanged );
            this.pictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler( this.OnPictureBoxLoadCompleted );

            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add( this.lnkShowInfo );
            this.Controls.Add( this.pictureBox );
            this.Controls.Add( this.statusStrip );
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "VisorImagen";
            this.Text = "VisorImagen";
            this.statusStrip.ResumeLayout( false );
            this.statusStrip.PerformLayout();
            ( ( System.ComponentModel.ISupportInitialize ) ( this.pictureBox ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel lnkShowInfo;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripProgressBar progressBar;
	}
}