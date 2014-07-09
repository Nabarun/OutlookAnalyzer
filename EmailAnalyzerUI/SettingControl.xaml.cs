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
    /// Interaction logic for SettingControl.xaml
    /// </summary>
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();
            LoadDefaultRule();
        }

        private void BtnSetRules_Click(object sender, RoutedEventArgs e)
        {
            SetRuleString setRuleObj = new SetRuleString();
            Rules readRulesObj = new Rules();
            string shouldContainText = this.txtBx_Text.Text;
            string shouldContainSubject = this.txtBx_Subject.Text;
            string shouldContainTo = this.txtBx_To.Text;
            string shouldNotContainDepartment = this.txtBx_DenyDepartment.Text;
            string shouldNotContainBody = this.txtBx_DenyBodyTag.Text;
            string shouldNotContainSubject = this.txtBx_DenySubject.Text;

            
            try
            {
                setRuleObj.AllowBodyTags = shouldContainText;
                setRuleObj.AllowSubjectTags = shouldContainSubject;
                setRuleObj.AllowToPeople = shouldContainTo;
                setRuleObj.DenyBodyTags = shouldNotContainBody;
                setRuleObj.DenyDepartment = shouldNotContainDepartment;
                setRuleObj.DenySubject = shouldNotContainSubject;
                bool isSuccess = readRulesObj.SetCustomRules(setRuleObj);
                if (isSuccess)
                {
                    MessageBox.Show("Succesfully updated");   
                }
            }

            catch (Exception ex)
            {
            }

        }

        public void LoadDefaultRule()
        {
            Rules readRuleObj = new Rules();
            RuleDataModel readRuleDataModelObj = new RuleDataModel();
            try
            {
                readRuleDataModelObj = readRuleObj.ReadCustomRules();
                this.txtBx_Subject.Text = String.Join(",", readRuleDataModelObj.SearchForSubject);
                this.txtBx_Text.Text = string.Join(",", readRuleDataModelObj.SearchForBodyTags);
                this.txtBx_To.Text = string.Join(",", readRuleDataModelObj.SearchForToRecepients);
                this.txtBx_DenyBodyTag.Text = String.Join(",", readRuleDataModelObj.SearchForDenyBodyTags);
                this.txtBx_DenyDepartment.Text = String.Join(",", readRuleDataModelObj.SearchForDenyDepartments);
                this.txtBx_DenySubject.Text = String.Join(",", readRuleDataModelObj.SearchForDenySubject);

               
            }
            catch (Exception ex)
            {
            }

        }

        
    }
}
