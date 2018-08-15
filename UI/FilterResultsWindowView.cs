// GestorFincas (c) 2005-2018 Baltasarq MIT License (baltasarq@gmail.com)

namespace EstateManager.UI {
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;

	public partial class FilterResultsWindow: Explorer {
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
        
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
            this.BuildIcons();
            
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FilterResultsWindow ) );
            this.gvData = new DataGridView();
            this.idColumn = new DataGridViewTextBoxColumn();
            this.nameColumn = new DataGridViewTextBoxColumn();
            this.areaColumn = new DataGridViewTextBoxColumn();
            this.remarksColumn = new DataGridViewTextBoxColumn();
            this.addressColumn = new DataGridViewTextBoxColumn();
            this.pnlButtons = new Panel();
            this.btGenerateReport = new Button();
            this.imageList = new ImageList( this.components );
            ( ( System.ComponentModel.ISupportInitialize ) ( this.gvData ) ).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvData
            // 
            this.gvData.AllowUserToAddRows = false;
            this.gvData.AllowUserToDeleteRows = false;
            this.gvData.Columns.AddRange( new DataGridViewColumn[] {
            this.idColumn,
            this.nameColumn,
            this.areaColumn,
            this.remarksColumn,
            this.addressColumn} );
            this.gvData.Dock = DockStyle.Fill;
            this.gvData.Location = new Point( 0, 0 );
            this.gvData.MultiSelect = false;
            this.gvData.Name = "gvData";
            this.gvData.ReadOnly = true;
            this.gvData.TabIndex = 0;
            // 
            // ColumnaId
            // 
            this.idColumn.Frozen = true;
            this.idColumn.HeaderText = "Id";
            this.idColumn.Name = "ColumnaId";
            this.idColumn.ReadOnly = true;
            this.idColumn.ToolTipText = "Id de la finca";
            // 
            // ColumnaNombre
            // 
            this.nameColumn.Frozen = true;
            this.nameColumn.HeaderText = "Nombre";
            this.nameColumn.Name = "ColumnaNombre";
            this.nameColumn.ReadOnly = true;
            // 
            // ColumnaArea
            // 
            this.areaColumn.HeaderText = "Area";
            this.areaColumn.Name = "ColumnaArea";
            this.areaColumn.ReadOnly = true;
            this.areaColumn.ToolTipText = "Superficie de la finca";
            // 
            // ColumnaObservaciones
            // 
            this.remarksColumn.HeaderText = "Obs.";
            this.remarksColumn.Name = "ColumnaObservaciones";
            this.remarksColumn.ReadOnly = true;
            this.remarksColumn.ToolTipText = "Observaciones";
            // 
            // ColumnaDireccion
            // 
            this.addressColumn.HeaderText = "Direcci¨®n";
            this.addressColumn.Name = "ColumnaDireccion";
            this.addressColumn.ReadOnly = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add( this.btGenerateReport );
            this.pnlButtons.Dock = DockStyle.Bottom;
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.TabIndex = 1;
            // 
            // btGenerateReport
            // 
            this.btGenerateReport.Dock = DockStyle.Right;
            this.btGenerateReport.ImageIndex = 0;
            this.btGenerateReport.ImageList = this.imageList;
            this.btGenerateReport.Name = "btGenerateReport";
            this.btGenerateReport.Size = new System.Drawing.Size( 112, 27 );
            this.btGenerateReport.TabIndex = 1;
            this.btGenerateReport.Text = "&Generar informe";
            this.btGenerateReport.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btGenerateReport.UseVisualStyleBackColor = true;
            this.btGenerateReport.Click += (o, e) => this.OnBtGenerateReportClicked();
            // 
            // imageList
            // 
            this.imageList.TransparentColor = Color.Transparent;
            this.imageList.Images.AddRange( new Image[] {
                                    this.bmpNew
            });

            this.AutoScroll = true;
            this.Controls.Add( this.gvData );
            this.Controls.Add( this.pnlButtons );
            this.Name = "ResultadosBusqueda";
            this.Text = "Resultados";
            ( ( System.ComponentModel.ISupportInitialize ) ( this.gvData ) ).EndInit();
            this.pnlButtons.ResumeLayout( false );
            this.ResumeLayout( false );

		}
        
        void BuildIcons()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            
            try {
                this.bmpNew = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.nuevo.png" ) );
            } catch(Exception e) {
                Debug.WriteLine( "ERROR loading icons: " + e.Message);
            }

            return;
        }

        Bitmap bmpNew;
		DataGridView gvData;
        DataGridViewTextBoxColumn idColumn;
        DataGridViewTextBoxColumn nameColumn;
        DataGridViewTextBoxColumn areaColumn;
        DataGridViewTextBoxColumn remarksColumn;
        DataGridViewTextBoxColumn addressColumn;
        Panel pnlButtons;
        Button btGenerateReport;
        ImageList imageList;
        System.ComponentModel.IContainer components;
	}
}
