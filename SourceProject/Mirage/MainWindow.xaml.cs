using System;
using System.Collections.Generic;
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
// To access MetroWindow, add the following reference
using MahApps.Metro.Controls;
//needed libs for SQLite
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
//regex
using System.Text.RegularExpressions;

namespace Mirage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        //глобальная переменная для подключения к бд
        string global_constr = @"Data Source=db/mirage.sqlite;Version=3;Password=monksilentmirage;"; //Password=monksilentmirage; conn.ChangePassword("new_password");
        //глобальный адаптер
        SQLiteDataAdapter adapter;

        public MainWindow()
        {
            InitializeComponent();

            /*if (!File.Exists(@"db/mirage.db")) { MessageBox.Show("Базы данных паролей не было обнаружено, она была создана (на данный момент пуста)."); }
            DbCrypt.DecryptDatabase();*/

            string constr = global_constr;
            SQLiteConnection conn = new SQLiteConnection(constr);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM `accounts`;";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        List<FirstTable> result = new List<FirstTable>(7);
                        while (rdr.Read())
                        {
                            result.Add(new FirstTable(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString()));
                        }
                        account_grid.ItemsSource = result;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();


            //новое подключение, формирующее вторую таблицу (редактируемую)
            constr = global_constr;
            conn = new SQLiteConnection(constr);
            try
            {
                conn.Open();

                string sql = "SELECT * FROM `accounts`;";
                adapter = new SQLiteDataAdapter(sql, conn);

                SQLiteDataAdapter da1 = new SQLiteDataAdapter(sql, conn);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                edit_datagrid.DataContext = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();


            //Some code
            //connection.Close();*/

        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*DbCrypt.EncryptDatabase();*/
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            /*//first use
            string conn = @"Data Source=db/mirage.sqlite;";
            SQLiteConnection connection = new SQLiteConnection(conn);
            connection.Open();
            //Some code
            connection.ChangePassword("monksilentmirage");
            connection.Close();*/

            /*//EVERY USE CONNECT
            string conn = @"Data Source=db/mirage.sqlite;Password=monksilentmirage;";
            SQLiteConnection connection = new SQLiteConnection(conn);
            connection.Open();
            connection.ChangePassword(String.Empty);
            //Some code
            //connection.Close();*/

            //for reset pass: conn.ChangePassword(String.Empty);
        }

        //при загрузке парсим базу селектами с помощью ридера и формируем датагрид
        private void account_grid_Loaded(object sender, RoutedEventArgs e)
        {
            /*List<FirstTable> result = new List<FirstTable>(7);
            result.Add(new FirstTable(1, "Steam.com", "Monk", "sqlithebest", "datagrid@wpf.com", "site http://steamcommunity.com, regdata 12.12.2012", "games"));
            account_grid.ItemsSource = result;*/
        }

        //защита от подсматривания
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            account_grid.Visibility = Visibility.Hidden;
            edit_datagrid.Visibility = Visibility.Hidden;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            account_grid.Visibility = Visibility.Visible;
            edit_datagrid.Visibility = Visibility.Visible;
        }

        //добавление новых аккаунтов в базу
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textbox_resourse.Text != "" && textbox_username.Text != "" && textbox_password.Text != "")
            {
                string constr = global_constr;
                SQLiteConnection conn = new SQLiteConnection(constr);

                try
                {
                    conn.Open();

                    string sql = "INSERT INTO `accounts` (`resourse`, `username`, `password`, `email`, `information`, `type`) VALUES ('"+ remove_spec_chars(textbox_resourse.Text) + "', '" + remove_spec_chars(textbox_username.Text) + "', '" + remove_spec_chars(textbox_password.Text) + "', '" + remove_spec_chars(textbox_email.Text) + "', '" + remove_spec_chars(textbox_inform.Text) + "', '" + remove_spec_chars(textbox_type.Text) + "');";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    //popup message
                    var messageQueue = SnackbarThree.MessageQueue;
                    //the message queue can be called from any thread
                    Task.Factory.StartNew(() => messageQueue.Enqueue("Completed"));

                    textbox_resourse.Text = "";
                    textbox_username.Text = "";
                    textbox_password.Text = "";
                    textbox_email.Text = "";
                    textbox_inform.Text = "";
                    textbox_type.Text = "";

                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Resourse, username and password fields must not be empty");
            }

        }

        public string remove_spec_chars(string str)
        {
            str = str.Replace("'", "");
            str = str.Replace("&", "");
            str = str.Replace("%", "");
            str = str.Replace("^", "");
            //str.Replace("_", ""); can used in nicknames
            str = str.Replace("[", "");
            str = str.Replace("]", "");
            str = str.Replace("|", "");
            str = str.Replace("*", "");
            str = str.Replace("+", "");

            return str;
        }

        //кнопка обновления первой таблицы
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";

            string constr = global_constr;
            SQLiteConnection conn = new SQLiteConnection(constr);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM `accounts`;";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        List<FirstTable> result = new List<FirstTable>(7);
                        
                        while (rdr.Read())
                        {
                            result.Add(new FirstTable(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString()));
                        }
                        account_grid.ItemsSource = result;
                    }
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string constr = global_constr;
            SQLiteConnection conn = new SQLiteConnection(constr);

            try
            {
                conn.Open();

                string sql = textbox_sql.Text;

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    //object amount = cmd.ExecuteScalar().ToString();
                    textBlock.Text = "ExecuteNonQuery return: " + cmd.ExecuteNonQuery().ToString();
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            
            conn.Close();
        }

        private void edit_datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            /*var sqlConnection = new SQLiteConnection("Data Source=db/mirage.sqlite;; Version = 3");
            sqlConnection.Open();

            var sqlCommand = new SQLiteCommand("SELECT * FROM `accounts`;", sqlConnection);
            sqlCommand.ExecuteNonQuery();

            var dataTable = new DataTable("List");
            var sqlAdapter = new SQLiteDataAdapter(sqlCommand);
            //Автоматически сформируем команды обновления данных 
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(sqlAdapter);
            sqlAdapter.Fill(dataTable);

            edit_datagrid.ItemsSource = dataTable.DefaultView;
            sqlAdapter.Update(dataTable);

            sqlConnection.Close();*/
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            adapter.Update((DataTable)edit_datagrid.DataContext);//обновляет БД
        }

        //поиск по первой таблице
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string constr = global_constr;
            SQLiteConnection conn = new SQLiteConnection(constr);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM `accounts` WHERE ID LIKE '%" + SearchBox.Text + "%' OR resourse LIKE '%" + SearchBox.Text + "%' OR username LIKE '%" + SearchBox.Text + "%' OR password LIKE '%" + SearchBox.Text + "%' OR email LIKE '%" + SearchBox.Text + "%' OR information LIKE '%" + SearchBox.Text + "%' OR type LIKE '%" + SearchBox.Text + "%';";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        List<FirstTable> result = new List<FirstTable>(7);
                        while (rdr.Read())
                        {
                            result.Add(new FirstTable(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString()));
                        }
                        account_grid.ItemsSource = result;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        //обновление второй таблицы
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SearchBox2.Text = "";

            string constr = global_constr;
            SQLiteConnection conn = new SQLiteConnection(constr);
            try
            {
                conn.Open();

                string sql = "SELECT * FROM `accounts`;";
                adapter = new SQLiteDataAdapter(sql, conn);

                SQLiteDataAdapter da1 = new SQLiteDataAdapter(sql, conn);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                edit_datagrid.DataContext = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        //поиск по второй таблице
        private void SearchBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string constr = global_constr;
            SQLiteConnection conn = new SQLiteConnection(constr);
            try
            {
                conn.Open();

                string sql = "SELECT * FROM `accounts` WHERE ID LIKE '%" + SearchBox2.Text + "%' OR resourse LIKE '%" + SearchBox2.Text + "%' OR username LIKE '%" + SearchBox2.Text + "%' OR password LIKE '%" + SearchBox2.Text + "%' OR email LIKE '%" + SearchBox2.Text + "%' OR information LIKE '%" + SearchBox2.Text + "%' OR type LIKE '%" + SearchBox2.Text + "%';";
                adapter = new SQLiteDataAdapter(sql, conn);

                SQLiteDataAdapter da1 = new SQLiteDataAdapter(sql, conn);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                edit_datagrid.DataContext = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

    }

    class FirstTable
    {
        public FirstTable(int Id, string Resourse, string Username, string Password, string Email, string Information, string Type)
        {
            this.Id = Id;
            this.Resourse = Resourse;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.Information = Information;
            this.Type = Type;
        }
        public int Id { get; set; }
        public string Resourse { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Information { get; set; }
        public string Type { get; set; }
    }

    //класс для работы с RC4
    static class DbCrypt
    {
        static string DataBasePath = @"db/mirage.db";
        static string CryptoKey = "monksilentmirage";

        public static void EncryptDatabase()
        {
            //механизм шифрования
            Encoding ANSI = Encoding.GetEncoding(1252);

            StreamReader sr = new StreamReader(DataBasePath, ANSI);
            string sourcefile = sr.ReadToEnd();
            sr.Close();
            byte[] key = ANSI.GetBytes(CryptoKey);
            //процесс шифрования
            RC4 encoder = new RC4(key);
            byte[] SourceBytes = ANSI.GetBytes(sourcefile);
            byte[] result = encoder.Encode(SourceBytes, SourceBytes.Length);
            string encryptedString = ANSI.GetString(result);
            StreamWriter sw = new StreamWriter(@"db/mirage.db", false, ANSI);
            sw.WriteLine(encryptedString);
            sw.Close();
        }

        public static void DecryptDatabase()
        {
            //механизм расшифровки
            Encoding ANSI = Encoding.GetEncoding(1252);

            StreamReader sr = new StreamReader(DataBasePath, ANSI);
            string sourcefile = sr.ReadToEnd();
            sr.Close();
            byte[] key = ANSI.GetBytes(CryptoKey);
            RC4 decoder = new RC4(key);
            byte[] SourceBytes = ANSI.GetBytes(sourcefile);
            byte[] decryptedBytes = decoder.Decode(SourceBytes, SourceBytes.Length);
            string decryptedString = ANSI.GetString(decryptedBytes);
            StreamWriter sw = new StreamWriter(@"db/mirage.db", false, ANSI);
            sw.WriteLine(decryptedString);
            sw.Close();
        }
    }

    //ARCFOUR
    public class RC4
    {
        byte[] S = new byte[256];

        int x = 0;
        int y = 0;

        public RC4(byte[] key)
        {
            init(key);
        }

        // Key-Scheduling Algorithm 
        // Алгоритм ключевого расписания 
        private void init(byte[] key)
        {
            int keyLength = key.Length;

            for (int i = 0; i < 256; i++)
            {
                S[i] = (byte)i;
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + key[i % keyLength]) % 256;
                S.Swap(i, j);
            }
        }

        public byte[] Encode(byte[] dataB, int size)
        {
            byte[] data = dataB.Take(size).ToArray();

            byte[] cipher = new byte[data.Length];

            for (int m = 0; m < data.Length; m++)
            {
                cipher[m] = (byte)(data[m] ^ keyItem());
            }

            return cipher;
        }
        public byte[] Decode(byte[] dataB, int size)
        {
            return Encode(dataB, size);
        }

        // Pseudo-Random Generation Algorithm 
        // Генератор псевдослучайной последовательности 
        private byte keyItem()
        {
            x = (x + 1) % 256;
            y = (y + S[x]) % 256;

            S.Swap(x, y);

            return S[(S[x] + S[y]) % 256];
        }
    }

    static class SwapExt
    {
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }




}
