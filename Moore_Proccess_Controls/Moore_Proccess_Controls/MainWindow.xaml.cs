using Microsoft.Win32;
using Moore_Proccess_Controls.Core.Calculation;
using Moore_Proccess_Controls.Core.Handler;
using Moore_Proccess_Controls.Core.Models;
using Moore_Proccess_Controls.Core.Models.Enums;
using Moore_Proccess_Controls.Core.Models.Request;
using Moore_Proccess_Controls.Core.Values;
using Moore_Proccess_Controls.Mapper;
using Moore_Proccess_Controls.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            var data = homeVM.Lines.Select(c => (decimal)c.GetType().GetProperty(homeVM.ColumnCalculation).GetValue(c)).ToList();
            switch (homeVM.ColumnCalculationType)
            {
                case "Standard Deviation":
                    lbCalculationResult.Content = StandardDeviation.Calculate(data);
                    break;
                case "RMS":
                    lbCalculationResult.Content = Rms.Calculate(data);
                    break;
                case "Specific Rate of Change":
                    var ts = homeVM.Lines.Select(c => (DateTime)c.GetType().GetProperty("TS").GetValue(c)).ToList();
                    List<Tuple<DateTime, decimal>> valuesTuple = new List<Tuple<DateTime, decimal>>();
                    for (int i = 0; i < ts.Count; i++)
                    {
                        valuesTuple.Add(new Tuple<DateTime, decimal>(ts[i], data[i]));
                    }
                    lbCalculationResult.Content = string.Join(CONSTS.Separator.ToString(), SpecificRateOfChange.Calculate(valuesTuple));
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
                    Value = lbCalculationResult.Content.ToString().Split(CONSTS.Separator).Select(c => Convert.ToDecimal(c, CultureInfo.InvariantCulture)).ToList(),
                    Date = DateTime.Now
                }
            });
        }

        private void btnChangeConnection_Click(object sender, RoutedEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["Moore_Proccess_ControlsEntities"].ConnectionString = homeVM.ConnectionString;
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
