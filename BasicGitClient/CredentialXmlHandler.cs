using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BasicGitClient
{
    internal class XmlHandler
    {
        private const string credentialFile = "configuration.xml";

        public string GetLastLocation()
        {
            string lastLocation = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(credentialFile);
            
            XmlNode node = doc.FirstChild.ChildNodes[1];
            lastLocation = node.InnerText;
            
            return lastLocation;
        }

        public void SetLastLocation(string lastLocation)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(credentialFile);

            foreach (XmlNode node in doc.FirstChild.ChildNodes)
            {
                if (String.Equals(node.Name, "lastLocation"))
                {
                    node.InnerText = lastLocation;
                    doc.Save(credentialFile);
                }
            }
        }

        public void GetCredentials(out string username, out string password)
        {
            username = password = "";
            
            XmlDocument doc = new XmlDocument();
            doc.Load(credentialFile);

            foreach (XmlNode node in doc.FirstChild.ChildNodes[0].ChildNodes)
            {
                switch (node.Name)
                {
                    case "username":
                        username = node.InnerText;
                        break;
                    case "password":
                        password = node.InnerText;
                        break;
                }
            }
        }

        public void SetCredentials(string username, string password)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(credentialFile);

            foreach (XmlNode node in doc.FirstChild.ChildNodes[0].ChildNodes)
            {
                switch (node.Name)
                {
                    case "username":
                        node.InnerText = username;
                        break;
                    case "password":
                        node.InnerText = password;
                        break;
                }
            }

            doc.Save(credentialFile);
        }
    }
}
