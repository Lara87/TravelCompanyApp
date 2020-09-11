namespace TravelCompanyApp
{
    partial class TripsAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TripsAddEdit));
            this.button_save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNameClient = new System.Windows.Forms.ComboBox();
            this.comboBoxNameRoute = new System.Windows.Forms.ComboBox();
            this.dateTimePickerTravel = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.button_back = new System.Windows.Forms.Button();
            this.IdTrips_pk = new System.Windows.Forms.Label();
            this.textBoxTotalSum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1Price = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.Image = ((System.Drawing.Image)(resources.GetObject("button_save.Image")));
            this.button_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_save.Location = new System.Drawing.Point(345, 447);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(163, 45);
            this.button_save.TabIndex = 48;
            this.button_save.Text = "Сохранить";
            this.button_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 39);
            this.label4.TabIndex = 45;
            this.label4.Text = "Количество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 39);
            this.label3.TabIndex = 44;
            this.label3.Text = "Дата отправления";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 39);
            this.label2.TabIndex = 43;
            this.label2.Text = "Название тура";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 39);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ф.И.О. клиента";
            // 
            // comboBoxNameClient
            // 
            this.comboBoxNameClient.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxNameClient.FormattingEnabled = true;
            this.comboBoxNameClient.Location = new System.Drawing.Point(208, 22);
            this.comboBoxNameClient.Name = "comboBoxNameClient";
            this.comboBoxNameClient.Size = new System.Drawing.Size(301, 47);
            this.comboBoxNameClient.TabIndex = 41;
            // 
            // comboBoxNameRoute
            // 
            this.comboBoxNameRoute.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxNameRoute.FormattingEnabled = true;
            this.comboBoxNameRoute.Location = new System.Drawing.Point(208, 84);
            this.comboBoxNameRoute.Name = "comboBoxNameRoute";
            this.comboBoxNameRoute.Size = new System.Drawing.Size(300, 47);
            this.comboBoxNameRoute.TabIndex = 40;
            // 
            // dateTimePickerTravel
            // 
            this.dateTimePickerTravel.CalendarFont = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerTravel.CustomFormat = "dd.MM.yyyy";
            this.dateTimePickerTravel.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerTravel.Location = new System.Drawing.Point(309, 159);
            this.dateTimePickerTravel.Name = "dateTimePickerTravel";
            this.dateTimePickerTravel.Size = new System.Drawing.Size(199, 43);
            this.dateTimePickerTravel.TabIndex = 39;
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownQuantity.Location = new System.Drawing.Point(388, 224);
            this.numericUpDownQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 43);
            this.numericUpDownQuantity.TabIndex = 38;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back.Image = ((System.Drawing.Image)(resources.GetObject("button_back.Image")));
            this.button_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_back.Location = new System.Drawing.Point(12, 447);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(104, 45);
            this.button_back.TabIndex = 49;
            this.button_back.Text = "Назад";
            this.button_back.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // IdTrips_pk
            // 
            this.IdTrips_pk.AutoSize = true;
            this.IdTrips_pk.Location = new System.Drawing.Point(228, 479);
            this.IdTrips_pk.Name = "IdTrips_pk";
            this.IdTrips_pk.Size = new System.Drawing.Size(29, 13);
            this.IdTrips_pk.TabIndex = 50;
            this.IdTrips_pk.Text = "label";
            this.IdTrips_pk.Visible = false;
            // 
            // textBoxTotalSum
            // 
            this.textBoxTotalSum.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTotalSum.Location = new System.Drawing.Point(309, 356);
            this.textBoxTotalSum.Name = "textBoxTotalSum";
            this.textBoxTotalSum.Size = new System.Drawing.Size(200, 43);
            this.textBoxTotalSum.TabIndex = 52;
            this.textBoxTotalSum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTotalSum_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 39);
            this.label6.TabIndex = 51;
            this.label6.Text = "Итого";
            // 
            // textBox1Price
            // 
            this.textBox1Price.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1Price.Location = new System.Drawing.Point(309, 289);
            this.textBox1Price.Name = "textBox1Price";
            this.textBox1Price.ReadOnly = true;
            this.textBox1Price.Size = new System.Drawing.Size(200, 43);
            this.textBox1Price.TabIndex = 54;
            this.textBox1Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1Price_KeyPress);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.Location = new System.Drawing.Point(12, 292);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(106, 39);
            this.labelPrice.TabIndex = 53;
            this.labelPrice.Text = "Стоимость";
            // 
            // TripsAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 504);
            this.Controls.Add(this.textBox1Price);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxTotalSum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.IdTrips_pk);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxNameClient);
            this.Controls.Add(this.comboBoxNameRoute);
            this.Controls.Add(this.dateTimePickerTravel);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TripsAddEdit";
            this.Text = "Туры: добавление или изменение";
            this.Load += new System.EventHandler(this.TripsAddEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxNameClient;
        private System.Windows.Forms.ComboBox comboBoxNameRoute;
        private System.Windows.Forms.DateTimePicker dateTimePickerTravel;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Label IdTrips_pk;
        private System.Windows.Forms.TextBox textBoxTotalSum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1Price;
        private System.Windows.Forms.Label labelPrice;
    }
}