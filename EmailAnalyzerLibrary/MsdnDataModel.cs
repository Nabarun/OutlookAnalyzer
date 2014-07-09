using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAnalyzerLibrary
{
    public class MsdnDataModel
    {
        string _msdnMemberName;

        public string MsdnMemberName
        {
            get { return _msdnMemberName; }
            set { _msdnMemberName = value; }
        }

        string _msdnMessage;

        public string MsdnMessage
        {
            get { return _msdnMessage; }
            set { _msdnMessage = value; }
        }
    }
}
