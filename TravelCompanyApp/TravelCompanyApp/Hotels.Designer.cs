namespace TravelCompanyApp
{
    partial class Hotels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hotels));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNameCity = new System.Windows.Forms.Label();
            this.comboBoxNameCity = new System.Windows.Forms.ComboBox();
            this.button_show_table = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.textBoxNameHotel = new System.Windows.Forms.TextBox();
            this.comboBoxCategoryHotel = new System.Windows.Forms.ComboBox();
            this.comboBoxTypeFoodHotel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(810, 502);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(839, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Название отеля";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(828, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "Категория отеля";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(892, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "Питание";
            // 
            // labelNameCity
            // 
            this.labelNameCity.AutoSize = true;
            this.labelNameCity.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameCity.Location = new System.Drawing.Point(921, 81);
            this.labelNameCity.Name = "labelNameCity";
            this.labelNameCity.Size = new System.Drawing.Size(59, 39);
            this.labelNameCity.TabIndex = 7;
            this.labelNameCity.Text = "Город";
            // 
            // comboBoxNameCity
            // 
            this.comboBoxNameCity.DropDownHeight = 350;
            this.comboBoxNameCity.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxNameCity.FormattingEnabled = true;
            this.comboBoxNameCity.IntegralHeight = false;
            this.comboBoxNameCity.Location = new System.Drawing.Point(986, 78);
            this.comboBoxNameCity.Name = "comboBoxNameCity";
            this.comboBoxNameCity.Size = new System.Drawing.Size(273, 47);
            this.comboBoxNameCity.TabIndex = 8;
            // 
            // button_show_table
            // 
            this.button_show_table.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_show_table.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_show_table.Image = ((System.Drawing.Image)(resources.GetObject("button_show_table.Image")));
            this.button_show_table.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_show_table.Location = new System.Drawing.Point(846, 576);
            this.button_show_table.Name = "button_show_table";
            this.button_show_table.Size = new System.Drawing.Size(208, 45);
            this.button_show_table.TabIndex = 23;
            this.button_show_table.Text = "Показать таблицу";
            this.button_show_table.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_show_table.UseVisualStyleBackColor = true;
            this.button_show_table.Click += new System.EventHandler(this.button_show_table_Click);
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.Image = ((System.Drawing.Image)(resources.GetObject("button_save.Image")));
            this.button_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_save.Location = new System.Drawing.Point(959, 400);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(300, 45);
            this.button_save.TabIndex = 22;
            this.button_save.Text = "Редактировать данные отеля";
            this.button_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_search.Location = new System.Drawing.Point(206, 578);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(300, 43);
            this.textBox_search.TabIndex = 21;
            this.textBox_search.Enter += new System.EventHandler(this.textBox_search_Enter);
            this.textBox_search.Leave += new System.EventHandler(this.textBox_search_Leave);
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Image = ((System.Drawing.Image)(resources.GetObject("button_exit.Image")));
            this.button_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_exit.Location = new System.Drawing.Point(1155, 576);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(104, 45);
            this.button_exit.TabIndex = 20;
            this.button_exit.Text = "Выход";
            this.button_exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_add
            // 
            this.button_add.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add.Image = ((System.Drawing.Image)(resources.GetObject("button_add.Image")));
            this.button_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_add.Location = new System.Drawing.Point(959, 312);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(300, 45);
            this.button_add.TabIndex = 19;
            this.button_add.Text = "Добавить отель";
            this.button_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back.Image = ((System.Drawing.Image)(resources.GetObject("button_back.Image")));
            this.button_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_back.Location = new System.Drawing.Point(12, 576);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(104, 45);
            this.button_back.TabIndex = 18;
            this.button_back.Text = "Назад";
            this.button_back.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_search
            // 
            this.button_search.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_search.Image = ((System.Drawing.Image)(resources.GetObject("button_search.Image")));
            this.button_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_search.Location = new System.Drawing.Point(577, 576);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(124, 45);
            this.button_search.TabIndex = 17;
            this.button_search.Text = "Искать";
            this.button_search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBoxNameHotel
            // 
            this.textBoxNameHotel.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameHotel.Location = new System.Drawing.Point(986, 12);
            this.textBoxNameHotel.Name = "textBoxNameHotel";
            this.textBoxNameHotel.Size = new System.Drawing.Size(273, 43);
            this.textBoxNameHotel.TabIndex = 3;
            // 
            // comboBoxCategoryHotel
            // 
            this.comboBoxCategoryHotel.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCategoryHotel.FormattingEnabled = true;
            this.comboBoxCategoryHotel.IntegralHeight = false;
            this.comboBoxCategoryHotel.Location = new System.Drawing.Point(986, 148);
            this.comboBoxCategoryHotel.Name = "comboBoxCategoryHotel";
            this.comboBoxCategoryHotel.Size = new System.Drawing.Size(273, 47);
            this.comboBoxCategoryHotel.TabIndex = 24;
            // 
            // comboBoxTypeFoodHotel
            // 
            this.comboBoxTypeFoodHotel.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTypeFoodHotel.FormattingEnabled = true;
            this.comboBoxTypeFoodHotel.IntegralHeight = false;
            this.comboBoxTypeFoodHotel.Location = new System.Drawing.Point(986, 221);
            this.comboBoxTypeFoodHotel.Name = "comboBoxTypeFoodHotel";
            this.comboBoxTypeFoodHotel.Size = new System.Drawing.Size(273, 47);
            this.comboBoxTypeFoodHotel.TabIndex = 25;
            // 
            // Hotels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 633);
            this.Controls.Add(this.comboBoxTypeFoodHotel);
            this.Controls.Add(this.comboBoxCategoryHotel);
            this.Controls.Add(this.button_show_table);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.comboBoxNameCity);
            this.Controls.Add(this.labelNameCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNameHotel);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Hotels";
            this.Text = "Отели";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Hotels_FormClosed);
            this.Load += new System.EventHandler(this.Hotels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNameCity;
        private System.Windows.Forms.ComboBox comboBoxNameCity;
        private System.Windows.Forms.Button button_show_table;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBoxNameHotel;
        private System.Windows.Forms.ComboBox comboBoxCategoryHotel;
        private System.Windows.Forms.ComboBox comboBoxTypeFoodHotel;
    }
}