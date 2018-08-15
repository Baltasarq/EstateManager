using System;
using System.Windows.Forms;

using EstateManager.Core;

namespace EstateManager.UI {
    public partial class ChangeRemarks : Form {
        public ChangeRemarks(Area a)
        {
            InitializeComponent();

            this.Area = a;
            this.Text = Area.FormatForPresentation( a.Name );
            this.edRemarks.Text = this.Area.Remarks;
        }

        private void OnBtSaveClicked(object sender, EventArgs e)
        {
            this.Area.Remarks = edRemarks.Text;
            this.Close();
        }

        private void OnBtCancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public Area Area {
            get; private set;
        }
    }
}
