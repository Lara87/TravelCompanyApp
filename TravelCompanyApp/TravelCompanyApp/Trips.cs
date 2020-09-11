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
    public partial class Trips : Form
    {
        Authorization authorization;
        Start start;

        List<TripCl> tripsList = new List<TripCl>();

        private List<int> _idClient = new List<int>();
        private List<int> _idRoute = new List<int>();

        String imgEdit = @"C:\Users\Любовь\Desktop\Учеба\Базы данных\WindowsFormsApp2\pen.png";

        private static readonly NpgsqlConnection Connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["pgConnect"].ConnectionString);//строка соединения

        public Trips(Start s)
        {
            Connection.Open();
            start = s;
            InitializeComponent();
        }

        public void AddTrips(TripCl tripCl)//добавляем новый 
        {
            tripsList.Clear();
            LoadData();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        }

        public void UpdateTrips(TripCl tripCl)//обновляем 
        {
            tripsList.Clear();
            LoadData();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        }

        void LoadData()//загрузили данные
        {
            using (var cmd = new NpgsqlCommand($"SELECT id_trip, trips.id_client, trips.id_route, hotels.id_city, cities.id_country, routes.id_hotel, hotels.id_type_of_food, " +
                $"hotels.id_hotel_category, trips.id_route, surname, name_client, middle_name, date_travel, quantity, total_sum, name_city, name_country, name_hotel, " +
                $"number_of_nights, price, name_route, name_type_of_food, name_hotel_category " +
                $"FROM clientle, trips, cities, countries, hotels, routes, typies_of_food, hotels_categories " +
                $"WHERE trips.id_client = clientle.id_client " +
                $"AND hotels.id_city = cities.id_city " +
                $"AND cities.id_country = countries.id_country " +
                $"AND routes.id_hotel = hotels.id_hotel " +
                $"AND hotels.id_hotel_category = hotels_categories.id_hotel_category " +
                $"AND hotels.id_type_of_food = typies_of_food.id_type_of_food " +
                $"AND trips.id_route = routes.id_route", Connection))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var tripCl = new TripCl();

                        var idT = reader["id_trip"].ToString().Trim();
                        tripCl.idTrip = Int32.Parse(idT);

                        var idC = reader["id_client"].ToString().Trim();
                        tripCl.idClient = Int32.Parse(idC);

                        var idR = reader["id_route"].ToString().Trim();
                        tripCl.idRoute = Int32.Parse(idR);

                        var idCi = reader["id_city"].ToString().Trim();
                        tripCl.idCity = Int32.Parse(idCi);

                        var idCo = reader["id_country"].ToString().Trim();
                        tripCl.idCountry = Int32.Parse(idCo);

                        var idH = reader["id_hotel"].ToString().Trim();
                        tripCl.idHotel = Int32.Parse(idH);

                        var idTF = reader["id_type_of_food"].ToString().Trim();
                        tripCl.idTypeFoodHotel = Int32.Parse(idTF);

                        var idHC = reader["id_hotel_category"].ToString().Trim();
                        tripCl.idCategoryHotel = Int32.Parse(idHC);

                        var priceR = reader["price"].ToString().Trim();
                        tripCl.price = float.Parse(priceR);

                        var nT = reader["quantity"].ToString().Trim();
                        tripCl.numTrip = Int32.Parse(nT);
                        
                        var d = reader["total_sum"].ToString().Trim();
                        tripCl.totalSum = Int32.Parse(d);
                        
                        var nN = reader["number_of_nights"].ToString().Trim();
                        tripCl.numNights = Int32.Parse(nN);

                        tripCl.nameRoute = reader["name_route"].ToString().Trim();

                        tripCl.nameHotel = reader["name_hotel"].ToString().Trim();

                        tripCl.nameCity = reader["name_city"].ToString().Trim();

                        tripCl.nameCountry = reader["name_country"].ToString().Trim();

                        tripCl.nameCategoryHotel = reader["name_hotel_category"].ToString().Trim();

                        tripCl.nameTypeFoodHotel = reader["name_type_of_food"].ToString().Trim();

                        tripCl.nameClient = reader["name_client"].ToString().Trim();

                        tripCl.surnameClient = reader["surname"].ToString().Trim();

                        tripCl.middlenameClient = reader["middle_name"].ToString().Trim();

                        tripCl.dateTravel = reader["date_travel"].ToString().Trim();

                        tripCl.nameTypeFoodHotel = reader["name_type_of_food"].ToString().Trim();

                        tripCl.nameCategoryHotel = reader["name_hotel_category"].ToString().Trim();

                        tripsList.Add(tripCl);
                    }
            }
        }

        void FillDGV()//вывели в таблицу
        {         
            DataGridViewImageColumn imgC2 = new DataGridViewImageColumn();
            dataGridView1.Columns.AddRange(imgC2);

            for (int i = 0; i <= 18; i++)
            {
                DataGridViewTextBoxColumn cl = new DataGridViewTextBoxColumn();
                dataGridView1.Columns.Add(cl);
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Ф.И.О. клиента";
            dataGridView1.Columns[3].HeaderText = "Название тура";
            dataGridView1.Columns[4].HeaderText = "Страна";
            dataGridView1.Columns[5].HeaderText = "Город";
            dataGridView1.Columns[6].HeaderText = "Отель";
            dataGridView1.Columns[7].HeaderText = "Категория отеля";
            dataGridView1.Columns[8].HeaderText = "Тип питания";
            dataGridView1.Columns[9].HeaderText = "Количество ночей";
            dataGridView1.Columns[10].HeaderText = "Стоимость";
            dataGridView1.Columns[11].HeaderText = "Дата";
            dataGridView1.Columns[12].HeaderText = "Кол-во путёвок";
            dataGridView1.Columns[13].HeaderText = "Итого";
            dataGridView1.Columns[1].Width = 32;
            dataGridView1.Columns[3].Width = 150;

            foreach (var el in tripsList)
            {
                //el - userList[i] - бежим по списку элементов
                //ячейки удалить и изменить
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.Height = 32;

                //создаём кнопки редак и удал

                DataGridViewImageCell dataGridViewCellEdit = new DataGridViewImageCell();
                var iedit = Image.FromFile(imgEdit);
                dataGridViewCellEdit.Value = iedit;
                dataGridViewRow.Cells.Add(dataGridViewCellEdit);

                imgC2.Width = 32;

                var idT = el.idTrip;
                DataGridViewCell dGVCell0 = new DataGridViewTextBoxCell();
                dGVCell0.Value = idT;
                dataGridViewRow.Cells.Add(dGVCell0);

                var surnameNMn = shotName(el.surnameClient, el.nameClient, el.middlenameClient);
                DataGridViewCell dGVCell1 = new DataGridViewTextBoxCell();
                dGVCell1.Value = surnameNMn;
                dataGridViewRow.Cells.Add(dGVCell1);

                var nameRo = el.nameRoute;
                DataGridViewCell dGVCell2 = new DataGridViewTextBoxCell();
                dGVCell2.Value = nameRo;
                dataGridViewRow.Cells.Add(dGVCell2);

                var nameCountr = el.nameCountry;
                DataGridViewCell dGVCell3 = new DataGridViewTextBoxCell();
                dGVCell3.Value = nameCountr;
                dataGridViewRow.Cells.Add(dGVCell3);

                var nameCit = el.nameCity;
                DataGridViewCell dGVCell4 = new DataGridViewTextBoxCell();
                dGVCell4.Value = nameCit;
                dataGridViewRow.Cells.Add(dGVCell4);

                var nameHot = el.nameHotel;
                DataGridViewCell dGVCell5 = new DataGridViewTextBoxCell();
                dGVCell5.Value = nameHot;
                dataGridViewRow.Cells.Add(dGVCell5);

                var nameCatHot = el.nameCategoryHotel;
                DataGridViewCell dGVCell6 = new DataGridViewTextBoxCell();
                dGVCell6.Value = nameCatHot;
                dataGridViewRow.Cells.Add(dGVCell6);

                var nameTypeF = el.nameTypeFoodHotel;
                DataGridViewCell dGVCell7 = new DataGridViewTextBoxCell();
                dGVCell7.Value = nameTypeF;
                dataGridViewRow.Cells.Add(dGVCell7);

                var nightsR = el.numNights;
                DataGridViewCell dGVCell8 = new DataGridViewTextBoxCell();
                dGVCell8.Value = nightsR;
                dataGridViewRow.Cells.Add(dGVCell8);

                var priceR = el.price;
                DataGridViewCell dGVCell9 = new DataGridViewTextBoxCell();
                dGVCell9.Value = priceR;
                dataGridViewRow.Cells.Add(dGVCell9);

                var dateT = el.dateTravel;
                DataGridViewCell dGVCell10 = new DataGridViewTextBoxCell();
                dGVCell10.Value = dateT;
                dataGridViewRow.Cells.Add(dGVCell10);

                var numT = el.numTrip;
                DataGridViewCell dGVCell11 = new DataGridViewTextBoxCell();
                dGVCell11.Value = numT;
                dataGridViewRow.Cells.Add(dGVCell11);

                var disc = el.totalSum;
                DataGridViewCell dGVCell12 = new DataGridViewTextBoxCell();
                dGVCell12.Value = disc;
                dataGridViewRow.Cells.Add(dGVCell12);

                var idHot = el.idHotel;
                DataGridViewCell dGVCell13 = new DataGridViewTextBoxCell();
                dGVCell13.Value = idHot;
                dataGridViewRow.Cells.Add(dGVCell13);

                var idCities = el.idCity;
                DataGridViewCell dGVCell14 = new DataGridViewTextBoxCell();
                dGVCell14.Value = idCities;
                dataGridViewRow.Cells.Add(dGVCell14);

                var idCountries = el.idCountry;
                DataGridViewCell dGVCell15 = new DataGridViewTextBoxCell();
                dGVCell15.Value = idCountries;
                dataGridViewRow.Cells.Add(dGVCell15);

                var idCatHot = el.idCategoryHotel;
                DataGridViewCell dGVCell16 = new DataGridViewTextBoxCell();
                dGVCell16.Value = idCatHot;
                dataGridViewRow.Cells.Add(dGVCell16);

                var idTypeF = el.idTypeFoodHotel;
                DataGridViewCell dGVCell17 = new DataGridViewTextBoxCell();
                dGVCell17.Value = idTypeF;
                dataGridViewRow.Cells.Add(dGVCell17);

                var idR = el.idRoute;
                DataGridViewCell dGVCell18 = new DataGridViewTextBoxCell();
                dGVCell18.Value = idR;
                dataGridViewRow.Cells.Add(dGVCell18);

                dataGridView1.Rows.Add(dataGridViewRow);
            }
        }

        private void Trips_Load(object sender, EventArgs e)
        {
            LoadData();
            FillDGV();
            if((start.role == 0) || (start.role == 1))
            {
                button_add.Visible = true;
            }
        }

        public String shotName(String a, String b, String c)
        {
            var N = b.ToUpper().ElementAt(0);
            var MN = c.ToUpper().ElementAt(0);
            a += " " + N + ". " + MN + ".";
            return a;
        }
        
        private void button_back_Click(object sender, EventArgs e)
        {
            Connection.Close();
            start.Show();
            this.Hide();
        }

        private void button_show_table_Click(object sender, EventArgs e)
        {
            Connection.Close();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            tripsList.Clear();
            Connection.Open();
            Trips_Load(sender, e);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Connection.Close();
            Close();
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (start.role == 0) || (start.role == 1))
            {
                //edit
                TripsAddEdit tripsAddEdit = new TripsAddEdit(tripsList[e.RowIndex], false, this);
                tripsAddEdit.Show();
            }
        }
        
        private void Trips_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.Close();
            start.Close();
        }

        private void button_add_Click_1(object sender, EventArgs e)
        {
            TripsAddEdit tripsAddEdit = new TripsAddEdit(null, true, this);
            tripsAddEdit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var cmd = new NpgsqlCommand($"SELECT all_sum_column FROM trips WHERE id_trip = 1", Connection))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        textBoxAllSumColumn.Text = reader["all_sum_column"].ToString().Trim();
                    }
            }
        }
    }

    public class TripCl
    {
        public int idTrip;
        public int idClient;
        public int idCountry;
        public int idCity;
        public int idHotel;
        public int idRoute;
        public int idCategoryHotel;
        public int idTypeFoodHotel;
        public String nameClient;
        public String surnameClient;
        public String middlenameClient;
        public String nameCountry;
        public String nameCity;
        public String nameRoute;
        public String nameHotel;
        public String nameCategoryHotel;
        public String nameTypeFoodHotel;
        public int numNights;
        public float price;
        public int numTrip;
        public int totalSum;
        public String dateTravel;
        public int allSumCol;
    }
}
