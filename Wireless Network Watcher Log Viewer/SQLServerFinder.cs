/***
 * 
 * This class is used for finding sql servers and instances locally and remotely.
 * 
 */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WirelessNetWatcherLogViewer
{
    public class SQLServerFinder
    {
       [DllImport("netapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]

       // Create the NetServerEnum function definition.
        public static extern int NetServerEnum(
       string servername,
       int level,
       ref IntPtr bufptr,
       int prefmaxlen,
       out int entriesread,
       out int totalentries,
       int servertype,
       string domain,
       IntPtr resume_handle);

        // Import the NetAPI32 dll
        [DllImport("netapi32.dll", SetLastError = true)]
        public static extern int NetApiBufferFree(IntPtr buffer);

        // Create neccessary struct needed .
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SERVER_INFO_101
        {
            public int sv101_platform_id;
            public string sv101_name;
            public int sv101_version_major;
            public int sv101_version_minor;
            public int sv101_type;
            public string sv101_comment;
        }

        // The type of server to enumerate on the network. In this case look for a computer/server running a SQL server.
        private const int SV_TYPE_SQLSERVER = 0x00000004;

        // Get all of the SQL servers on the network.
        public List<string> getSQLServers()
        {
            List<string> servers = new List<string>();
            IntPtr buffer = IntPtr.Zero;
            int entriesRead, totalEntries;

            try
            {
                int ret = NetServerEnum(null, 101, ref buffer, -1, out entriesRead, out totalEntries, SV_TYPE_SQLSERVER, null, IntPtr.Zero);
                
                // If the server enermation for was successful, then added to the list of servers.
                if (ret == 0)
                {
                    for (int i = 0; i < entriesRead; i++)
                    {
                        var ptr = new IntPtr(buffer.ToInt64() + (i * Marshal.SizeOf(typeof(SERVER_INFO_101))));
                        var info = Marshal.PtrToStructure<SERVER_INFO_101>(ptr);
                        servers.Add(info.sv101_name);
                    }
                }
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                    NetApiBufferFree(buffer);
            }
            return servers;
        }

        // Get all of the SQL servers on the network asynchronously.
        public async Task<List<string>> getSQLServersAsyc()
        {
            return await Task.Run(() => getSQLServers());
        }

        // Get all the local SQL server instances installed on the local machine.
        private List<string> getLocalSQLInstances()
        {
            List<string> instances = new List<string>();

            try
            {
                RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey sqlKey = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");

                string[] installedInstances = (string[])sqlKey?.GetValue("InstalledInstances");

                // Add all of the local instances to the list.
                for (int i = 0; i < installedInstances.Length; i++)
                    instances.Add($"{Environment.MachineName}\\{installedInstances[i]}");
            }
            catch
            {
            }

            return instances;
        }

        // Get all of the remote SQL server instances on a remote machine.
        private List<string> getRemoteSQLServerInstances (string serverName)
        {
            List<string> instances = new List<string>();

            try
            {
                // Connect to the remote machine's HKLM hive
                var baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, serverName);
                var sqlKey = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");

                string[] instanceList = (string[])sqlKey?.GetValue("InstalledInstances");
                
                // If the add all of the SQL server instances installed on the remote computer.
                if (instanceList != null)
                {
                    foreach (string inst in instanceList)
                    {
                        string fullName = inst == "MSSQLSERVER" ? serverName : $"{serverName}\\{inst}";
                        instances.Add(fullName);
                    }
                }
            }
            catch 
            {
            }

            return instances;
        }

        // Get all of the SQL servers instances both local and remote.
        private List<string> getAllSQLServersAndInstances(bool includeRemoteInstances)
        {
            List<string> serversAndInstances = new List<string>();

            // Get all of the local instances.
            List<string> localInstances = getLocalSQLInstances();

            // Add all of the local instances to the list.
            foreach (string instance in localInstances)
                serversAndInstances.Add(instance);

            // If there are no remote instances, then just return the list of the local instances.
            if (!includeRemoteInstances)
                return serversAndInstances;

            // Get all SQL servers on the network.
            List<string> serverNames = getSQLServers();
            List<string> instances;

            // Add all of the remote instances to the list.
            foreach (string serverName in serverNames)
            {
                instances = getRemoteSQLServerInstances(serverName);

                foreach(string instance in instances)
                {
                    serversAndInstances.Add(instance);
                }
            }

            //  Return list of all local and remote SQL server instances on the network.
            return serversAndInstances;
        }

        // Get all of the SQL servers instances both local and remote asynchronously.
        public async Task<List<string>> getAllSQLServersAndInstancesAsync(bool includeRemoteInstances)
        {
            // Wait for the task to complete first before returning.
            return await Task.Run(() => getAllSQLServersAndInstances(includeRemoteInstances));
        }
    }
}
