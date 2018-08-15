namespace EstateManager.UI {
    partial class NameChanger {
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point( 109, 15 );
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size( 185, 20 );
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 23, 18 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 80, 13 );
            this.label1.TabIndex = 1;
            this.label1.Text = "Nuevo nombre:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 28, 3 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 75, 23 );
            this.button1.TabIndex = 2;
            this.button1.Text = "&Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point( 219, 3 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 75, 23 );
            this.button2.TabIndex = 3;
            this.button2.Text = "&Descartar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler( this.button2_Click );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.button1 );
            this.panel1.Controls.Add( this.button2 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 0, 45 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 319, 29 );
            this.panel1.TabIndex = 4;
            // 
            // UICambioNombre
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size( 319, 74 );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.textBox1 );
            this.Name = "UICambioNombre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UICambioNombre";
            this.TopMost = true;
            this.panel1.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
    }
}