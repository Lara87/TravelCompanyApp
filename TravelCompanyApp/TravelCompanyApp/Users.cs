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
    public partial class Users : Form
    {
        List<User> userList = new List<User>();//создали список для пользователей
        private List<int> _rolesId = new List<int>();//список айдишников маршрутов

        String imgDelete = @"C:\Users\Любовь\Desktop\Учеба\СУБД PostgreSQL\TravelCompanyApp\del.png";

        User users = new User();

        Start start;

        private static readonly NpgsqlConnection Connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["pgConnect"].ConnectionString);//строка соединения

        public Users(Start s)
        {
            Connection.Open();
            start = s;
            InitializeComponent();
            textBox_login_search.ForeColor = SystemColors.GrayText;
            textBox_login_search.Text = "Введите логин";
            this.textBox_login_search.Leave += new System.EventHandler(this.textBox_login_search_Leave);
            this.textBox_login_search.Enter += new System.EventHandler(this.textBox_login_search_Enter);
        }

        void FillComboRole()
        {
            using (var cmd = new NpgsqlCommand("SELECT id_role, name_role FROM roles ORDER BY name_role ASC", Connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _rolesId.Add(reader.GetInt32(0));
                        comboBox_name_role.Items.Add(reader.GetString(1));
                    }
                }
                comboBox_name_role.SelectedIndex = 0;
            }
        }

        void LoadData()//загружаем данные
        {
            using (var cmd = new NpgsqlCommand("SELECT DISTINCT roles.id_role, roles.name_role, users.id_user, users.login_user, users.pass_user FROM roles, users WHERE users.id_role = roles.id_role", Connection))
            {

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var user = new User();
                        user.loginUser = reader["login_user"].ToString().Trim();
                        user.passUser = reader["pass_user"].ToString().Trim();
                        var idUs = reader["id_user"].ToString().Trim();
                        user.idUser = Int32.Parse(idUs);
                        var idRo = reader["id_role"].ToString().Trim();
                        user.idRole = Int32.Parse(idRo);
                        user.nameRole = reader["name_role"].ToString().Trim();
                        userList.Add(user);
                    }
            }
        }

        void FillDGV()//заполнить таблицу
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
            dataGridView1.Columns[2].HeaderText = "Логин";
            dataGridView1.Columns[3].HeaderText = "Пароль";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Наименование роли";
            dataGridView1.Columns[5].Width = 198;
            dataGridView1.Columns[0].Width = 32;

            foreach (var el in userList)
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

                var iduser = el.idUser;
                DataGridViewCell dGVCell = new DataGridViewTextBoxCell();
                dGVCell.Value = iduser;
                dataGridViewRow.Cells.Add(dGVCell);

                var log = el.loginUser;
                DataGridViewCell dGVCell0 = new DataGridViewTextBoxCell();
                dGVCell0.Value = log;
                dataGridViewRow.Cells.Add(dGVCell0);

                var pass = el.passUser;
                DataGridViewCell dGVCell1 = new DataGridViewTextBoxCell();
                dGVCell1.Value = pass;
                dataGridViewRow.Cells.Add(dGVCell1);

                var role = el.idRole;
                DataGridViewCell dGVCell2 = new DataGridViewTextBoxCell();
                dGVCell2.Value = role;
                dataGridViewRow.Cells.Add(dGVCell2);

                var nameRol = el.nameRole;
                DataGridViewCell dGVCell22 = new DataGridViewTextBoxCell();
                dGVCell22.Value = nameRol;
                dataGridViewRow.Cells.Add(dGVCell22);

                dataGridView1.Rows.Add(dataGridViewRow);
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            FillComboRole();
            LoadData();
            FillDGV();
        }

        public void AddUpdateUser(User user)//добавляем нового ползователя
        {
            userList.Add(user);
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        }

        public void UpdateUser(User user)//обновляем данные у существующего пользователя
        {
            userList.Clear();
            LoadData();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            FillDGV();
        }

        private void button_exit_Click(object sender, EventArgs e)//кнопка выход
        {
            Connection.Close();
            Close();
        }

        private void button_back_Click(object sender, EventArgs e)//кнопка назад
        {
            Connection.Close();
            start.Show();
            this.Hide();
        }

        private void Users_FormClosed_1(object sender, FormClosedEventArgs e)//кнопка крестик - закрыли форму
        {
            Connection.Close();
            start.Close();
        }

        private void button_search_Click(object sender, EventArgs e)//кнопка поиска по логину
        {
            if (textBox_login_search.Text.Length == 0)
            {
                MessageBox.Show($"Поле поиска не может быть пустым!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                userList.Clear();

                using (var cmdCount = new NpgsqlCommand($"SELECT COUNT(*) FROM users WHERE login_user LIKE '%" + textBox_login_search.Text.ToString().Trim() + "%'", Connection))
                {
                    int countRows = Convert.ToInt32(cmdCount.ExecuteScalar());
                    if (countRows > 0)
                    {
                        using (var cmd = new NpgsqlCommand("SELECT roles.id_role, roles.name_role, users.id_user, users.login_user, users.pass_user FROM roles, users WHERE users.id_role = roles.id_role AND users.login_user LIKE '%" + textBox_login_search.Text.ToString().Trim() + "%'", Connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var user = new User();
                                    user.loginUser = reader["login_user"].ToString().Trim();
                                    user.passUser = reader["pass_user"].ToString().Trim();
                                    var idUs = reader["id_user"].ToString().Trim();
                                    user.idUser = Int32.Parse(idUs);
                                    var idRo = reader["id_role"].ToString().Trim();
                                    user.idRole = Int32.Parse(idRo);
                                    user.nameRole = reader["name_role"].ToString().Trim();
                                    userList.Add(user);
                                }
                            }
                        }
                        FillDGV();
                        MessageBox.Show($"Найдено " + countRows + " совпадений!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином не зарегистрирован в базе данных!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)//сохранить изменения кнопка
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Вы не выбрали ни одной строки для редактирования! Выберите строку в таблице!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                {
                    if ((textBox_pass.Text.Length <= 5) || (textBox_login.Text.Length <= 2) || (textBox_pass.Text.Length >= 15) || (textBox_login.Text.Length >= 15))
                    {
                        MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var comboNameRole = comboBox_name_role.SelectedItem;

                        using (var cmdIdR = new NpgsqlCommand($"SELECT id_role FROM roles WHERE name_role = '{comboNameRole}'", Connection))
                        {
                            users.idRole = Convert.ToInt32(cmdIdR.ExecuteScalar());
                        }
                        var IdRole = users.idRole;

                        using (var cmd = new NpgsqlCommand($"SELECT id_user FROM users WHERE id_user = {dataGridView1.SelectedRows[0].Cells[1].Value}", Connection))
                        {
                            int idUserSel = Convert.ToInt32(cmd.ExecuteScalar());

                            using (var cmdPass = new NpgsqlCommand($"SELECT COUNT(*) FROM users WHERE pass_user = '{textBox_pass.Text}'", Connection))
                            {
                                int numberMatches = Convert.ToInt32(cmdPass.ExecuteScalar());
                                if (numberMatches > 0)
                                {
                                    MessageBox.Show("Такой пароль в системе уже существует! Придумайте другой!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    using (var cmdUp = new NpgsqlCommand($"UPDATE users SET id_role = {IdRole}, login_user = '{textBox_login.Text.Trim()}', pass_user = '{textBox_pass.Text.Trim()}' " +
                                $"WHERE id_user = {idUserSel}", Connection))
                                    {
                                        cmdUp.ExecuteNonQuery();
                                    }
                                    users.loginUser = textBox_login.Text.Trim();
                                    users.passUser = textBox_pass.Text.Trim();
                                    users.idRole = IdRole;
                                    using (var cmdNameRole = new NpgsqlCommand($"SELECT name_role FROM roles WHERE id_role = {users.idRole}", Connection))
                                    {
                                        using (var read = cmdNameRole.ExecuteReader())
                                        {
                                            while (read.Read())
                                            {
                                                users.nameRole = read["name_role"].ToString().Trim();
                                            }
                                        }
                                    }
                                    UpdateUser(users);
                                    dataGridView1.Refresh();
                                    MessageBox.Show("Данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }

            
        }
    
         
        private void button_add_Click(object sender, EventArgs e)//добавить пользователя кнопка
        {
            using (var cmd = new NpgsqlCommand($"SELECT COUNT(*) FROM users WHERE login_user = '{textBox_login.Text}'", Connection))
            {
                int numberMatches = Convert.ToInt32(cmd.ExecuteScalar());
                if (numberMatches > 0)
                {
                    MessageBox.Show("Пользователь с таким именем уже зарегистрирован!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if ((textBox_pass.Text.Length <= 5) || (textBox_login.Text.Length <= 2) || (textBox_pass.Text.Length >= 15) || (textBox_login.Text.Length >= 15))
                    {
                        MessageBox.Show("Данные введены некорректно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var comboNameRole = comboBox_name_role.SelectedItem;

                        using (var cmdIdR = new NpgsqlCommand($"SELECT id_role FROM roles WHERE name_role = '{comboNameRole}'", Connection))
                        {
                            users.idRole = Convert.ToInt32(cmdIdR.ExecuteScalar());
                        }

                        var idRole = users.idRole;

                        using (var cmdInto = new NpgsqlCommand($"INSERT INTO users(id_role, login_user, pass_user) values ({idRole}, '{textBox_login.Text}', '{textBox_pass.Text}')", Connection))
                        {
                            cmdInto.ExecuteNonQuery();
                        }
                        users.loginUser = textBox_login.Text;
                        users.passUser = textBox_pass.Text;
                        users.idRole = idRole;
                        using (var cmdNameRole = new NpgsqlCommand($"SELECT name_role FROM roles WHERE id_role = {idRole}", Connection))
                        {
                            using (var read = cmdNameRole.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    users.nameRole = read["name_role"].ToString().Trim();
                                }
                            }
                        }
                        AddUpdateUser(users);
                        dataGridView1.Refresh();
                        MessageBox.Show("Новый пользователь успешно добавлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)//отслеживаем нажатие на таблице + выводим выделенные данные в текстбокс и комбобокс
        {
            if(e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            int idRole = 0;
            if(dataGridView1.SelectedRows.Count!=0)//выбрана строка
            {
                using (var cmd = new NpgsqlCommand($"SELECT *from users WHERE id_user = {dataGridView1.SelectedRows[0].Cells[1].Value}", Connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idRole = reader.GetInt32(1);
                            textBox_login.Text = reader.GetString(2);
                            textBox_pass.Text = reader.GetString(3);
                        }
                    }
                }

                using (var cmdUsers = new NpgsqlCommand($"SELECT id_user, users.id_role, name_role FROM users, roles WHERE users.id_role = roles.id_role AND users.id_role = {idRole}", Connection))
                {
                    using (var readerUsers = cmdUsers.ExecuteReader())
                    {
                        while (readerUsers.Read())
                        {
                            comboBox_name_role.SelectedItem = readerUsers.GetString(2);//выводими данные в комбобокс маршруты
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//удаляем пользователя
        {
            if (e.ColumnIndex == 0)//delete
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var rowIndexDel = e.RowIndex;
                    var cellDell = dataGridView1.Rows[rowIndexDel].Cells[1].Value;
                    using (var cmd = new NpgsqlCommand($"DELETE FROM users WHERE id_user = '" + cellDell + "' ", Connection))
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

        private void textBox_login_search_Leave(object sender, EventArgs e)
        {
            if (textBox_login_search.Text.Length == 0)
            {
                textBox_login_search.Text = "Введите логин";
                textBox_login_search.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox_login_search_Enter(object sender, EventArgs e)
        {
            if (textBox_login_search.Text == "Введите логин")
            {
                textBox_login_search.Text = "";
                textBox_login_search.ForeColor = SystemColors.WindowText;
            }
        }

        private void button_show_table_Click(object sender, EventArgs e)//показать таблицу
        {
            Connection.Close();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            userList.Clear();
            Connection.Open();
            LoadData();
            FillDGV();
            textBox_login.Clear();
            textBox_pass.Clear();
            textBox_login_search.Clear();
        }
    }

    public class User
    {
            public int idRole;
            public String nameRole;
            public String loginUser;
            public String passUser;
            public int idUser;
    }
}
