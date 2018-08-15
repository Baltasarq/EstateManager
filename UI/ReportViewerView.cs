using System.Reflection;

namespace EstateManager.UI {
    partial class ReportViewer {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            this.BuildIcons();
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ReportViewer ) );
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.imageList = new System.Windows.Forms.ImageList( this.components );
            this.btSaveReport = new System.Windows.Forms.Button();
            this.reportViewer = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.Images.AddRange(
                new System.Drawing.Image[] { this.bmpSave } );
            // 
            // panelButtons
            // 
            this.pnlButtons.Controls.Add( this.btSaveReport );
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.TabIndex = 0;
            this.pnlButtons.ResumeLayout( true );
            this.pnlButtons.MaximumSize = new System.Drawing.Size(
                                                this.btSaveReport.Width + 10,
                                                int.MaxValue );
            // 
            // btSaveReport
            // 
            this.btSaveReport.ImageIndex = 0;
            this.btSaveReport.ImageList = this.imageList;
            this.btSaveReport.Name = "btSaveReport";
            this.btSaveReport.TabIndex = 0;
            this.btSaveReport.Text = "&Guardar como...";
            this.btSaveReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSaveReport.UseVisualStyleBackColor = true;
            this.btSaveReport.Click += new System.EventHandler( this.OnBtSaveReportClick );
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.TabIndex = 1;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "html";
            this.saveFileDialog.Filter = "Archivos informes  (*.html)|*.html";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // VisorInforme
            // 
            this.Controls.Add( this.reportViewer );
            this.Controls.Add( this.pnlButtons );            
            this.Name = "VisorInforme";
            this.Text = "VisorInforme";
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResumeLayout( true );
        }

        #endregion
        
        void BuildIcons()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            
            try {
                this.bmpSave = new System.Drawing.Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.guardar.png" ) );
            } catch(System.Exception e) {
                System.Diagnostics.Debug.WriteLine( "ERROR loading icons: " + e.Message );
            }

            return;
        }
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            
            base.Dispose( disposing );
        }

        System.Drawing.Bitmap bmpSave;
        System.Windows.Forms.Panel pnlButtons;
        System.Windows.Forms.RichTextBox reportViewer;
        System.Windows.Forms.Button btSaveReport;
        System.Windows.Forms.SaveFileDialog saveFileDialog;
        System.Windows.Forms.ImageList imageList;
        System.ComponentModel.IContainer components;
    }
}