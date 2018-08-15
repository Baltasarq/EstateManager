using System;
using System.Collections;
using System.Windows.Forms;

using EstateManager.Core;

namespace EstateManager.UI {
	public partial class Eliminator : Form {
		public Eliminator(Area donde)
		{
            Area[] allAreas = MainForm.mainForm.Db.AllAreas;
			MdiParent = MainForm.mainForm;
			InitializeComponent();

			MaximumSize = MinimumSize = Size;
            areaToRemove = null;
			SetTitle();

			// Crear el motor del explorador
			xpLugares = new PlaceExplorerEngine(
							null,
							MainForm.mainForm.Db,
							treeView,
							null,
							PlaceExplorerEngine.Selector
			);

            // Preparar el indicativo del área a eliminar
            treeView.SelectedNode = MainForm.LocateInTreeView( treeView, donde );
            treeView.SelectedNode.EnsureVisible();
            areaToRemove = donde;

			// Rellenar los combos
            MainForm.mainForm.StartProcess(
                        "Leyendo BD...",
                        0, 
                        allAreas.Length
            );

            for ( int i = 0; i < allAreas.Length; ++i ) {
                Area a = allAreas[ i ];

                // Añadir cada una de las áreas
                cbId.Items.Add( a.Id );
                cbName.Items.Add( a.Name );
            }

            MainForm.mainForm.EndProcess();

			// Prepararlos para empezar
            cbId.Text = areaToRemove.Id; ;
			cbName.Text = areaToRemove.Name;
		}

		private void SetTitle()
		{
			if ( areaToRemove == null ) {
				Text = "Eliminador";
			} else {
                Text = "Por eliminar: " 
                        + Area.FormatForPresentation( areaToRemove.Name );
            }
            
            return;
		}

		private void OnBtCloseClicked(object sender, EventArgs e)
		{
			this.CloseDialog();
		}

		private void CloseDialog()
		{
			xpLugares.OnStopObserving();
			this.Close();
		}

		/// <summary>Remove the selected area.</summary>
		private void OnBtRemoveClicked(object sender, EventArgs e)
		{
			DialogResult resultado = MessageBox.Show( 
								  "¿Está seguro? ... ¡se perderá para siempre!", 
								  "Eliminar: " 
                                  + Area.FormatForPresentation( areaToRemove.Name ),
								  MessageBoxButtons.YesNo
			);

			if ( resultado == DialogResult.Yes
			  && areaToRemove is Place placeToRemove)
			{
                Enabled = false;
				int numSubEstates  = placeToRemove.CountEstates;
				int numSubplaces = placeToRemove.CountPlaces;

				if ( numSubEstates > 0
				  || numSubplaces > 0 )
				{
					resultado = MessageBox.Show(
								"¿Desea realmente borrar el lugar "
									+ "y todos sus dependientes ("
									+ " SubLugares: " + numSubplaces 
									+ " Fincas: " + numSubEstates
									+ " )? ¡No podrá recuperarlos!",
								"Eliminar: " 
                                 + Area.FormatForPresentation( areaToRemove.Name ),
								MessageBoxButtons.YesNo
					);
				}
			}

			// Borrar de forma efectiva el área seleccionada
			if ( resultado == DialogResult.Yes ) {
				if ( areaToRemove.Parent != null ) {
					// Eliminar el área y cerrar ventana
					CloseDialog();
					MainForm.mainForm.Db.Remove( areaToRemove );
					MainForm.mainForm.Db.Sync();
                    MainForm.mainForm.Db.Root.Notify();
				}
				else {
					MessageBox.Show(
						"Lo siento, no es posible eliminar "
							+ "el tope de la jerarquía.",
						"Eliminando lugar raíz."
					);
				}
			}

			return;
		}

		private void OnAfterSelectTreeViewNode(object sender, TreeViewEventArgs e)
		{
			this.areaToRemove = ( (AreaTreeNode) treeView.SelectedNode ).Area;
			this.cbId.Text = areaToRemove.Id;
			this.cbName.Text = areaToRemove.Name;
		}

		private void OnComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox pivot = (ComboBox) sender;
			ComboBox aux;

            // Look for the one that changed
			if ( pivot == cbId ) {
				aux = cbName;
            } else {
			    aux = cbId;
            }

            // Modify the other one
			aux.SelectedIndex = pivot.SelectedIndex;

            // Find the corresponding area
            this.areaToRemove = MainForm.mainForm.Db.GetAreaById(
                                            cbId.SelectedItem.ToString()
            );

            // Not found?
            if ( areaToRemove == null ) {
                this.areaToRemove = MainForm.mainForm.Db.Root;
                this.cbId.Text = areaToRemove.Id;
                this.cbName.Text = areaToRemove.Name;
            }

            // Show & quit
			this.SetTitle();
            this.treeView.SelectedNode = MainForm.LocateInTreeView( treeView, areaToRemove );
            this.treeView.SelectedNode.EnsureVisible();
		}
        
        PlaceExplorerEngine xpLugares;
        Area areaToRemove;
	}
}