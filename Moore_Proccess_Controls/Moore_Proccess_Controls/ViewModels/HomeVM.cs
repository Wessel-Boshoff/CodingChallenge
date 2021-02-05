using Moore_Proccess_Controls.Core.Models;
using Moore_Proccess_Controls.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Moore_Proccess_Controls.ViewModels
{
    public class HomeVM
    {
        public ObservableCollection<string> Headers { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> CalculationTypes { get; set; } = new ObservableCollection<string>()
        { 
            "Standard Deviation",
            "RMS",
            "Specific Rate of Change"
        };
        public ObservableCollection<TagLineModel> Lines { get; set; } = new ObservableCollection<TagLineModel>();
        public string Column { get; set; }
        public string ColumnCalculation { get; set; }
        public string ColumnCalculationType { get; set; }
    }
}
