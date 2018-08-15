// GestorFincas (c) 2005-2018 Baltasarq MIT License (baltasarq@gmail.com)

namespace EstateManager.UI {
    using System;
    using System.Windows.Forms;
    
    using EstateManager.Core;

    public partial class FilterResultsWindow
    {
        public FilterResultsWindow(string searchDesc,
                                   Area[] resultingAreas,
                                   Control owner,
                                   Action<string, int, int> processStart,
                                   Action<int> processMakeStep,
                                   Action processEnd)
            :base( owner )
        {
            this.SearchDesc = searchDesc;
            this.Areas = resultingAreas;
            this.processStart = processStart;
            this.processEnd = processEnd;
            this.processMakeStep = processMakeStep;
            
            this.InitializeComponent();
        }
        
        void OnBtGenerateReportClicked()
        {
        }
        
        public Area[] Areas {
            get; private set;
        }
        
        public string SearchDesc {
            get; private set;
        }
        
        Action<string, int, int> processStart;
        Action<int> processMakeStep;
        Action processEnd;
    }
}
