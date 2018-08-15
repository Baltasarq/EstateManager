// GestorFincas (c) 2005-2018 Baltasarq MIT License (baltasarq@gmail.com)

namespace EstateManager.UI {
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Diagnostics;
    using System.Windows.Forms;

	partial class FilterWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
            this.BuildIcons();
        
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FilterWindow ) );
            this.grpButtons = new GroupBox();
            this.imageList = new ImageList( this.components );
            this.btSearch = new Button();
            this.grpSearchFrom = new GroupBox();
            this.comboBox1 = new ComboBox();
            this.grpCompareTo = new GroupBox();
            this.cbCmpOperations = new ComboBox();
            this.edValue = new TextBox();
            this.cbFields = new ComboBox();
            this.grpButtons.SuspendLayout();
            this.grpSearchFrom.SuspendLayout();
            this.grpCompareTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add( this.btSearch );
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.ForeColor = System.Drawing.Color.Navy;
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.TabIndex = 0;
            this.grpButtons.TabStop = false;
            this.grpButtons.Text = "Hacer...";
            // 
            // imageList
            // 
            this.imageList.Images.AddRange( new Image[] {
                                                this.bmpSearch,
                                                this.bmpDismiss });
            this.imageList.TransparentColor = Color.Transparent;
            // 
            // btSearch
            // 
            this.btSearch.ImageIndex = 0;
            this.btSearch.ImageList = this.imageList;
            this.btSearch.Name = "button1";
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "&Buscar";
            this.btSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btSearch.Click += new System.EventHandler( this.OnBtSearchClicked );
            // 
            // grpSearchFrom
            // 
            this.grpSearchFrom.Controls.Add( this.comboBox1 );
            this.grpSearchFrom.Dock = DockStyle.Top;
            this.grpSearchFrom.ForeColor = Color.Navy;
            this.grpSearchFrom.Name = "groupBox2";
            this.grpSearchFrom.TabIndex = 1;
            this.grpSearchFrom.TabStop = false;
            this.grpSearchFrom.Text = "Buscar a partir de...";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.TabIndex = 0;
            // 
            // grpCompareTo
            // 
            this.grpCompareTo.Controls.Add( this.cbCmpOperations );
            this.grpCompareTo.Controls.Add( this.edValue );
            this.grpCompareTo.Controls.Add( this.cbFields );
            this.grpCompareTo.Dock = DockStyle.Fill;
            this.grpCompareTo.ForeColor = Color.Navy;
            this.grpCompareTo.Location = new Point( 0, 66 );
            this.grpCompareTo.Name = "groupBox3";
            this.grpCompareTo.TabIndex = 2;
            this.grpCompareTo.TabStop = false;
            this.grpCompareTo.Text = "Condición";
            // 
            // cbCmpOperations
            // 
            this.cbCmpOperations.FormattingEnabled = true;
            this.cbCmpOperations.Name = "comboBox3";
            this.cbCmpOperations.TabIndex = 2;
            // 
            // edValue
            // 
            this.edValue.Name = "edValue";
            this.edValue.TabIndex = 1;
            this.edValue.KeyPress += new KeyPressEventHandler( this.OnTextBoxKeyPress );
            // 
            // cbFields
            // 
            this.cbFields.FormattingEnabled = true;
            this.cbFields.Location = new Point( 7, 35 );
            this.cbFields.Name = "cbFields";
            this.cbFields.Size = new Size( 121, 21 );
            this.cbFields.TabIndex = 0;

            this.Controls.Add( this.grpCompareTo );
            this.Controls.Add( this.grpSearchFrom );
            this.Controls.Add( this.grpButtons );
            this.Dock = DockStyle.Fill;
            this.Name = "VentanaBusqueda";
            this.Text = "Buscar";
            this.Enter += new System.EventHandler( this.OnSearchWindowEnter );
            this.grpButtons.ResumeLayout( false );
            this.grpSearchFrom.ResumeLayout( false );
            this.grpCompareTo.ResumeLayout( false );
            this.grpCompareTo.PerformLayout();
            this.ResumeLayout( false );

		}

		#endregion
        
        void BuildIcons()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            
            try {
                this.bmpSearch = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.buscar.png" ) );
                this.bmpDismiss = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.eliminar.png" ) );
            } catch(Exception e) {
                Debug.WriteLine( "ERROR loading icons: " + e.Message);
            }

            return;
        }

        Bitmap bmpSearch;
        Bitmap bmpDismiss;
		GroupBox grpButtons;
		GroupBox grpSearchFrom;
		ComboBox comboBox1;
		GroupBox grpCompareTo;
		ComboBox cbCmpOperations;
		TextBox edValue;
		ComboBox cbFields;
		Button btSearch;
        ImageList imageList;
	}
}