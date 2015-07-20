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

        public XmlHandler(UIEventManager eventManager)
        {
            eventManager_m = eventManager;
            eventManager_m.OnNewCredentials += new UIEventManager.NewCredentialsEvent(eventManager_m_OnNewCredentials);

            if (!File.Exists(configFile_m))
            {
                string xml = "<gitClient><credential><username></username>" +
                        "<password></password></credential><lastLocation></lastLocation></gitClient>";
                File.WriteAllText(configFile_m, xml);

                eventManager_m.TriggerUpdateCredentialsEvent(true);
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
                } // end switch
            } // end foreach

            doc.Save(configFile_m);
        }

        #endregion

        #region Private Methods

        private void eventManager_m_OnNewCredentials(string username, string password)
        {
            SetCredentials(username, password);
        } // end method

        #endregion

        #region Private Data

        // Location of configuration file.
        private const string configFile_m = "configuration.xml";
        private const string NodePassword = "password";
        private const string NodeUsername = "username";
        private const string NodeLastLocation = "lastLocation";

        private UIEventManager eventManager_m;

        #endregion
    } // end class
} // end namespace
