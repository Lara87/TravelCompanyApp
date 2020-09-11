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
    public partial class AboutProgramms : Form
    {
        Start start;      

        public AboutProgramms(Start s)
        {
            start = s;
            InitializeComponent();
        }

        private void AboutProgramms_Load(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Text = "Астраханский государтсвенный технический университет" + "\n" +
                "Институт информационных технологий и коммуникаций" + "\n" +
                "Кафедра автоматизированные системы обработки информации и управления" + "\n" +
                "\n" +
                "Курсовой проект" + "\n" +
                "\n" +
                "Программа: Туристическая фирма" + "\n" +
                "по дисциплине: СУБД PostgreSQL" + "\n" +
                "Проект выполнен студенткой группы ЗИНРБ - 41 Черниковой Л.В." + "\n" +
                "\n" +
                "Руководитель работы: ст.преподаватель Куркурин Н.Д.";
            richTextBox1.Paste();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            start.Show();
            this.Hide();
        }

        private void AboutProgramms_FormClosed(object sender, FormClosedEventArgs e)
        {
            start.Close();
        }
    }
}
