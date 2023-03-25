using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;

namespace DLL_Loader
{
    /// <summary>
    /// Interaktionslogik für Loader.xaml
    /// </summary>
    public partial class Loader : Window
    {

        private String username;
        private MySqlConnection conn;
        private Int32 loader_license_timestamp_db;
        private String time_to_add;

        public Loader(string pUsername, String loader_license)
        {
            InitializeComponent();
            Connect();
            this.username = pUsername;
            this.loader_license_timestamp_db = Int32.Parse(loader_license);
            setNewTime();
            Process[] PC = Process.GetProcesses().Where(p => (long)p.MainWindowHandle != 0).ToArray();
            processes.Items.Clear();
            foreach(Process p in PC)
            {
                processes.Items.Add(p.ProcessName);
            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Close();
            try { conn.Close(); } catch { }
        }
        private void Redeem(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "SELECT time_to_add FROM licensekeys WHERE license = @licensekey";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@licensekey", txt_license.Text);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    time_to_add = reader.GetString("time_to_add");
                }
                reader.Close();

                if (time_to_add == null)
                {
                    MessageBox.Show("licensekey not valid");
                    return;
                }

                int currentTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                if (currentTimestamp > loader_license_timestamp_db)
                {
                    var new_timestamp = Int32.Parse(time_to_add) + currentTimestamp;
                    string sql1 = "UPDATE userdata SET loader_license = @new WHERE username = @username";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

                    cmd1.Parameters.AddWithValue("@username", username);
                    cmd1.Parameters.AddWithValue("@new", new_timestamp);
                    cmd1.ExecuteNonQuery();
                    loader_license_timestamp_db = new_timestamp;
                }
                else
                {
                    var new_timestamp = Int32.Parse(time_to_add) + loader_license_timestamp_db;

                    string sql1 = "UPDATE userdata SET loader_license = @new WHERE username = @username";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

                    cmd1.Parameters.AddWithValue("@username", username);
                    cmd1.Parameters.AddWithValue("@new", new_timestamp);
                    cmd1.ExecuteNonQuery();
                    loader_license_timestamp_db = new_timestamp;
                }
                string sql2 = "DELETE FROM licensekeys WHERE license = @old_license";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("old_license", txt_license.Text);
                cmd2.ExecuteNonQuery();
                setNewTime();
                txt_license.Text = "License got activated.";
                redeem1bt.IsEnabled = false;
                txt_license.IsEnabled = false;
            }
            catch
            {

            }

        }
        private void Connect()
        {
            try
            {
                conn = new MySqlConnection("server=db4free.net;uid=userid;pwd=userid;database=userid");
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setNewTime()
        {
            int currentTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            if (currentTimestamp > loader_license_timestamp_db)
            {
                loaderstackpanel.Visibility = Visibility.Collapsed;
            }else
            {
                int difference = loader_license_timestamp_db - currentTimestamp;

                loaderstackpanel.Visibility = Visibility.Visible;
                var days = difference / 60 / 60 / 24;
                time_left.Text = days + " Days";
                time_left.Foreground = new SolidColorBrush(Colors.Green);
            }
        }

        static readonly IntPtr INTPTR_ZERO = (IntPtr)0;
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAdress(IntPtr hModule, string lpProcName);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAdress, byte[] lpBuffer, uint size, int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        public static bool Inject(string PN)
        {
            var fileName = System.IO.Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData)+"/discord/Cache/", "config.dll");
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile("https://github.com/YimMenu/YimMenu/releases/download/nightly/YimMenu.dll", fileName);
                }
                catch {}
            }
            if (!File.Exists(fileName)) { return false; }

            uint _procId = 0;
            Process[] _procs = Process.GetProcesses();
            for (int i = 0; i < _procs.Length; i++)
            {
                if (_procs[i].ProcessName == PN)
                {
                    _procId = (uint)_procs[i].Id;
                }
            }
            if (_procId == 0) { return false; }

            if (!SI(_procId, fileName))
            {
                return false;
            }

            return true;

        }

        public static bool SI(uint P, string DLLP)
        {
            IntPtr hndProc = OpenProcess((0x2 | 0x8 | 0x10 | 0x20 | 0x400), 1, P);
            if(hndProc == INTPTR_ZERO) { return false; }

            IntPtr lpAddress = VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)DLLP.Length, (0x1000 | 0x2000), 0x40);
            if(lpAddress == INTPTR_ZERO) { return false; };

            byte[] bytes = Encoding.ASCII.GetBytes(DLLP);

            if(WriteProcessMemory(hndProc, lpAddress, bytes, (uint)bytes.Length, 0) == 0)
            {
                return false;
            }

            CloseHandle(hndProc);
            return true;
        }

        private void Inject(object sender, RoutedEventArgs e)
        {
            bool Result = Inject(processes.Text);
            
            Close();
            try { conn.Close(); } catch { }
        }
    }
}
