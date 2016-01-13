using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatusLogger
{
    interface IStatusLogger
    {
        void LogStatus(string statusMessage);

        void LogException(Exception exception);
    } // end interface
} // end namespace
