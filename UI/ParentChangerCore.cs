using System;
using System.Windows.Forms;

using EstateManager.Core;

namespace EstateManager.UI {
    public partial class ParentChanger: Form {
        public ParentChanger(Area area)
        {
            InitializeComponent();

            this.Area = area;

            Text = @"Cambiar padre de: '" 
                    + Area.FormatForPresentation( area.Name )
                    + '\''
            ;

            label2.Text = Area.FormatForPresentation( area.Name )
                    + @" en "
            ;

            if ( area.Parent != null ) {
                label2.Text = Area.FormatForPresentation( area.Parent.Name );
            }

            return;
        }

        void OnBtCloseClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        void OnBtChangeParentClicked(object sender, EventArgs e)
        {            
            Place parent = this.Area.Parent;

            if ( parent != null ) {
                Place newParent = null;
           
                this.Enabled = false;
                
                // Look for the new parent
                var node = (AreaTreeNode) treeView.SelectedNode;

                if ( node != null ) {
                    // Remove it from parent and insert it in the new parent
                    parent.Remove( this.Area );
                    newParent.Insert( this.Area );

                    // Modify the area and close
                    this.Close();
                    this.Area.Parent = newParent;
                    MainForm.mainForm.Db.Update();
                    MainForm.mainForm.Db.Root.Notify();
                } else {
                    MessageBox.Show(
                        "Debe seleccionar un nodo.",
                        "No hay nuevo padre",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error );
                }
            } else {
                MessageBox.Show(
                      "No es posible modificar este nodo.",
                      "No pertenece a sitio alguno.",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error );
            }
        }
        
        public Area Area {
            get; private set;
        }
    }
}
