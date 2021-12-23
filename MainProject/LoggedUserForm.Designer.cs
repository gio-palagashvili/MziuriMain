namespace MainProject
{
    partial class LoggedUserForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoggedUserForm));
            this.LogOutButton = new System.Windows.Forms.Button();
            this.SimpGroupbox = new System.Windows.Forms.GroupBox();
            this.BalanceAmont = new System.Windows.Forms.Label();
            this.BalanceIcon = new System.Windows.Forms.Label();
            this.SettingsIcon = new System.Windows.Forms.PictureBox();
            this.ItemsLabel = new System.Windows.Forms.Label();
            this.HomeLabel = new System.Windows.Forms.Label();
            this.ItemViewer = new System.Windows.Forms.Button();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CategoryChooser = new System.Windows.Forms.ComboBox();
            this.ItemList = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchIcon = new System.Windows.Forms.PictureBox();
            this.NoItemsLabel = new System.Windows.Forms.Label();
            this.UserDataLabel = new System.Windows.Forms.Label();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.MinLabel = new System.Windows.Forms.Label();
            this.MaxLabel = new System.Windows.Forms.Label();
            this.JustMiddleLabel = new System.Windows.Forms.Label();
            this.MinimalPriceBox = new System.Windows.Forms.TextBox();
            this.MaxPriceBox = new System.Windows.Forms.TextBox();
            this.SimpGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LogOutButton.ForeColor = System.Drawing.Color.Black;
            this.LogOutButton.Location = new System.Drawing.Point(903, 13);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(96, 42);
            this.LogOutButton.TabIndex = 3;
            this.LogOutButton.Text = "Log out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // SimpGroupbox
            // 
            this.SimpGroupbox.BackColor = System.Drawing.Color.DodgerBlue;
            this.SimpGroupbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SimpGroupbox.Controls.Add(this.BalanceAmont);
            this.SimpGroupbox.Controls.Add(this.BalanceIcon);
            this.SimpGroupbox.Controls.Add(this.SettingsIcon);
            this.SimpGroupbox.Controls.Add(this.ItemsLabel);
            this.SimpGroupbox.Controls.Add(this.HomeLabel);
            this.SimpGroupbox.Controls.Add(this.LogOutButton);
            this.SimpGroupbox.Location = new System.Drawing.Point(0, 0);
            this.SimpGroupbox.Name = "SimpGroupbox";
            this.SimpGroupbox.Size = new System.Drawing.Size(1015, 61);
            this.SimpGroupbox.TabIndex = 5;
            this.SimpGroupbox.TabStop = false;
            this.SimpGroupbox.Enter += new System.EventHandler(this.Categories_Enter);
            // 
            // BalanceAmont
            // 
            this.BalanceAmont.AutoSize = true;
            this.BalanceAmont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BalanceAmont.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.BalanceAmont.Location = new System.Drawing.Point(723, 32);
            this.BalanceAmont.Name = "BalanceAmont";
            this.BalanceAmont.Size = new System.Drawing.Size(75, 22);
            this.BalanceAmont.TabIndex = 16;
            this.BalanceAmont.Text = "Balance";
            this.BalanceAmont.Click += new System.EventHandler(this.BalanceAmont_Click);
            // 
            // BalanceIcon
            // 
            this.BalanceIcon.AutoSize = true;
            this.BalanceIcon.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BalanceIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.BalanceIcon.Location = new System.Drawing.Point(723, 10);
            this.BalanceIcon.Name = "BalanceIcon";
            this.BalanceIcon.Size = new System.Drawing.Size(75, 22);
            this.BalanceIcon.TabIndex = 15;
            this.BalanceIcon.Text = "Balance";
            this.BalanceIcon.Click += new System.EventHandler(this.BalanceIcon_Click);
            // 
            // SettingsIcon
            // 
            this.SettingsIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsIcon.Image = ((System.Drawing.Image)(resources.GetObject("SettingsIcon.Image")));
            this.SettingsIcon.Location = new System.Drawing.Point(851, 13);
            this.SettingsIcon.Name = "SettingsIcon";
            this.SettingsIcon.Size = new System.Drawing.Size(46, 41);
            this.SettingsIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SettingsIcon.TabIndex = 11;
            this.SettingsIcon.TabStop = false;
            // 
            // ItemsLabel
            // 
            this.ItemsLabel.AutoSize = true;
            this.ItemsLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.ItemsLabel.Location = new System.Drawing.Point(86, 24);
            this.ItemsLabel.Name = "ItemsLabel";
            this.ItemsLabel.Size = new System.Drawing.Size(52, 22);
            this.ItemsLabel.TabIndex = 7;
            this.ItemsLabel.Text = "Items";
            this.ItemsLabel.Click += new System.EventHandler(this.ItemsLabel_Click);
            // 
            // HomeLabel
            // 
            this.HomeLabel.AutoSize = true;
            this.HomeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.HomeLabel.Location = new System.Drawing.Point(16, 23);
            this.HomeLabel.Name = "HomeLabel";
            this.HomeLabel.Size = new System.Drawing.Size(64, 25);
            this.HomeLabel.TabIndex = 6;
            this.HomeLabel.Text = "Home";
            this.HomeLabel.Click += new System.EventHandler(this.HomeLabel_Click);
            // 
            // ItemViewer
            // 
            this.ItemViewer.BackColor = System.Drawing.Color.DodgerBlue;
            this.ItemViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ItemViewer.ForeColor = System.Drawing.Color.Black;
            this.ItemViewer.Location = new System.Drawing.Point(62, 472);
            this.ItemViewer.Name = "ItemViewer";
            this.ItemViewer.Size = new System.Drawing.Size(135, 34);
            this.ItemViewer.TabIndex = 7;
            this.ItemViewer.Text = "View";
            this.ItemViewer.UseVisualStyleBackColor = false;
            this.ItemViewer.Visible = false;
            this.ItemViewer.Click += new System.EventHandler(this.ItemViewer_Click);
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.CategoryLabel.ForeColor = System.Drawing.Color.White;
            this.CategoryLabel.Location = new System.Drawing.Point(18, 93);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(65, 16);
            this.CategoryLabel.TabIndex = 8;
            this.CategoryLabel.Text = "Category:";
            this.CategoryLabel.Visible = false;
            // 
            // CategoryChooser
            // 
            this.CategoryChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryChooser.FormattingEnabled = true;
            this.CategoryChooser.Items.AddRange(new object[] {
            "all",
            "undefined",
            "defined",
            "other"});
            this.CategoryChooser.Location = new System.Drawing.Point(90, 93);
            this.CategoryChooser.Name = "CategoryChooser";
            this.CategoryChooser.Size = new System.Drawing.Size(149, 21);
            this.CategoryChooser.TabIndex = 10;
            this.CategoryChooser.Visible = false;
            // 
            // ItemList
            // 
            this.ItemList.AllowUserToAddRows = false;
            this.ItemList.AllowUserToDeleteRows = false;
            this.ItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ItemName,
            this.Quantity,
            this.Price});
            this.ItemList.Location = new System.Drawing.Point(21, 180);
            this.ItemList.MultiSelect = false;
            this.ItemList.Name = "ItemList";
            this.ItemList.ReadOnly = true;
            this.ItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemList.Size = new System.Drawing.Size(218, 286);
            this.ItemList.TabIndex = 6;
            this.ItemList.Visible = false;
            this.ItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemList_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "ItemId";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 60;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 60;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 55;
            // 
            // SearchIcon
            // 
            this.SearchIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchIcon.Image = ((System.Drawing.Image)(resources.GetObject("SearchIcon.Image")));
            this.SearchIcon.Location = new System.Drawing.Point(245, 87);
            this.SearchIcon.Name = "SearchIcon";
            this.SearchIcon.Size = new System.Drawing.Size(32, 32);
            this.SearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SearchIcon.TabIndex = 12;
            this.SearchIcon.TabStop = false;
            this.SearchIcon.Visible = false;
            this.SearchIcon.Click += new System.EventHandler(this.SearchIcon_Click);
            // 
            // NoItemsLabel
            // 
            this.NoItemsLabel.AutoSize = true;
            this.NoItemsLabel.BackColor = System.Drawing.Color.DodgerBlue;
            this.NoItemsLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NoItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.NoItemsLabel.Location = new System.Drawing.Point(45, 180);
            this.NoItemsLabel.Name = "NoItemsLabel";
            this.NoItemsLabel.Size = new System.Drawing.Size(175, 25);
            this.NoItemsLabel.TabIndex = 13;
            this.NoItemsLabel.Text = "There are no items";
            this.NoItemsLabel.Visible = false;
            this.NoItemsLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // UserDataLabel
            // 
            this.UserDataLabel.AutoSize = true;
            this.UserDataLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.UserDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UserDataLabel.ForeColor = System.Drawing.Color.White;
            this.UserDataLabel.Location = new System.Drawing.Point(32, 97);
            this.UserDataLabel.Name = "UserDataLabel";
            this.UserDataLabel.Size = new System.Drawing.Size(70, 17);
            this.UserDataLabel.TabIndex = 14;
            this.UserDataLabel.Text = "User data";
            this.UserDataLabel.Click += new System.EventHandler(this.UserDataLabel_Click);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.WelcomeLabel.ForeColor = System.Drawing.Color.White;
            this.WelcomeLabel.Location = new System.Drawing.Point(16, 68);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(95, 25);
            this.WelcomeLabel.TabIndex = 12;
            this.WelcomeLabel.Text = "Welcome";
            this.WelcomeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // MinLabel
            // 
            this.MinLabel.AutoSize = true;
            this.MinLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.MinLabel.ForeColor = System.Drawing.Color.White;
            this.MinLabel.Location = new System.Drawing.Point(18, 127);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(31, 15);
            this.MinLabel.TabIndex = 15;
            this.MinLabel.Text = "Min:";
            this.MinLabel.Visible = false;
            // 
            // MaxLabel
            // 
            this.MaxLabel.AutoSize = true;
            this.MaxLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.MaxLabel.ForeColor = System.Drawing.Color.White;
            this.MaxLabel.Location = new System.Drawing.Point(205, 127);
            this.MaxLabel.Name = "MaxLabel";
            this.MaxLabel.Size = new System.Drawing.Size(34, 15);
            this.MaxLabel.TabIndex = 16;
            this.MaxLabel.Text = "Max:";
            this.MaxLabel.Visible = false;
            // 
            // JustMiddleLabel
            // 
            this.JustMiddleLabel.AutoSize = true;
            this.JustMiddleLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.JustMiddleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.JustMiddleLabel.ForeColor = System.Drawing.Color.White;
            this.JustMiddleLabel.Location = new System.Drawing.Point(113, 156);
            this.JustMiddleLabel.Name = "JustMiddleLabel";
            this.JustMiddleLabel.Size = new System.Drawing.Size(37, 15);
            this.JustMiddleLabel.TabIndex = 17;
            this.JustMiddleLabel.Text = "<^-^>";
            this.JustMiddleLabel.Visible = false;
            // 
            // MinimalPriceBox
            // 
            this.MinimalPriceBox.BackColor = System.Drawing.Color.White;
            this.MinimalPriceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MinimalPriceBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MinimalPriceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.MinimalPriceBox.Location = new System.Drawing.Point(21, 148);
            this.MinimalPriceBox.Name = "MinimalPriceBox";
            this.MinimalPriceBox.Size = new System.Drawing.Size(81, 29);
            this.MinimalPriceBox.TabIndex = 19;
            this.MinimalPriceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MinimalPriceBox.Visible = false;
            this.MinimalPriceBox.TextChanged += new System.EventHandler(this.MinimalPriceBox_TextChanged);
            // 
            // MaxPriceBox
            // 
            this.MaxPriceBox.BackColor = System.Drawing.Color.White;
            this.MaxPriceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaxPriceBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaxPriceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.MaxPriceBox.Location = new System.Drawing.Point(158, 148);
            this.MaxPriceBox.Name = "MaxPriceBox";
            this.MaxPriceBox.Size = new System.Drawing.Size(81, 29);
            this.MaxPriceBox.TabIndex = 20;
            this.MaxPriceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaxPriceBox.Visible = false;
            this.MaxPriceBox.TextChanged += new System.EventHandler(this.MaxPriceBox_TextChanged);
            // 
            // LoggedUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.MaxPriceBox);
            this.Controls.Add(this.MinimalPriceBox);
            this.Controls.Add(this.JustMiddleLabel);
            this.Controls.Add(this.MaxLabel);
            this.Controls.Add(this.MinLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.SearchIcon);
            this.Controls.Add(this.CategoryChooser);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.ItemViewer);
            this.Controls.Add(this.SimpGroupbox);
            this.Controls.Add(this.ItemList);
            this.Controls.Add(this.NoItemsLabel);
            this.Controls.Add(this.UserDataLabel);
            this.Name = "LoggedUserForm";
            this.Size = new System.Drawing.Size(1015, 538);
            this.Load += new System.EventHandler(this.LoggedUserForm_Load);
            this.SimpGroupbox.ResumeLayout(false);
            this.SimpGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.GroupBox SimpGroupbox;
        private System.Windows.Forms.Label ItemsLabel;
        private System.Windows.Forms.Button ItemViewer;
        private System.Windows.Forms.PictureBox SettingsIcon;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.ComboBox CategoryChooser;
        private System.Windows.Forms.DataGridView ItemList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.PictureBox SearchIcon;
        private System.Windows.Forms.Label HomeLabel;
        private System.Windows.Forms.Label NoItemsLabel;
        private System.Windows.Forms.Label UserDataLabel;
        private System.Windows.Forms.Label BalanceAmont;
        private System.Windows.Forms.Label BalanceIcon;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label MaxLabel;
        private System.Windows.Forms.Label JustMiddleLabel;
        private System.Windows.Forms.TextBox MinimalPriceBox;
        private System.Windows.Forms.TextBox MaxPriceBox;
    }
}
