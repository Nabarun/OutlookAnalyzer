using System;
using System.Collections.Generic;
using System.IO;
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

namespace EmailAnalyzerUI
{
    /// <summary>
    /// Interaction logic for DepartmentInterest.xaml
    /// </summary>
    public partial class DepartmentInterest : UserControl
    {
        int emailCount;
        static Dictionary<string, int> WinFabInterest = new Dictionary<string, int>();
        private readonly System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
        static List<KeyValuePair<string, int>> winFabInterestDataPoints = new List<KeyValuePair<string, int>>();
        EmailAnalyzerLibrary.ReadEmails emails;
        List<string> searchInFolders;

        public DepartmentInterest(int count, List<String> searchIn)
        {
            InitializeComponent();
            emailCount = count;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            winFabInterestDataPoints.Clear();
            emails = new EmailAnalyzerLibrary.ReadEmails();
            searchInFolders = new List<string>();
            searchInFolders = searchIn;
        }

        void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (winFabInterestDataPoints.Count == 0)
            {
                MessageBox.Show("No Records Found.Try changing the folder option.");
            }
            DepartmentInterestChart.DataContext = winFabInterestDataPoints;
            this.LoadingLabel.Visibility = Visibility.Collapsed;
            WinFabInterest.Clear();
            this.UpdateLayout();

        }

        void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            WinFabInterest = emails.GetDepartmentInterest_UpdatedApi(emailCount, searchInFolders);
            //emails.GetDepartmentInterest_UpdatedApi(emailCount, searchInFolders);
            
            foreach (var item in WinFabInterest)
            {
                winFabInterestDataPoints.Add(new KeyValuePair<string, int>(item.Key, item.Value));
            }
            CreateCSV(winFabInterestDataPoints);
        }

        public void CreateCSV(List<KeyValuePair<string, int>> winFabInterest)
        {
            using (StreamWriter writer = new StreamWriter(@"E:\Result.txt"))
            {
                writer.WriteLine("Customer Group,Contribuition");
                foreach (var customerGroup in winFabInterest)
                {
                    writer.WriteLine(customerGroup.Key + "," + customerGroup.Value);
                }
            }
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.LoadingLabel.Visibility = Visibility.Visible;
            winFabInterestDataPoints.Clear();
            worker.RunWorkerAsync();
        }
    }
}
