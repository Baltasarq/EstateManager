// gF (c) Baltasar 2005-18 MIT License <baltasarq@gmail.com>

namespace EstateManager.UI {
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    public partial class MainForm {
        void Build()
        {
            this.BuildIcons();
            this.Init();
            this.SuspendLayout();

            this.BuildMenuStrip();
            this.BuildImageList();
            this.BuildToolbar();
            this.BuildPanel();
            this.BuildExplorerContainer();
            this.BuildStatesTree();
            this.BuildAreasContextMenu();
            this.BuildStatesContextMenu();
            this.BuildFileSystemBrowsers();
            
            this.SplitContainer = new SplitContainer { Dock = DockStyle.Fill };
            
            this.Controls.Add( this.SplitContainer );
            this.Controls.Add( this.statusStrip );
            this.Controls.Add( this.menuStrip );
            
            this.SplitContainer.Panel1.Controls.Add( this.panel );
            this.SplitContainer.Panel2.Controls.Add( this.ExplorerContainer );
            
            this.ClientSize = new Size( 615, 440 );
            this.Icon = Icon.FromHandle( this.bmpAppIcon.GetHicon() );
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new Size( 320, 200 );
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestor de Fincas";
            this.FormClosed += new FormClosedEventHandler( this.OnClosed );
            this.Resize += new EventHandler( this.MainFormResize );
            this.Load += new EventHandler( this.MainFormLoad );

            ( ( System.ComponentModel.ISupportInitialize ) ( this.imageViewer ) ).EndInit();
            this.ResumeLayout( true );
            this.PerformLayout();
        }
        
        void Init()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarcomoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lugarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fincaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelDeFincasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visorFotosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarDatosparaCdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.panel = new System.Windows.Forms.Panel();
            this.EstatesTree = new System.Windows.Forms.TreeView();
            this.stateContextMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.expandCollapseStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lugarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fincaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colapsarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarnombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarPadreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocultarVisorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageList = new System.Windows.Forms.ImageList( this.components );
            this.imageViewer = new System.Windows.Forms.PictureBox();
            this.areaContextMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.ocultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ampliarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandirTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ( ( System.ComponentModel.ISupportInitialize ) ( this.imageViewer ) ).BeginInit();
        }
        
        void BuildIcons()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            
            try {
                this.bmpAppIcon = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.gf32.ico" ) );
                this.bmpState = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.finca.png" ) );
                this.bmpUrbanState = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.urbana.png" ) );
                this.bmpVcrRew = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.vcrrewnd.png" ) );
                this.bmpArea = new Bitmap(
                    asm.GetManifestResourceStream( "EstateManager.Res.lugar.png" ) );
            } catch(Exception e) {
                Debug.WriteLine( "ERROR loading icons: " + e.Message);
            }

            return;
        }
        
        void BuildMenuStrip()
        {
            this.menuStrip.SuspendLayout();
            this.menuStrip.Items.AddRange(
                new ToolStripItem[] {
                    this.archivoToolStripMenuItem,
                    this.editarToolStripMenuItem,
                    this.toolStripMenuItem4,
                    this.herramientasToolStripMenuItem,
                    this.ayudaToolStripMenuItem1 });

            this.menuStrip.Dock = DockStyle.Top;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size( 617, 24 );
            this.menuStrip.TabIndex = 0;
            this.menuStrip.ResumeLayout( true );
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.guardarcomoToolStripMenuItem,
            this.salirToolStripMenuItem} );
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new Size( 55, 20 );
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // guardarcomoToolStripMenuItem
            // 
            this.guardarcomoToolStripMenuItem.Name = "guardarcomoToolStripMenuItem";
            this.guardarcomoToolStripMenuItem.Size = new Size( 167, 22 );
            this.guardarcomoToolStripMenuItem.Text = "&Guardar como ...";
            this.guardarcomoToolStripMenuItem.Click += new EventHandler( this.SaveAsToolStripMenuItem_Click );
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeyDisplayString = "Ctr+F4";
            this.salirToolStripMenuItem.Size = new Size( 167, 22 );
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new EventHandler( this.ExitToolStripMenuItemClick );
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripSeparator1,
            this.copiarToolStripMenuItem} );
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new Size( 47, 20 );
            this.editarToolStripMenuItem.Text = "&Editar";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.lugarToolStripMenuItem,
            this.fincaToolStripMenuItem} );
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size( 308, 22 );
            this.toolStripMenuItem2.Text = "&Insertar";
            this.toolStripMenuItem2.Click += new EventHandler( this.DeleterToolStripMenuItem_Click );
            // 
            // lugarToolStripMenuItem
            // 
            this.lugarToolStripMenuItem.Image = this.bmpArea;
            this.lugarToolStripMenuItem.Name = "lugarToolStripMenuItem";
            this.lugarToolStripMenuItem.Size = new Size( 112, 22 );
            this.lugarToolStripMenuItem.Text = "&Lugar";
            this.lugarToolStripMenuItem.Click += new EventHandler( this.ZoneCreatorToolStripMenuItem_Click );
            // 
            // fincaToolStripMenuItem
            // 
            this.fincaToolStripMenuItem.Image = this.bmpState;
            this.fincaToolStripMenuItem.Name = "fincaToolStripMenuItem";
            this.fincaToolStripMenuItem.Size = new Size( 112, 22 );
            this.fincaToolStripMenuItem.Text = "&Finca";
            this.fincaToolStripMenuItem.Click += new EventHandler( this.EstateToolStripMenuItem_Click );
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new Size( 308, 22 );
            this.toolStripMenuItem3.Text = "&Eliminar";
            this.toolStripMenuItem3.Click += new EventHandler( this.DeleterToolStripMenuItem_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size( 305, 6 );
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new Size( 308, 22 );
            this.copiarToolStripMenuItem.Text = "&Copiar información del área en el portapapeles";
            this.copiarToolStripMenuItem.Click += new EventHandler( this.CopyToolStripMenuItem_Click );
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.panelDeFincasToolStripMenuItem,
            this.visorFotosToolStripMenuItem} );
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new Size( 35, 20 );
            this.toolStripMenuItem4.Text = "&Ver";
            // 
            // panelDeFincasToolStripMenuItem
            // 
            this.panelDeFincasToolStripMenuItem.Checked = true;
            this.panelDeFincasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.panelDeFincasToolStripMenuItem.Name = "panelDeFincasToolStripMenuItem";
            this.panelDeFincasToolStripMenuItem.Size = new Size( 171, 22 );
            this.panelDeFincasToolStripMenuItem.Text = "&Panel de fincas";
            this.panelDeFincasToolStripMenuItem.Click += new EventHandler( this.ToggleEstatesPanelToolStripMenuItem_Click );
            // 
            // visorDeImágenesToolStripMenuItem
            // 
            this.visorFotosToolStripMenuItem.Checked = true;
            this.visorFotosToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.visorFotosToolStripMenuItem.Name = "visorDeImágenesToolStripMenuItem";
            this.visorFotosToolStripMenuItem.Size = new Size( 171, 22 );
            this.visorFotosToolStripMenuItem.Text = "&Visor de imágenes";
            this.visorFotosToolStripMenuItem.Click += new EventHandler( this.PictureViewerToolStripMenuItem_Click );
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.buscaToolStripMenuItem,
            this.generarDatosparaCdToolStripMenuItem} );
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new Size( 83, 20 );
            this.herramientasToolStripMenuItem.Text = "&Herramientas";
            // 
            // búsquedasToolStripMenuItem
            // 
            this.buscaToolStripMenuItem.Name = "búsquedasToolStripMenuItem";
            this.buscaToolStripMenuItem.ShortcutKeys = ( ( System.Windows.Forms.Keys ) ( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B ) ) );
            this.buscaToolStripMenuItem.Size = new Size( 211, 22 );
            this.buscaToolStripMenuItem.Text = "&Búsquedas ...";
            this.buscaToolStripMenuItem.Click += this.FilterToolStripMenuItem_Click;
            // 
            // generarDatosparaCdToolStripMenuItem
            // 
            this.generarDatosparaCdToolStripMenuItem.Name = "generarDatosparaCdToolStripMenuItem";
            this.generarDatosparaCdToolStripMenuItem.Size = new Size( 211, 22 );
            this.generarDatosparaCdToolStripMenuItem.Text = "&Generar Datos para Cd ...";
            this.generarDatosparaCdToolStripMenuItem.Click += new EventHandler( this.GenerateCDDataToolStripMenuItem_Click );
            // 
            // ayudaToolStripMenuItem1
            // 
            this.ayudaToolStripMenuItem1.DropDownItems.AddRange(
            new ToolStripItem[] {
	            this.helpMenuItem,
	            this.acercadeToolStripMenuItem });
                
            this.ayudaToolStripMenuItem1.Name = "ayudaToolStripMenuItem1";
            this.ayudaToolStripMenuItem1.Size = new Size( 50, 20 );
            this.ayudaToolStripMenuItem1.Text = "Ay&uda";
             // 
            // toolStripMenuItem6
            // 
            this.helpMenuItem.Name = "toolStripMenuItem6";
            this.helpMenuItem.ShortcutKeys = Keys.F1;
            this.helpMenuItem.Size = new Size( 148, 22 );
            this.helpMenuItem.Text = "&Ayuda";
            this.helpMenuItem.Click += new EventHandler( this.HelpStripMenuItem_Click );
            // 
            // acercadeToolStripMenuItem
            // 
            this.acercadeToolStripMenuItem.Name = "acercadeToolStripMenuItem";
            this.acercadeToolStripMenuItem.Size = new Size( 148, 22 );
            this.acercadeToolStripMenuItem.Text = "Acerca &de ...";
            this.acercadeToolStripMenuItem.Click += new EventHandler( this.AboutToolStripMenuItemClick );

            // 
            // insertarToolStripMenuItem
            // 
            this.insertarToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.lugarToolStripMenuItem2,
            this.fincaToolStripMenuItem2} );
            this.insertarToolStripMenuItem.Name = "insertarToolStripMenuItem";
            this.insertarToolStripMenuItem.Size = new Size( 163, 22 );
            this.insertarToolStripMenuItem.Text = "&Insertar";
            // 
            // lugarToolStripMenuItem2
            // 
            this.lugarToolStripMenuItem2.Name = "lugarToolStripMenuItem2";
            this.lugarToolStripMenuItem2.Size = new Size( 127, 22 );
            this.lugarToolStripMenuItem2.Text = "&Lugar ...";
            this.lugarToolStripMenuItem2.Click += new EventHandler( this.ZoneCreatorToolStripMenuItem_Click );
            // 
            // fincaToolStripMenuItem2
            // 
            this.fincaToolStripMenuItem2.Name = "fincaToolStripMenuItem2";
            this.fincaToolStripMenuItem2.Size = new Size( 127, 22 );
            this.fincaToolStripMenuItem2.Text = "&Finca ...";
            this.fincaToolStripMenuItem2.Click += new EventHandler( this.EstateToolStripMenuItem_Click );
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new Size( 163, 22 );
            this.toolStripMenuItem5.Text = "Ex&plorar";
            this.toolStripMenuItem5.Click += new EventHandler( this.ExploreToolStripMenuItem_Click );
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new Size( 163, 22 );
            this.eliminarToolStripMenuItem.Text = "&Eliminar";
            this.eliminarToolStripMenuItem.Click += new EventHandler( this.DeleterToolStripMenuItem_Click );
            // 
            // expandirToolStripMenuItem
            // 
            this.expandirToolStripMenuItem.Name = "expandirToolStripMenuItem";
            this.expandirToolStripMenuItem.Size = new Size( 163, 22 );
            this.expandirToolStripMenuItem.Text = "E&xpandir";
            this.expandirToolStripMenuItem.Click += new EventHandler( this.ExpandTreeViewToolStripMenuItem_Click );
            // 
            // colapsarToolStripMenuItem
            // 
            this.colapsarToolStripMenuItem.Name = "colapsarToolStripMenuItem";
            this.colapsarToolStripMenuItem.Size = new Size( 163, 22 );
            this.colapsarToolStripMenuItem.Text = "&Colapsar";
            this.colapsarToolStripMenuItem.Click += new EventHandler( this.ColapseTreeViewToolStripMenuItem_Click );
            // 
            // cambiarnombreToolStripMenuItem
            // 
            this.cambiarnombreToolStripMenuItem.Name = "cambiarnombreToolStripMenuItem";
            this.cambiarnombreToolStripMenuItem.Size = new Size( 163, 22 );
            this.cambiarnombreToolStripMenuItem.Text = "Cambiar &nombre";
            this.cambiarnombreToolStripMenuItem.Click += new EventHandler( this.RenameStripMenuItem_Click );
            // 
            // cambiarPadreToolStripMenuItem
            // 
            this.cambiarPadreToolStripMenuItem.Name = "cambiarPadreToolStripMenuItem";
            this.cambiarPadreToolStripMenuItem.Size = new Size( 181, 22 );
            this.cambiarPadreToolStripMenuItem.Text = "Cambiar de &lugar ...";
            this.cambiarPadreToolStripMenuItem.Click += new EventHandler( this.ChangeParentToolStripMenuItem_Click );
            // 
            // ocultarPanelToolStripMenuItem
            // 
            this.ocultarPanelToolStripMenuItem.Name = "ocultarPanelToolStripMenuItem";
            this.ocultarPanelToolStripMenuItem.Size = new Size( 187, 22 );
            this.ocultarPanelToolStripMenuItem.Text = "&Ocultar panel";
            this.ocultarPanelToolStripMenuItem.Click += new EventHandler( this.HideEstatesPanel );
            // 
            // ocultarVisorToolStripMenuItem
            // 
            this.ocultarVisorToolStripMenuItem.Name = "ocultarVisorToolStripMenuItem";
            this.ocultarVisorToolStripMenuItem.Size = new Size( 187, 22 );
            this.ocultarVisorToolStripMenuItem.Text = "Ocultar/mostrar &Visor";
            this.ocultarVisorToolStripMenuItem.Click += this.PictureViewerToolStripMenuItem_Click;
            
            // 
            // pictureBox1
            // 
            this.imageViewer.ContextMenuStrip = this.areaContextMenu;
            this.imageViewer.Dock = DockStyle.Bottom;
            this.imageViewer.Location = new Point( 0, 203 );
            this.imageViewer.Name = "pictureBox1";
            this.imageViewer.Size = new Size( 282, 189 );
            this.imageViewer.SizeMode = PictureBoxSizeMode.StretchImage;
            this.imageViewer.TabIndex = 1;
            this.imageViewer.TabStop = false;
            this.imageViewer.DoubleClick += new EventHandler( this.ZoomInToolStripMenuItem_Click );
            // 
            // ocultarToolStripMenuItem
            // 
            this.ocultarToolStripMenuItem.Name = "ocultarToolStripMenuItem";
            this.ocultarToolStripMenuItem.Size = new Size( 125, 22 );
            this.ocultarToolStripMenuItem.Text = "&Ocultar";
            this.ocultarToolStripMenuItem.Click += this.PictureViewerToolStripMenuItem_Click;
            // 
            // ampliarToolStripMenuItem
            // 
            this.ampliarToolStripMenuItem.Name = "ampliarToolStripMenuItem";
            this.ampliarToolStripMenuItem.Size = new Size( 125, 22 );
            this.ampliarToolStripMenuItem.Text = "&Ampliar";
            this.ampliarToolStripMenuItem.Click += new EventHandler( this.ZoomInToolStripMenuItem_Click );
            // 
            // explorarToolStripMenuItem
            // 
            this.explorarToolStripMenuItem.Name = "explorarToolStripMenuItem";
            this.explorarToolStripMenuItem.Size = new Size( 125, 22 );
            this.explorarToolStripMenuItem.Text = "&Explorar";
            this.explorarToolStripMenuItem.Click += new EventHandler( this.ExploreToolStripMenuItem_Click );
            // 
            // expandirTodoToolStripMenuItem
            // 
            this.expandirTodoToolStripMenuItem.Name = "expandirTodoToolStripMenuItem";
            this.expandirTodoToolStripMenuItem.Size = new Size( 187, 22 );
            this.expandirTodoToolStripMenuItem.Text = "&Expandir todo";
            this.expandirTodoToolStripMenuItem.Click += new EventHandler( this.ExpandAllToolStripMenuItem_Click );
        }
        
        void BuildImageList()
        {
            this.ImageList.TransparentColor = Color.Transparent;
            
            this.ImageList.Images.AddRange( new Bitmap[] {
                this.bmpState,
                this.bmpUrbanState,
                this.bmpVcrRew
            });
        }
        
        void BuildToolbar()
        {
            this.statusStrip.SuspendLayout();
            
            this.statusStrip.Items.AddRange(
                new ToolStripItem[] {
                    this.lblStatus,
                    this.progressBar });
                    
            this.lblStatus.Name = "status";
            this.lblStatus.Text = "Preparado";

            this.statusStrip.Dock = DockStyle.Bottom;
            this.statusStrip.Name = "statusStrip1";
            this.statusStrip.TabIndex = 1;
            this.statusStrip.ResumeLayout( true );
        }
        
        /// <summary>
        /// Builds the explorer container at the right.
        /// Contains the future explorers for places and estates.
        /// </summary>
        void BuildExplorerContainer()
        {
            this.ExplorerContainer = new Panel { Dock = DockStyle.Fill };
        }

        /// <summary>Builds the panel at the left, with the tree and image.</summary>
        void BuildPanel()
        {
            this.panel.SuspendLayout(); 
            this.panel.AutoScroll = true;
            this.panel.BorderStyle = BorderStyle.Fixed3D;
            this.panel.Controls.Add( this.EstatesTree );
            this.panel.Controls.Add( this.imageViewer );
            this.panel.Dock = DockStyle.Fill;
            this.panel.Name = "panel1";
            this.panel.Size = new Size( 286, 396 );
            this.panel.TabIndex = 5;
            this.panel.ResumeLayout( true );
        }
        
        void BuildStatesTree()
        {
            this.EstatesTree.AccessibleName = "Vista de fincas";
            this.EstatesTree.ContextMenuStrip = this.stateContextMenu;
            this.EstatesTree.Dock = DockStyle.Fill;
            this.EstatesTree.ImageIndex = 0;
            this.EstatesTree.ImageList = this.ImageList;
            this.EstatesTree.Location = new Point( 0, 0 );
            this.EstatesTree.Name = "treeView1";
            this.EstatesTree.SelectedImageIndex = 0;
            this.EstatesTree.ShowNodeToolTips = true;
            this.EstatesTree.Size = new Size( 282, 203 );
            this.EstatesTree.TabIndex = 0;
            this.EstatesTree.AfterSelect += new TreeViewEventHandler( this.TreeViewAfterSelect );
            this.EstatesTree.MouseHover += new EventHandler( this.TreeViewMouseHover );
        }
        
        void BuildAreasContextMenu()
        {
            this.areaContextMenu.SuspendLayout(); 
            this.areaContextMenu.Items.AddRange(
                new ToolStripItem[] {
                    this.ocultarToolStripMenuItem,
                    this.ampliarToolStripMenuItem,
                    this.explorarToolStripMenuItem });
            this.areaContextMenu.Name = "stateContextMenu";
            this.areaContextMenu.Size = new Size( 126, 70 );
            this.areaContextMenu.ResumeLayout( true );
        }
        
        void BuildStatesContextMenu()
        {
            this.stateContextMenu.SuspendLayout();
            
            this.expandCollapseStripMenuItem.DropDownItems.AddRange(
                new ToolStripItem[] {
                    this.expandAllToolStripMenuItem,
                    this.collapseAllToolStripMenuItem });
                this.expandCollapseStripMenuItem.Name = "toolStripMenuItem10";
                this.expandCollapseStripMenuItem.Dock = DockStyle.Top;
                this.expandCollapseStripMenuItem.Text = "&Todas las fincas";
                
            this.expandAllToolStripMenuItem.Name = "expandirTodoToolStripMenuItem1";
            this.expandAllToolStripMenuItem.Size = new Size( 152, 22 );
            this.expandAllToolStripMenuItem.Text = "&Expandir todo";
            this.expandAllToolStripMenuItem.Click += new EventHandler( this.ExpandAllToolStripMenuItem_Click );

            this.collapseAllToolStripMenuItem.Name = "colapsarTodoToolStripMenuItem1";
            this.collapseAllToolStripMenuItem.Size = new Size( 152, 22 );
            this.collapseAllToolStripMenuItem.Text = "&Colapsar todo";
            this.collapseAllToolStripMenuItem.Click += new EventHandler( this.ColapseAllToolStripMenuItem_Click );

            this.toolStripMenuItem9.DropDownItems.AddRange( new ToolStripItem[] {
	            this.insertarToolStripMenuItem,
	            this.toolStripMenuItem5,
	            this.eliminarToolStripMenuItem,
	            this.expandirToolStripMenuItem,
	            this.colapsarToolStripMenuItem,
	            this.cambiarnombreToolStripMenuItem,
	            this.cambiarPadreToolStripMenuItem });
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new Size( 187, 22 );
            this.toolStripMenuItem9.Text = "&Finca o área";
            
            this.stateContextMenu.Items.AddRange(
                new ToolStripItem[] {
                    this.expandCollapseStripMenuItem,
                    this.toolStripMenuItem9,
                    this.ocultarPanelToolStripMenuItem,
                    this.ocultarVisorToolStripMenuItem });
            this.stateContextMenu.Name = "contextMenuStrip1";
            
            this.stateContextMenu.ResumeLayout( true );
        }
        
        void BuildFileSystemBrowsers()
        {
            this.folderBrowserDialog.Description = "Elija una carpeta donde guardar la estructura del CD. Dentro de la carpeta que el" +
                "ija se creará una nueva carpeta con el verdadero contenido.";
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "Archivos XML (*.xml) |*.xml|Todos los archivos (*.*)|*.*";
            this.saveFileDialog.RestoreDirectory = true;
        }
        
        public ImageList ImageList {
            get;  set;
        }
        
        /// <summary>Gets the estates tree (at the left).</summary>
        /// <value>A TreeView.</value>
        public TreeView EstatesTree {
            get;  set;
        }
        
        /// <summary>Gets the explorer container (at the right).</summary>
        /// <value>The explorer container, as a Panel.</value>
        public Panel ExplorerContainer {
            get;  set;
        }
        
        SplitContainer SplitContainer {
            get; set;
        }
        
        Bitmap bmpAppIcon;
        Bitmap bmpState;
        Bitmap bmpArea;
        Bitmap bmpUrbanState;
        Bitmap bmpVcrRew;
        
        PictureBox imageViewer;
        StatusStrip statusStrip;
        ToolStripStatusLabel lblStatus;
        Panel panel;
        System.ComponentModel.IContainer components;
        ContextMenuStrip stateContextMenu;
        ContextMenuStrip areaContextMenu;
        ToolStripProgressBar progressBar;
        FolderBrowserDialog folderBrowserDialog;
        SaveFileDialog saveFileDialog;
        
        MenuStrip menuStrip;
        ToolStripMenuItem archivoToolStripMenuItem;
        ToolStripMenuItem guardarcomoToolStripMenuItem;
        ToolStripMenuItem salirToolStripMenuItem;
        ToolStripMenuItem editarToolStripMenuItem;
        ToolStripMenuItem herramientasToolStripMenuItem;
        ToolStripMenuItem ayudaToolStripMenuItem1;
        ToolStripMenuItem copiarToolStripMenuItem;
        ToolStripMenuItem acercadeToolStripMenuItem;
        ToolStripMenuItem generarDatosparaCdToolStripMenuItem;
        ToolStripMenuItem buscaToolStripMenuItem;
        ToolStripMenuItem toolStripMenuItem2;
        ToolStripSeparator toolStripSeparator1;
        ToolStripMenuItem lugarToolStripMenuItem;
        ToolStripMenuItem fincaToolStripMenuItem;
        ToolStripMenuItem toolStripMenuItem3;
        ToolStripMenuItem toolStripMenuItem4;
        ToolStripMenuItem panelDeFincasToolStripMenuItem;
        ToolStripMenuItem explorarToolStripMenuItem;
        ToolStripMenuItem cerrarTodoToolStripMenuItem;
        ToolStripMenuItem expandCollapseStripMenuItem;
        ToolStripMenuItem expandAllToolStripMenuItem;
        ToolStripMenuItem collapseAllToolStripMenuItem;
        ToolStripMenuItem toolStripMenuItem9;
        ToolStripMenuItem insertarToolStripMenuItem;
        ToolStripMenuItem lugarToolStripMenuItem2;
        ToolStripMenuItem fincaToolStripMenuItem2;
        ToolStripMenuItem eliminarToolStripMenuItem;
        ToolStripMenuItem expandirToolStripMenuItem;
        ToolStripMenuItem colapsarToolStripMenuItem;
        ToolStripMenuItem cambiarnombreToolStripMenuItem;
        ToolStripMenuItem toolStripMenuItem5;
        ToolStripMenuItem cambiarPadreToolStripMenuItem;
        ToolStripMenuItem ocultarToolStripMenuItem;
        ToolStripMenuItem ampliarToolStripMenuItem;
        ToolStripMenuItem expandirTodoToolStripMenuItem;
        ToolStripMenuItem ocultarPanelToolStripMenuItem;
        ToolStripMenuItem ocultarVisorToolStripMenuItem;
        ToolStripMenuItem visorFotosToolStripMenuItem;
        ToolStripMenuItem helpMenuItem;
    }
}
