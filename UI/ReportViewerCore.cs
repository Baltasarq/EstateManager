using System;
using System.IO;
using System.Windows.Forms;

using EstateManager.Core;

namespace EstateManager.UI {
    public partial class ReportViewer: Explorer {
        public const string EtqInforme = "Informe";
        public const string ErrorNoEncontrado = "Error 404 - Archivo no encontrado";
        
        public ReportViewer(Control owner)
            :base( owner )
        {
        }

        public ReportViewer(Control owner, string fileName)
            :this( owner )
        {
            this.Build();
            this.btSaveReport.Enabled = false;

            if ( File.Exists( fileName ) ) {
                this.Text = fileName;
                this.reportViewer.Text = "Cargando ...";
                this.Show();
                this.reportViewer.LoadFile( Path.GetFullPath( fileName ) );
            } else {
                this.reportViewer.Text = ErrorNoEncontrado;
            }
                
            return;
        }

        public ReportViewer(Control owner, Report inf)
            :this( owner )
        {
            this.Build();
            this.report = inf;
            this.Text = EtqInforme + " - " + inf.Name
                        + "\n\n"
                        + inf.GetHtml();
        }

        void Build()
        {
            this.InitializeComponent();
            this.MinimumSize = Size;
        }

        void OnBtSaveReportClick(object sender, EventArgs e)
        {
            if ( saveFileDialog.ShowDialog() == DialogResult.OK ) {
                try {
                    report.Generate( saveFileDialog.FileName );
                }
                catch (IOException) {
                    MessageBox.Show( "Error guardando informe",
                                     "Error de disco",
                                     MessageBoxButtons.OK
                    );
                }
            }
            
            return;
        }

        Report report;
    }
}