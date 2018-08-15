using System;
using System.Text;
using System.Collections.Generic;

namespace EstateManager.Core {
    public class Report {
        public const string DirReports = "informesGF";
        public const string ReportFile = "informe.html";
        const string PrefixReportFile = "gf_";

        public Report(  List<Area> areas,
                        string names,
                        Action<string, int, int> processStart,
                        Action<int> processMakeStep,
                        Action processEnd)
        {
            this.html = new StringBuilder();
            this.areas = areas;
            this.Name = names;
            
            this.processStart = processStart;
            this.processMakeStep = processMakeStep;
            this.processEnd = processEnd;

            this.File = DirReports
                        + Database.DirDiv
                        + PrefixReportFile
                        + Database.BuildTimeDescriptor( DateTime.Now )
                        + '_' + ReportFile
            ;
        }

        public void Generate(string fileName)
        {
            string finalFileName;

            // Generar o no el html, según se le pase el nombre
            if ( !string.IsNullOrEmpty( fileName ) )
                finalFileName = fileName;
            else {
                finalFileName = this.File;
                this.html.Clear();
            }

            // Crear el contenido HTML
            GetHtml();

            // Guardar en archivo
            System.IO.Directory.CreateDirectory( DirReports );
            System.IO.StreamWriter f = 
                new System.IO.StreamWriter( finalFileName, false, Encoding.Default )
            ;

            f.Write( this.Html );
            f.Close();
        }

        public static string PreparePath(Area a)
        {
            Area parent = a.Parent;
            string toret = "";
            string placeName = "";

            if ( parent != null ) {
                placeName = Area.FormatForPresentation( parent.Name );

                toret += "<b>" + placeName + "</b> (";
                string.Join( ",", new List<Area>( parent.BuildPath() ) );
                toret += ')';
            }

            return toret;
        }

        public string GetHtml()
        {
            int numFincas = 0;
            double superficieTotal = 0.0;
            double valorTotal = 0.0;
            double valor;
            double valorMedio;

            if ( this.Html == null ) {

                this.processStart( 
                            "Generando informe...",
                            0, areas.Count
                );

                // Crear el contenido HTML
                this.html.Append(
                    "<header><META HTTP-EQUIV=\"Content-Type\" "
                     + "CONTENT=\"text/html;charset=ISO-8859-1\">"
                     + "<title>Informe gF</title>\n\n</header><body>\n\n" );

                this.html.Append( "\n\n<p><center><h1>Informe de fincas</h1></center></p>\n\n" );
                this.html.Append( "<table width=100%>\n" );
                this.html.Append( "<tr><td><b><u>Ref.Catastral/Id</u></b></td>"
                        + "<td><b><u>Nombre</u></b></td>"
                        + "<td><b><u>Superficie</u></b></td>"
                        + "<td><b><u>Valoración</u></b></td>"
                        + "<td><b><u>Situado en</u></b></td>"
                        + "<td><b><u>Observaciones</u></b></td></tr>\n\n" );

                for ( int i = 0; i < areas.Count; ++i ) {
                    if ( areas[ i ] is Estate finca) {
                        ++numFincas;
                        finca = ( Estate ) areas[ i ];

                        // Calcular el valor
                        superficieTotal += finca.Extension;

                        if ( finca.WasSold() )
                                valor = finca.getPrecioDeVenta();
                        else    valor = finca.Valor;

                        valorTotal += valor;

                        // Crear el contenido en Html para la finca
                        this.html.Append( "<tr><td><font size=-2><b>" + finca.RefCatastral
                                    + "</b></font></td></tr><tr><td><font size=-2><b>"
                                    + finca.Id + "</b></font></td><td><font size=-2>"
                                    + Area.FormatForPresentation( finca.Name )
                                    + "</font></td>" );

                        this.html.Append( "<td><font size=-2>"
                                    + Estate.cnvtHaMc( ( ( Estate ) finca ).Extension ).ToString( "N2" )
                                    + " m<sup>2</sup></font></td>" );

                        this.html.Append( "<td><font size=-2>"
                                    + valor.ToString( "C" )
                                    + "</font></td>" );

                        this.html.Append( "<td><font size=-2>"
                                + PreparePath( finca )
                                + "</td></font><td><font size=-2>"
                                + finca.Remarks
                                + "</font></td>\n</tr>\n" );

                        this.html.Append( "\n<tr><td><hr></td></tr>\n" );
                    }

                    this.processMakeStep( i );
                }

                this.html.Append( "</table><p>\n" );

                // Indicar el valor y la superficie total
                if ( superficieTotal == 0 )
                        valorMedio = 0;
                else    valorMedio = valorTotal / 
                                    ( (double) Estate.cnvtHaMc( superficieTotal ) );

                this.html.Append( "\n\n<table border=0>"
                      + "<tr><td><font size=-2><b>Núm. fincas:</b></font></td>"
                      + "<td><font size=-2>"
                      + Convert.ToString( numFincas )
                      + "</font></td></tr>"
                      + "\n<tr><td><font size=-2><b>Superficie total:</b></font></td>"
                      + "<td><font size=-2>"
                      + Estate.cnvtHaMc( superficieTotal ).ToString( "N2" )
                      + " m<sup>2</sup></font></td></tr>"
                      + "\n<tr><td><font size=-2><b>Valor total:</b></font></td>"
                      + "<td><font size=-2>"
                      + valorTotal.ToString( "C" )
                      + "</font></td></tr>"
                      + "\n<tr><td><b><font size=-2>Valor medio por m.c.:</b></font></td>"
                      + "<td><font size=-2>"
                      + valorMedio.ToString( "C" )
                      + "</font></td></tr>\n"
                      + "</table>" );

                this.html.Append( "\n\n<p>\n\n</body></html>\n" );
                this.processEnd();
            }

            return this.Html;
        }
        
        public string Html {
            get {
                return this.html.ToString();
            }
        }
        
        public string File {
            get; private set;
        }
        
        public string Name {
            get; private set;
        }
        
        public Area[] Areas {
            get {
                var toret = new Area[ this.areas.Count ];
                
                this.areas.CopyTo( toret );
                return toret;
            }
        }
        
        StringBuilder html;
        List<Area> areas;
        Action<string, int, int> processStart;
        Action<int> processMakeStep;
        Action processEnd;
    }
}
