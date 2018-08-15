using System;
using System.Windows.Forms;

using EstateManager.Core;

namespace EstateManager.UI {
    public partial class NameChanger : Form {
        private Area a;
        private Database bd;
        private string nuevoNombre;

        public string NuevoNombre
        {
            get { return nuevoNombre; }
            set { nuevoNombre = value; }
        }


        public NameChanger(Area a, Database bd)
        {
            InitializeComponent();

            Text = "Cambio de nombre: '" + a.Id + '\'';
            NuevoNombre = null;
            this.a = a;
            this.bd = bd;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Area.NormalizeName( textBox1.Text );
            Area areaEncontrada = bd.GetAreaByName( textBox1.Text );

            // Probar con el nombre ... ¿existe?
            if ( areaEncontrada == null
              || areaEncontrada == a ) {
                // Asignárselo a nuevoNombre
                nuevoNombre = textBox1.Text;
                bd.UpdateAreaName( a );
            } else MessageBox.Show(
                  "No es posible asignar ese nombre. El área: '"
                  + areaEncontrada.Id + "(" + areaEncontrada.Name + ")"
                  + "' ya lo tiene asignado ... elija otro distinto",
                  About.name,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
              );

            // Finalizar
            if ( nuevoNombre != null ) {
                Close();
            }
        }
    }
}