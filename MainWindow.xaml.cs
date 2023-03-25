using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DLL_Loader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySqlConnection conn;
        private String dbPassword;
        private String loader_license;
        public MainWindow()
        {
            InitializeComponent();
            Connect();
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
        private void Login(object sender, RoutedEventArgs e)
        {
            if (txt_username.Text != null && txt_password.Password != null)
            {
                ManageLogin();
            }
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (txt_username.Text != null && txt_password.Password != null)
                {
                    ManageLogin();
                }
            }
        }
        private void ManageLogin()
        {
            try
            {
                String username = txt_username.Text;
                String password = txt_password.Password;

                string sql = "SELECT password, loader_license FROM userdata WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dbPassword = reader.GetString("password");
                    loader_license = reader.GetString("loader_license");
                }
                reader.Close();

                if (dbPassword == null)
                {
                    MessageBox.Show("Wrong Username or Password!");
                    return;
                }
                // HOW TO HASH A PASSWORD -> BCrypt.Net.BCrypt.HashPassword(-> PLAIN TEXT OF THE PASSWORD IN HERE ->);
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, dbPassword);
                if(isValidPassword)
                {
                    dbPassword = null;
                    Loader loader = new Loader(username, loader_license);
                    loader.Show();
                    Close();
                    try { conn.Close(); } catch { }
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("LOGIN | Please contact support!");
                Console.Write(ex);
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
    }
}
