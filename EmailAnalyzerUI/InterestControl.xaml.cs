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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmailAnalyzerUI
{
    /// <summary>
    /// Interaction logic for InterestControl.xaml
    /// </summary>
    public partial class InterestControl : UserControl
    {
         int emailCount;
        static Dictionary<string, EmailDataModel> WinFabInterest = new Dictionary<string, EmailDataModel>();
        
        public InterestControl()
        {
            InitializeComponent();
           
        }

      
       public void SetUI(EmailDataModel item)
       {
           
            this.IndividualName.Content = "Name : " + item.SenderName;
            this.IndividualDepartment.Content = "Department : " + item.SenderGroup;
            this.IndividualCount.Content = "Number of Email Conversation: " + item.SenderParticipation.ToString();
       }


        
    }
}
