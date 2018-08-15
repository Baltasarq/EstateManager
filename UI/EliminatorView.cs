namespace EstateManager.UI {
	partial class Eliminator {
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
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Eliminator ) );
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.cbId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.cbName );
            this.groupBox1.Controls.Add( this.cbId );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point( 0, 0 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 292, 83 );
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Indicar lugar o finca a eliminar por datos";
            // 
            // comboBox2
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point( 106, 47 );
            this.cbName.Name = "comboBox2";
            this.cbName.Size = new System.Drawing.Size( 151, 21 );
            this.cbName.TabIndex = 13;
            this.cbName.SelectedIndexChanged += new System.EventHandler( this.OnComboBoxSelectedIndexChanged );
            // 
            // comboBox1
            // 
            this.cbId.FormattingEnabled = true;
            this.cbId.Location = new System.Drawing.Point( 106, 16 );
            this.cbId.Name = "comboBox1";
            this.cbId.Size = new System.Drawing.Size( 151, 21 );
            this.cbId.TabIndex = 12;
            this.cbId.SelectedIndexChanged += new System.EventHandler( this.OnComboBoxSelectedIndexChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12, 50 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 44, 13 );
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 12, 16 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 18, 13 );
            this.label2.TabIndex = 10;
            this.label2.Text = "ID";
            // 
            // button2
            // 
            this.button2.ImageIndex = 0;
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point( 194, 248 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 75, 23 );
            this.button2.TabIndex = 3;
            this.button2.Text = "&Cancelar";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.Click += new System.EventHandler( this.OnBtCloseClicked );
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ( ( System.Windows.Forms.ImageListStreamer ) ( resources.GetObject( "imageList1.ImageStream" ) ) );
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName( 0, "eliminar.bmp" );
            this.imageList1.Images.SetKeyName( 1, "borrar.bmp" );
            // 
            // button1
            // 
            this.button1.ImageIndex = 1;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point( 25, 248 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 69, 23 );
            this.button1.TabIndex = 2;
            this.button1.Text = "&Eliminar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.Click += new System.EventHandler( this.OnBtRemoveClicked );
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add( this.treeView );
            this.groupBox3.Location = new System.Drawing.Point( 0, 89 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 292, 153 );
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar área a eliminar ...";
            // 
            // treeView1
            // 
            this.treeView.Location = new System.Drawing.Point( 25, 20 );
            this.treeView.Name = "treeView1";
            this.treeView.Size = new System.Drawing.Size( 244, 117 );
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.OnAfterSelectTreeViewNode );
            // 
            // UIEliminador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 292, 283 );
            this.Controls.Add( this.groupBox3 );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.groupBox1 );
            this.Name = "UIEliminador";
            this.Text = "UIEliminador";
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout( false );
            this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox cbName;
		private System.Windows.Forms.ComboBox cbId;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ImageList imageList1;
	}
}