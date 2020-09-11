using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelCompanyApp
{
    public partial class Start : Form
    {
        Authorization authorization;

        public int role;

        public Start(Authorization auth, int role)
        {
            this.role = role;
            authorization = auth;
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            if(role == 1)
            {
                button_users.Enabled = false;
           
            }
            else if(role==2)
            {
                button_users.Enabled = false;
                button_clientele.Enabled = false;
                button_countries_cities.Enabled = false;
                button_trips.Enabled = false;
            }
            else if(role!=0)
            {

            }
        }

        private void Start_FormClosed(object sender, FormClosedEventArgs e)
        {
            authorization.Close();
        }

        private void button_users_Click(object sender, EventArgs e)
        {
            Users users = new Users(this);
            users.Show();
            this.Hide();
        }

        private void button_clientele_Click(object sender, EventArgs e)
        {
            Clientele clientele = new Clientele(this);
            clientele.Show();
            this.Hide();
        }

        private void button_countries_cities_Click(object sender, EventArgs e)
        {
            Countries countries = new Countries(this);
            countries.Show();
            this.Hide();
        }

        private void button_routes_Click(object sender, EventArgs e)
        {
            Routes routes = new Routes(this);
            routes.Show();
            this.Hide();
        }

        private void button_trips_Click(object sender, EventArgs e)
        {
            Trips trips = new Trips(this);
            trips.Show();
            this.Hide();
        }

        private void button_residence_Click(object sender, EventArgs e)
        {
            Hotels hotels = new Hotels(this);
            hotels.Show();
            this.Hide();
        }

        private void button_about_programs_Click(object sender, EventArgs e)
        {
            AboutProgramms aboutProgramms = new AboutProgramms(this);
            aboutProgramms.Show();
            this.Hide();
        }
    }
}
