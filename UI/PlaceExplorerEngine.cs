// gF (c) Baltasar 2005-18 MIT License <baltasarq@gmail.com>

using System;
using System.Windows.Forms;
using System.Collections;

using EstateManager.Core;

namespace EstateManager.UI {
	public class PlaceExplorerEngine: Observer {
        public const bool Launcher = true;
        public const bool Selector = false;

        /// <summary>
        /// Crea un explorador de lugar asociado a un componente treeView
        /// </summary>
        /// <param name="ui">Si está asociado a un treeView en UILugar, 
        /// indicarlo (puede ser null)
        /// </param>
        /// <param name="b">La base de datos.</param>
        /// <param name="tr">El treeView</param>
        /// <param name="l">El nodo del lugar donde empezar a mostrar. Si es
        /// null, se toma el nodo raiz.
        /// </param>
        /// <param name="isLauncher">Si es un lanzador permite abrir interfaces para
        /// las fincas y lugares</param>
		public PlaceExplorerEngine(
						PlaceExplorer ui,
						Database b,
						TreeView tr,
						Place l,
						bool isLauncher)
		{
			// Explorer id
			id = numExplorers++;

			// Prepare the interface
			uiPlace = ui;
			bd   = b;
			tree = tr;

			// Observing data
			keepUpdating = true;
			selectedArea = areaFrom = l;
			observedAreas = new ArrayList();

			// Show the root?
			if ( areaFrom == null ) {
				selectedArea = areaFrom = bd.Root;
			}

			// Prepare the tree
			if ( isLauncher ) {
				tree.DoubleClick += (o, args) =>  this.OnTreeViewItemDoubleClick();
			}
			tree.ImageList = MainForm.mainForm.ImageList;
			tree.SelectedImageIndex = tree.ImageIndex = 0;

			// Show
			this.Update( DateTime.Now, Observable.NotificationType.Update );
		}

		void Show()
		{
			tree.Visible = true;
			tree.Nodes[0].Expand();
		}
        
        void Build(Place l)
        {
            TreeNode node;

            // Eliminar todos los nodos del árbol y borrar la lista de áreas
            FreeObservedAreas();
            tree.Nodes.Clear();
            tree.ShowNodeToolTips = true;

            // Añadir la raiz
            node = InsertElement( tree.Nodes, l );
            node.ToolTipText = l.Remarks;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 0;

            // Añadir los nodos
            this.InsertNodes( l.Places, node );
            this.InsertNodes( l.Estates, node );

            return;
        }
        
        void FreeObservedAreas()
        {
            foreach ( Area a in observedAreas ) {
                a.EliminateObserver( this );

                Application.DoEvents();
            }

            observedAreas.Clear();
        }

        TreeNode InsertElement(TreeNodeCollection treeNodeBranch, Area a)
        {
            AreaTreeNode nodo;

            // Observamos esta área
            if ( a is Place ) {
                observedAreas.Add( a );
                a.InsertObserver( this );
            }

            treeNodeBranch.Add( nodo = new AreaTreeNode( 
                                Area.FormatForPresentation( a.Name ), a ) 
            );

            return nodo;
        }

        void InsertNodes(Area[] areas, TreeNode n)
        {
            TreeNode node;

            for(int i = 0; i < areas.Length; ++i) {
                Application.DoEvents();

                Area area = areas[ i ];
                node = InsertElement( n.Nodes, area );
                node.ToolTipText = area.Remarks;

                if ( area is Estate f ) {
                    node.ImageIndex = 2;
                    node.ToolTipText =
                        '('
                        + Estate.cnvtHaMc( f.Extension ).ToString()
                        + @" m.c.) "
                        + node.ToolTipText
                    ;

                    if ( f.IsUrban ) {
                        node.ImageIndex = 3;
                    }
                } else {
                    Place l = (Place) area;
                    node.BackColor = System.Drawing.Color.LightGray;
                    node.ImageIndex = 1;

                    // Recusively insert
                    this.InsertNodes( l.Places, node );
                    this.InsertNodes( l.Estates, node );
                }
            }
            
            return;
        }


		public bool Update(DateTime tiempoActualizacion, Observable.NotificationType tn)
		{
			bool toret = false;

			if ( tn == Observable.NotificationType.Eliminate
			  && keepUpdating )
			{
                if ( uiPlace != null ) {
                    this.uiPlace.Hide();
                    
                }

                this.OnStopObserving();
                toret = true;
			}
            else
			if ( keepUpdating ) {

				if ( lastUpdate != tiempoActualizacion ) {
                    Build( areaFrom );
                    Show();

                    if ( uiPlace != null ) {
                        uiPlace.UpdatePanel();
                    }

					toret = true;
					lastUpdate = tiempoActualizacion;
				}
			}

			return toret;
		}

		/// <summary>
		/// Returns the area associated to that tree node.
		/// </summary>
		/// <param name="treeNode">A TreeNode referencing an Area.</param>
		/// <returns>The area references, as an <see cref="Area"/>.</returns>
		public static Area LookForArea(TreeNode treeNode)
		{
            Area toret = null;
            
            if ( treeNode != null ) {
                var nodo = (AreaTreeNode) treeNode;

                if ( nodo != null ) {
                    toret = nodo.Area;
                }
            }

            return toret;
		}

        /// <summary>
        /// Choose the object referenced and show an appropriate explorer.
        /// </summary>
		void OnTreeViewItemDoubleClick()
		{
			// Buscar el nodo seleccionado.
			selectedArea = LookForArea( tree.SelectedNode );

			// Visualizar un explorador adecuado
			LaunchExplorerFor( selectedArea );
		}

        /// <summary>
        /// Launches an appropriate explorer for a.
        /// </summary>
        /// <param name="a">The object to launch the explorer for.</param>
		public static void LaunchExplorerFor(Area a)
		{
            Explorer explorer;
			Estate f = ( a as Estate );
			Place l = ( a as Place );

			if ( f != null ) {
				explorer = new EstateExplorer( f, MainForm.mainForm.ExplorerContainer );
				explorer.Show();
			}
			else
			if ( l != null ) {
				explorer = new PlaceExplorer( l, MainForm.mainForm.Db, MainForm.mainForm.ExplorerContainer );
				explorer.Show();
			}
			else {
				MessageBox.Show(
						"Ya ha alcanzado el tope de la jerarquía, "
                        + "o no ha seleccionado un nodo",
						"Gestor de Fincas",
						MessageBoxButtons.OK,
						MessageBoxIcon.Asterisk
				);
			}
            
            return;
		}

		/// <summary>
		/// La parte UI nos avisa cuando se termina de observar.
		/// </summary>
		public void OnStopObserving()
		{
			keepUpdating = false;
			FreeObservedAreas();
		}

		public static void FocusOn(TreeView t, String clave)
		{
			TreeNode[] nodos = t.Nodes.Find( clave, true );

			if ( nodos != null 
			  && nodos.Length > 0 ) 
			{
				t.SelectedNode = nodos[0];
			}
		}
        
        /// <summary>Returns the selected area. NULL for the root.</summary>
        /// <returns>The selected area as an <see cref="Area">.</returns>
        public Area SelectedArea {
            get {
                if ( this.selectedArea == null ) {
                    this.selectedArea = LookForArea( tree.SelectedNode );
                }
                
                return this.selectedArea;
            }
        }
        
        DateTime lastUpdate;
        int id;
        TreeView tree;
        Database bd;
        Place areaFrom;
        Area selectedArea;
        ArrayList observedAreas;
        bool keepUpdating;
        PlaceExplorer uiPlace;
        
        public static int numExplorers;
	}
}
