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
    public partial class Hotels : Form
    {
        List<HotelClass> hotelsList = new List<HotelClass>();
        private List<int> _cityId = new List<int>();
        private List<int> _categoryHotel = new List<int>();
        private List<int> _typeFood = new List<int>();

        HotelClass hotelClass = new HotelClass();

        String imgDelete = @"C:\Users\Любовь\Desktop\Учеба\СУБД PostgreSQL\TravelCompanyApp\del.png";

        Start start;

        private static readonly NpgsqlConnection Connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["pgConnect"].ConnectionString);//строка соединения

        public Hotels(Start s)
        {
            Connection.Open();
            start = s;
            InitializeComponent();

            textBox_search.ForeColor = SystemColors.GrayText;
            textBox_search.Text = "Введите название отеля";
            this.textBox_search.Leave += new System.EventHandler(this.textBox_search_Leave);
            this.textBox_search.Enter += new System.EventHandler(this.textBox_search_Enter); 
            
            if(start.role == 2)
            {
                button_add.Enabled = false;
                button_save.Enabled = false;
            }
        }

        void FillcomboCity()
        {
            using (var cmdCity = new NpgsqlCommand("SELECT id_city, name_city FROM cities ORDER BY name_city ASC", Connection))
            {
                using (var reader = cmdCity.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _cityId.Add(reader.GetInt32(0));
                        comboBoxNameCity.Items.Add(reader.GetString(1));
                    }
                    comboBoxNameCity.SelectedIndex = 0;
                }
            }
        }

        void FillcomboCategory()
        {
            using (var cmdCategory = new NpgsqlCommand("SELECT id_hotel_category, name_hotel_category FROM hotels_categories ORDER BY name_hotel_category ASC ", Connection))
            {
                using (var reader = cmdCategory.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _categoryHotel.Add(reader.GetInt32(0));
                        comboBoxCategoryHotel.Items.Add(reader.GetString(1));
                    }
                    comboBoxCategoryHotel.SelectedIndex = 0;
                }
            }
        }
            
        void FillcomboTypeFood()
        {
            using (var cmdTypeFood = new NpgsqlCommand("SELECT id_type_of_food, name_type_of_food FROM typies_of_food ORDER BY name_type_of_food ASC", Connection))
            {
                using (var reader = cmdTypeFood.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _typeFood.Add(reader.GetInt32(0));
                        comboBoxTypeFoodHotel.Items.Add(reader.GetString(1));
                    }
                    comboBoxTypeFoodHotel.SelectedIndex = 0;
                }
            }

        }

        void LoadData()//загрузили данные
        {
            using (var cmd = new NpgsqlCommand($"SELECT hotels.id_hotel," +
                $"hotels.id_city, " +
                $"hotels.name_hotel, " +
                $"hotels.id_hotel_category, " +
                $"hotels.id_type_of_food, " +
                $"cities.name_city, " +
                $"hotels_categories.name_hotel_category, " +
                $"typies_of_food.name_type_of_food " +
                $"FROM hotels, cities, hotels_categories, typies_of_food " +
                $"WHERE cities.id_city = hotels.id_city " +
                $"AND hotels_categories.id_hotel_category = hotels.id_hotel_category " +
                $"AND typies_of_food.id_type_of_food = hotels.id_type_of_food", Connection))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var hotelClass = new HotelClass();
                        var idHot = reader["id_hotel"].ToString().Trim();
                        hotelClass.idHotel = Int32.Parse(idHot);

                        hotelClass.nameHotel = reader["name_hotel"].ToString().Trim();

                        var idCities = reader["id_city"].ToString().Trim();
                        hotelClass.idCity = Int32.Parse(idCities);

                        hotelClass.nameCity = reader["name_city"].ToString().Trim();

                        var idCategHot = reader["id_hotel_category"].ToString().Trim();
                        hotelClass.idCategoryHotel = Int32.Parse(idCategHot);

                        hotelClass.nameCategoryHotel = reader["name_hotel_category"].ToString().Trim();

                        var idTypeF = reader["id_type_of_food"].ToString().Trim();
                        hotelClass.idTypeFood = Int32.Parse(idTypeF);

                        hotelClass.nameTypeFood = reader["name_type_of_food"].ToString().Trim();
                        hotelsList.Add(hotelClass);
                    }
            }
        }

        void FillDGV()//вывели в таблицу
        {
            DataGridViewImageColumn imgC = new DataGridViewImageColumn();
            dataGridView1.Columns.AddRange(imgC);

            for (int i = 0; i <= 7; i++)
            {
                DataGridViewTextBoxColumn cl = new DataGridViewTextBoxColumn();
                dataGridView1.Columns.Add(cl);
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Отель";
            dataGridView1.Columns[4].HeaderText = "Город";
            dataGridView1.Columns[6].HeaderText = "Категория отеля";
            dataGridView1.Columns[8].HeaderText = "Тип питания";
            dataGridView1.Columns[0].Width = 32;
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[4].Width = 180;
            dataGridView1.Columns[6].Width = 180;
            dataGridView1.Columns[8].Width = 180;

            foreach (var el in hotelsList)
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

                var idHot = el.idHotel;
                DataGridViewCell dGVCell = new DataGridViewTextBoxCell();
                dGVCell.Value = idHot;
                dataGridViewRow.Cells.Add(dGVCell);

                var nameHot = el.nameHotel;
                DataGridViewCell dGVCell0 = new DataGridViewTextBoxCell();
                dGVCell0.Value = nameHot;
                dataGridViewRow.Cells.Add(dGVCell0);

                var idCity = el.idCity;
                DataGridViewCell dGVCell1 = new DataGridViewTextBoxCell();
                dGVCell1.Value = idCity;
                dataGridViewRow.Cells.Add(dGVCell1);

                var nameCity = el.nameCity;
                DataGridViewCell dGVCell2 = new DataGridViewTextBoxCell();
                dGVCell2.Value = nameCity;
                dataGridViewRow.Cells.Add(dGVCell2);

                var idCatHot = el.idCategoryHotel;
                DataGridViewCell dGVCell3 = new DataGridViewTextBoxCell();
                dGVCell3.Value = nameCity;
                dataGridViewRow.Cells.Add(dGVCell3);

                var nameCatHot = el.nameCategoryHotel;
                DataGridViewCell dGVCell4 = new DataGridViewTextBoxCell();
                dGVCell4.Value = nameCatHot;
                dataGridViewRow.Cells.Add(dGVCell4);

                var idTypeF = el.idTypeFood;
                DataGridViewCell dGVCell5 = new DataGridViewTextBoxCell();
                dGVCell5.Value = idTypeF;
                dataGridViewRow.Cells.Add(dGVCell5);

                var nameTypeF = el.nameTypeFood;
                DataGridViewCell dGVCell6 = new DataGridViewTextBoxCell();
                dGVCell6.Value = nameTypeF;
                dataGridViewRow.Cells.Add(dGVCell6);

                dataGridView1.Rows.Add(dataGridViewRow);
            }
        }

        private void Hotels_Load(object sender, EventArgs e)
        {
            LoadData();
            FillDGV();
            FillcomboCategory();
            FillcomboTypeFood();
            FillcomboCity();
            textBoxNameHotel.Clear();
        }

        public void AddHotels(HotelClass hotelClass)//добавляем новый 
        {
            hotelsList.Add(hotelClass);
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        }

        public void UpdateHotels(HotelClass hotelClass)//обновляем 
        {
            hotelsList.Clear();
            LoadData();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
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
            hotelsList.Clear();
            Connection.Open();
            Hotels_Load(sender, e);
            textBoxNameHotel.Clear();
            textBox_search.Clear();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Connection.Close();
            start.Show();
            this.Hide();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            using (var cmd = new NpgsqlCommand($"SELECT COUNT(*) FROM hotels WHERE name_hotel = '{textBoxNameHotel.Text}'", Connection))
            {
                int numberMatches = Convert.ToInt32(cmd.ExecuteScalar());
                if (numberMatches > 0)
                {
                    MessageBox.Show("Такой отель уже существует!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if ((textBoxNameHotel.Text.Length <= 2) || (textBoxNameHotel.Text.Length >= 20))
                    {
                        MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var comboCity = comboBoxNameCity.SelectedItem;

                        using (var cmdIdCi = new NpgsqlCommand($"SELECT id_city FROM cities WHERE name_city = '{comboCity}'", Connection))
                        {
                            hotelClass.idCity = Convert.ToInt32(cmdIdCi.ExecuteScalar());
                        }

                        var idCities = hotelClass.idCity;
                        
                        var comboСatHot = comboBoxCategoryHotel.SelectedItem;

                        using (var cmdIdCH = new NpgsqlCommand($"SELECT id_hotel_category FROM hotels_categories WHERE name_hotel_category = '{comboСatHot}'", Connection))
                        {
                            hotelClass.idCategoryHotel = Convert.ToInt32(cmdIdCH.ExecuteScalar());
                        }
                        var idCategHotel = hotelClass.idCategoryHotel;
                        
                        var comboTypF = comboBoxTypeFoodHotel.SelectedItem;

                        using (var cmdIdTF = new NpgsqlCommand($"SELECT id_type_of_food FROM typies_of_food WHERE name_type_of_food = '{comboTypF}'", Connection))
                        {
                            hotelClass.idTypeFood = Convert.ToInt32(cmdIdTF.ExecuteScalar());
                        }
                        var idTypeFoodHotel = hotelClass.idTypeFood;

                        using (var cmdInto = new NpgsqlCommand($"INSERT INTO hotels(id_city, name_hotel, id_hotel_category, id_type_of_food) values ({idCities}, '{textBoxNameHotel.Text.Trim()}', {idCategHotel}, {idTypeFoodHotel})", Connection))
                        {
                            cmdInto.ExecuteNonQuery();
                        }
                        hotelClass.idCity = idCities;
                        hotelClass.idCategoryHotel = idCategHotel;
                        hotelClass.idTypeFood = idTypeFoodHotel;
                        hotelClass.nameHotel = textBoxNameHotel.Text.Trim();

                        using (var cmdNameCity = new NpgsqlCommand($"SELECT name_city FROM cities WHERE id_city = {idCities}", Connection))
                        {
                            using (var read = cmdNameCity.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    hotelClass.nameCity = read["name_city"].ToString().Trim();
                                }
                            }
                        }

                        using (var cmdNameCategoryHotel = new NpgsqlCommand($"SELECT name_hotel_category FROM hotels_categories WHERE " +
                            $"id_hotel_category = {idCategHotel}", Connection))
                        {
                            using (var read = cmdNameCategoryHotel.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    hotelClass.nameCategoryHotel = read["name_hotel_category"].ToString().Trim();
                                }
                            }
                        }

                        using (var cmdNameTypeFood = new NpgsqlCommand($"SELECT name_type_of_food FROM typies_of_food WHERE" +
                            $" id_type_of_food = {idTypeFoodHotel}", Connection))
                        {
                            using (var read = cmdNameTypeFood.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    hotelClass.nameTypeFood = read["name_type_of_food"].ToString().Trim();
                                }
                            }
                        }
                        dataGridView1.Refresh();
                        AddHotels(hotelClass);
                        MessageBox.Show("Новый отель успешно добавлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((textBoxNameHotel.Text.Length <= 2) || (textBoxNameHotel.Text.Length >= 20))
                {
                    MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var comboCity = comboBoxNameCity.SelectedItem;

                    using (var cmdIdCi = new NpgsqlCommand($"SELECT id_city FROM cities WHERE name_city = '{comboCity}'", Connection))
                    {
                        hotelClass.idCity = Convert.ToInt32(cmdIdCi.ExecuteScalar());
                    }

                    var idCities = hotelClass.idCity;

                    var comboСatHot = comboBoxCategoryHotel.SelectedItem;

                    using (var cmdIdCH = new NpgsqlCommand($"SELECT id_hotel_category FROM hotels_categories WHERE name_hotel_category = '{comboСatHot}'", Connection))
                    {
                        hotelClass.idCategoryHotel = Convert.ToInt32(cmdIdCH.ExecuteScalar());
                    }
                    var idCategHotel = hotelClass.idCategoryHotel;

                    var comboTypF = comboBoxTypeFoodHotel.SelectedItem;

                    using (var cmdIdTF = new NpgsqlCommand($"SELECT id_type_of_food FROM typies_of_food WHERE name_type_of_food = '{comboTypF}'", Connection))
                    {
                        hotelClass.idTypeFood = Convert.ToInt32(cmdIdTF.ExecuteScalar());
                    }
                    var idTypeFoodHotel = hotelClass.idTypeFood;

                    using (var cmd = new NpgsqlCommand($"SELECT id_hotel FROM hotels WHERE id_hotel = {dataGridView1.SelectedRows[0].Cells[1].Value}", Connection))
                    {
                        int idSelHotel = Convert.ToInt32(cmd.ExecuteScalar());

                        using (var cmdUp = new NpgsqlCommand($"UPDATE hotels SET id_city = {idCities}, name_hotel = '{textBoxNameHotel.Text.Trim()}', " +
                        $"id_hotel_category = {idCategHotel}, id_type_of_food = {idTypeFoodHotel} WHERE id_hotel = {idSelHotel}", Connection))
                        {
                            cmdUp.ExecuteNonQuery();
                        }
                        hotelClass.nameHotel = textBoxNameHotel.Text.Trim();
                        hotelClass.idCity = idCities;
                        hotelClass.idCategoryHotel = idCategHotel;
                        hotelClass.idTypeFood = idTypeFoodHotel;

                        using (var cmdNameCity = new NpgsqlCommand($"SELECT name_city FROM cities WHERE id_city = {idCities}", Connection))
                        {
                            using (var read = cmdNameCity.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    hotelClass.nameCity = read["name_city"].ToString().Trim();
                                }
                            }
                        }


                        using (var cmdNameCategoryHotel = new NpgsqlCommand($"SELECT name_hotel_category FROM hotels_categories WHERE " +
                            $"id_hotel_category = {idCategHotel}", Connection))
                        {
                            using (var read = cmdNameCategoryHotel.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    hotelClass.nameCategoryHotel = read["name_hotel_category"].ToString().Trim();
                                }
                            }
                        }

                        using (var cmdNameTypeFood = new NpgsqlCommand($"SELECT name_type_of_food FROM typies_of_food WHERE" +
                            $" id_type_of_food = {idTypeFoodHotel}", Connection))
                        {
                            using (var read = cmdNameTypeFood.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    hotelClass.nameTypeFood = read["name_type_of_food"].ToString().Trim();
                                }
                            }
                        }

                        using (var cmdNameHotel = new NpgsqlCommand($"SELECT name_hotel FROM hotels WHERE id_hotel = {idSelHotel}", Connection))
                        {
                            using (var read = cmdNameHotel.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    hotelClass.nameHotel = read["name_hotel"].ToString().Trim();
                                }
                            }
                        }
                        UpdateHotels(hotelClass);
                        dataGridView1.Refresh();
                        MessageBox.Show("Данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            hotelsList.Clear();

            using (var cmdCount = new NpgsqlCommand($"SELECT COUNT(*) FROM hotels WHERE name_hotel LIKE '%" + textBox_search.Text.ToString().Trim() + "%'", Connection))
            {
                int countRows = Convert.ToInt32(cmdCount.ExecuteScalar());
                if (countRows > 0)
                {
                    using (var cmd = new NpgsqlCommand("SELECT hotels.id_hotel," +
                $"hotels.id_city, " +
                $"hotels.name_hotel, " +
                $"hotels.id_hotel_category, " +
                $"hotels.id_type_of_food, " +
                $"cities.name_city, " +
                $"hotels_categories.name_hotel_category, " +
                $"typies_of_food.name_type_of_food " +
                $"FROM hotels, cities, hotels_categories, typies_of_food " +
                $"WHERE cities.id_city = hotels.id_city " +
                $"AND hotels_categories.id_hotel_category = hotels.id_hotel_category " +
                $"AND typies_of_food.id_type_of_food = hotels.id_type_of_food AND name_hotel LIKE '%" + textBox_search.Text.ToString().Trim() + "%'", Connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var hotelClass = new HotelClass();
                                var idHot = reader["id_hotel"].ToString().Trim();
                                hotelClass.idHotel = Int32.Parse(idHot);

                                hotelClass.nameHotel = reader["name_hotel"].ToString().Trim();

                                var idCities = reader["id_city"].ToString().Trim();
                                hotelClass.idCity = Int32.Parse(idCities);

                                hotelClass.nameCity = reader["name_city"].ToString().Trim();

                                var idCategHot = reader["id_hotel_category"].ToString().Trim();
                                hotelClass.idCategoryHotel = Int32.Parse(idCategHot);

                                hotelClass.nameCategoryHotel = reader["name_hotel_category"].ToString().Trim();

                                var idTypeF = reader["id_type_of_food"].ToString().Trim();
                                hotelClass.idTypeFood = Int32.Parse(idTypeF);

                                hotelClass.nameTypeFood = reader["name_type_of_food"].ToString().Trim();
                                hotelsList.Add(hotelClass);
                            }
                        }
                    }
                    FillDGV();
                    MessageBox.Show($"Найдено " + countRows + " совпадений!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Отель с таким названием отсутствует в базе данных!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Hotels_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.Close();
            start.Close();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            if (dataGridView1.SelectedRows.Count != 0)//выбрана строка
            {
                using (var cmdIH = new NpgsqlCommand($"SELECT *from hotels WHERE id_hotel = {dataGridView1.SelectedRows[0].Cells[1].Value}", Connection))
                {
                    var idHotels = Convert.ToInt32(cmdIH.ExecuteScalar());

                    using (var cmdNH = new NpgsqlCommand($"SELECT name_hotel from hotels WHERE id_hotel = {idHotels}", Connection))
                    {
                        using (var reader = cmdNH.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                textBoxNameHotel.Text = reader["name_hotel"].ToString().Trim();
                            }
                        }
                    }

                    using (var cmdCities = new NpgsqlCommand($"SELECT hotels.id_hotel, hotels.id_city, cities.name_city FROM hotels, cities WHERE " +
                    $"cities.id_city = hotels.id_city " +
                    $"AND hotels.id_hotel = {idHotels}", Connection))
                {
                    using (var readerCity = cmdCities.ExecuteReader())
                    {
                        while (readerCity.Read())
                        {
                            comboBoxNameCity.SelectedItem = readerCity.GetString(2);//выводими данные в комбобокс
                        }
                    }
                }

                using (var cmdCategHot = new NpgsqlCommand($"SELECT hotels.id_hotel, hotels.id_hotel_category, hotels_categories.name_hotel_category FROM hotels, hotels_categories" +
                    $" WHERE hotels_categories.id_hotel_category = hotels.id_hotel_category AND hotels.id_hotel = {idHotels}", Connection))
                {
                    using (var readerCity = cmdCategHot.ExecuteReader())
                    {
                        while (readerCity.Read())
                        {
                            comboBoxCategoryHotel.SelectedItem = readerCity.GetString(2);//выводими данные в комбобокс 
                        }
                    }
                }

                    using (var cmdFoodHot = new NpgsqlCommand($"SELECT hotels.id_hotel, hotels.id_type_of_food, typies_of_food.name_type_of_food FROM hotels, typies_of_food " +
                        $"WHERE typies_of_food.id_type_of_food = hotels.id_type_of_food AND hotels.id_hotel = {idHotels}", Connection))
                    {
                        using (var readerCity = cmdFoodHot.ExecuteReader())
                        {
                            while (readerCity.Read())
                            {
                                comboBoxTypeFoodHotel.SelectedItem = readerCity.GetString(2);//выводими данные в комбобокс маршруты
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (start.role == 0) || (start.role == 1))//delete
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var rowIndexDel = e.RowIndex;
                    var cellDell = dataGridView1.Rows[rowIndexDel].Cells[1].Value;
                    using (var cmdidR = new NpgsqlCommand($"SELECT COUNT(*) FROM routes WHERE id_hotel = {cellDell}", Connection))
                    {
                        var idR = Convert.ToInt32(cmdidR.ExecuteScalar());
                        if (idR > 0)
                        {
                            MessageBox.Show("Данные удалены быть не могут! Отель включен в тур!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            using (var cmd = new NpgsqlCommand($"DELETE FROM hotels WHERE id_hotel = '" + cellDell + "' ", Connection))
                            {
                                using (var reader = cmd.ExecuteReader())
                                {
                                    dataGridView1.Rows.RemoveAt(rowIndexDel);
                                    MessageBox.Show("Данные успешно удалены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);           
                                }
                            }
                        }
                    }
                }
            }                 
        }

        private void textBox_search_Enter(object sender, EventArgs e)
        {
            if (textBox_search.Text == "Введите название отеля")
            {
                textBox_search.Text = "";
                textBox_search.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBox_search_Leave(object sender, EventArgs e)
        {
            if (textBox_search.Text.Length == 0)
            {
                textBox_search.Text = "Введите название отеля";
                textBox_search.ForeColor = SystemColors.GrayText;
            }
        }
    }

    public class HotelClass
    {
        public int idHotel;
        public String nameHotel;
        public int idCity;
        public String nameCity;
        public int idCategoryHotel;
        public String nameCategoryHotel;
        public int idTypeFood;
        public String nameTypeFood;
    }
}
