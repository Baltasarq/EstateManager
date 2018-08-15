using System.Windows.Forms;

using EstateManager.Core;

namespace EstateManager.UI {
    /// <summary>
    /// A tree node that also holds an <see cref="Area"/>.
    /// </summary>
	public class AreaTreeNode : TreeNode {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EstateManager.UI.AreaTreeNode"/> class.
        /// </summary>
        /// <param name="txt">The text in the tree node.</param>
        /// <param name="area">The <see cref="Area"/> represented in the tree node.</param>
		public AreaTreeNode(string txt, Area area)
            :base( txt )
		{
			this.Area = area;
		}
        
        /// <summary>
        /// Gets or sets the area held.
        /// </summary>
        /// <value>The <see cref="Area"/>.</value>
        public Area Area {
            get; set;
        }
	}
}
