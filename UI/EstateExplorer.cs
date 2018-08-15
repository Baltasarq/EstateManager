// gF (c) Baltasar 2005-18 MIT License <baltasarq@gmail.com>

using System;
using System.Windows.Forms;

using EstateManager.Core;

namespace EstateManager.UI {
	/// <summary>
	/// Esta clase es la interfaz necesaria para explorar los datos de una finca.
	/// </summary>
	public class EstateExplorer : Explorer, Observer
	{
        public const string EtqFinca = "Finca";
        public const string EtqUrbana = "urbana";

        public EstateExplorer(Estate f, Control owner)
            :base( owner )
        {
            this.RealEstate = f;
            f.InsertObserver( this );
            
            this.Build();
            this.MinimumSize = new System.Drawing.Size( Width, Height );
            this.mustUpdate = true;
            this.Update( DateTime.Now, Observable.NotificationType.Update );
        }
        		
		public void OnStopObserving()
		{
			mustUpdate = false;
            MainForm.mainForm.Db.Save();
			this.RealEstate.EliminateObserver( this );

            // Actualizar las observaciones
            AreaTreeNode nodo = (AreaTreeNode)
                MainForm.LocateInTreeView( MainForm.mainForm.EstatesTree, this.RealEstate )
            ;

            if ( nodo != null ) {
                nodo.ToolTipText = this.RealEstate.Remarks;
            }
            
            return;
		}

        /// <summary>
        /// Executed when this control needs updating.
        /// </summary>
        /// <returns>Whether it was updated or not.</returns>
        /// <param name="updateTime">Update time.</param>
        /// <param name="tn">The type of the notification</param>
		public bool Update(DateTime updateTime, Observable.NotificationType tn)
		{
			bool toret = false;
			int posCursor; // No modificar pos de cursor en obs

			if ( tn == Observable.NotificationType.Eliminate
			  && mustUpdate )
			{
				this.OnStopObserving();
				this.Hide();
				toret = true;
			}

			if ( mustUpdate
			  && updateTime != lastUpdate )
			{
				// Let's update
				toret = true;
				mustUpdate = false;
				lastUpdate = updateTime;

				// Basic data
				Text = this.RealEstate.Name
					+ @" - "
					+ EtqFinca
					+ ( this.RealEstate.IsUrban ? ( @" " + EtqUrbana ) : "" )
				;

				textBox1.Text = this.RealEstate.Id;
				textBox2.Text = this.RealEstate.Name;
				textBox3.Text = this.RealEstate.Extension.ToString( textBox3.Mask );
                superfmc.Text = Estate.cnvtHaMc( this.RealEstate.Extension )
                                    .ToString( superfmc.Mask )
                ;

                // Is it urban?
                UpdateIsUrban( this.RealEstate.IsUrban );

				// Post address
				if ( this.RealEstate.getDireccion() != null ) {
					textBox6.Text = this.RealEstate.getDireccion().Street;
					textBox7.Text = this.RealEstate.getDireccion().City;
					textBox8.Text = this.RealEstate.getDireccion().Province;
					textBox9.Text = this.RealEstate.getDireccion().StreetNumber.ToString( textBox9.Mask );
					textBox10.Text = this.RealEstate.getDireccion().Floor.ToString( textBox10.Mask );
                    textBox12.Text = this.RealEstate.getDireccion().Door;
					textBox11.Text = this.RealEstate.getDireccion().PostalCode.ToString( textBox11.Mask );
				}
				else {
					textBox6.Text = "";
					textBox7.Text = "";
					textBox8.Text = "";
					textBox9.Text = "";
					textBox10.Text = "";
					textBox12.Text = "";
					textBox11.Text = "";
				}

                // Referencia catastral
                textBox14.Text = this.RealEstate.RefCatastral;

                // Value
                lblValue.Text = this.RealEstate.Valor.ToString( lblValue.Mask );
                if ( this.RealEstate.Extension != 0 )
                    textBox15.Text =
                        Convert.ToString(
                            this.RealEstate.Valor / Estate.cnvtHaMc( this.RealEstate.Extension ) );
                else textBox15.Text = "0";

				// Was sold?
				textBox5.Text = this.RealEstate.getNombreDeComprador();
				textBox4.Text = this.RealEstate.getPrecioDeVenta().ToString( textBox4.Mask );

				// Remarks
				posCursor = richTextBox1.SelectionStart;
				richTextBox1.Text = this.RealEstate.Remarks;
				richTextBox1.SelectionStart = posCursor;
				richTextBox1.SelectionLength = 0;
				richTextBox1.ScrollToCaret();

				// Update from now on
				mustUpdate = true;
			}

			return toret;
		}

        void UpdateIsUrban(bool isUrban)
        {
            this.chkIsUrban.Checked = isUrban;
            
            if ( isUrban ) {
                chkIsUrban.Text = "Es urbana";
            } else {
                chkIsUrban.Text = "No es urbana";
            }
            
            return;
        }
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		 void Build()
        {
            this.textBox2 = new TextBox();
            this.textBox1 = new TextBox();
            this.lblArea = new Label();
            this.tabPage2 = new TabPage();
            this.chkIsUrban = new CheckBox();
            this.lblIsUrban = new Label();
            this.textBox14 = new TextBox();
            this.lblValue = new MaskedTextBox();
            this.label13 = new Label();
            this.grpWasSold = new GroupBox();
            this.textBox4 = new MaskedTextBox();
            this.lblPrice = new Label();
            this.lblSoldTo = new Label();
            this.textBox5 = new TextBox();
            this.lblCatastralRef = new Label();
            this.tabPage3 = new TabPage();
            this.richTextBox1 = new RichTextBox();
            this.lblName = new Label();
            this.tabPage1 = new TabPage();
            this.btChange = new Button();
            this.panel1 = new Panel();
            this.lnkEstatePhoto = new LinkLabel();
            this.lnkCopyCatastralReference = new LinkLabel();
            this.lnkPhotoZone = new LinkLabel();
            this.lnkPlace = new LinkLabel();
            this.lblHa = new Label();
            this.superfmc = new MaskedTextBox();
            this.lblExtension = new Label();
            this.textBox3 = new MaskedTextBox();
            this.lblId = new Label();
            this.tabControl1 = new TabControl();
            this.tabPage4 = new TabPage();
            this.textBox11 = new MaskedTextBox();
            this.textBox10 = new MaskedTextBox();
            this.textBox9 = new MaskedTextBox();
            this.lblPostCode = new Label();
            this.lblDoor = new Label();
            this.textBox12 = new TextBox();
            this.lblFloor = new Label();
            this.lblStreetNumber = new Label();
            this.lblProvince = new Label();
            this.textBox8 = new TextBox();
            this.lblCity = new Label();
            this.textBox7 = new TextBox();
            this.lblStreet = new Label();
            this.textBox6 = new TextBox();
            this.lblPricePerSquareMeter = new Label();
            this.textBox15 = new TextBox();
            this.tabPage2.SuspendLayout();
            this.grpWasSold.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point( 61, 40 );
            this.textBox2.Name = "textBox2";
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "textBox2";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point( 61, 8 );
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler( this.OnTextBox1Changed );
            // 
            // label5
            // 
            this.lblArea.Location = new System.Drawing.Point( 8, 71 );
            this.lblArea.Name = "lblArea";
            this.lblArea.TabIndex = 6;
            this.lblArea.Text = "Superficie";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add( this.textBox15 );
            this.tabPage2.Controls.Add( this.lblPricePerSquareMeter );
            this.tabPage2.Controls.Add( this.chkIsUrban );
            this.tabPage2.Controls.Add( this.lblIsUrban );
            this.tabPage2.Controls.Add( this.textBox14 );
            this.tabPage2.Controls.Add( this.lblValue );
            this.tabPage2.Controls.Add( this.label13 );
            this.tabPage2.Controls.Add( this.grpWasSold );
            this.tabPage2.Controls.Add( this.lblCatastralRef );
            this.tabPage2.ForeColor = System.Drawing.Color.Green;
            this.tabPage2.Location = new System.Drawing.Point( 4, 25 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datos fiscales";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.chkIsUrban.AutoSize = true;
            this.chkIsUrban.Location = new System.Drawing.Point( 107, 78 );
            this.chkIsUrban.Name = "chkIsUrban";
            this.chkIsUrban.Size = new System.Drawing.Size( 98, 21 );
            this.chkIsUrban.TabIndex = 29;
            this.chkIsUrban.Text = "Urbana";
            this.chkIsUrban.UseVisualStyleBackColor = true;
            this.chkIsUrban.Click += new System.EventHandler( this.OnCheckBox1Click );
            // 
            // label17
            // 
            this.lblIsUrban.Location = new System.Drawing.Point( 10, 80 );
            this.lblIsUrban.Name = "lblIsUrban";
            this.lblIsUrban.Size = new System.Drawing.Size( 91, 19 );
            this.lblIsUrban.TabIndex = 28;
            this.lblIsUrban.Text = "Urbana";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point( 129, 45 );
            this.textBox14.Name = "textBox14";
            this.textBox14.TabIndex = 27;
            this.textBox14.Text = "textBox14";
            this.textBox14.TextChanged += new System.EventHandler( this.OnTextBox14Changed );
            // 
            // textBox13
            // 
            this.lblValue.Location = new System.Drawing.Point( 88, 7 );
            this.lblValue.Mask = "0000000000.00";
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size( 109, 22 );
            this.lblValue.TabIndex = 25;
            this.lblValue.MaskInputRejected += new MaskInputRejectedEventHandler( this.OnTextBox4MaskInputRejected );
            this.lblValue.TextChanged += new System.EventHandler( this.OnTextBox13Changed );
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point( 10, 10 );
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size( 72, 16 );
            this.label13.TabIndex = 14;
            this.label13.Text = "Valor";
            // 
            // groupBox1
            // 
            this.grpWasSold.Controls.Add( this.textBox4 );
            this.grpWasSold.Controls.Add( this.lblPrice );
            this.grpWasSold.Controls.Add( this.lblSoldTo );
            this.grpWasSold.Controls.Add( this.textBox5 );
            this.grpWasSold.Dock = DockStyle.Bottom;
            this.grpWasSold.ForeColor = System.Drawing.SystemColors.Desktop;
            this.grpWasSold.Name = "grpWasSold";
            this.grpWasSold.TabIndex = 5;
            this.grpWasSold.TabStop = false;
            this.grpWasSold.Text = "Si fue vendido ...";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point( 88, 65 );
            this.textBox4.Mask = "0000000000.00";
            this.textBox4.Name = "textBox4";
            this.textBox4.TabIndex = 26;
            this.textBox4.MaskInputRejected += new MaskInputRejectedEventHandler( this.OnTextBox4MaskInputRejected );
            this.textBox4.TextChanged += new System.EventHandler( this.OnTextBox4Changed );
            // 
            // label2
            // 
            this.lblPrice.Location = new System.Drawing.Point( 10, 69 );
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.TabIndex = 13;
            this.lblPrice.Text = "Cantidad:";
            // 
            // label1
            // 
            this.lblSoldTo.Location = new System.Drawing.Point( 10, 28 );
            this.lblSoldTo.Name = "lblSoldTo";
            this.lblSoldTo.TabIndex = 12;
            this.lblSoldTo.Text = "Vendido a:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point( 88, 24 );
            this.textBox5.Name = "textBox5";
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "textBox5";
            this.textBox5.TextChanged += new System.EventHandler( this.OnTextBox5Changed );
            // 
            // label16
            // 
            this.lblCatastralRef.Location = new System.Drawing.Point( 10, 45 );
            this.lblCatastralRef.Name = "lblCatastralRef";
            this.lblCatastralRef.TabIndex = 26;
            this.lblCatastralRef.Text = "Ref. Catastral";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add( this.richTextBox1 );
            this.tabPage3.Location = new System.Drawing.Point( 4, 25 );
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Observaciones";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point( 0, 0 );
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler( this.OnRemaksChanged );
            // 
            // label4
            // 
            this.lblName.Location = new System.Drawing.Point( 8, 43 );
            this.lblName.Name = "label4";
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Nombre:";
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add( this.btChange );
            this.tabPage1.Controls.Add( this.panel1 );
            this.tabPage1.Controls.Add( this.lblHa );
            this.tabPage1.Controls.Add( this.superfmc );
            this.tabPage1.Controls.Add( this.lblExtension );
            this.tabPage1.Controls.Add( this.textBox3 );
            this.tabPage1.Controls.Add( this.lblArea );
            this.tabPage1.Controls.Add( this.lblName );
            this.tabPage1.Controls.Add( this.lblId );
            this.tabPage1.Controls.Add( this.textBox2 );
            this.tabPage1.Controls.Add( this.textBox1 );
            this.tabPage1.ForeColor = System.Drawing.Color.Green;
            this.tabPage1.Location = new System.Drawing.Point( 4, 25 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos f¨ªsicos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.btChange.Location = new System.Drawing.Point( 275, 39 );
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size( 75, 23 );
            this.btChange.TabIndex = 33;
            this.btChange.Text = "&Cambiar";
            this.btChange.UseVisualStyleBackColor = true;
            this.btChange.Click += new System.EventHandler( this.OnButton1Click );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.lnkEstatePhoto );
            this.panel1.Controls.Add( this.lnkCopyCatastralReference );
            this.panel1.Controls.Add( this.lnkPhotoZone );
            this.panel1.Controls.Add( this.lnkPlace );
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 0, 109 );
            this.panel1.Name = "panel1";
            this.panel1.TabIndex = 32;
            // 
            // linkLabel2
            // 
            this.lnkEstatePhoto.AutoSize = true;
            this.lnkEstatePhoto.Location = new System.Drawing.Point( 45, 31 );
            this.lnkEstatePhoto.Name = "lnkEstatePhoto";
            this.lnkEstatePhoto.TabIndex = 22;
            this.lnkEstatePhoto.TabStop = true;
            this.lnkEstatePhoto.Text = "Foto de la finca";
            this.lnkEstatePhoto.LinkClicked += new LinkLabelLinkClickedEventHandler( this.OnLinkLabel2Clicked );
            // 
            // linkLabel4
            // 
            this.lnkCopyCatastralReference.AutoSize = true;
            this.lnkCopyCatastralReference.Location = new System.Drawing.Point( 45, 57 );
            this.lnkCopyCatastralReference.Name = "lnkCopyCatastralReference";
            this.lnkCopyCatastralReference.TabIndex = 31;
            this.lnkCopyCatastralReference.TabStop = true;
            this.lnkCopyCatastralReference.Text = "Copiar la referencia catastral al portapapeles";
            this.lnkCopyCatastralReference.LinkClicked += new LinkLabelLinkClickedEventHandler( this.OnLinkLabel4Clicked );
            // 
            // linkLabel1
            // 
            this.lnkPhotoZone.AutoSize = true;
            this.lnkPhotoZone.Location = new System.Drawing.Point( 234, 31 );
            this.lnkPhotoZone.Name = "lnkPhotoZone";
            this.lnkPhotoZone.TabIndex = 21;
            this.lnkPhotoZone.TabStop = true;
            this.lnkPhotoZone.Text = "Foto de Zona";
            this.lnkPhotoZone.LinkClicked += new LinkLabelLinkClickedEventHandler( this.OnLinkLabel1Clicked );
            // 
            // linkLabel3
            // 
            this.lnkPlace.AutoSize = true;
            this.lnkPlace.Location = new System.Drawing.Point( 148, 31 );
            this.lnkPlace.Name = "lnkPlace";
            this.lnkPlace.TabIndex = 23;
            this.lnkPlace.TabStop = true;
            this.lnkPlace.Text = "Info de lugar";
            this.lnkPlace.LinkClicked += new LinkLabelLinkClickedEventHandler( this.OnLinkLabel3Clicked );
            // 
            // label15
            // 
            this.lblHa.AutoSize = true;
            this.lblHa.Location = new System.Drawing.Point( 150, 71 );
            this.lblHa.Name = "lblHa";
            this.lblHa.TabIndex = 30;
            this.lblHa.Text = "ha.";
            // 
            // superfmc
            // 
            this.superfmc.Location = new System.Drawing.Point( 225, 68 );
            this.superfmc.Mask = "0000000000.00";
            this.superfmc.Name = "superfmc";
            this.superfmc.TabIndex = 29;
            this.superfmc.MaskInputRejected += new MaskInputRejectedEventHandler( this.OnTextBox4MaskInputRejected );
            this.superfmc.TextChanged += new System.EventHandler( this.OnExtensionChanged );
            // 
            // label14
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point( 316, 71 );
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.TabIndex = 27;
            this.lblExtension.Text = "m.c.";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point( 61, 68 );
            this.textBox3.Mask = "0000000.00000";
            this.textBox3.Name = "textBox3";
            this.textBox3.TabIndex = 26;
            this.textBox3.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler( this.OnTextBox4MaskInputRejected );
            this.textBox3.TextChanged += new System.EventHandler( this.OnTextBox3Changed );
            // 
            // label3
            // 
            this.lblId.Location = new System.Drawing.Point( 8, 11 );
            this.lblId.Name = "lblId";
            this.lblId.TabIndex = 4;
            this.lblId.Text = "ID:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage4 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Controls.Add( this.tabPage3 );
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add( this.textBox11 );
            this.tabPage4.Controls.Add( this.textBox10 );
            this.tabPage4.Controls.Add( this.textBox9 );
            this.tabPage4.Controls.Add( this.lblPostCode );
            this.tabPage4.Controls.Add( this.lblDoor );
            this.tabPage4.Controls.Add( this.textBox12 );
            this.tabPage4.Controls.Add( this.lblFloor );
            this.tabPage4.Controls.Add( this.lblStreetNumber );
            this.tabPage4.Controls.Add( this.lblProvince );
            this.tabPage4.Controls.Add( this.textBox8 );
            this.tabPage4.Controls.Add( this.lblCity );
            this.tabPage4.Controls.Add( this.textBox7 );
            this.tabPage4.Controls.Add( this.lblStreet );
            this.tabPage4.Controls.Add( this.textBox6 );
            this.tabPage4.ForeColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 0 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 0 ) ) ) ) );
            this.tabPage4.Location = new System.Drawing.Point( 4, 25 );
            this.tabPage4.Name = "address";
            this.tabPage4.Padding = new Padding( 3 );
            this.tabPage4.Size = new System.Drawing.Size( 358, 209 );
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Direcci¨®n";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point( 306, 148 );
            this.textBox11.Mask = "0000000";
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size( 44, 22 );
            this.textBox11.TabIndex = 41;
            this.textBox11.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.textBox11.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler( this.OnTextBox4MaskInputRejected );
            this.textBox11.TextChanged += new System.EventHandler( this.OnTextBox11Changed );
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point( 306, 114 );
            this.textBox10.Mask = "000000";
            this.textBox10.Name = "textBox10";
            this.textBox10.TabIndex = 40;
            this.textBox10.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.textBox10.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler( this.OnTextBox4MaskInputRejected );
            this.textBox10.TextChanged += new System.EventHandler( this.OnTextBox10Changed );
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point( 86, 116 );
            this.textBox9.Mask = "000000";
            this.textBox9.Name = "textBox9";
            this.textBox9.TabIndex = 39;
            this.textBox9.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            this.textBox9.MaskInputRejected += new MaskInputRejectedEventHandler( this.OnTextBox4MaskInputRejected );
            this.textBox9.TextChanged += new System.EventHandler( this.OnTextBox9Changed );
            // 
            // label11
            // 
            this.lblPostCode.ForeColor = System.Drawing.Color.Green;
            this.lblPostCode.Location = new System.Drawing.Point( 218, 152 );
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.TabIndex = 38;
            this.lblPostCode.Text = "Cod. Postal";
            // 
            // label12
            // 
            this.lblDoor.ForeColor = System.Drawing.Color.Green;
            this.lblDoor.Location = new System.Drawing.Point( 8, 154 );
            this.lblDoor.Name = "lblDoor";
            this.lblDoor.Size = new System.Drawing.Size( 72, 16 );
            this.lblDoor.TabIndex = 37;
            this.lblDoor.Text = "Puerta";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point( 86, 150 );
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size( 44, 22 );
            this.textBox12.TabIndex = 36;
            this.textBox12.TextChanged += new System.EventHandler( this.OnTextBox12Changed );
            // 
            // label10
            // 
            this.lblFloor.ForeColor = System.Drawing.Color.Green;
            this.lblFloor.Location = new System.Drawing.Point( 253, 118 );
            this.lblFloor.Name = "label10";
            this.lblFloor.Size = new System.Drawing.Size( 47, 16 );
            this.lblFloor.TabIndex = 35;
            this.lblFloor.Text = "Piso";
            // 
            // label9
            // 
            this.lblStreetNumber.ForeColor = System.Drawing.Color.Green;
            this.lblStreetNumber.Location = new System.Drawing.Point( 8, 120 );
            this.lblStreetNumber.Name = "lblStreetNumber";
            this.lblStreetNumber.TabIndex = 34;
            this.lblStreetNumber.Text = "Num.";
            // 
            // label8
            // 
            this.lblProvince.ForeColor = System.Drawing.Color.Green;
            this.lblProvince.Location = new System.Drawing.Point( 8, 86 );
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size( 72, 16 );
            this.lblProvince.TabIndex = 33;
            this.lblProvince.Text = "Provincia";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point( 86, 82 );
            this.textBox8.Name = "textBox8";
            this.textBox8.TabIndex = 32;
            this.textBox8.TextChanged += new System.EventHandler( this.OnTextBox8Changed );
            // 
            // label7
            // 
            this.lblCity.ForeColor = System.Drawing.Color.Green;
            this.lblCity.Location = new System.Drawing.Point( 8, 50 );
            this.lblCity.Name = "lblCity";
            this.lblCity.TabIndex = 31;
            this.lblCity.Text = "Ciudad";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point( 86, 46 );
            this.textBox7.Name = "textBox7";
            this.textBox7.TabIndex = 30;
            this.textBox7.TextChanged += new System.EventHandler( this.OnTextBox7Changed );
            // 
            // label6
            // 
            this.lblStreet.ForeColor = System.Drawing.Color.Green;
            this.lblStreet.Location = new System.Drawing.Point( 8, 15 );
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.TabIndex = 29;
            this.lblStreet.Text = "Calle";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point( 86, 11 );
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size( 264, 22 );
            this.textBox6.TabIndex = 28;
            this.textBox6.TextChanged += new System.EventHandler( this.OnTextBox6Changed );
            // 
            // label18
            // 
            this.lblPricePerSquareMeter.Location = new System.Drawing.Point( 203, 10 );
            this.lblPricePerSquareMeter.Name = "lblPricePerSquareMeter";
            this.lblPricePerSquareMeter.TabIndex = 30;
            this.lblPricePerSquareMeter.Text = "euros/m.c.";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point( 274, 7 );
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.TabIndex = 31;
            this.textBox15.Text = "textBox15";
            // 
            // UIFinca
            // 
            this.AutoScroll = true;
            this.Dock = DockStyle.Fill;
            this.Controls.Add( this.tabControl1 );
            this.Name = "UIFinca";
            this.Text = "Datos de la finca";
            this.tabPage2.ResumeLayout( true );
            this.grpWasSold.ResumeLayout( true );
            this.tabPage3.ResumeLayout( true );
            this.tabPage1.ResumeLayout( true );
            this.panel1.ResumeLayout( true );
            this.tabControl1.ResumeLayout( true );
            this.tabPage4.ResumeLayout( true );
            this.ResumeLayout( true );

		}
		#endregion

        void OnChanged()
        {
            MainForm.mainForm.Db.Update();
        }
        
        void OnTextBox8Changed(object sender, EventArgs e)
		{
			if ( mustUpdate ) {
				this.RealEstate.creaDireccionEnBlanco();
				this.RealEstate.getDireccion().Province = textBox8.Text;
                this.OnChanged();
			}
		}

		 void OnTextBox7Changed(object sender, EventArgs e)
		{
			if ( mustUpdate ) {
				this.RealEstate.creaDireccionEnBlanco();
				this.RealEstate.getDireccion().City = textBox7.Text;
                this.OnChanged();
			}
		}

		void OnTextBox6Changed(object sender, EventArgs e)
		{
			if ( mustUpdate ) {
				this.RealEstate.creaDireccionEnBlanco();
				this.RealEstate.getDireccion().Street = textBox6.Text;
                this.OnChanged();
			}
		}

		void OnTextBox3Changed(object sender, EventArgs e)
		{
            double valor;

			if ( mustUpdate ) {
                valor = textBox3.Text.DoubleFromString();
				this.RealEstate.Extension = valor;
                mustUpdate = false;
                superfmc.Text = Estate.cnvtHaMc( valor ).ToString( superfmc.Mask );
                mustUpdate = true;
                this.OnChanged();
			}
		}

        void OnExtensionChanged(object sender, EventArgs e)
        {
            double valor;

            if (mustUpdate) {
                valor = Estate.cnvtMcHa( superfmc.Text.DoubleFromString() );
                this.RealEstate.Extension = valor;
                mustUpdate = false;
                textBox3.Text = valor.ToString( textBox3.Mask );
                mustUpdate = true;
                this.OnChanged();
            }
        }

		void OnTextBox1Changed(object sender, EventArgs e)
		{
			if ( mustUpdate ) {
				this.RealEstate.Id = textBox1.Text;
                this.OnChanged();
			}
		}

		void OnTextBox9Changed(object sender, EventArgs e)
		{
			if ( mustUpdate ) {
				this.RealEstate.creaDireccionEnBlanco();
                this.RealEstate.getDireccion().StreetNumber = textBox9.Text.IntFromString();
                this.OnChanged();
			}
		}

		void OnTextBox10Changed(object sender, EventArgs e)
		{
			if ( mustUpdate ) {
				this.RealEstate.creaDireccionEnBlanco();
                this.RealEstate.getDireccion().Floor = textBox10.Text.IntFromString();
                this.OnChanged();
			}
		}

        void OnTextBox11Changed(object sender, EventArgs e)
        {
            if (mustUpdate) {
                this.RealEstate.creaDireccionEnBlanco();
                this.RealEstate.getDireccion().PostalCode = textBox11.Text.IntFromString();
                this.OnChanged();
            }
        }

		void OnTextBox12Changed(object sender, EventArgs e)
		{
			if ( mustUpdate ) {
				this.RealEstate.creaDireccionEnBlanco();
				this.RealEstate.getDireccion().Door = textBox12.Text;
                this.OnChanged();
			}
		}

		void OnTextBox13Changed(object sender, EventArgs e)
		{
			if ( mustUpdate ) {
				this.RealEstate.Valor = lblValue.Text.DoubleFromString();
                this.OnChanged();
			}
		}

		void OnTextBox5Changed(object sender, EventArgs e)
		{
			if ( mustUpdate ) {
				this.RealEstate.fueVendido( textBox5.Text, this.RealEstate.getPrecioDeVenta() );
                this.OnChanged();
			}
		}

		void OnTextBox4Changed(object sender, EventArgs e)
		{
            double valor;

			if ( mustUpdate ) {
                valor = textBox4.Text.DoubleFromString();
                this.RealEstate.fueVendido( this.RealEstate.getNombreDeComprador(), valor );
                this.OnChanged();
			}
		}

         void OnTextBox4MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        /**
         * Cuando el usuario pulsa una letra o no tiene el insertar desactivado.
         */
        {
            ShowHelpHowToUseMask();
        }

		void OnRemaksChanged(object sender, EventArgs e)
		{
			if ( mustUpdate ) {
				this.RealEstate.Remarks = richTextBox1.Text;
                this.OnChanged();
			}
		}

		void OnLinkLabel2Clicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ImageViewer visor = new ImageViewer(
                                        this.RealEstate.getNombreImagenFinca(),
                                        this.RealEstate,
                                        this.Owner );
			visor.Show();
		}

		void OnLinkLabel1Clicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ImageViewer visor = new ImageViewer(
                                         this.RealEstate.getNombreImagenZona(),
                                         this.RealEstate,
                                         this.Owner );
			visor.Show();
		}

		void OnLinkLabel3Clicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			PlaceExplorer uil = new PlaceExplorer( 
						this.RealEstate.Parent,
						MainForm.mainForm.Db,
						this.Owner
			);

			uil.Show();
		}

        public static void ShowHelpHowToUseMask()
        {
            MessageBox.Show(
                "Pulse \"Insertar\" para modificar el campo. Solo se permiten d¨ªgitos.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

        }

         void OnTextBox14Changed(object sender, EventArgs e)
        {
            if ( mustUpdate ) {
                this.RealEstate.RefCatastral = textBox14.Text;
                this.OnChanged();
            }
            
            return;
        }

         void OnLinkLabel4Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText( this.RealEstate.RefCatastral );

            MessageBox.Show(
                        "La referencia catastral ha sido copiada "
                        + "al portapapeles",
                        About.name,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
            );
        }

         void OnCheckBox1Click(object sender, EventArgs e)
        {
            if ( mustUpdate ) {
                this.RealEstate.IsUrban = !this.RealEstate.IsUrban;
                this.UpdateIsUrban( this.RealEstate.IsUrban );
                this.OnChanged();
            }
            
            return;
        }

         void OnButton1Click(object sender, EventArgs e)
        {
            string nuevoNombre = MainForm.LaunchNameChangeFor( this.RealEstate );

            // Asignar el nuevo nombre si se ha elegido uno
            if ( nuevoNombre != null ) {
                this.RealEstate.Name = nuevoNombre;
            }
            
            return;
        }
        
        public Estate RealEstate { 
            get;  set;
        }
        
        bool mustUpdate;
     
        DateTime lastUpdate;
        LinkLabel lnkEstatePhoto;
        LinkLabel lnkPhotoZone;
        LinkLabel lnkPlace;
        MaskedTextBox lblValue;
        MaskedTextBox textBox4;
        MaskedTextBox textBox3;
        TabPage tabPage4;
        MaskedTextBox textBox11;
        MaskedTextBox textBox10;
        MaskedTextBox textBox9;
        Label lblPostCode;
        Label lblDoor;
        TextBox textBox12;
        Label lblFloor;
        Label lblStreetNumber;
        Label lblProvince;
        TextBox textBox8;
        Label lblCity;
        TextBox textBox7;
        Label lblStreet;
        TextBox textBox6;
        Label lblExtension;
        Label lblHa;
        MaskedTextBox superfmc;
        Label lblCatastralRef;
        TextBox textBox14;
        LinkLabel lnkCopyCatastralReference;
        Label lblIsUrban;
        CheckBox chkIsUrban;
        Panel panel1;
        Button btChange;
        Label lblPricePerSquareMeter;
        TextBox textBox15;
        Label lblId;
        TabControl tabControl1;
        RichTextBox richTextBox1;
        TabPage tabPage1;
        Label lblName;
        TabPage tabPage3;
        TabPage tabPage2;
        Label lblArea;
        TextBox textBox1;
        TextBox textBox2;
        Label label13;
        GroupBox grpWasSold;
        Label lblPrice;
        Label lblSoldTo;
        TextBox textBox5;
    }
}
