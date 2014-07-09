using EmailAnalyzerLibrary;
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
using System.Windows.Shapes;

namespace EmailAnalyzerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
        List<EmailDataModel> winFabInterest = new List<EmailDataModel>();
        List<string> searchInFolderNames = new List<string>();
        int emailCount;
        public MainWindow()
        {
            InitializeComponent();
            this.Email_Folders.Items.Clear();
            DisplayOutlookFolders();
            CenterWindowOnScreen();
            CallSettingControl();
        }

        
        void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var winFabSortedList = winFabInterest;
            ListBox lstBx = new ListBox();
            lstBx.Height = this.MainPanel.Height;
            lstBx.Width = this.MainPanel.Width;
            this.MainPanel.Children.Add(lstBx);
            if (winFabSortedList.Count == 0)
            {
                MessageBox.Show("No Records Found.Try changing the folder option.");
            }
            else
            {
                foreach (var itm in winFabSortedList)
                {
                    EmailDataModel emailObj = new EmailDataModel();
                    emailObj.SenderName = itm.SenderName;
                    emailObj.SenderGroup = itm.SenderGroup;
                    emailObj.SenderParticipation = itm.SenderParticipation;
                    emailObj.SenderContact = itm.SenderContact;
                    InterestControl intControl = new InterestControl();
                    intControl.SetUI(emailObj);
                    lstBx.Items.Add(intControl);
                }
            }
            this.EllipseAnimate.Visibility = Visibility.Collapsed;
            this.EllipseAnimate.Visibility = Visibility.Collapsed;
            this.UpdateLayout();
        }

        void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
           
            EmailAnalyzerLibrary.ReadEmails emails = new EmailAnalyzerLibrary.ReadEmails();
            winFabInterest = emails.GetIndividualInterest(emailCount,searchInFolderNames);
            
        }

        private void Btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            searchInFolderNames.Clear();
            foreach (CheckBox item in this.Email_Folders.Items)
            {
                if (item.IsChecked == true)
                {
                    searchInFolderNames.Add(item.Content.ToString());
                }
            }

            if (!String.IsNullOrEmpty(this.ComboBx_Days.SelectionBoxItem.ToString()) && searchInFolderNames.Count > 0)
            {
                if (this.ComboBx_Days.SelectionBoxItem.ToString() != "Total")
                {
                    emailCount = Int32.Parse(this.ComboBx_Days.SelectionBoxItem.ToString());
                }
                else
                {
                    emailCount = 0;
                }
                this.MainPanel.Children.Clear();
                if ((bool)this.DepartmentAnalysis.IsChecked)
                {
                    this.EllipseAnimate.Visibility = Visibility.Collapsed;
                    this.LabelLoding.Visibility = Visibility.Collapsed;
                    DepartmentInterest depInterest = new DepartmentInterest(emailCount, searchInFolderNames);
                    this.MainPanel.Children.Add(depInterest);
                }
                if ((bool)this.InterestAnalysis.IsChecked)
                {
                    this.EllipseAnimate.Visibility = Visibility.Visible;
                    this.LabelLoding.Visibility = Visibility.Visible;
                    worker.RunWorkerAsync();
                }
            }

            else
            {
                MessageBox.Show("Please retry. Check if the folders and days are selected properly.");
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.LabelLoding.Visibility = Visibility.Collapsed;
            this.EllipseAnimate.Visibility = Visibility.Collapsed;
            
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            
        }

        private void DisplayOutlookFolders()
        {
            List<string> folderNames = new List<string>();
            ReadEmails emailObj = new ReadEmails();

            folderNames = emailObj.TriggerOutlook();
            foreach (string itm in folderNames)
            {
                CheckBox chkBox = new CheckBox();
                chkBox.Content = itm;
                this.Email_Folders.Items.Add(chkBox);
            }
            this.UpdateLayout();
        }

        private void Btn_Setting_Click(object sender, RoutedEventArgs e)
        {
            CallSettingControl();
        }

        public void CallSettingControl()
        {
            SettingControl settingObj = new SettingControl();
            this.MainPanel.Children.Clear();

            MainPanel.Children.Add(settingObj);
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
