using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAnalyzerLibrary
{
    public class RuleDataModel
    {
        List<string> _searchForBodyTags;

        public List<string> SearchForBodyTags
        {
            get { return _searchForBodyTags; }
            set { _searchForBodyTags = value; }
        }

        List<string> _searchForSubject;

        public List<string> SearchForSubject
        {
            get { return _searchForSubject; }
            set { _searchForSubject = value; }
        }

        List<string> _searchForToRecepients;

        public List<string> SearchForToRecepients
        {
            get { return _searchForToRecepients; }
            set { _searchForToRecepients = value; }
        }

        List<string> _searchForDenyBodyTags;

        public List<string> SearchForDenyBodyTags
        {
            get { return _searchForDenyBodyTags; }
            set { _searchForDenyBodyTags = value; }
        }

        List<string> _searchForDenyDepartments;

        public List<string> SearchForDenyDepartments
        {
            get { return _searchForDenyDepartments; }
            set { _searchForDenyDepartments = value; }
        }

       
        List<string> _searchForDenySubject;

        public List<string> SearchForDenySubject
        {
            get { return _searchForDenySubject; }
            set { _searchForDenySubject = value; }
        }
    }
}
