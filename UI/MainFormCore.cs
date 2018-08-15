/*
 * Principal de GestorFincas
 * 
 *		Arranca la app, abriendo la base de datos.
 *		Contiene todas las opciones principales
 * 
 * Author: baltasarq
 * Date: 11/09/2005
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using EstateManager.Core;

namespace EstateManager.UI {
	/// <summary>
	/// Description of MainForm.
	/// </summary>
    public partial class MainForm: Form {
        public MainForm()
        {
            mainForm = this;
            
            this.Build();
            this.lblStatus.Text = "Cargando ...";
            
            this.Hide();
            this.MinimumSize = Size;
            this.progressBar.Visible = false;

            this.init = new SplashInit();
            this.init.Show();
            Application.DoEvents();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            try {
                this.Visible = false;
                init.Show();

                // Crear la base de datos y el explorador de fincas
                Db = new Database( "", 
                                    this.StartProcess,
                                    this.MakeStepProcess,
                                    this.EndProcess );

                xpl = new PlaceExplorerEngine(
                            null,
                            Db,
                            EstatesTree,
                            null,
                            PlaceExplorerEngine.Launcher
                );

                MinimumSize = new System.Drawing.Size( 400, 200 );
                lblStatus.Text = "Preparado ...";

                // Preparar la ventana principal
                MainFormResize( this, null );

                // Preparar la imagen inicial
                EstatesTree.SelectedNode = EstatesTree.Nodes[ 0 ];
            }
            catch ( UserException exc ) {
                ChangeToErrorStatus();
                MessageBox.Show(
                    exc.Message,
                    "Gestor de Fincas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch ( Exception exc ) {
                ChangeToErrorStatus();
                MessageBox.Show(
                    exc.Message,
                    "Gestor de Fincas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally {
                init.Close();
                this.Show();
            }
        }

        private void MainFormResize(object sender, EventArgs e)
        {
            LayoutMdi( MdiLayout.TileVertical );
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            About aboutDlg = new About();
            aboutDlg.Show();
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.CloseApp();
        }

        private void CloseApp()
        {
            if ( this.Db != null ) {
                this.Db.Sync();
            }

            Application.Exit();
        }

        private void ChangeToErrorStatus()
        {
            // Permitir acceder a "Salir" y a "Ayuda"
            acercadeToolStripMenuItem.Enabled = true;
            salirToolStripMenuItem.Enabled = true;

            // Eliminar acceso al resto
            editarToolStripMenuItem.Enabled = false;
            herramientasToolStripMenuItem.Enabled = false;
            guardarcomoToolStripMenuItem.Enabled = false;
        }

        private void FallWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi( MdiLayout.Cascade );
        }

        private void MinimizeWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach ( Form mdiChild in MdiChildren ) {
                mdiChild.WindowState = FormWindowState.Minimized;
            }
        }

        private void TileHorizontalWindowsStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            LayoutMdi( MdiLayout.TileHorizontal );
        }

        private void VerticalMosaicWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi( MdiLayout.TileVertical );
        }

        private void FilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterWindow searchWindow =
                new FilterWindow(   this.Db,
                                    this.ExplorerContainer,
                                    this.StartProcess,
                                    this.MakeStepProcess,
                                    this.EndProcess );

            searchWindow.Show();
        }

        private void ZoneCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creator gen = new Creator(
                                    GetChosenArea( EstatesTree ),
                                    Creator.LUGAR
            );

            gen.Show();
        }

        private void EstateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creator gen = new Creator(
	                                GetChosenArea( EstatesTree ),
	                                Creator.FINCA
            );

            gen.Show();
        }

        private void DeleterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminator destr = new Eliminator(
                                    GetChosenArea( EstatesTree )
            );

            destr.Show();
        }

        public static Area GetChosenArea(TreeView treeView1)
        {
            Area toret = ( ( AreaTreeNode ) treeView1.Nodes[ 0 ] ).Area;

            if ( treeView1.SelectedNode != null ) {
                toret = ( ( AreaTreeNode ) treeView1.SelectedNode ).Area;
            }

            return toret;
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Area a = null;
            
            if ( this.ExplorerContainer.Controls.Count > 0 ) {
                Control explorer = this.ExplorerContainer.Controls[ 0 ];
                
                // Buscar en las ventanas actuales
                if ( explorer is PlaceExplorer ) {
                    a = ( ( PlaceExplorer ) explorer ).Lugar;
                } else
                if ( explorer is EstateExplorer ) {
                    a = ( ( EstateExplorer ) explorer ).RealEstate;
                }
                else
                if ( explorer is ImageViewer ) {
                    a = ( ( ImageViewer ) explorer ).Area;
                }
            }

            // The treeview?
            if ( a == null ) {
                a = MainForm.GetChosenArea( EstatesTree );
            }

            Clipboard.SetText( a.ToString(), TextDataFormat.UnicodeText );
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            this.CloseApp();
        }

        private void HideEstatesPanel(object sender, EventArgs e)
        {
            panel.Visible = false;
            panelDeFincasToolStripMenuItem.Checked = false;
        }

        private void ToggleEstatesPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( panelDeFincasToolStripMenuItem.Checked )
                panel.Visible = false;
            else panel.Visible = true;

            panelDeFincasToolStripMenuItem.Checked =
                                    !panelDeFincasToolStripMenuItem.Checked
            ;
        }

        private void GenerateCDDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( folderBrowserDialog.ShowDialog() == DialogResult.OK ) {
                CDGenerator gCD = new CDGenerator( 
                                        Db, 
                                        folderBrowserDialog.SelectedPath,
                                        StartProcess,
                                        MakeStepProcess,
                                        EndProcess
                );

                if ( gCD.IsValid() ) {
                    gCD.Generate();
                } else {
                    MessageBox.Show( 
                            "El directorio elegido no es válido", 
                            "Error"
                     );
                }
            }
            
        }

        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstatesTree.ExpandAll();
        }

        private void ColapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstatesTree.CollapseAll();
        }

        private void PictureViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( visorFotosToolStripMenuItem.Checked ) {
                imageViewer.Visible = false;
            } else {
                imageViewer.Visible = true;
            }    

            visorFotosToolStripMenuItem.Checked =
                                   !visorFotosToolStripMenuItem.Checked
           ;
        }

        private void TreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            if ( EstatesTree.SelectedNode != null ) {
                Area a = ( ( AreaTreeNode ) EstatesTree.SelectedNode ).Area;

                imageViewer.LoadAsync( a.GetImageName() );
            }
        }

        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( EstatesTree.SelectedNode != null ) {
                Area a = ( ( AreaTreeNode ) EstatesTree.SelectedNode ).Area;
                ImageViewer visor = new ImageViewer(
                                            imageViewer.ImageLocation,
                                            a,
                                            this.ExplorerContainer );
                visor.Show();
            }
            
            return;
        }

        public Size GetWorkspaceSize()
        {
            Size toret = new Size {
                Width = ClientSize.Width - 50,
                Height = ClientSize.Height - 50
            };
            
            if ( panel.Visible ) {
                toret.Width -= panel.Width;
            }

            return toret;
        }

        /// <summary>
        /// Busca en un TreeView una Area determinada, utilizando
        /// getRuta() como referencia.
        /// Los nodos de éstos árboles son UINodoFinca, que lleva asociado
        /// un área.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static TreeNode LocateInTreeView(TreeView t, Area a)
        {
            int j;
            AreaTreeNode toret = ( AreaTreeNode ) t.Nodes[ 0 ];
            var areas = new List<Area>( a.BuildPath() );

            // Ponerla la primera para ser tb. tenida en cuenta
            areas.Insert( 0, a );

            if ( areas.Count > 1
              && toret.Area == areas[ areas.Count - 1 ] ) {
                for ( int i = areas.Count - 2; i >= 0; --i ) {
                    for ( j = 0; j < toret.Nodes.Count; ++j ) {
                        AreaTreeNode n = ( AreaTreeNode ) toret.Nodes[ j ];
                        if ( n.Area == areas[ i ] ) {
                            break;
                        }
                    }

                    if ( j < toret.Nodes.Count )
                        toret = ( AreaTreeNode ) toret.Nodes[ j ];
                    else break;
                }
            }

            return toret;
        }

        public void StartProcess(string nombre, int min, int max)
        {
            lblStatus.Text = nombre;

            progressBar.Visible = true;
            progressBar.Maximum = max;
            progressBar.Minimum = min;

            Application.DoEvents();
        }

        public void MakeStepProcess(int avance)
        {
            try {
                progressBar.Value = avance;
            }
            catch ( Exception e) {
                MessageBox.Show( 
                    "Excepción: " + progressBar.Maximum.ToString() + ','
                    + progressBar.Minimum.ToString() + ':' + ' '
                    + e.ToString(),
                    "Error interno"
                );
            }

            Application.DoEvents();
        }

        public void EndProcess()
        {
            progressBar.Value = progressBar.Maximum;
            progressBar.Visible = false;

            lblStatus.Text = "Preparado ...";

            Application.DoEvents();
        }

        private void HelpStripMenuItem_Click(object sender, EventArgs e)
        {
            // Visualizar la ayuda
            StartProcess( "Cargando ayuda ...", 0, 2 );
            Application.DoEvents();
            ReportViewer ayuda = new ReportViewer(
		                                    this.ExplorerContainer,
		                                    "ayuda.rtf" );

            MakeStepProcess( 1 );

            ayuda.Show();
            EndProcess();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Permite guardar la base de datos en otro archivo
            if ( saveFileDialog.ShowDialog() == DialogResult.OK ) {
                Db.StoreDBCopy( saveFileDialog.FileName );
                Db.Sync();
            }
        }

        private void ExploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaceExplorerEngine.LaunchExplorerFor( xpl.SelectedArea );
        }

        private void TreeViewMouseHover(object sender, EventArgs e)
        {
            TreeNode nodo = EstatesTree.GetNodeAt(
                    EstatesTree.PointToClient( Cursor.Position )
            );

            if ( nodo != null ) {
                nodo.ToolTipText = ( nodo as AreaTreeNode ).Area.Remarks;
            }
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach ( Form f in MainForm.mainForm.MdiChildren ) {
                f.Close();
            }
        }

        private void RenameStripMenuItem_Click(object sender, EventArgs e)
        {
            AreaTreeNode nodo = ( AreaTreeNode ) EstatesTree.SelectedNode;

            if ( nodo != null
              && nodo != EstatesTree.Nodes[ 0 ] )
            {
                string nuevoNombre = LaunchNameChangeFor( nodo.Area );

                // Asignar el nuevo nombre si se ha elegido uno
                if ( nuevoNombre != null ) {
                    nodo.Area.Name = nuevoNombre;
                    nodo.Text = nuevoNombre;
                }
            } else {
                MessageBox.Show( "Es necesario seleccionar un nodo, "
                                  + "que no puede ser el raiz." );
            }
            
            return;
        }

        internal static string LaunchNameChangeFor(Area a)
        {
            // Ask for new name
            NameChanger vCN = new NameChanger( a, MainForm.mainForm.Db );
            vCN.ShowDialog();

            return vCN.NuevoNombre;
        }

        private void ExpandTreeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode nodo = EstatesTree.SelectedNode;

            if ( nodo != null ) {
                nodo.ExpandAll();
            }
        }

        private void ColapseTreeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode nodo = EstatesTree.SelectedNode;

            if ( nodo != null ) {
                nodo.Collapse();
            }
        }

        private void ChangeParentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AreaTreeNode nodo = (AreaTreeNode) EstatesTree.SelectedNode;

            if ( nodo != null ) {
                // Preparar el visor para cambiar de padre
                ParentChanger cmp = new ParentChanger( nodo.Area );
                cmp.ShowDialog();
            }
        }
        
        public Database Db {
            get; private set;
        }
        
        PlaceExplorerEngine xpl;
        SplashInit init;

        public static MainForm mainForm;
    }
}
