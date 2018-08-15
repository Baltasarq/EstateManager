namespace EstateManager.UI {
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class About {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            
            base.Dispose( disposing );
        }
        
        private void BuildIcons()
        {
            var asm = System.Reflection.Assembly.GetEntryAssembly();
            
            try {
                this.bmpLogo = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.logo.png" ) );
                this.bmpDelete = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.eliminar.png" ) );
            } catch(Exception e) {
                Debug.WriteLine( "ERROR loading icons: " + e.Message);
            }

            return;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void Build()
        {
            this.BuildIcons();
            
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( About ) );
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList( this.components );
            this.tableLayoutPanel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize) ( this.logoPictureBox ) ).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 28.77698F ) );
            this.tableLayoutPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 71.22302F ) );
            this.tableLayoutPanel.Controls.Add( this.labelVersion, 0, 3 );
            this.tableLayoutPanel.Controls.Add( this.logoPictureBox, 0, 0 );
            this.tableLayoutPanel.Controls.Add( this.labelProductName, 1, 0 );
            this.tableLayoutPanel.Controls.Add( this.labelCompanyName, 1, 1 );
            this.tableLayoutPanel.Controls.Add( this.textBoxDescription, 1, 2 );
            this.tableLayoutPanel.Controls.Add( this.okButton, 1, 4 );
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point( 12, 11 );
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding( 4 );
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 32.03883F ) );
            this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 9.708738F ) );
            this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 48.54369F ) );
            this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 9.708738F ) );
            this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 37F ) );
            this.tableLayoutPanel.Size = new System.Drawing.Size( 556, 326 );
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point( 168, 260 );
            this.labelVersion.Margin = new System.Windows.Forms.Padding( 8, 0, 4, 0 );
            this.labelVersion.MaximumSize = new System.Drawing.Size( 0, 21 );
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size( 384, 21 );
            this.labelVersion.TabIndex = 26;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = this.bmpLogo;
            this.logoPictureBox.Location = new System.Drawing.Point( 4, 4 );
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding( 4 );
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan( this.logoPictureBox, 4 );
            this.logoPictureBox.Size = new System.Drawing.Size( 152, 280 );
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Font = new System.Drawing.Font( "Times New Roman", 9.75F, ( (System.Drawing.FontStyle) ( ( System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline ) ) ), System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.labelProductName.Location = new System.Drawing.Point( 168, 0 );
            this.labelProductName.Margin = new System.Windows.Forms.Padding( 8, 0, 4, 0 );
            this.labelProductName.MaximumSize = new System.Drawing.Size( 0, 21 );
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size( 384, 21 );
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "gF";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCompanyName.Location = new System.Drawing.Point( 168, 92 );
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding( 8, 0, 4, 0 );
            this.labelCompanyName.MaximumSize = new System.Drawing.Size( 0, 21 );
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size( 384, 21 );
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.Text = "Company Name";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point( 168, 124 );
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding( 8, 4, 4, 4 );
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size( 384, 132 );
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Description";
            // 
            // okButton
            // 
            this.okButton.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.ImageIndex = 1;
            this.okButton.ImageList = this.imageList;
            this.okButton.Location = new System.Drawing.Point( 437, 292 );
            this.okButton.Margin = new System.Windows.Forms.Padding( 4 );
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size( 115, 30 );
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&Descartar";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.Click += new System.EventHandler( this.okButton_Click );
            // 
            // imageList1
            // 
            this.imageList.Images.AddRange( new Bitmap[] {
                this.bmpLogo,
                this.bmpDelete
            });
            
            this.imageList.TransparentColor = Color.Transparent;
            // 
            // AcercaDe
            // 
            this.AutoScaleDimensions = new SizeF( 8F, 16F );
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size( 580, 348 );
            this.Controls.Add( this.tableLayoutPanel );
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Margin = new Padding( 4 );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AcercaDe";
            this.Padding = new Padding( 12, 11, 12, 11 );
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AcercaDe";
            this.tableLayoutPanel.ResumeLayout( false );
            this.tableLayoutPanel.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize) ( this.logoPictureBox ) ).EndInit();
            this.ResumeLayout( true );
        }

        private Bitmap bmpLogo;
        private Bitmap bmpDelete;
        private TableLayoutPanel tableLayoutPanel;
        private PictureBox logoPictureBox;
        private Label labelCompanyName;
        private TextBox textBoxDescription;
        private Button okButton;
        private ImageList imageList;
        private Label labelProductName;
        private Label labelVersion;
        private System.ComponentModel.IContainer components;
    }
}
