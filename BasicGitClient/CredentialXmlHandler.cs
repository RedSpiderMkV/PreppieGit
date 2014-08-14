using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BasicGitClient
{
    internal class CredentialXmlHandler
    {
        private readonly string credentialFile = "credentials.xml";

        public void getCredentials(out string username, out string password)
        {
            username = password = "";
            
            XmlDocument doc = new XmlDocument();
            doc.Load(credentialFile);

            foreach (XmlNode node in doc.FirstChild.ChildNodes)
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

        public void setCredentials(string username, string password)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(credentialFile);

            foreach (XmlNode node in doc.FirstChild.ChildNodes)
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
