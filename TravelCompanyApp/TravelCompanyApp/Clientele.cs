using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Configuration;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TravelCompanyApp
{
    public partial class Clientele : Form
    {
        List<Client> clientList = new List<Client>();

        private static readonly NpgsqlConnection Connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["pgConnect"].ConnectionString);//строка соединения

        Start start;

        Client clientCl = new Client();

        public Clientele(Start s)
        {
            Connection.Open();
            start = s;
            InitializeComponent();

            textBox_search.ForeColor = SystemColors.GrayText;
            textBox_search.Text = "Введите номер телефона клиента";
            this.textBox_search.Leave += new System.EventHandler(this.textBox_search_Leave);
            this.textBox_search.Enter += new System.EventHandler(this.textBox_search_Enter);      
        }

        void LoadData()//загружаем данные
        {
            using (var cmd = new NpgsqlCommand("SELECT id_client, surname, name_client, middle_name, phone, email, address FROM clientle", Connection))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        Client client = new Client();
                        var idClient = reader["id_client"].ToString().Trim();
                        client.idClient = Int32.Parse(idClient);
                        client.surname = reader["surname"].ToString().Trim();
                        client.nameClient = reader["name_client"].ToString().Trim();
                        client.middlenameClient = reader["middle_name"].ToString().Trim();                      
                        client.phone = reader["phone"].ToString();
                        client.email = reader["email"].ToString().Trim();

                        Address address = new Address();
                        string addressCl = reader["address"].ToString().Trim();
                        string a = addressCl.Replace('\"', '\'');
                        Address adr = JsonConvert.DeserializeObject<Address>(a);
                        textBoxCity.Text = adr.city;
                        var cit = textBoxCity.Text.ToString().Trim();
                        textBoxStreet.Text = adr.street;
                        var str = textBoxStreet.Text.ToString().Trim();
                        textBoxHouse.Text= adr.house;
                        var ho = textBoxHouse.Text.ToString().Trim();
                        textBoxFlat.Text = adr.flat;
                        var fl = textBoxFlat.Text.ToString().Trim();
                        client.address = singleAddress(cit, str, ho, fl);
                        clientList.Add(client);
                    }
            }
        }

        public String singleAddress(String a, String b, String c, String d)
        {
            a ="г. " + a + " ул. " + b + " д. " + c + " кв. " + d;
            return a;
        }

        void FillDGV()//заполнить таблицу
        {
            for (int i = 0; i <= 6; i++)
            {
                DataGridViewTextBoxColumn cl = new DataGridViewTextBoxColumn();
                dataGridView1.Columns.Add(cl);
            }
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Телефон";
            dataGridView1.Columns[5].HeaderText = "E-mail";
            dataGridView1.Columns[6].HeaderText = "Адрес";
            dataGridView1.Columns[5].Width = 130;
            dataGridView1.Columns[6].Width = 240;

            foreach (var el in clientList)
            {
                //el - userList[i] - бежим по списку элементов
                //ячейки удалить и изменить
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.Height = 32;

                var idcl = el.idClient;
                DataGridViewCell dGVCell = new DataGridViewTextBoxCell();
                dGVCell.Value = idcl;
                dataGridViewRow.Cells.Add(dGVCell);

                var surcl = el.surname;
                DataGridViewCell dGVCell0 = new DataGridViewTextBoxCell();
                dGVCell0.Value = surcl;
                dataGridViewRow.Cells.Add(dGVCell0);

                var namecl = el.nameClient;
                DataGridViewCell dGVCell1 = new DataGridViewTextBoxCell();
                dGVCell1.Value = namecl;
                dataGridViewRow.Cells.Add(dGVCell1);

                var middlecl = el.middlenameClient;
                DataGridViewCell dGVCell2 = new DataGridViewTextBoxCell();
                dGVCell2.Value = middlecl;
                dataGridViewRow.Cells.Add(dGVCell2);

                var phonecl = el.phone;
                DataGridViewCell dGVCell3 = new DataGridViewTextBoxCell();
                dGVCell3.Value = phonecl;
                dataGridViewRow.Cells.Add(dGVCell3);

                var emailcl = el.email;
                DataGridViewCell dGVCell4 = new DataGridViewTextBoxCell();
                dGVCell4.Value = emailcl;
                dataGridViewRow.Cells.Add(dGVCell4);

                var addresscl = el.address;
                DataGridViewCell dGVCell5 = new DataGridViewTextBoxCell();
                dGVCell5.Value = addresscl;
                dataGridViewRow.Cells.Add(dGVCell5);

                dataGridView1.Rows.Add(dataGridViewRow);
            }
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    var domainName = idn.GetAscii(match.Groups[2].Value);              
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void Clientele_Load(object sender, EventArgs e)
        {
            LoadData();
            FillDGV();
            textBoxCity.Clear();
            textBoxStreet.Clear();
            textBoxHouse.Clear();
            textBoxFlat.Clear();
            textBoxSurname.Clear();
            textBoxName.Clear();
            textBoxMiddleName.Clear();
            textBoxPhone.Clear();
            textBoxEmail.Clear();
        }

        public void AddClientle(Client clientCl)//добавляем новый 
        {
            clientList.Clear();
            dataGridView1.Refresh();          
            LoadData();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        }

        public void UpdateClientle(Client clientCl)//обновляем 
        {
            clientList.Clear();
            LoadData();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        } 

        private void button_search_Click(object sender, EventArgs e)
        {
            if(textBox_search.Text.Length !=11)
            {
                MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                clientList.Clear();
                using (var cmdId = new NpgsqlCommand($"SELECT search_client('{textBox_search.Text.ToString().Trim()}')", Connection))
                {
                    int idCl = Convert.ToInt32(cmdId.ExecuteScalar());
                    if (idCl > 0)
                    {
                        using (var cmd = new NpgsqlCommand($"SELECT *from clientle WHERE id_client = {idCl}", Connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var clientCl = new Client();                                   
                                    clientCl.surname = reader["surname"].ToString().Trim();
                                    clientCl.nameClient = reader["name_client"].ToString().Trim();
                                    clientCl.middlenameClient = reader["middle_name"].ToString().Trim();
                                    clientCl.email = reader["email"].ToString().Trim();

                                    Address address = new Address();
                                    string addressCl = reader["address"].ToString().Trim();
                                    string a = addressCl.Replace('\"', '\'');
                                    Address adr = JsonConvert.DeserializeObject<Address>(a);
                                    string cit = adr.city;
                                    string str = adr.street;
                                    string ho = adr.house;
                                    string fl = adr.flat;
                                    clientCl.address = singleAddress(cit, str, ho, fl);
                                    clientCl.phone = reader["phone"].ToString().Trim();
                                    clientList.Add(clientCl);
                                }
                            }
                        }

                        FillDGV();
                        MessageBox.Show("Совпадения найдены!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Совпадений не найдено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }                
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Вы не выбрали ни одной строки для редактирования! Выберите строку в таблице!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if ((textBoxSurname.Text.Length <= 1) ||
                (textBoxName.Text.Length <= 1) ||
                (textBoxMiddleName.Text.Length <= 1) ||
                (textBoxEmail.Text.Length <= 7) ||
                (IsValidEmail(textBoxEmail.Text.ToString()) == false) ||
                (textBoxPhone.Text.Length != 11) ||
                (textBoxCity.Text.Length < 1) ||
                (textBoxStreet.Text.Length < 1) ||
                (textBoxHouse.Text.Length < 1) ||
                (textBoxFlat.Text.Length < 1))
                {
                    MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (var cmd = new NpgsqlCommand($"SELECT id_client FROM clientle WHERE id_client = {dataGridView1.SelectedRows[0].Cells[0].Value}", Connection))
                    {
                        int idSelCl = Convert.ToInt32(cmd.ExecuteScalar());

                        Address address = new Address();
                        address.city = textBoxCity.Text.ToString().Trim();
                        address.street = textBoxStreet.Text.ToString().Trim();
                        address.house = textBoxHouse.Text.ToString().Trim();
                        address.flat = textBoxFlat.Text.ToString().Trim();
                        string jsonAdress = JsonConvert.SerializeObject(address);

                        using (var cmdUp = new NpgsqlCommand($"UPDATE clientle SET surname = '{textBoxSurname.Text.Trim()}', name_client = '{textBoxName.Text.Trim()}', " +
                        $"middle_name = '{textBoxMiddleName.Text.Trim()}', email = '{textBoxEmail.Text.Trim()}', address = '{jsonAdress}', phone = '{textBoxPhone.Text.Trim()}' " +
                        $"WHERE id_client = {idSelCl}", Connection))
                        {
                            cmdUp.ExecuteNonQuery();
                        }
                        clientCl.surname = textBoxSurname.Text.Trim();
                        clientCl.nameClient = textBoxName.Text.Trim();
                        clientCl.middlenameClient = textBoxMiddleName.Text.Trim();
                        clientCl.email = textBoxEmail.Text.Trim();
                        clientCl.phone = textBoxPhone.Text.Trim();
                        clientCl.address = singleAddress(textBoxCity.Text.ToString().Trim(), textBoxStreet.Text.ToString().Trim(), textBoxHouse.Text.ToString().Trim(), textBoxFlat.Text.ToString().Trim());
                        UpdateClientle(clientCl);
                        dataGridView1.Refresh();
                        MessageBox.Show("Данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if ((textBoxSurname.Text.Length <= 1) ||
                (textBoxName.Text.Length <= 1) ||
                (textBoxMiddleName.Text.Length <= 1) ||
                (textBoxEmail.Text.Length <= 7) ||
                (IsValidEmail(textBoxEmail.Text.ToString()) == false) ||
                (textBoxPhone.Text.Length != 11) ||
                (textBoxCity.Text.Length < 1) ||
                (textBoxStreet.Text.Length < 1) ||
                (textBoxHouse.Text.Length < 1) ||
                (textBoxFlat.Text.Length < 1))
            {
                MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Address address = new Address();
                address.city = textBoxCity.Text.ToString().Trim();
                address.street = textBoxStreet.Text.ToString().Trim();
                address.house = textBoxHouse.Text.ToString().Trim();
                address.flat = textBoxFlat.Text.ToString().Trim();
                string jsonAdress = JsonConvert.SerializeObject(address);

                using (var cmdPh = new NpgsqlCommand($"SELECT id_client FROM clientle WHERE phone = '{textBoxPhone.Text.ToString().Trim()}'", Connection))
                {
                    var idClp = Convert.ToInt32(cmdPh.ExecuteScalar());
                    if(idClp > 0)
                    {
                        MessageBox.Show("Такой клиент уже существует в базе!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
 using (var cmdInto = new NpgsqlCommand($"INSERT INTO clientle(surname, name_client, middle_name, email, address, phone) " +
                    $"values ('{textBoxSurname.Text.ToString().Trim()}', '{textBoxName.Text.ToString().Trim()}', '{textBoxMiddleName.Text.ToString().Trim()}', '{textBoxEmail.Text.ToString().Trim()}', " +
                    $"'{jsonAdress}', '{textBoxPhone.Text.ToString().Trim()}')", Connection))
                {
                    cmdInto.ExecuteNonQuery();
                }
                clientCl.surname = textBoxSurname.Text.Trim();
                clientCl.nameClient = textBoxName.Text.Trim();
                clientCl.middlenameClient = textBoxMiddleName.Text.Trim();
                clientCl.email = textBoxEmail.Text.Trim();
                clientCl.address = singleAddress(textBoxCity.Text.ToString().Trim(), textBoxStreet.Text.ToString().Trim(), textBoxHouse.Text.ToString().Trim(), textBoxFlat.Text.ToString().Trim());
                clientCl.phone = textBoxPhone.Text.Trim();
                clientList.Add(clientCl);
                dataGridView1.Refresh();
                AddClientle(clientCl);
                MessageBox.Show("Новый клиент успешно добавлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Connection.Close();
            Close();
        }

        private void button_show_table_Click(object sender, EventArgs e)
        {
            Connection.Close();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            clientList.Clear();
            Connection.Open();
            Clientele_Load(sender, e);
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Connection.Close();
            start.Show();
            this.Hide();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            int idCl = 0;
            if (dataGridView1.SelectedRows.Count != 0)//выбрана строка
            {
                using (var cmd = new NpgsqlCommand($"SELECT *from clientle WHERE id_client = {dataGridView1.SelectedRows[0].Cells[0].Value}", Connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idCl = reader.GetInt32(0);
                            textBoxSurname.Text = reader.GetString(1);
                            textBoxName.Text = reader.GetString(2);
                            textBoxMiddleName.Text = reader.GetString(3);
                            textBoxEmail.Text = reader.GetString(4);
                            Address address = new Address();
                            string addressCl = reader.GetString(5);
                            string a = addressCl.Replace('\"', '\'');
                            Address adr = JsonConvert.DeserializeObject<Address>(a);
                            textBoxCity.Text = adr.city;
                            var cit = textBoxCity.Text.ToString().Trim();
                            textBoxStreet.Text = adr.street;
                            var str = textBoxStreet.Text.ToString().Trim();
                            textBoxHouse.Text = adr.house;
                            var ho = textBoxHouse.Text.ToString().Trim();
                            textBoxFlat.Text = adr.flat;
                            var fl = textBoxFlat.Text.ToString().Trim();
                            textBoxPhone.Text = reader.GetString(6);
                        }
                    }
                }
            }
        }

        private void Clientele_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.Close();
            start.Close();
        }

        private void textBox_search_Leave(object sender, EventArgs e)
        {
             if (textBox_search.Text.Length == 0)
            {
                textBox_search.Text = "Введите номер телефона клиента";
                textBox_search.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox_search_Enter(object sender, EventArgs e)
        {
            if (textBox_search.Text == "Введите номер телефона клиента")
            {
                textBox_search.Text = "";
                textBox_search.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if(!Char.IsDigit(num) && num != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBoxHouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBoxFlat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }

        }

        private void textBox_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }

    public class Address
    {
        public String city;
        public String street;
        public String house;
        public String flat;
    }


    public class Client
    {
        public int idClient;
        public String surname;
        public String nameClient;
        public String middlenameClient;
        public String phone;
        public String email;
        public String address;
    }
}
