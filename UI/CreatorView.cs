namespace EstateManager.UI {
	public partial class Creator {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Creator ) );
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.MaskedTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.button2 );
            this.panel1.Controls.Add( this.button1 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 0, 323 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 292, 25 );
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.ImageIndex = 0;
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point( 211, 0 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 81, 25 );
            this.button2.TabIndex = 14;
            this.button2.Text = "&Descartar";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.Click += new System.EventHandler( this.OnButton2Click );
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ( ( System.Windows.Forms.ImageListStreamer ) ( resources.GetObject( "imageList1.ImageStream" ) ) );
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName( 0, "eliminar.bmp" );
            this.imageList1.Images.SetKeyName( 1, "nuevo.bmp" );
            this.imageList1.Images.SetKeyName( 2, "abrir.bmp" );
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.ImageIndex = 1;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point( 0, 0 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 57, 25 );
            this.button1.TabIndex = 13;
            this.button1.Text = "&Crear";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.Click += new System.EventHandler( this.OnButton1Click );
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Controls.Add( this.tabPage3 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point( 0, 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 292, 323 );
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.groupBox3 );
            this.tabPage1.Controls.Add( this.groupBox1 );
            this.tabPage1.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 284, 297 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos básicos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add( this.treeView1 );
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point( 3, 118 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 278, 176 );
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "En el lugar de ...";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point( 9, 19 );
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size( 262, 147 );
            this.treeView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Controls.Add( this.textBox3 );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Controls.Add( this.textBox1 );
            this.groupBox1.Controls.Add( this.textBox2 );
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point( 3, 3 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 278, 115 );
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nueva área";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 6, 85 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 78, 13 );
            this.label3.TabIndex = 9;
            this.label3.Text = "Observaciones";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point( 118, 82 );
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size( 151, 20 );
            this.textBox3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 6, 54 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 44, 13 );
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 6, 22 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 18, 13 );
            this.label2.TabIndex = 6;
            this.label2.Text = "ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point( 118, 51 );
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size( 151, 20 );
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point( 118, 19 );
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size( 151, 20 );
            this.textBox2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.groupBox2 );
            this.tabPage2.Controls.Add( this.groupBox4 );
            this.tabPage2.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage2.Size = new System.Drawing.Size( 284, 297 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datos de finca";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.textBox4 );
            this.groupBox2.Controls.Add( this.checkBox1 );
            this.groupBox2.Controls.Add( this.label5 );
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point( 3, 220 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 278, 71 );
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos extra finca";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point( 92, 22 );
            this.textBox4.Mask = "0000000.00000";
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size( 177, 20 );
            this.textBox4.TabIndex = 5;
            this.textBox4.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler( this.OnTextBox4MaskInputRejected );
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox1.Location = new System.Drawing.Point( 92, 48 );
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size( 119, 17 );
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Es una finca urbana";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 6, 25 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 29, 13 );
            this.label5.TabIndex = 3;
            this.label5.Text = "Área";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add( this.textBox7 );
            this.groupBox4.Controls.Add( this.button4 );
            this.groupBox4.Controls.Add( this.label6 );
            this.groupBox4.Controls.Add( this.textBox6 );
            this.groupBox4.Controls.Add( this.button3 );
            this.groupBox4.Controls.Add( this.label4 );
            this.groupBox4.Controls.Add( this.textBox5 );
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point( 3, 3 );
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size( 278, 217 );
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Imágenes";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point( 9, 97 );
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size( 260, 98 );
            this.textBox7.TabIndex = 8;
            this.textBox7.Text = resources.GetString( "textBox7.Text" );
            // 
            // button4
            // 
            this.button4.ImageKey = "abrir.bmp";
            this.button4.ImageList = this.imageList1;
            this.button4.Location = new System.Drawing.Point( 227, 50 );
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size( 42, 23 );
            this.button4.TabIndex = 7;
            this.button4.Text = "...";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler( this.OnButton3Click );
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 3, 55 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 83, 13 );
            this.label6.TabIndex = 6;
            this.label6.Text = "Imagen de zona";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point( 92, 52 );
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size( 122, 20 );
            this.textBox6.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.ImageIndex = 2;
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point( 227, 23 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 42, 23 );
            this.button3.TabIndex = 4;
            this.button3.Text = "...";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler( this.OnButton3Click );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 3, 28 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 83, 13 );
            this.label4.TabIndex = 3;
            this.label4.Text = "Imagen de finca";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point( 92, 25 );
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size( 122, 20 );
            this.textBox5.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add( this.groupBox5 );
            this.tabPage3.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage3.Size = new System.Drawing.Size( 284, 297 );
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Datos de lugar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add( this.textBox8 );
            this.groupBox5.Controls.Add( this.button5 );
            this.groupBox5.Controls.Add( this.label7 );
            this.groupBox5.Controls.Add( this.textBox9 );
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point( 3, 3 );
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size( 278, 291 );
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Imagen";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point( 12, 125 );
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size( 260, 98 );
            this.textBox8.TabIndex = 8;
            this.textBox8.Text = resources.GetString( "textBox8.Text" );
            // 
            // button5
            // 
            this.button5.ImageKey = "abrir.bmp";
            this.button5.ImageList = this.imageList1;
            this.button5.Location = new System.Drawing.Point( 230, 59 );
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size( 42, 23 );
            this.button5.TabIndex = 7;
            this.button5.Text = "...";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler( this.OnButton3Click );
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point( 9, 64 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 83, 13 );
            this.label7.TabIndex = 6;
            this.label7.Text = "Imagen de zona";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point( 102, 61 );
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size( 122, 20 );
            this.textBox9.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "jpg";
            this.openFileDialog1.Filter = "Archivos de imágenes JPEG (*.jpg)|*.jpg";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Buscar archivos de imágenes";
            // 
            // UICreador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 292, 348 );
            this.Controls.Add( this.tabControl1 );
            this.Controls.Add( this.panel1 );
            this.Name = "UICreador";
            this.Text = "Nueva área";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.UICreadorClosed );
            this.Shown += new System.EventHandler( this.UICreadorShown );
            this.panel1.ResumeLayout( false );
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.groupBox3.ResumeLayout( false );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout( false );
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout( false );
            this.groupBox5.ResumeLayout( false );
            this.groupBox5.PerformLayout();
            this.ResumeLayout( false );

		}

		#endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MaskedTextBox textBox4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;

    }
}