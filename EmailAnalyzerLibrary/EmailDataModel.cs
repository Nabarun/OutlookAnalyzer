using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAnalyzerLibrary
{
    public class EmailDataModel
    {
        string _senderName;

        public string SenderName
        {
            get { return _senderName; }
            set { _senderName = value; }
        }

        string _senderGroup;

        public string SenderGroup
        {
            get { return _senderGroup; }
            set { _senderGroup = value; }
        }

        string _senderLocation;

        public string SenderLocation
        {
            get { return _senderLocation; }
            set { _senderLocation = value; }
        }

        string _senderMessage;

        public string SenderMessage
        {
            get { return _senderMessage; }
            set { _senderMessage = value; }
        }

        string _recepientName;

        public string RecepientName
        {
            get { return _recepientName; }
            set { _recepientName = value; }
        }

        string _senderImage;

        public string SenderImage
        {
            get { return _senderImage; }
            set { _senderImage = value; }
        }

        int _senderParticipation;

        public int SenderParticipation
        {
            get { return _senderParticipation; }
            set { _senderParticipation = value; }
        }

        string _senderContact;

        public string SenderContact
        {
            get { return _senderContact; }
            set { _senderContact = value; }
        }
    }
}
