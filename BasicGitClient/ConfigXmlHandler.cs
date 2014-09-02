using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace BasicGitClient
{
    internal class XmlHandler
    {
        #region Private Data

        // Location of configuration file.
        private const string configFile = "configuration.xml";
        
        #endregion

        #region Public Methods

        public XmlHandler()
        {
            if (!File.Exists(configFile))
            {
                string xml = "<gitClient><credential><username></username>" +
                    "<password></password></credential><lastLocation></lastLocation></gitClient>";
                File.WriteAllText(configFile, xml);

                System.Windows.Forms.MessageBox.Show("Credentials required");
                CredentialConfigureWindow credentialWindow = new CredentialConfigureWindow();
                credentialWindow.ShowDialog();

                string username = credentialWindow.Username;
                string password = credentialWindow.Password;

                SetCredentials(username, password);
            }
        }

        /// <summary>
        /// Retrieve the last directory the client was used in.
        /// </summary>
        /// <returns>Last working directory opened in this client.</returns>
        public string GetLastLocation()
        {
            string lastLocation = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(configFile);
            
            XmlNode node = doc.FirstChild.ChildNodes[1];
            lastLocation = node.InnerText;
            
            return lastLocation;
        }

        /// <summary>
        /// Save the current working directory to config file.
        /// </summary>
        /// <param name="currentLocation">Current working directory.</param>
        public void SetLastLocation(string currentLocation)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFile);

            foreach (XmlNode node in doc.FirstChild.ChildNodes)
            {
                if (String.Equals(node.Name, "lastLocation"))
                {
                    node.InnerText = currentLocation;
                    doc.Save(configFile);
                }
            }
        }

        /// <summary>
        /// Get credentials from the configuration file.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="password">Password.</param>
        public void GetCredentials(out string username, out string password)
        {
            username = password = "";
            
            XmlDocument doc = new XmlDocument();
            doc.Load(configFile);

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

        /// <summary>
        /// Save new credentials to the configuration file.
        /// </summary>
        /// <param name="username">New username.</param>
        /// <param name="password">New password.</param>
        public void SetCredentials(string username, string password)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFile);

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

            doc.Save(configFile);
        }

        #endregion

    }
}
