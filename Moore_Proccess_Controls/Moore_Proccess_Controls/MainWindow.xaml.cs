using Moore_Proccess_Controls.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Moore_Proccess_Controls.Core.Handler;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using Moore_Proccess_Controls.Core.Models;
using System.Dynamic;
using Moore_Proccess_Controls.Mapper;
using Moore_Proccess_Controls.Core.Calculation;
using Moore_Proccess_Controls.Core.Models.Request;
using Moore_Proccess_Controls.Core.Models.Enums;

namespace Moore_Proccess_Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HomeVM homeVM;
        private readonly CSVFileHandler loadCSVFileHandler;
        private readonly CalculationResultHandler calculationResultHandler;
        private readonly StaticDataHandler staticDataHandler;
        public MainWindow()
        {
            loadCSVFileHandler = new CSVFileHandler();
            calculationResultHandler = new CalculationResultHandler();
            staticDataHandler = new StaticDataHandler();
            homeVM = new HomeVM();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                TagFile tagFile = loadCSVFileHandler.Load(new Core.Models.Request.LoadCSVFileRequest() { Path = openFileDialog.FileName }).FileData;
                homeVM.Headers = new ObservableCollection<string>(tagFile.Headers);
                homeVM.Lines = new ObservableCollection<Models.TagLineModel>(tagFile.Lines.Map());
            };


            DataContext = homeVM;
            InitializeComponent();
        }

        private void cbColumn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgTags.ItemsSource = new ObservableCollection<Models.TagLineModel>(homeVM.Lines.OrderBy(c => c.GetType().GetProperty(homeVM.Column).GetValue(c)));
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(homeVM.ColumnCalculationType) || string.IsNullOrEmpty(homeVM.ColumnCalculation))
            {
                return;
            }
            var data = homeVM.Lines.Select(c => (decimal)c.GetType().GetProperty(homeVM.ColumnCalculation).GetValue(c));
            switch (homeVM.ColumnCalculationType)
            {
                case "Standard Deviation":
                    lbCalculationResult.Content = StandardDeviation.Calculate(data);
                    break;
                case "RMS":
                    lbCalculationResult.Content = Rms.Calculate(data);
                    break;
                case "Specific Rate of Change":
                    lbCalculationResult.Content = SpecificRateOfChange.Calculate(data);
                    break;
                default:
                    return;
            }
        }

        private void btnSaveCSV_Click(object sender, RoutedEventArgs e) => Insert(DataEndpoint.CSV);

        private void btnSaveDB_Click(object sender, RoutedEventArgs e) => Insert(DataEndpoint.DB);

        private void Insert(DataEndpoint endpoint)
        {

            var tags = staticDataHandler.Handle(new GetStaticDataRequest() { StaticDataType = StaticDataType.Tags }).StaticItems;
            var calculationTypes = staticDataHandler.Handle(new GetStaticDataRequest() { StaticDataType = StaticDataType.CalculationTypes }).StaticItems;
            calculationResultHandler.Insert(new InsertCalculationResultRequest()
            {
                Endpoint = endpoint,
                CalculationResult = new CalculationResult()
                {
                    CalculationType = calculationTypes.First(c => c.Value.ToString() == homeVM.ColumnCalculationType),
                    Tag = tags.First(c => c.Value.ToString() == homeVM.ColumnCalculation),
                    Value = (decimal)lbCalculationResult.Content,
                    Date = DateTime.Now
                }
            });
        }
    }
}
