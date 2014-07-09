using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace EmailAnalyzerLibrary
{
    public class Rules
    {
        public Rules()
        {
        }

        public void CreateXml()
        {
            XDocument xDoc = new XDocument(
                    new XElement("Rules",
                        new XElement("SetRules",
                            new XElement("AllowBody", "WinFabric, Windows Fabric"),
                            new XElement("AllowSubject", "WinFabric,Azure"),
                            new XElement("AllowTo", "Windows Fabric Discussion")
                            ),
                        new XElement("ExcludeRules",
                            new XElement("DenyBody", ""),
                            new XElement("DenySubject", "EIG Job"),
                            new XElement("DenyDepartments", "US - WinAzure WinFab"))));
            var fileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Ruleset.xml";
            xDoc.Save(fileName);
        }

        public RuleDataModel ReadCustomRules()
        {
            string line = String.Empty;
            RuleDataModel ruleDataObj = new RuleDataModel();
            try
            {
                var fileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Ruleset.xml";
                if (!File.Exists(fileName))
                {
                    CreateXml();
                }
                using (XmlTextReader reader = new XmlTextReader(fileName))
                {
                    
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "AllowBody":
                                    reader.Read();
                                    ruleDataObj.SearchForBodyTags = reader.Value.Split(',').ToList();
                                    break;
                                case "AllowSubject":
                                    reader.Read();
                                    ruleDataObj.SearchForSubject = reader.Value.Split(',').ToList();
                                    break;
                                case "AllowTo":
                                    reader.Read();
                                    ruleDataObj.SearchForToRecepients = reader.Value.Split(',').ToList();
                                    break;
                                case "DenyBody":
                                    reader.Read();
                                    ruleDataObj.SearchForDenyBodyTags = reader.Value.Split(',').ToList();
                                    break;
                                case "DenySubject":
                                    reader.Read();
                                    ruleDataObj.SearchForDenySubject = reader.Value.Split(',').ToList();
                                    break;
                                case "DenyDepartments":
                                    reader.Read();
                                    ruleDataObj.SearchForDenyDepartments = reader.Value.Split(',').ToList();
                                    break;
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return ruleDataObj;
        }
        public bool SetCustomRules(SetRuleString setRuleObj)
        {
            string line = String.Empty;
            bool isSuccess = false;
            RuleDataModel ruleDataObj = new RuleDataModel();
            try
            {

                XDocument xDoc = new XDocument(
                    new XElement("Rules",
                        new XElement("SetRules",
                            new XElement("AllowBody", setRuleObj.AllowBodyTags),
                            new XElement("AllowSubject", setRuleObj.AllowSubjectTags),
                            new XElement("AllowTo", setRuleObj.AllowToPeople)
                            ),
                        new XElement("ExcludeRules",
                            new XElement("DenyBody", setRuleObj.DenyBodyTags),
                            new XElement("DenySubject", setRuleObj.DenySubject),
                            new XElement("DenyDepartments", setRuleObj.DenyDepartment))));
                var fileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+"\\Ruleset.xml";
                xDoc.Save(fileName);
                isSuccess = true;
            }
            catch (System.Exception ex)
            {
                throw;
                isSuccess = false;

            }
            return isSuccess;
        }

        
    }
    public class SetRuleString
    {
        string _allowBodyTags;

        public string AllowBodyTags
        {
          get { return _allowBodyTags; }
          set { _allowBodyTags = value; }
        }

        string _allowSubjectTags;

        public string AllowSubjectTags
        {
            get { return _allowSubjectTags; }
            set { _allowSubjectTags = value; }
        }

        string _allowToPeople;

        public string AllowToPeople
        {
            get { return _allowToPeople; }
            set { _allowToPeople = value; }
        }

        string _denyBodyTags;

        public string DenyBodyTags
        {
            get { return _denyBodyTags; }
            set { _denyBodyTags = value; }
        }

        string _denyDepartment;

        public string DenyDepartment
        {
            get { return _denyDepartment; }
            set { _denyDepartment = value; }
        }

        string _denySubject;

        public string DenySubject
        {
            get { return _denySubject; }
            set { _denySubject = value; }
        }
    }
    
}
