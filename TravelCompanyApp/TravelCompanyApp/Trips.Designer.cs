namespace TravelCompanyApp
{
    partial class Trips
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trips));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_show_table = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAllSumColumn = new System.Windows.Forms.TextBox();
            this.buttonAllSumColumn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1325, 519);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_show_table
            // 
            this.button_show_table.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_show_table.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_show_table.Image = ((System.Drawing.Image)(resources.GetObject("button_show_table.Image")));
            this.button_show_table.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_show_table.Location = new System.Drawing.Point(394, 569);
            this.button_show_table.Name = "button_show_table";
            this.button_show_table.Size = new System.Drawing.Size(208, 45);
            this.button_show_table.TabIndex = 37;
            this.button_show_table.Text = "Показать таблицу";
            this.button_show_table.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_show_table.UseVisualStyleBackColor = true;
            this.button_show_table.Click += new System.EventHandler(this.button_show_table_Click);
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Image = ((System.Drawing.Image)(resources.GetObject("button_exit.Image")));
            this.button_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_exit.Location = new System.Drawing.Point(1234, 654);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(104, 45);
            this.button_exit.TabIndex = 34;
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
            this.button_back.Location = new System.Drawing.Point(12, 654);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(104, 45);
            this.button_back.TabIndex = 32;
            this.button_back.Text = "Назад";
            this.button_back.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_add
            // 
            this.button_add.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add.Image = ((System.Drawing.Image)(resources.GetObject("button_add.Image")));
            this.button_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_add.Location = new System.Drawing.Point(13, 569);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(202, 45);
            this.button_add.TabIndex = 48;
            this.button_add.Text = "Добавить путёвку";
            this.button_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAllSumColumn);
            this.groupBox1.Controls.Add(this.buttonAllSumColumn);
            this.groupBox1.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(763, 547);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 150);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Общая сумма проданных туров за текущий месяц";
            // 
            // textBoxAllSumColumn
            // 
            this.textBoxAllSumColumn.Location = new System.Drawing.Point(190, 99);
            this.textBoxAllSumColumn.Name = "textBoxAllSumColumn";
            this.textBoxAllSumColumn.Size = new System.Drawing.Size(176, 43);
            this.textBoxAllSumColumn.TabIndex = 1;
            // 
            // buttonAllSumColumn
            // 
            this.buttonAllSumColumn.Location = new System.Drawing.Point(6, 99);
            this.buttonAllSumColumn.Name = "buttonAllSumColumn";
            this.buttonAllSumColumn.Size = new System.Drawing.Size(132, 45);
            this.buttonAllSumColumn.TabIndex = 0;
            this.buttonAllSumColumn.Text = "Показать";
            this.buttonAllSumColumn.UseVisualStyleBackColor = true;
            this.buttonAllSumColumn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Trips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 711);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_show_table);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Trips";
            this.Text = "Путёвки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Trips_FormClosed);
            this.Load += new System.EventHandler(this.Trips_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_show_table;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAllSumColumn;
        private System.Windows.Forms.Button buttonAllSumColumn;
    }
}