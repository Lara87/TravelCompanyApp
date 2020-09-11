namespace TravelCompanyApp
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_search = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.textBox_login_search = new System.Windows.Forms.TextBox();
            this.label_pass = new System.Windows.Forms.Label();
            this.textBox_pass = new System.Windows.Forms.TextBox();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.label_login = new System.Windows.Forms.Label();
            this.label_name_role = new System.Windows.Forms.Label();
            this.comboBox_name_role = new System.Windows.Forms.ComboBox();
            this.button_save = new System.Windows.Forms.Button();
            this.button_show_table = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(505, 347);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // button_search
            // 
            this.button_search.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_search.Image = ((System.Drawing.Image)(resources.GetObject("button_search.Image")));
            this.button_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_search.Location = new System.Drawing.Point(393, 386);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(124, 45);
            this.button_search.TabIndex = 1;
            this.button_search.Text = "Искать";
            this.button_search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Gabriola", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back.Image = ((System.Drawing.Image)(resources.GetObject("button_back.Image")));
            this.button_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_back.Location = new System.Drawing.Point(12, 462);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(104, 45);
            this.button_back.TabIndex = 2;
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
            this.button_add.Location = new System.Drawing.Point(748, 194);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(300, 45);
            this.button_add.TabIndex = 3;
            this.button_add.Text = "Добавить пользователя";
            this.button_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Image = ((System.Drawing.Image)(resources.GetObject("button_exit.Image")));
            this.button_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_exit.Location = new System.Drawing.Point(947, 462);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(104, 45);
            this.button_exit.TabIndex = 4;
            this.button_exit.Text = "Выход";
            this.button_exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // textBox_login_search
            // 
            this.textBox_login_search.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_login_search.Location = new System.Drawing.Point(12, 388);
            this.textBox_login_search.Name = "textBox_login_search";
            this.textBox_login_search.Size = new System.Drawing.Size(300, 43);
            this.textBox_login_search.TabIndex = 5;
            this.textBox_login_search.Enter += new System.EventHandler(this.textBox_login_search_Enter);
            this.textBox_login_search.Leave += new System.EventHandler(this.textBox_login_search_Leave);
            // 
            // label_pass
            // 
            this.label_pass.AutoSize = true;
            this.label_pass.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_pass.Location = new System.Drawing.Point(559, 131);
            this.label_pass.Name = "label_pass";
            this.label_pass.Size = new System.Drawing.Size(72, 39);
            this.label_pass.TabIndex = 13;
            this.label_pass.Text = "Пароль";
            // 
            // textBox_pass
            // 
            this.textBox_pass.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_pass.Location = new System.Drawing.Point(748, 127);
            this.textBox_pass.Name = "textBox_pass";
            this.textBox_pass.Size = new System.Drawing.Size(300, 43);
            this.textBox_pass.TabIndex = 12;
            // 
            // textBox_login
            // 
            this.textBox_login.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_login.Location = new System.Drawing.Point(748, 69);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(300, 43);
            this.textBox_login.TabIndex = 11;
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_login.Location = new System.Drawing.Point(559, 73);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(63, 39);
            this.label_login.TabIndex = 10;
            this.label_login.Text = "Логин";
            // 
            // label_name_role
            // 
            this.label_name_role.AutoSize = true;
            this.label_name_role.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name_role.Location = new System.Drawing.Point(559, 12);
            this.label_name_role.Name = "label_name_role";
            this.label_name_role.Size = new System.Drawing.Size(170, 39);
            this.label_name_role.TabIndex = 9;
            this.label_name_role.Text = "Наименование роли";
            // 
            // comboBox_name_role
            // 
            this.comboBox_name_role.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_name_role.FormattingEnabled = true;
            this.comboBox_name_role.Location = new System.Drawing.Point(748, 9);
            this.comboBox_name_role.Name = "comboBox_name_role";
            this.comboBox_name_role.Size = new System.Drawing.Size(300, 47);
            this.comboBox_name_role.TabIndex = 8;
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.Image = ((System.Drawing.Image)(resources.GetObject("button_save.Image")));
            this.button_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_save.Location = new System.Drawing.Point(748, 264);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(300, 45);
            this.button_save.TabIndex = 14;
            this.button_save.Text = "Изменить данные пользователя";
            this.button_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_show_table
            // 
            this.button_show_table.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_show_table.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_show_table.Image = ((System.Drawing.Image)(resources.GetObject("button_show_table.Image")));
            this.button_show_table.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_show_table.Location = new System.Drawing.Point(442, 463);
            this.button_show_table.Name = "button_show_table";
            this.button_show_table.Size = new System.Drawing.Size(208, 45);
            this.button_show_table.TabIndex = 15;
            this.button_show_table.Text = "Показать таблицу";
            this.button_show_table.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_show_table.UseVisualStyleBackColor = true;
            this.button_show_table.Click += new System.EventHandler(this.button_show_table_Click);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 520);
            this.Controls.Add(this.button_show_table);
            this.Controls.Add(this.label_name_role);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label_pass);
            this.Controls.Add(this.textBox_pass);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.comboBox_name_role);
            this.Controls.Add(this.textBox_login_search);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Users";
            this.Text = "Пользователи";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Users_FormClosed_1);
            this.Load += new System.EventHandler(this.Users_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.TextBox textBox_login_search;
        private System.Windows.Forms.Label label_pass;
        private System.Windows.Forms.TextBox textBox_pass;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label_name_role;
        private System.Windows.Forms.ComboBox comboBox_name_role;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_show_table;
    }
}