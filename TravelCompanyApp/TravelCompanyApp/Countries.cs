using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Npgsql;

namespace TravelCompanyApp 
{
    public partial class Countries : Form
    {
        List<CountryCity> countryCityList = new List<CountryCity>();//создали список для пользователей
        private List<int> _countriesId = new List<int>();//список айдишников маршрутов

        CountryCity countryCity = new CountryCity();

        String imgDelete = @"C:\Users\Любовь\Desktop\Учеба\СУБД PostgreSQL\TravelCompanyApp\del.png";

        Start start;

        private static readonly NpgsqlConnection Connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["pgConnect"].ConnectionString);//строка соединения

        public Countries(Start s)
        {
            Connection.Open();
            start = s;
            InitializeComponent();

            textBox_search.ForeColor = SystemColors.GrayText;
            textBox_search.Text = "Введите название города";
            this.textBox_search.Leave += new System.EventHandler(this.textBox_search_Leave);
            this.textBox_search.Enter += new System.EventHandler(this.textBox_search_Enter);
        }

        void FillComboboxNameCountry()
        {
            using (var cmd = new NpgsqlCommand("SELECT id_country, name_country FROM countries ORDER BY name_country ASC", Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _countriesId.Add(reader.GetInt32(0));
                        comboBox_name_countries.Items.Add(reader.GetString(1));
                    }
                    comboBox_name_countries.SelectedIndex = 0;
                }
            }
        }

        void LoadData()//загрузили данные
        {
            using (var cmd = new NpgsqlCommand($"Select distinct countries.id_country, id_city, name_country, name_city FROM countries, cities WHERE countries.id_country = cities.id_country", Connection))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var countryCity = new CountryCity();
                        var idCountries = reader["id_country"].ToString().Trim();
                        countryCity.idCountry = Int32.Parse(idCountries);
                        var idCities = reader["id_city"].ToString().Trim();
                        countryCity.idCity = Int32.Parse(idCities);
                        countryCity.nameCountry = reader["name_country"].ToString().Trim();
                        countryCity.nameCity = reader["name_city"].ToString().Trim();   
                        countryCityList.Add(countryCity);
                    }
            }
        }

        void FillDGV()//вывели в таблицу
        {
            DataGridViewImageColumn imgC = new DataGridViewImageColumn();
            dataGridView1.Columns.AddRange(imgC);

            for (int i = 0; i <= 4; i++)
            {
                DataGridViewTextBoxColumn cl = new DataGridViewTextBoxColumn();
                dataGridView1.Columns.Add(cl);
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Страна";
            dataGridView1.Columns[4].HeaderText = "Город";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[0].Width = 32;
            dataGridView1.Columns[3].Width = 198;
            dataGridView1.Columns[4].Width = 198;

            foreach (var el in countryCityList)
            {
                //el - userList[i] - бежим по списку элементов
                //ячейки удалить и изменить
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.Height = 32;

                //создаём кнопки редак и удал
                DataGridViewImageCell dataGridViewCell = new DataGridViewImageCell();
                var idel = Image.FromFile(imgDelete);
                dataGridViewCell.Value = idel;
                dataGridViewRow.Cells.Add(dataGridViewCell);

                imgC.Width = 32;

                var idCoun = el.idCountry;
                DataGridViewCell dGVCell = new DataGridViewTextBoxCell();
                dGVCell.Value = idCoun;
                dataGridViewRow.Cells.Add(dGVCell);

                var idCit = el.idCity;
                DataGridViewCell dGVCell0 = new DataGridViewTextBoxCell();
                dGVCell0.Value = idCit;
                dataGridViewRow.Cells.Add(dGVCell0);

                var nameCoun = el.nameCountry;
                DataGridViewCell dGVCell1 = new DataGridViewTextBoxCell();
                dGVCell1.Value = nameCoun;
                dataGridViewRow.Cells.Add(dGVCell1);

                var nameCit = el.nameCity;
                DataGridViewCell dGVCell2 = new DataGridViewTextBoxCell();
                dGVCell2.Value = nameCit;
                dataGridViewRow.Cells.Add(dGVCell2);

                dataGridView1.Rows.Add(dataGridViewRow);
            }
        }

        private void Countries_Load(object sender, EventArgs e)
        {
            FillComboboxNameCountry();
            LoadData();
            FillDGV();
        }

        public void AddCities(CountryCity countryCity)//добавляем новый город
        {
            countryCityList.Add(countryCity);
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        }

        public void UpdateCities(CountryCity countryCity)//обновляем город
        {
            countryCityList.Clear();
            LoadData();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        }

        private void button_add_Click(object sender, EventArgs e)//добавляем новый город кнопка
        {
            using (var cmd = new NpgsqlCommand($"SELECT COUNT(*) FROM cities WHERE name_city = '{textBox_cities.Text}'", Connection))
            {
                int numberMatches = Convert.ToInt32(cmd.ExecuteScalar());
                if (numberMatches > 0)
                {
                    MessageBox.Show("Такой город уже существует!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if ((textBox_cities.Text.Length <= 2) || (textBox_cities.Text.Length >= 20))
                    {
                        MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var comboIdСountries = comboBox_name_countries.SelectedIndex + 1;
                        dynamic idCo = comboIdСountries;
                        var idCountr = idCo;

                        using (var cmdInto = new NpgsqlCommand($"INSERT INTO cities(id_country, name_city) values ({idCountr}, '{textBox_cities.Text}')", Connection))
                        {
                            cmdInto.ExecuteNonQuery();
                        }
                        countryCity.nameCity = textBox_cities.Text;
                        countryCity.idCountry = idCountr;
                        using (var cmdNameRole = new NpgsqlCommand($"SELECT name_country FROM countries WHERE id_country = {idCountr}", Connection))
                        {
                            using (var read = cmdNameRole.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    countryCity.nameCountry = read["name_country"].ToString().Trim();
                                }
                            }
                        }
                        dataGridView1.Refresh();
                        AddCities(countryCity);
                        MessageBox.Show("Новый город успешно добавлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)//обновить - изменить-сохранить данные уже существующие
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Вы не выбрали ни одной строки для редактирования! Выберите строку в таблице!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                if ((textBox_cities.Text.Length <= 2) || (textBox_cities.Text.Length >= 20))
                {
                    MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var comboNameСountry = comboBox_name_countries.SelectedItem;

                    using (var cmdIdCo = new NpgsqlCommand($"SELECT id_country FROM countries WHERE name_country = '{comboNameСountry}'", Connection))
                    {
                        countryCity.idCountry = Convert.ToInt32(cmdIdCo.ExecuteScalar());
                    }
                    var IdCountr = countryCity.idCountry;

                    using (var cmd = new NpgsqlCommand($"SELECT id_city FROM cities WHERE id_city = {dataGridView1.SelectedRows[0].Cells[2].Value}", Connection))
                    {
                        int idCitySelsec = Convert.ToInt32(cmd.ExecuteScalar());

                        using (var cmdUp = new NpgsqlCommand($"UPDATE cities SET id_country = {IdCountr}, name_city = '{textBox_cities.Text.Trim()}'" +
                        $"WHERE id_city = {idCitySelsec}", Connection))
                        {
                            cmdUp.ExecuteNonQuery();
                        }
                        countryCity.nameCity = textBox_cities.Text.Trim();
                        countryCity.idCountry = IdCountr;
                        using (var cmdNameRole = new NpgsqlCommand($"SELECT name_country FROM countries WHERE id_country = {countryCity.idCountry}", Connection))
                        {
                            using (var read = cmdNameRole.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    countryCity.nameCountry = read["name_country"].ToString().Trim();
                                }
                            }
                        }
                    }
                    UpdateCities(countryCity);
                    dataGridView1.Refresh();
                    MessageBox.Show("Данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button_exit_Click(object sender, EventArgs e)//выход кнопка
        {
            Connection.Close();
            Close();
        }

        private void button_search_countries_Click(object sender, EventArgs e)//кнопка поиска
        {
            if(textBox_search.Text.Length<1)
            {
                MessageBox.Show($"Поле поиска не может быть пустым!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                countryCityList.Clear();
                using (var cmdCount = new NpgsqlCommand($"SELECT COUNT(*) FROM cities WHERE name_city LIKE '%" + textBox_search.Text.ToString().Trim() + "%'", Connection))
                {
                    int countRows = Convert.ToInt32(cmdCount.ExecuteScalar());
                    if (countRows > 0)
                    {
                        using (var cmd = new NpgsqlCommand("Select DISTINCT countries.id_country, id_city, name_country, name_city FROM countries, cities WHERE countries.id_country = cities.id_country AND name_city LIKE '%" + textBox_search.Text.ToString().Trim() + "%'", Connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var countryCity = new CountryCity();
                                    countryCity.nameCity = reader["name_city"].ToString().Trim();
                                    countryCity.nameCountry = reader["name_country"].ToString().Trim();
                                    var idCo = reader["id_country"].ToString().Trim();
                                    countryCity.idCountry = Int32.Parse(idCo);
                                    var idCi = reader["id_city"].ToString().Trim();
                                    countryCity.idCity = Int32.Parse(idCi);
                                    countryCityList.Add(countryCity);
                                }
                            }
                        }
                        FillDGV();
                        MessageBox.Show($"Совпадения найдены!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Совпадений не найдено! Туры в данный город не осуществляются!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }            

        private void button_back_Click(object sender, EventArgs e)//назад кнопка
        {
            Connection.Close();
            start.Show();
            this.Hide();
        }

        private void Countries_FormClosed(object sender, FormClosedEventArgs e)//закрыли форму крестом
        {
            Connection.Close();
            start.Close();
        }

        private void textBox_search_Leave(object sender, EventArgs e)
        {
            if (textBox_search.Text.Length == 0)
            {
                textBox_search.Text = "Введите название города";
                textBox_search.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox_search_Enter(object sender, EventArgs e)
        {
            if(textBox_search.Text == "Введите название города")
            {
                textBox_search.Text = "";
                textBox_search.ForeColor = SystemColors.WindowText;
            }
        }

        private void button_show_table_Click(object sender, EventArgs e)//кнопка показать таблицу
        {
            Connection.Close();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            countryCityList.Clear();
            Connection.Open();
            LoadData();
            FillDGV();
            textBox_cities.Clear();
            textBox_search.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//удалить данные
        {
            if (e.ColumnIndex == 0)//delete
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var rowIndexDel = e.RowIndex;
                    var cellDell = dataGridView1.Rows[rowIndexDel].Cells[2].Value;
                    using (var cmdidTr = new NpgsqlCommand($"SELECT COUNT(*) FROM trips WHERE id_route = {cellDell}", Connection))
                    {
                        var idTr = Convert.ToInt32(cmdidTr.ExecuteScalar());
                        if (idTr > 0)
                        {
                            MessageBox.Show("Данные удалены быть не могут! Тур в этот город куплен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            using (var cmd = new NpgsqlCommand($"DELETE FROM cities WHERE id_city = '" + cellDell + "' ", Connection))
                            {
                                using (var reader = cmd.ExecuteReader())
                                {
                                    dataGridView1.Rows.RemoveAt(rowIndexDel);
                                }
                            }
                            MessageBox.Show("Данные успешно удалены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)//когда выбрана строка
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            int idCountr = 0;
            if (dataGridView1.SelectedRows.Count != 0)//выбрана строка
            {
                using (var cmd = new NpgsqlCommand($"SELECT *from cities WHERE id_city = {dataGridView1.SelectedRows[0].Cells[2].Value}", Connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idCountr = reader.GetInt32(1);
                            textBox_cities.Text = reader.GetString(2);
                        }
                    }
                }

                using (var cmdCities = new NpgsqlCommand($"SELECT id_city, cities.id_country, name_country FROM cities, countries WHERE cities.id_country = countries.id_country AND cities.id_country = {idCountr}", Connection))
                {
                    using (var readerCity = cmdCities.ExecuteReader())
                    {
                        while (readerCity.Read())
                        {
                            comboBox_name_countries.SelectedItem = readerCity.GetString(2);//выводими данные в комбобокс маршруты
                        }
                    }
                }
            }
        }
    }

    public class CountryCity
    {
        public int idCity;
        public int idCountry;
        public String nameCity;
        public String nameCountry;      
    }
}



