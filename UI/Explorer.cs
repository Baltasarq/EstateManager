// gF (c) Baltasar 2005-18 MIT License <baltasarq@gmail.com>
using System.Windows.Forms;

namespace EstateManager.UI
{
    /// <summary>Common class for all explorers.</summary>
    public class Explorer: Panel
    {
        public Explorer(Control owner)
        {
            this.Owner = owner;
            
            this.RemoveAllSubControlsFrom( owner );
            this.Dock = DockStyle.Fill;
            owner.Controls.Add( this );
            this.Show();
        }
        
        void RemoveAllSubControlsFrom(Control widget)
        {
            foreach(Control subWidget in widget.Controls) {
                subWidget.Dispose();
            }
        
            widget.Controls.Clear();
        }
        
        /// <summary>
        /// Gets the owner of this explorer (the control it is in).
        /// </summary>
        /// <value>The owner, as a <see cref="Control"/>.</value>
        public Control Owner {
            get; private set;
        }
    }
}
