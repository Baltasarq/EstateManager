namespace EstateManager.UI {
    partial class ChangeRemarks {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.edRemarks = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel.Controls.Add( this.btCancel );
            this.panel.Controls.Add( this.btSave );
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point( 0, 224 );
            this.panel.Name = "panel1";
            this.panel.Size = new System.Drawing.Size( 292, 42 );
            this.panel.TabIndex = 0;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point( 12, 7 );
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size( 75, 23 );
            this.btSave.TabIndex = 0;
            this.btSave.Text = "&Guardar";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler( this.OnBtSaveClicked );
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point( 93, 7 );
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "&Descartar";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler( this.OnBtCancelClicked );
            // 
            // edRemarks
            // 
            this.edRemarks.AcceptsReturn = true;
            this.edRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edRemarks.Location = new System.Drawing.Point( 0, 0 );
            this.edRemarks.Multiline = true;
            this.edRemarks.Name = "textBox1";
            this.edRemarks.Size = new System.Drawing.Size( 292, 224 );
            this.edRemarks.TabIndex = 1;

            this.AcceptButton = this.btSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size( 292, 266 );
            this.Controls.Add( this.edRemarks );
            this.Controls.Add( this.panel );
            this.Name = "UIModificaObs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UIModificaObs";
            this.panel.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox edRemarks;
    }
}