namespace TravelCompanyApp
{
    partial class Routes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Routes));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxHotels = new System.Windows.Forms.ComboBox();
            this.labelHotels = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.button_show_table = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelNights = new System.Windows.Forms.Label();
            this.numericUpDownNights = new System.Windows.Forms.NumericUpDown();
            this.labelNameRoute = new System.Windows.Forms.Label();
            this.textBoxNameRoute = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNights)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(925, 553);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged_1);
            // 
            // comboBoxHotels
            // 
            this.comboBoxHotels.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxHotels.FormattingEnabled = true;
            this.comboBoxHotels.Location = new System.Drawing.Point(959, 151);
            this.comboBoxHotels.Name = "comboBoxHotels";
            this.comboBoxHotels.Size = new System.Drawing.Size(379, 47);
            this.comboBoxHotels.TabIndex = 3;
            // 
            // labelHotels
            // 
            this.labelHotels.AutoSize = true;
            this.labelHotels.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHotels.Location = new System.Drawing.Point(1118, 109);
            this.labelHotels.Name = "labelHotels";
            this.labelHotels.Size = new System.Drawing.Size(65, 39);
            this.labelHotels.TabIndex = 8;
            this.labelHotels.Text = "Отель";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPrice.Location = new System.Drawing.Point(959, 392);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(379, 43);
            this.textBoxPrice.TabIndex = 11;
            // 
            // button_show_table
            // 
            this.button_show_table.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_show_table.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_show_table.Image = ((System.Drawing.Image)(resources.GetObject("button_show_table.Image")));
            this.button_show_table.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_show_table.Location = new System.Drawing.Point(603, 649);
            this.button_show_table.Name = "button_show_table";
            this.button_show_table.Size = new System.Drawing.Size(208, 45);
            this.button_show_table.TabIndex = 30;
            this.button_show_table.Text = "Показать таблицу";
            this.button_show_table.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_show_table.UseVisualStyleBackColor = true;
            this.button_show_table.Click += new System.EventHandler(this.button_show_table_Click_1);
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.Image = ((System.Drawing.Image)(resources.GetObject("button_save.Image")));
            this.button_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_save.Location = new System.Drawing.Point(1000, 520);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(300, 45);
            this.button_save.TabIndex = 29;
            this.button_save.Text = "Изменить тур";
            this.button_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_search.Location = new System.Drawing.Point(12, 586);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(300, 43);
            this.textBox_search.TabIndex = 28;
            this.textBox_search.Enter += new System.EventHandler(this.textBox_search_Enter);
            this.textBox_search.Leave += new System.EventHandler(this.textBox_search_Leave);
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Image = ((System.Drawing.Image)(resources.GetObject("button_exit.Image")));
            this.button_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_exit.Location = new System.Drawing.Point(1234, 649);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(104, 45);
            this.button_exit.TabIndex = 27;
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
            this.button_add.Location = new System.Drawing.Point(1000, 457);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(300, 45);
            this.button_add.TabIndex = 26;
            this.button_add.Text = "Добавить тур";
            this.button_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back.Image = ((System.Drawing.Image)(resources.GetObject("button_back.Image")));
            this.button_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_back.Location = new System.Drawing.Point(12, 649);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(104, 45);
            this.button_back.TabIndex = 25;
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
            this.button_search.Location = new System.Drawing.Point(353, 585);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(124, 45);
            this.button_search.TabIndex = 24;
            this.button_search.Text = "Искать";
            this.button_search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.Location = new System.Drawing.Point(1103, 338);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(106, 39);
            this.labelPrice.TabIndex = 32;
            this.labelPrice.Text = "Стоимость";
            // 
            // labelNights
            // 
            this.labelNights.AutoSize = true;
            this.labelNights.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNights.Location = new System.Drawing.Point(1082, 216);
            this.labelNights.Name = "labelNights";
            this.labelNights.Size = new System.Drawing.Size(155, 39);
            this.labelNights.TabIndex = 12;
            this.labelNights.Text = "Количество ночей";
            // 
            // numericUpDownNights
            // 
            this.numericUpDownNights.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownNights.Location = new System.Drawing.Point(1125, 272);
            this.numericUpDownNights.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.numericUpDownNights.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNights.Name = "numericUpDownNights";
            this.numericUpDownNights.Size = new System.Drawing.Size(69, 43);
            this.numericUpDownNights.TabIndex = 5;
            this.numericUpDownNights.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelNameRoute
            // 
            this.labelNameRoute.AutoSize = true;
            this.labelNameRoute.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameRoute.Location = new System.Drawing.Point(1091, 12);
            this.labelNameRoute.Name = "labelNameRoute";
            this.labelNameRoute.Size = new System.Drawing.Size(135, 39);
            this.labelNameRoute.TabIndex = 34;
            this.labelNameRoute.Text = "Название тура";
            // 
            // textBoxNameRoute
            // 
            this.textBoxNameRoute.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameRoute.Location = new System.Drawing.Point(959, 63);
            this.textBoxNameRoute.Name = "textBoxNameRoute";
            this.textBoxNameRoute.Size = new System.Drawing.Size(379, 43);
            this.textBoxNameRoute.TabIndex = 33;
            // 
            // Routes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 711);
            this.Controls.Add(this.labelNameRoute);
            this.Controls.Add(this.textBoxNameRoute);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.button_show_table);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.labelNights);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelHotels);
            this.Controls.Add(this.numericUpDownNights);
            this.Controls.Add(this.comboBoxHotels);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Routes";
            this.Text = "Туры";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Routes_FormClosed);
            this.Load += new System.EventHandler(this.Routes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNights)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxHotels;
        private System.Windows.Forms.Label labelHotels;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Button button_show_table;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelNights;
        private System.Windows.Forms.NumericUpDown numericUpDownNights;
        private System.Windows.Forms.Label labelNameRoute;
        private System.Windows.Forms.TextBox textBoxNameRoute;
    }
}