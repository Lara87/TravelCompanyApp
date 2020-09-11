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
    public partial class TripsAddEdit : Form
    {
        Trips pForm;
        bool AddOrUpd1;

        private static readonly NpgsqlConnection Connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["pgConnect"].ConnectionString);//строка соединения

        TripCl tripsSS;

        private List<int> _idClient = new List<int>();
        private List<int> _idRoute = new List<int>();

        public TripsAddEdit(TripCl tripCl, bool AddOrUpd, Trips pForms)
        {
           // Connection.Open();
            this.AddOrUpd1 = AddOrUpd;
            this.pForm = pForms;
            tripsSS = tripCl;
            InitializeComponent();
            dateTimePickerTravel.Format = DateTimePickerFormat.Custom;
        }

        void fillComboboxNameRoute()
        {
            Connection.Open();
            using (var cmdRoute = new NpgsqlCommand("SELECT id_route, name_route FROM routes", Connection))
            {
                using (var reader = cmdRoute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _idRoute.Add(reader.GetInt32(0));
                        comboBoxNameRoute.Items.Add(reader.GetString(1));
                    }
                    comboBoxNameRoute.SelectedIndex = 0;
                }
            }
            Connection.Close();
        }

        void fillComboboxNameCliente()
        {
            Connection.Open();
            using (var cmdClientle = new NpgsqlCommand($"Select id_client, surname, name_client, middle_name from clientle", Connection))
            {
                using (var readerClientle = cmdClientle.ExecuteReader())
                {
                    while (readerClientle.Read())
                    {
                        _idClient.Add(readerClientle.GetInt32(0));
                        comboBoxNameClient.Items.Add($"{readerClientle.GetString(1)} {readerClientle.GetString(2)} {readerClientle.GetString(3)}");
                    }
                    comboBoxNameClient.SelectedIndex = 0;
                }
            }
            Connection.Close();
        }

        private void TripsAddEdit_Load(object sender, EventArgs e)
        {
            fillComboboxNameCliente();
            fillComboboxNameRoute();
            if (!AddOrUpd1)//Upd - false
            {
                Connection.Open();
                var idTrtr = tripsSS.idTrip;
                IdTrips_pk.Text = idTrtr.ToString().Trim();
                comboBoxNameClient.Text = pForm.shotName(tripsSS.surnameClient, tripsSS.nameClient, tripsSS.middlenameClient);
                comboBoxNameRoute.Text = tripsSS.nameRoute;
                dateTimePickerTravel.Text = tripsSS.dateTravel;
                numericUpDownQuantity.Value = tripsSS.numTrip;
                var totalSm = tripsSS.totalSum;
                textBoxTotalSum.Text = totalSm.ToString();
                var priceTr = tripsSS.price;
                textBox1Price.Text = priceTr.ToString();
                Connection.Close();
            }

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Connection.Close();
            this.Close();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Connection.Open();
            if (textBoxTotalSum.Text.Length > 0)
            {
                if (AddOrUpd1)//Upd - false
                {//Add
                    var tripC = new TripCl();
                    var cNCl = comboBoxNameClient.SelectedItem.ToString();
                    var comboSurnameClient = cNCl.Split()[0];
                    var comboNameClient = cNCl.Split()[1];
                    var comboMiddleNameCLient = cNCl.Split()[2];//$""
                    using (var cmdIdClient = new NpgsqlCommand($"SELECT id_client FROM clientle WHERE surname = '{comboSurnameClient}' " +
                        $"AND name_client ='{comboNameClient}' AND middle_name = '{comboMiddleNameCLient}'", Connection))
                    {
                        tripC.idClient = Convert.ToInt32(cmdIdClient.ExecuteScalar());
                    }
                    var idCl = tripC.idClient;

                    var comboNameRoute = comboBoxNameRoute.SelectedItem.ToString();
                    using (var cmdIdRoute = new NpgsqlCommand($"SELECT id_route FROM routes WHERE name_route = '{comboNameRoute}'", Connection))
                    {
                        tripC.idRoute = Convert.ToInt32(cmdIdRoute.ExecuteScalar());
                    }
                    var idR = tripC.idRoute;

                    tripC.dateTravel = dateTimePickerTravel.Text.ToString().Trim();
                    var dT = tripC.dateTravel;


                    var totalS = textBoxTotalSum.Text.ToString().Trim();
                    tripC.totalSum = Int32.Parse(totalS);

                    var qu = numericUpDownQuantity.Text.Trim();
                    tripC.numTrip = Int32.Parse(qu);

                    using (var cmdInto = new NpgsqlCommand($"INSERT INTO trips(id_client, id_route, date_travel, quantity, total_sum) values " +
                                $"({idCl}, '{idR}', '{dateTimePickerTravel.Value}', '{qu}', '{totalS}')", Connection))
                    {
                        cmdInto.ExecuteNonQuery();
                    }

                    var idTr = 0;

                    using (var cmdMax = new NpgsqlCommand($"Select MAX(id_trip) FROM trips", Connection))
                    {
                        idTr = Convert.ToInt32(cmdMax.ExecuteScalar());
                    }
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
                    $"AND trips.id_route = routes.id_route " +
                    $"AND id_trip = {idTr}", Connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var priceR = reader["price"].ToString().Trim();
                                var nN = reader["number_of_nights"].ToString().Trim();
                                pForm.AddTrips(new TripCl()
                                {
                                    nameRoute = reader["name_route"].ToString().Trim(),
                                    surnameClient = tripC.surnameClient = reader["surname"].ToString().Trim(),
                                    nameClient = reader["name_client"].ToString().Trim(),
                                    middlenameClient = reader["middle_name"].ToString().Trim(),
                                    nameCountry = reader["name_country"].ToString().Trim(),
                                    nameCategoryHotel = reader["name_hotel_category"].ToString().Trim(),
                                    nameCity = reader["name_city"].ToString().Trim(),
                                    nameHotel = reader["name_hotel"].ToString().Trim(),
                                    nameTypeFoodHotel = reader["name_type_of_food"].ToString().Trim(),
                                    price = float.Parse(priceR),
                                    numNights = Int32.Parse(nN),
                                    dateTravel = reader["date_travel"].ToString().Trim().Remove(10),

                                });
                            }
                        MessageBox.Show("Данные успешно добавлены!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Connection.Close();
                }
                else
                {
                    var tripC = new TripCl();
                    var cNCl = comboBoxNameClient.SelectedItem.ToString();
                    var comboSurnameClient = cNCl.Split()[0];
                    var comboNameClient = cNCl.Split()[1];
                    var comboMiddleNameCLient = cNCl.Split()[2];//$""

                    using (var cmdIdClient = new NpgsqlCommand($"SELECT id_client FROM clientle WHERE surname = '{comboSurnameClient}' " +
                    $"AND name_client ='{comboNameClient}' AND middle_name = '{comboMiddleNameCLient}'", Connection))
                    {
                        tripC.idClient = Convert.ToInt32(cmdIdClient.ExecuteScalar());
                    }
                    var idCl = tripC.idClient;

                    var comboNameRoute = comboBoxNameRoute.SelectedItem.ToString();
                    using (var cmdIdRoute = new NpgsqlCommand($"SELECT id_route FROM routes WHERE name_route = '{comboNameRoute}'", Connection))
                    {
                        tripC.idRoute = Convert.ToInt32(cmdIdRoute.ExecuteScalar());
                    }
                    var idR = tripC.idRoute;

                    tripC.dateTravel = dateTimePickerTravel.Text.ToString().Trim();
                    var dT = tripC.dateTravel;

                    var qu = numericUpDownQuantity.Text.Trim();
                    tripC.numTrip = Int32.Parse(qu);

                    var totalS = textBoxTotalSum.Text.ToString().Trim();
                    tripC.totalSum = Int32.Parse(totalS);

                    using (var cmd = new NpgsqlCommand($"UPDATE trips SET id_client = {idCl}, id_route = {idR}, date_travel = '{dT}' ," +
                    $"quantity = {qu}, total_sum = {totalS} WHERE id_trip = {IdTrips_pk.Text}", Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
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
                    $"AND trips.id_route = routes.id_route " +
                    $"AND id_trip = {IdTrips_pk.Text}", Connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                            while (reader.Read())
                            {
                                var priceR = reader["price"].ToString().Trim();
                                var nN = reader["number_of_nights"].ToString().Trim();
                                pForm.UpdateTrips(new TripCl()
                                {
                                    nameRoute = reader["name_route"].ToString().Trim(),
                                    surnameClient = tripC.surnameClient = reader["surname"].ToString().Trim(),
                                    nameClient = reader["name_client"].ToString().Trim(),
                                    middlenameClient = reader["middle_name"].ToString().Trim(),
                                    nameCountry = reader["name_country"].ToString().Trim(),
                                    nameCategoryHotel = reader["name_hotel_category"].ToString().Trim(),
                                    nameCity = reader["name_city"].ToString().Trim(),
                                    nameHotel = reader["name_hotel"].ToString().Trim(),
                                    nameTypeFoodHotel = reader["name_type_of_food"].ToString().Trim(),
                                    price = float.Parse(priceR),
                                    numNights = Int32.Parse(nN),
                                    dateTravel = reader["date_travel"].ToString().Trim().Remove(10)
                                });
                            }
                        MessageBox.Show("Данные успешно изменены!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Итоговая стоимость не заполнена!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Connection.Close();
        }

        private void TripsAddEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.Close();
            this.Close();
        }

        private void textBox1Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBoxTotalSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!Char.IsDigit(num) && num != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
