using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;//add
using Npgsql;//add

namespace TravelCompanyApp
{
    public partial class Authorization : Form
    {
        private static readonly NpgsqlConnection Connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["pgConnect"].ConnectionString);//строка соединения
        
        public Authorization()
        {
            InitializeComponent();
            
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            Connection.Open();
            if((Login.Text.Length>1)&&(Password.Text.Length>1))
            {
                using (var cmd = new NpgsqlCommand("SELECT users.id_role, roles.name_role FROM users, roles " +
                    "WHERE roles.id_role = users.id_role and login_user='" + Login.Text + "' AND pass_user='" + Password.Text + "'", Connection))//инкапсулируем sql-выражение, которое должно быть выполнено
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var k = reader.GetValue(0).ToString();
                            var m = reader.GetValue(1);
                            Start start = new Start(this, Int32.Parse(k));
                            start.Show();
                            this.Hide();
                        }
                    else
                        {
                            MessageBox.Show("Логин или пароль введены неверно!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Connection.Close();
                        }
                    }
                }
            }
        }
    }
}
