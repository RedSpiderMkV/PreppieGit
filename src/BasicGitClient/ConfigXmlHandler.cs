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
        #region Public Methods

        public XmlHandler()
        {
            if (!File.Exists(configFile_m))
            {
                // Change this, message box shouldn't be shown here perhaps??
                System.Windows.Forms.MessageBox.Show("Credentials required");
                CredentialConfigureWindow credentialWindow = new CredentialConfigureWindow();
                credentialWindow.ShowDialog();

                string username = credentialWindow.Username;
                string password = credentialWindow.Password;

                if (!username.Equals(String.Empty) && !password.Equals(String.Empty))
                {
                    string xml = "<gitClient><credential><username></username>" +
                        "<password></password></credential><lastLocation></lastLocation></gitClient>";
                    File.WriteAllText(configFile_m, xml);

                    SetCredentials(username, password);
                }
            }
        }

        /// <summary>
        /// Retrieve the last directory the client was used in.
        /// </summary>
        /// <returns>Last working directory opened in this client if it exists on disk.</returns>
        public string GetLastLocation()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFile_m);
            
            XmlNode node = doc.FirstChild.ChildNodes[1];
            return Directory.Exists(node.InnerText) ? node.InnerText : string.Empty;
        }

        /// <summary>
        /// Save the current working directory to config file.
        /// </summary>
        /// <param name="currentLocation">Current working directory.</param>
        public void SetLastLocation(string currentLocation)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFile_m);

            foreach (XmlNode node in doc.FirstChild.ChildNodes)
            {
                if (String.Equals(node.Name, NodeLastLocation))
                {
                    node.InnerText = currentLocation;
                    doc.Save(configFile_m);
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
            doc.Load(configFile_m);

            foreach (XmlNode node in doc.FirstChild.ChildNodes[0].ChildNodes)
            {
                switch (node.Name)
                {
                    case NodeUsername:
                        username = node.InnerText;
                        break;
                    case NodePassword:
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
            doc.Load(configFile_m);

            foreach (XmlNode node in doc.FirstChild.ChildNodes[0].ChildNodes)
            {
                switch (node.Name)
                {
                    case NodeUsername:
                        node.InnerText = username;
                        break;
                    case NodePassword:
                        node.InnerText = password;
                        break;
                }
            }

            doc.Save(configFile_m);
        }

        #endregion

        #region Private Data

        // Location of configuration file.
        private const string configFile_m = "configuration.xml";
        private const string NodePassword = "password";
        private const string NodeUsername = "username";
        private const string NodeLastLocation = "lastLocation";

        #endregion
    } // end class
} // end namespace
