namespace TravelCompanyApp
{
    partial class Countries
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Countries));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_search_cities = new System.Windows.Forms.Button();
            this.label_name_countries = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_cities = new System.Windows.Forms.TextBox();
            this.label_cities = new System.Windows.Forms.Label();
            this.comboBox_name_countries = new System.Windows.Forms.ComboBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_show_table = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(496, 360);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // textBox_search
            // 
            this.textBox_search.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_search.Location = new System.Drawing.Point(208, 395);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(300, 43);
            this.textBox_search.TabIndex = 9;
            this.textBox_search.Enter += new System.EventHandler(this.textBox_search_Enter);
            this.textBox_search.Leave += new System.EventHandler(this.textBox_search_Leave);
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Image = ((System.Drawing.Image)(resources.GetObject("button_exit.Image")));
            this.button_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_exit.Location = new System.Drawing.Point(963, 393);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(104, 45);
            this.button_exit.TabIndex = 8;
            this.button_exit.Text = "Выход";
            this.button_exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back.Image = ((System.Drawing.Image)(resources.GetObject("button_back.Image")));
            this.button_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_back.Location = new System.Drawing.Point(12, 393);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(104, 45);
            this.button_back.TabIndex = 7;
            this.button_back.Text = "Назад";
            this.button_back.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_search_cities
            // 
            this.button_search_cities.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_search_cities.Image = ((System.Drawing.Image)(resources.GetObject("button_search_cities.Image")));
            this.button_search_cities.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_search_cities.Location = new System.Drawing.Point(539, 393);
            this.button_search_cities.Name = "button_search_cities";
            this.button_search_cities.Size = new System.Drawing.Size(281, 45);
            this.button_search_cities.TabIndex = 6;
            this.button_search_cities.Text = "Поиск по названию города";
            this.button_search_cities.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_search_cities.UseVisualStyleBackColor = true;
            this.button_search_cities.Click += new System.EventHandler(this.button_search_countries_Click);
            // 
            // label_name_countries
            // 
            this.label_name_countries.AutoSize = true;
            this.label_name_countries.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name_countries.Location = new System.Drawing.Point(668, 13);
            this.label_name_countries.Name = "label_name_countries";
            this.label_name_countries.Size = new System.Drawing.Size(79, 39);
            this.label_name_countries.TabIndex = 17;
            this.label_name_countries.Text = "Страна";
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.Image = ((System.Drawing.Image)(resources.GetObject("button_save.Image")));
            this.button_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_save.Location = new System.Drawing.Point(764, 230);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(300, 45);
            this.button_save.TabIndex = 22;
            this.button_save.Text = "Изменить город";
            this.button_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_cities
            // 
            this.textBox_cities.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_cities.Location = new System.Drawing.Point(764, 70);
            this.textBox_cities.Name = "textBox_cities";
            this.textBox_cities.Size = new System.Drawing.Size(300, 43);
            this.textBox_cities.TabIndex = 19;
            // 
            // label_cities
            // 
            this.label_cities.AutoSize = true;
            this.label_cities.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_cities.Location = new System.Drawing.Point(668, 74);
            this.label_cities.Name = "label_cities";
            this.label_cities.Size = new System.Drawing.Size(59, 39);
            this.label_cities.TabIndex = 18;
            this.label_cities.Text = "Город";
            // 
            // comboBox_name_countries
            // 
            this.comboBox_name_countries.DropDownHeight = 350;
            this.comboBox_name_countries.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_name_countries.FormattingEnabled = true;
            this.comboBox_name_countries.IntegralHeight = false;
            this.comboBox_name_countries.Location = new System.Drawing.Point(764, 10);
            this.comboBox_name_countries.Name = "comboBox_name_countries";
            this.comboBox_name_countries.Size = new System.Drawing.Size(300, 47);
            this.comboBox_name_countries.TabIndex = 16;
            // 
            // button_add
            // 
            this.button_add.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add.Image = ((System.Drawing.Image)(resources.GetObject("button_add.Image")));
            this.button_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_add.Location = new System.Drawing.Point(764, 149);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(300, 45);
            this.button_add.TabIndex = 15;
            this.button_add.Text = "Добавить город";
            this.button_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_show_table
            // 
            this.button_show_table.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_show_table.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_show_table.Image = ((System.Drawing.Image)(resources.GetObject("button_show_table.Image")));
            this.button_show_table.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_show_table.Location = new System.Drawing.Point(533, 230);
            this.button_show_table.Name = "button_show_table";
            this.button_show_table.Size = new System.Drawing.Size(214, 45);
            this.button_show_table.TabIndex = 23;
            this.button_show_table.Text = "Показать таблицу";
            this.button_show_table.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_show_table.UseVisualStyleBackColor = true;
            this.button_show_table.Click += new System.EventHandler(this.button_show_table_Click);
            // 
            // Countries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 450);
            this.Controls.Add(this.button_show_table);
            this.Controls.Add(this.label_name_countries);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textBox_cities);
            this.Controls.Add(this.label_cities);
            this.Controls.Add(this.comboBox_name_countries);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_search_cities);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Countries";
            this.Text = "Страны и города";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Countries_FormClosed);
            this.Load += new System.EventHandler(this.Countries_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_search_cities;
        private System.Windows.Forms.Label label_name_countries;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_cities;
        private System.Windows.Forms.Label label_cities;
        private System.Windows.Forms.ComboBox comboBox_name_countries;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_show_table;
    }
}