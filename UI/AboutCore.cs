using System;
using System.Windows.Forms;
using System.Reflection;

namespace EstateManager.UI {
    partial class About : Form {
        public const string name = "gF";
        public const string version = "v1.3 Serial 20070125";
        public const string email = "baltasar@yahoo.es";
        public const string description =
                        "gF es un gestor de fincas que permite,"
                        + " de una manera visual, manejar todas"
                        + " las fincas, rústicas o no, así como"
                        + " ciertos datos de las mismas."
                        + " Es capaz de generar una web con las"
                        + " imágenes de las fincas, que puede ser"
                        + " guardada en un CD."
                        + " Permite la realización de búsquedas"
                        + " por casi todos los campos existentes."
        ;

        public About()
        {
            this.Build();

            this.Text = String.Format( "Acerca de {0} ...", name );
            this.labelProductName.Text = name;
            this.labelVersion.Text = version;
            this.labelCompanyName.Text = email;
            this.textBoxDescription.Text = description;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyTitleAttribute ), false );
                // If there is at least one Title attribute
                if ( attributes.Length > 0 ) {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = ( AssemblyTitleAttribute ) attributes[ 0 ];
                    // If it is not an empty string, return it
                    if ( titleAttribute.Title != "" )
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension( Assembly.GetExecutingAssembly().CodeBase );
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyDescriptionAttribute ), false );
                // If there aren't any Description attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Description attribute, return its value
                return ( ( AssemblyDescriptionAttribute ) attributes[ 0 ] ).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyProductAttribute ), false );
                // If there aren't any Product attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Product attribute, return its value
                return ( ( AssemblyProductAttribute ) attributes[ 0 ] ).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCopyrightAttribute ), false );
                // If there aren't any Copyright attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Copyright attribute, return its value
                return ( ( AssemblyCopyrightAttribute ) attributes[ 0 ] ).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCompanyAttribute ), false );
                // If there aren't any Company attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Company attribute, return its value
                return ( ( AssemblyCompanyAttribute ) attributes[ 0 ] ).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
