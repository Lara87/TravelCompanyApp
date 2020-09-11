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
    public partial class Routes : Form
    {
        List<RouteCl> routeList = new List<RouteCl>();
        private List<int> _idHotel = new List<int>();

        RouteCl routeCl = new RouteCl();

        String imgDelete = @"C:\Users\Любовь\Desktop\Учеба\СУБД PostgreSQL\TravelCompanyApp\del.png";

        Start start;

        private static readonly NpgsqlConnection Connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["pgConnect"].ConnectionString);//строка соединения
        
        

        public Routes(Start s)
        {
            Connection.Open();
            start = s;
            InitializeComponent();

            textBox_search.ForeColor = SystemColors.GrayText;
            textBox_search.Text = "Введите название тура";
            this.textBox_search.Leave += new System.EventHandler(this.textBox_search_Leave);
            this.textBox_search.Enter += new System.EventHandler(this.textBox_search_Enter);

            if(start.role == 2)
            {
                button_add.Enabled = false;
                button_save.Enabled = false;
            }
        }

        void FillcombobHotel()
        {
            using (var cmdHotel = new NpgsqlCommand("SELECT id_hotel, name_hotel FROM hotels ORDER BY name_hotel ASC", Connection))
            {
                using (var reader = cmdHotel.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _idHotel.Add(reader.GetInt32(0));
                        comboBoxHotels.Items.Add(reader.GetString(1));
                    }
                    comboBoxHotels.SelectedIndex = 0;
                }
            }
        }

        void LoadData()//загрузили данные
        {
            using (var cmd = new NpgsqlCommand($"Select id_route, routes.id_hotel, name_route, hotels.name_hotel, countries.name_country, cities.name_city, " +
                $"hotels_categories.name_hotel_category, typies_of_food.name_type_of_food, number_of_nights, price, " +
                $"cities.id_city, cities.id_country, hotels.id_hotel_category, hotels.id_type_of_food " +
                $"FROM routes, countries, cities, hotels, hotels_categories, typies_of_food WHERE routes.id_hotel = hotels.id_hotel " +
                $"AND countries.id_country = cities.id_country " +
                $"AND cities.id_city = hotels.id_city " +
                $"AND routes.id_hotel = hotels.id_hotel " +
                $"AND hotels.id_hotel_category = hotels_categories.id_hotel_category " +
                $"AND hotels.id_type_of_food = typies_of_food.id_type_of_food", Connection))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var routeCl = new RouteCl();

                        var idR = reader["id_route"].ToString().Trim();
                        routeCl.idRoute = Int32.Parse(idR);

                        routeCl.nameRoute = reader["name_route"].ToString().Trim();

                        var idHot = reader["id_hotel"].ToString().Trim();
                        routeCl.idHotel = Int32.Parse(idHot);

                        routeCl.nameHotel = reader["name_hotel"].ToString().Trim();

                        var idCities = reader["id_city"].ToString().Trim();
                        routeCl.idCity = Int32.Parse(idCities);

                        routeCl.nameCity = reader["name_city"].ToString().Trim();

                        var idCountries = reader["id_country"].ToString().Trim();
                        routeCl.idCountry = Int32.Parse(idCountries);

                        routeCl.nameCountry = reader["name_country"].ToString().Trim();

                        var idCategHot = reader["id_hotel_category"].ToString().Trim();
                        routeCl.idCategoryHotel = Int32.Parse(idCategHot);

                        routeCl.nameCategoryHotel = reader["name_hotel_category"].ToString().Trim();

                        var idTypeF = reader["id_type_of_food"].ToString().Trim();
                        routeCl.idTypeFooHotel = Int32.Parse(idTypeF);

                        routeCl.nameTypeFoodHotel = reader["name_type_of_food"].ToString().Trim();
                        routeList.Add(routeCl);

                        var numNight = reader["number_of_nights"].ToString().Trim();
                        routeCl.numNights = Int32.Parse(numNight);

                        var priceR = reader["price"].ToString().Trim();
                        routeCl.price = float.Parse(priceR);
                    }
            }
        }

        void FillDGV()//вывели в таблицу
        {
            DataGridViewImageColumn imgC = new DataGridViewImageColumn();
            dataGridView1.Columns.AddRange(imgC);

            for (int i = 0; i <= 13; i++)
            {
                DataGridViewTextBoxColumn cl = new DataGridViewTextBoxColumn();
                dataGridView1.Columns.Add(cl);
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Название тура";
            dataGridView1.Columns[3].HeaderText = "Страна";
            dataGridView1.Columns[4].HeaderText = "Город";
            dataGridView1.Columns[5].HeaderText = "Отель";
            dataGridView1.Columns[6].HeaderText = "Категория отеля";
            dataGridView1.Columns[7].HeaderText = "Тип питания";
            dataGridView1.Columns[8].HeaderText = "Количество ночей";
            dataGridView1.Columns[9].HeaderText = "Стоимость";
            dataGridView1.Columns[0].Width = 32;
            dataGridView1.Columns[2].Width = 130;

            foreach (var el in routeList)
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

                var idR = el.idRoute;
                DataGridViewCell dGVCell0 = new DataGridViewTextBoxCell();
                dGVCell0.Value = idR;
                dataGridViewRow.Cells.Add(dGVCell0);

                var nameRo = el.nameRoute;
                DataGridViewCell dGVCell1 = new DataGridViewTextBoxCell();
                dGVCell1.Value = nameRo;
                dataGridViewRow.Cells.Add(dGVCell1);

                var nameCountr = el.nameCountry;
                DataGridViewCell dGVCell2 = new DataGridViewTextBoxCell();
                dGVCell2.Value = nameCountr;
                dataGridViewRow.Cells.Add(dGVCell2);

                var nameCit = el.nameCity;
                DataGridViewCell dGVCell3 = new DataGridViewTextBoxCell();
                dGVCell3.Value = nameCit;
                dataGridViewRow.Cells.Add(dGVCell3);

                var nameHot = el.nameHotel;
                DataGridViewCell dGVCell4 = new DataGridViewTextBoxCell();
                dGVCell4.Value = nameHot;
                dataGridViewRow.Cells.Add(dGVCell4);

                var nameCatHot = el.nameCategoryHotel;
                DataGridViewCell dGVCell5 = new DataGridViewTextBoxCell();
                dGVCell5.Value = nameCatHot;
                dataGridViewRow.Cells.Add(dGVCell5);

                var nameTypeF = el.nameTypeFoodHotel;
                DataGridViewCell dGVCell6 = new DataGridViewTextBoxCell();
                dGVCell6.Value = nameTypeF;
                dataGridViewRow.Cells.Add(dGVCell6);

                var nightsR = el.numNights;
                DataGridViewCell dGVCell7 = new DataGridViewTextBoxCell();
                dGVCell7.Value = nightsR;
                dataGridViewRow.Cells.Add(dGVCell7);

                var priceR = el.price;
                DataGridViewCell dGVCell8 = new DataGridViewTextBoxCell();
                dGVCell8.Value = priceR;
                dataGridViewRow.Cells.Add(dGVCell8);

                var idHot = el.idHotel;
                DataGridViewCell dGVCell9 = new DataGridViewTextBoxCell();
                dGVCell9.Value = idHot;
                dataGridViewRow.Cells.Add(dGVCell9);                

                var idCities = el.idCity;
                DataGridViewCell dGVCell10 = new DataGridViewTextBoxCell();
                dGVCell10.Value = idCities;
                dataGridViewRow.Cells.Add(dGVCell10);

                var idCountries = el.idCountry;
                DataGridViewCell dGVCell11 = new DataGridViewTextBoxCell();
                dGVCell11.Value = idCountries;
                dataGridViewRow.Cells.Add(dGVCell11);

                var idCatHot = el.idCategoryHotel;
                DataGridViewCell dGVCell12 = new DataGridViewTextBoxCell();
                dGVCell12.Value = idCatHot;
                dataGridViewRow.Cells.Add(dGVCell12);         

                var idTypeF = el.idTypeFooHotel;
                DataGridViewCell dGVCell13 = new DataGridViewTextBoxCell();
                dGVCell13.Value = idTypeF;
                dataGridViewRow.Cells.Add(dGVCell13);
              
                dataGridView1.Rows.Add(dataGridViewRow);
            }
        }

        private void Routes_Load(object sender, EventArgs e)
        {
            LoadData();
            FillDGV();
            FillcombobHotel();
            textBoxNameRoute.Clear();
            textBoxPrice.Clear();
        }

        public void AddRoutes(RouteCl routeCl)//добавляем новый 
        {
            routeList.Clear();
            routeList.Add(routeCl);
            LoadData();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        }

        public void UpdateRoutes(RouteCl routeCl)//обновляем 
        {
            routeList.Clear();
            LoadData();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if(textBox_search.Text.Length == 0)
            {
                MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                routeList.Clear();
                using (var cmdCount = new NpgsqlCommand($"SELECT COUNT(*) FROM routes WHERE name_route LIKE '%" + textBox_search.Text.ToString().Trim() + "%'", Connection))
                {
                    int countRows = Convert.ToInt32(cmdCount.ExecuteScalar());
                    if (countRows > 0)
                    {
                        using (var cmd = new NpgsqlCommand("Select id_route, routes.id_hotel, name_route, hotels.name_hotel, countries.name_country, cities.name_city, " +
                    $"hotels_categories.name_hotel_category, typies_of_food.name_type_of_food, number_of_nights, price, " +
                    $"cities.id_city, cities.id_country, hotels.id_hotel_category, hotels.id_type_of_food " +
                    $"FROM routes, countries, cities, hotels, hotels_categories, typies_of_food WHERE routes.id_hotel = hotels.id_hotel " +
                    $"AND countries.id_country = cities.id_country " +
                    $"AND cities.id_city = hotels.id_city " +
                    $"AND routes.id_hotel = hotels.id_hotel " +
                    $"AND hotels.id_hotel_category = hotels_categories.id_hotel_category " +
                    $"AND hotels.id_type_of_food = typies_of_food.id_type_of_food AND name_route LIKE '%" + textBox_search.Text.ToString().Trim() + "%'", Connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var routeCl = new RouteCl();
                                    var idR = reader["id_route"].ToString().Trim();
                                    routeCl.idRoute = Int32.Parse(idR);

                                    routeCl.nameRoute = reader["name_route"].ToString().Trim();

                                    var idHot = reader["id_hotel"].ToString().Trim();
                                    routeCl.idHotel = Int32.Parse(idHot);

                                    routeCl.nameHotel = reader["name_hotel"].ToString().Trim();

                                    var idCities = reader["id_city"].ToString().Trim();
                                    routeCl.idCity = Int32.Parse(idCities);

                                    routeCl.nameCity = reader["name_city"].ToString().Trim();

                                    var idCountries = reader["id_country"].ToString().Trim();
                                    routeCl.idCountry = Int32.Parse(idCountries);

                                    routeCl.nameCountry = reader["name_country"].ToString().Trim();

                                    var idCategHot = reader["id_hotel_category"].ToString().Trim();
                                    routeCl.idCategoryHotel = Int32.Parse(idCategHot);

                                    routeCl.nameCategoryHotel = reader["name_hotel_category"].ToString().Trim();

                                    var idTypeF = reader["id_type_of_food"].ToString().Trim();
                                    routeCl.idTypeFooHotel = Int32.Parse(idTypeF);

                                    routeCl.nameTypeFoodHotel = reader["name_type_of_food"].ToString().Trim();

                                    var numNight = reader["number_of_nights"].ToString().Trim();
                                    routeCl.numNights = Int32.Parse(numNight);

                                    var priceR = reader["price"].ToString().Trim();
                                    routeCl.price = float.Parse(priceR);

                                    routeList.Add(routeCl);
                                }
                            }
                        }
                        FillDGV();
                        MessageBox.Show($"Совпадения найдены!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Совпадений не найдено!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Connection.Close();
            start.Show();
            this.Hide();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            using (var cmd = new NpgsqlCommand($"SELECT COUNT(*) FROM routes WHERE name_route = '{textBoxNameRoute.Text}'", Connection))
            {
                int numberMatches = Convert.ToInt32(cmd.ExecuteScalar());
                if (numberMatches > 0)
                {
                    MessageBox.Show("Тур с таким названием уже существует!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if ((textBoxNameRoute.Text.Length <= 2) || (textBoxNameRoute.Text.Length >= 20))
                    {
                        MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var comboNameHotel = comboBoxHotels.SelectedItem;
 
                        using (var cmdIdH = new NpgsqlCommand($"SELECT id_hotel FROM hotels WHERE name_hotel = '{comboNameHotel}'", Connection))
                        {
                            routeCl.idHotel = Convert.ToInt32(cmdIdH.ExecuteScalar());
                        }
                        var idHotelR = routeCl.idHotel;

                        using (var cmdInto = new NpgsqlCommand($"INSERT INTO routes(id_hotel, number_of_nights, price, name_route) values " +
                            $"({idHotelR}, '{numericUpDownNights.Text.Trim()}', '{textBoxPrice.Text.Trim()}', '{textBoxNameRoute.Text.Trim()}')", Connection))
                        {
                            cmdInto.ExecuteNonQuery();
                        }
                        routeCl.idHotel = idHotelR;

                        var numN = numericUpDownNights.Text.Trim();
                        routeCl.numNights = Int32.Parse(numN);

                        var priceM = textBoxPrice.Text.Trim();
                        routeCl.price = float.Parse(priceM);

                        routeCl.nameRoute = textBoxNameRoute.Text.Trim();

                        var idRou = 0;

                        using (var cmdMax = new NpgsqlCommand($"Select MAX(id_route) FROM routes", Connection))
                        {
                            idRou = Convert.ToInt32(cmdMax.ExecuteScalar());
                        }

                        using (var cmdOther = new NpgsqlCommand($"Select hotels.name_hotel, countries.name_country, cities.name_city, " +
                        $"hotels_categories.name_hotel_category, typies_of_food.name_type_of_food, " +
                        $"cities.id_city, cities.id_country, hotels.id_hotel_category, hotels.id_type_of_food " +
                        $"FROM routes, countries, cities, hotels, hotels_categories, typies_of_food WHERE routes.id_hotel = hotels.id_hotel " +
                        $"AND countries.id_country = cities.id_country " +
                        $"AND cities.id_city = hotels.id_city " +
                        $"AND routes.id_hotel = hotels.id_hotel " +
                        $"AND hotels.id_hotel_category = hotels_categories.id_hotel_category " +
                        $"AND hotels.id_type_of_food = typies_of_food.id_type_of_food AND id_route = {idRou} AND hotels.id_hotel = {idHotelR}", Connection))
                        {
                            using (var read = cmdOther.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    routeCl.nameHotel = read["name_hotel"].ToString().Trim();
                                    routeCl.nameCountry = read["name_country"].ToString().Trim();
                                    routeCl.nameCity = read["name_city"].ToString().Trim();
                                    routeCl.nameCategoryHotel = read["name_hotel_category"].ToString().Trim();
                                    routeCl.nameTypeFoodHotel = read["name_type_of_food"].ToString().Trim();

                                    var idCit = read["id_city"].ToString().Trim();
                                    routeCl.idCity = Int32.Parse(idCit);

                                    var idCountr = read["id_country"].ToString().Trim();
                                    routeCl.idCountry = Int32.Parse(idCountr);

                                    var idCategHot = read["id_hotel_category"].ToString().Trim();
                                    routeCl.idCategoryHotel = Int32.Parse(idCategHot);

                                    var idTypeF = read["id_type_of_food"].ToString().Trim();
                                    routeCl.idTypeFooHotel = Int32.Parse(idTypeF);
                                }
                            }
                        }
                        dataGridView1.Refresh();
                        AddRoutes(routeCl);
                        MessageBox.Show("Новый тур успешно добавлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if ((textBoxNameRoute.Text.Length <= 2) || (textBoxNameRoute.Text.Length >= 20))
                {
                    MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var comboNameHotel = comboBoxHotels.SelectedItem;

                    using (var cmdIdH = new NpgsqlCommand($"SELECT id_hotel FROM hotels WHERE name_hotel = '{comboNameHotel}'", Connection))
                    {
                        routeCl.idHotel = Convert.ToInt32(cmdIdH.ExecuteScalar());
                    }
                    var idHotelR = routeCl.idHotel;

                    using (var cmd = new NpgsqlCommand($"SELECT id_route FROM routes WHERE id_route = {dataGridView1.SelectedRows[0].Cells[1].Value}", Connection))
                    {
                        int idSelRoute = Convert.ToInt32(cmd.ExecuteScalar());

                        using (var cmdUp = new NpgsqlCommand($"UPDATE routes SET id_hotel = {idHotelR}, " +
                        $"number_of_nights = '{numericUpDownNights.Text.Trim()}', " +
                        $"price = '{textBoxPrice.Text.Trim()}', " +
                        $"name_route = '{textBoxNameRoute.Text.Trim()}' WHERE id_route = {idSelRoute}", Connection))
                        {
                            cmdUp.ExecuteNonQuery();
                        }
                        routeCl.idHotel = idHotelR;

                        var numN = numericUpDownNights.Text.Trim();
                        routeCl.numNights = Int32.Parse(numN);

                        var priceM = textBoxPrice.Text.Trim();
                        routeCl.price = float.Parse(priceM);

                        routeCl.nameRoute = textBoxNameRoute.Text.Trim();

                        using (var cmdOther = new NpgsqlCommand($"Select hotels.name_hotel, countries.name_country, cities.name_city, " +
                        $"hotels_categories.name_hotel_category, typies_of_food.name_type_of_food, " +
                        $"cities.id_city, cities.id_country, hotels.id_hotel_category, hotels.id_type_of_food " +
                        $"FROM routes, countries, cities, hotels, hotels_categories, typies_of_food WHERE routes.id_hotel = hotels.id_hotel " +
                        $"AND countries.id_country = cities.id_country " +
                        $"AND cities.id_city = hotels.id_city " +
                        $"AND routes.id_hotel = hotels.id_hotel " +
                        $"AND hotels.id_hotel_category = hotels_categories.id_hotel_category " +
                        $"AND hotels.id_type_of_food = typies_of_food.id_type_of_food AND id_route = {idSelRoute} AND hotels.id_hotel = {idHotelR}", Connection))
                        {
                            using (var read = cmdOther.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    routeCl.nameHotel = read["name_hotel"].ToString().Trim();
                                    routeCl.nameCountry = read["name_country"].ToString().Trim();
                                    routeCl.nameCity = read["name_city"].ToString().Trim();
                                    routeCl.nameCategoryHotel = read["name_hotel_category"].ToString().Trim();
                                    routeCl.nameTypeFoodHotel = read["name_type_of_food"].ToString().Trim();

                                    var idCit = read["id_city"].ToString().Trim();
                                    routeCl.idCity = Int32.Parse(idCit);

                                    var idCountr = read["id_country"].ToString().Trim();
                                    routeCl.idCountry = Int32.Parse(idCountr);

                                    var idCategHot = read["id_hotel_category"].ToString().Trim();
                                    routeCl.idCategoryHotel = Int32.Parse(idCategHot);

                                    var idTypeF = read["id_type_of_food"].ToString().Trim();
                                    routeCl.idTypeFooHotel = Int32.Parse(idTypeF);
                                }
                            }
                        }
                        UpdateRoutes(routeCl);
                        dataGridView1.Refresh();
                        MessageBox.Show("Данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } 
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Connection.Close();
            Close();
        }

        private void textBox_search_Enter(object sender, EventArgs e)
        {
            if (textBox_search.Text == "Введите название тура")
            {
                textBox_search.Text = "";
                textBox_search.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBox_search_Leave(object sender, EventArgs e)
        {
            if (textBox_search.Text.Length == 0)
            {
                textBox_search.Text = "Введите название тура";
                textBox_search.ForeColor = SystemColors.GrayText;
            }
        }

        private void Routes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.Close();
            start.Close();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (start.role == 0) || (start.role == 1))//delete
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var rowIndexDel = e.RowIndex;
                    var cellDell = dataGridView1.Rows[rowIndexDel].Cells[1].Value;
                    using (var cmdidTr = new NpgsqlCommand($"SELECT COUNT(*) FROM trips WHERE id_route = {cellDell}", Connection))
                    {
                        var idTr = Convert.ToInt32(cmdidTr.ExecuteScalar());
                        if (idTr > 0)
                        {
                            MessageBox.Show("Данные удалены быть не могут! Тур куплен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            using (var cmd = new NpgsqlCommand($"DELETE FROM routes WHERE id_route = '" + cellDell + "' ", Connection))
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

        private void button_show_table_Click_1(object sender, EventArgs e)
        {
            Connection.Close();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            routeList.Clear();
            Connection.Open();
            LoadData();
            FillDGV();
            textBoxNameRoute.Clear();
            textBoxPrice.Clear();
        }

        private void dataGridView1_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            int idRoutCl = 0;
            if (dataGridView1.SelectedRows.Count != 0)//выбрана строка
            {
                using (var cmd = new NpgsqlCommand($"SELECT *from routes WHERE id_route = {dataGridView1.SelectedRows[0].Cells[1].Value}", Connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idRoutCl = reader.GetInt32(0);
                            numericUpDownNights.Value = reader.GetInt32(2);//показываем Ночи
                            decimal bb = reader.GetDecimal(3);
                            textBoxPrice.Text = bb.ToString().Trim();
                            textBoxNameRoute.Text = reader.GetString(4);
                        }
                    }
                }
                using (var cmdCategHot = new NpgsqlCommand($"Select id_route, routes.id_hotel, hotels.name_hotel FROM routes, hotels " +
                    $"WHERE routes.id_hotel = hotels.id_hotel AND routes.id_route = {idRoutCl}", Connection))
                {
                    using (var readerCity = cmdCategHot.ExecuteReader())
                    {
                        while (readerCity.Read())
                        {
                            comboBoxHotels.SelectedItem = readerCity.GetString(2);//выводими данные в комбобокс маршруты
                        }
                    }
                }
            }
        }
    }

    public class RouteCl
    {
        public int idRoute;
        public string nameRoute;
        public int idCountry;
        public string nameCountry;
        public int idCity;
        public string nameCity;
        public int idHotel;
        public string nameHotel;
        public int idCategoryHotel;
        public string nameCategoryHotel;
        public int idTypeFooHotel;
        public string nameTypeFoodHotel;
        public int numNights;
        public float price;
    }
}
