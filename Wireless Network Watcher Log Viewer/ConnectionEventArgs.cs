/*
 * 
 *  Used for passing connection event info from one class to the other.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirelessNetWatcherLogViewer
{
    public class ConnectionEventArgs
    {
        public Dictionary<string, string> connectionInfo;

        public ConnectionEventArgs(Dictionary<string, string> connectionInfo)
        {
            this.connectionInfo = connectionInfo;
        }
    }
}
