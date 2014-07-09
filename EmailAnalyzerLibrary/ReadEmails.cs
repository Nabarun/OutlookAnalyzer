
using ApplicationLogger;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EmailAnalyzerLibrary
{
    public class ReadEmails
    {
        //Microsoft.Office.Interop.Outlook.MAPIFolder outlookFolder = null;
        Microsoft.Office.Interop.Outlook.Application app = null;
        Microsoft.Office.Interop.Outlook._NameSpace ns;
        List<string> folders;
        List<MAPIFolder> outlookFolders = new List<MAPIFolder>();

        public ReadEmails()
        {
            folders = new List<string>();
            ReadFromOutlook();           
        }
        
        public void ReadFromOutlook()
        {   
            Microsoft.Office.Interop.Outlook.PostItem item = null;

            Dictionary<string, EmailDataModel> senderContribuition = new Dictionary<string, EmailDataModel>();

            string department = String.Empty;
            string geo = String.Empty;
            string name = string.Empty;
            string individualImage = String.Empty;

            try
            {
                app = new Microsoft.Office.Interop.Outlook.Application();
                ns = app.GetNamespace("MAPI");
                ns.Logon(null, null, false, false);
                LoggerClass.WriteException(DateTime.Now, "Namespace", ns.ToString());
            }
            catch (System.Exception ex)
            {
                LoggerClass.WriteException(DateTime.Now, "Logic", ex.Message);
            }
        }

        /// <summary>
        /// Module for getting the Department Analysis
        /// </summary>
        /// <param name="count"></param>
        /// <param name="searchInFolders"></param>
        /// <returns></returns>
        public Dictionary<string, int> GetDepartmentInterest_UpdatedApi(int count, List<string> searchInFolders)
        {
            Dictionary<string, int> filterList = new Dictionary<string, int>();
            string department = String.Empty;
            int countnum = 0;
            string filter = String.Empty;
            List<MAPIFolder> searchFolders = new List<MAPIFolder>();
            RuleDataModel ruleObj = new RuleDataModel();
            Rules readRulesObj = new Rules();
            string filterCriteria = String.Empty;
            
            DateTime date = DateTime.Now.AddDays(-count);
            string filterDate = date.ToString("MM/dd/yyyy hh:mm t", CultureInfo.InvariantCulture);
            try
            {
                outlookFolders.Clear();
                filterList.Clear();
                ruleObj = readRulesObj.ReadCustomRules();
               // string subject = "WinFabric";
                searchFolders = SearchSelectedFolders (searchInFolders);
               
                filter = "[ReceivedTime]>='"+filterDate+ "'";

                foreach (MAPIFolder folder in searchFolders)
                {
                    var outlookItems = folder.Items.Restrict(filter);
                    for (int i = 1; i <= outlookItems.Count; i++)
                    {
                       // Task taskResult = Task.Factory.StartNew(() =>
                         //   {
                                try
                                {
                                    MailItem itm = (MailItem)outlookItems[i];
                                    //if (itm.SentOn > DateTime.Now.AddDays(-count) || count == 0)
                                    //{
                                        if (itm.Body.ContainsAny(ruleObj.SearchForBodyTags) ||
                                            itm.To.ContainsAny(ruleObj.SearchForToRecepients))
                                        {
                                            department = itm.Sender.GetExchangeUser().Department;
                                          
                                            if (!department.ContainsAny(ruleObj.SearchForDenyDepartments) &&
                                                !itm.Body.ContainsAny(ruleObj.SearchForDenyBodyTags) &&
                                                !itm.Subject.ContainsAny(ruleObj.SearchForDenySubject))
                                            {
                                                if (filterList.ContainsKey(department))
                                                {
                                                    filterList[department]++;
                                                }
                                                else
                                                {
                                                    filterList.Add(department, 1);
                                                }
                                            }

                                      //  }
                                    }
                                    countnum++;
                                }
                                catch (System.Exception ex)
                                {
                                    countnum--;
                                }
                          //});
                    }

                }

            }
            catch (System.Exception ex)
            {
                LoggerClass.WriteException(DateTime.Now, "Logic", ex.Message);
            }
            filterList = (from entry in filterList orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
            return filterList;
        }

    


        public List<EmailDataModel> GetIndividualInterest(int count, List<string> searchInFolders)
        {
            Dictionary<string, EmailDataModel> filterDictionary = new Dictionary<string, EmailDataModel>();
            List<EmailDataModel> filterList = new List<EmailDataModel>();
            List<MAPIFolder> searchFolders = new List<MAPIFolder>();
            string department = String.Empty;
            string name = String.Empty;
            string picturePath = String.Empty;
            string contact = String.Empty;
            RuleDataModel ruleObj = new RuleDataModel();
            Rules readRulesObj = new Rules();
            string filter = String.Empty;
            DateTime date = DateTime.Now.AddDays(-count);
            string filterDate = date.ToString("MM/dd/yyyy hh:mm t", CultureInfo.InvariantCulture);
            try
            {
                outlookFolders.Clear();
                ruleObj = readRulesObj.ReadCustomRules();
                searchFolders = SearchSelectedFolders(searchInFolders);
                filter = "[ReceivedTime]>='" + filterDate + "'";
                foreach (MAPIFolder folder in searchFolders)
                {
                    var outlookItems = folder.Items.Restrict(filter);
                    for (int i = 1; i <= outlookItems.Count; i++)
                    {
                        try
                        {
                            MailItem itm = (MailItem)outlookItems[i];
                            if (itm.SentOn > DateTime.Now.AddDays(-count) || count == 0)
                            {
                                if (itm.Body.ContainsAny(ruleObj.SearchForBodyTags) ||
                                   itm.To.ContainsAny(ruleObj.SearchForToRecepients))
                                {

                                    department = itm.Sender.GetExchangeUser().Department;

                                    if (!department.ContainsAny(ruleObj.SearchForDenyDepartments) &&
                                        !itm.Body.ContainsAny(ruleObj.SearchForDenyBodyTags) &&
                                        !itm.Subject.ContainsAny(ruleObj.SearchForDenySubject))
                                    {
                                        contact = itm.Sender.GetExchangeUser().MobileTelephoneNumber;
                                        name = itm.Sender.Name;
                                        if (filterDictionary.ContainsKey(name))
                                        {
                                            filterDictionary[name].SenderParticipation++;
                                        }
                                        else
                                        {
                                            EmailDataModel emailObj = new EmailDataModel();
                                            emailObj.SenderName = name;
                                            emailObj.SenderGroup = department;
                                            emailObj.SenderImage = contact;
                                            emailObj.SenderParticipation = 1;
                                            filterDictionary.Add(name, emailObj);
                                        }
                                    }
                                }
                            }
                        }
                        catch (System.Exception ex)
                        {
                            LoggerClass.WriteException(DateTime.Now, "Logic", ex.Message);
                        }

                    }

                }
                foreach (var itm in filterDictionary)
                {
                    filterList.Add(itm.Value);
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                Console.WriteLine(ex.ToString());
                LoggerClass.WriteException(DateTime.Now, "Logic", ex.Message);
            }
            catch (System.Exception ex)
            {
                LoggerClass.WriteException(DateTime.Now, "Logic", ex.Message);
            }
            

            filterList = filterList.OrderByDescending(e => e.SenderParticipation).ToList();
            CreateIndividualCSV(filterList);
            return filterList;
        }

        public void CreateIndividualCSV(List<EmailDataModel> winFabInterest)
        {
            using (StreamWriter writer = new StreamWriter(@"E:\IndividualResult.txt"))
            {
                writer.WriteLine("Name,Department,EmailCount");
                foreach (var individual in winFabInterest)
                {
                    writer.WriteLine(individual.SenderName + "," + individual.SenderGroup+","+individual.SenderParticipation);
                }
            }
        }

        public List<string> TriggerOutlook()
        {
           
            List<string> folders = new List<string>();
            try
            {
                app = new Microsoft.Office.Interop.Outlook.Application();
                ns = app.GetNamespace("MAPI");
                foreach (MAPIFolder folder in ns.Folders)
                {
                    folders = GetEmailFolders(folder);

                }
                folders.Sort();
            }
            catch (System.Exception ex)
            {
            }
            return folders;
        }


        public List<string> GetEmailFolders(MAPIFolder folder)
        {
            foreach (MAPIFolder subFolder in folder.Folders)
            {
                folders.Add(subFolder.FolderPath);
                foreach (MAPIFolder childFolder in subFolder.Folders)
                {
                    folders.Add(childFolder.FolderPath);
                }
            }


            return folders;
        }

        public List<MAPIFolder> GetSelectedEmailFolders(List<string> folderNames)
        {
            app = new Microsoft.Office.Interop.Outlook.Application();
            ns = app.GetNamespace("MAPI");
            
            foreach (MAPIFolder subFolder in ns.Folders)
            {
                GetSelectedEmailFolders(subFolder, folderNames);
            }
            return outlookFolders;
        }

        public List<MAPIFolder> SearchSelectedFolders(List<string> folderNames)
        {
            List<MAPIFolder> searchFolders = new List<MAPIFolder>();
            app = new Microsoft.Office.Interop.Outlook.Application();
            ns = app.GetNamespace("MAPI");
            foreach (MAPIFolder searchFolder in ns.Folders)
            {
                foreach (MAPIFolder sub in searchFolder.Folders)
                {
                    if (folderNames.Contains(sub.FolderPath))
                    {
                        searchFolders.Add(sub);
                    }
                }
            }
            return searchFolders;
        }

        public List<MAPIFolder> GetSelectedEmailFolders(MAPIFolder folder, List<string> folderNames)
        {
            try
            {
                if (folder.Folders.Count == 0)
                {
                    outlookFolders.Add(folder);
                }
                else
                {
                    foreach (MAPIFolder subFolder in folder.Folders)
                    {
                        if (folderNames.Contains(subFolder.FolderPath))
                        {
                            GetSelectedEmailFolders(subFolder, folderNames);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                LoggerClass.WriteException(DateTime.Now, "Logic", ex.Message);
            }

            return outlookFolders;
        }
    }
    public static class StringExtensions
    {
        public static bool ContainsAny(this string str, List<string> values)
        {
            if ((!string.IsNullOrEmpty(str) || values.Count > 0) )
            {
                foreach (string value in values)
                {
                    if (str.Contains(value))
                        return true;
                }
            }

            return false;
        }


    }
}
