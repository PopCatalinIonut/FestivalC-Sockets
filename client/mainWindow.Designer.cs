using System.ComponentModel;

namespace FESTIVAL_CS
{
    partial class mainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.showsGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtistColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoldColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buyerNameBox = new System.Windows.Forms.TextBox();
            this.seatsBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.filteredShowsGrid = new System.Windows.Forms.DataGridView();
            this.Artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.showsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.filteredShowsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // showsGrid
            // 
            this.showsGrid.AllowUserToAddRows = false;
            this.showsGrid.AllowUserToDeleteRows = false;
            this.showsGrid.AllowUserToOrderColumns = true;
            this.showsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.showsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.showsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Id, this.ArtistColumn, this.LocationColumn, this.DateColumn, this.AvailableColumn, this.SoldColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.showsGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.showsGrid.Location = new System.Drawing.Point(-1, 215);
            this.showsGrid.Name = "showsGrid";
            this.showsGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.showsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.showsGrid.RowHeadersVisible = false;
            this.showsGrid.RowTemplate.Height = 24;
            this.showsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.showsGrid.Size = new System.Drawing.Size(500, 300);
            this.showsGrid.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 30;
            // 
            // ArtistColumn
            // 
            this.ArtistColumn.HeaderText = "Artist";
            this.ArtistColumn.Name = "ArtistColumn";
            this.ArtistColumn.ReadOnly = true;
            this.ArtistColumn.Width = 70;
            // 
            // LocationColumn
            // 
            this.LocationColumn.HeaderText = "Location";
            this.LocationColumn.Name = "LocationColumn";
            this.LocationColumn.ReadOnly = true;
            this.LocationColumn.Width = 80;
            // 
            // DateColumn
            // 
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            this.DateColumn.Width = 110;
            // 
            // AvailableColumn
            // 
            this.AvailableColumn.HeaderText = "Available";
            this.AvailableColumn.Name = "AvailableColumn";
            this.AvailableColumn.ReadOnly = true;
            this.AvailableColumn.Width = 60;
            // 
            // SoldColumn
            // 
            this.SoldColumn.HeaderText = "Sold";
            this.SoldColumn.Name = "SoldColumn";
            this.SoldColumn.ReadOnly = true;
            this.SoldColumn.Width = 60;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(628, 84);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // buyerNameBox
            // 
            this.buyerNameBox.Location = new System.Drawing.Point(218, 43);
            this.buyerNameBox.Name = "buyerNameBox";
            this.buyerNameBox.Size = new System.Drawing.Size(100, 22);
            this.buyerNameBox.TabIndex = 2;
            // 
            // seatsBox
            // 
            this.seatsBox.Location = new System.Drawing.Point(218, 127);
            this.seatsBox.Name = "seatsBox";
            this.seatsBox.Size = new System.Drawing.Size(100, 22);
            this.seatsBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(61, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buyer Name: ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(74, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seats: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Buy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buyTicketsButton_Click);
            // 
            // filteredShowsGrid
            // 
            this.filteredShowsGrid.AllowUserToAddRows = false;
            this.filteredShowsGrid.AllowUserToDeleteRows = false;
            this.filteredShowsGrid.AllowUserToOrderColumns = true;
            this.filteredShowsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filteredShowsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.filteredShowsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Artist, this.Location, this.Hour, this.Available});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.filteredShowsGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.filteredShowsGrid.Location = new System.Drawing.Point(536, 215);
            this.filteredShowsGrid.Name = "filteredShowsGrid";
            this.filteredShowsGrid.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filteredShowsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.filteredShowsGrid.RowHeadersVisible = false;
            this.filteredShowsGrid.RowTemplate.Height = 24;
            this.filteredShowsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.filteredShowsGrid.Size = new System.Drawing.Size(355, 329);
            this.filteredShowsGrid.TabIndex = 7;
            // 
            // Artist
            // 
            this.Artist.HeaderText = "Artist";
            this.Artist.Name = "Artist";
            this.Artist.ReadOnly = true;
            this.Artist.Width = 70;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 70;
            // 
            // Hour
            // 
            this.Hour.HeaderText = "Hour";
            this.Hour.Name = "Hour";
            this.Hour.ReadOnly = true;
            this.Hour.Width = 60;
            // 
            // Available
            // 
            this.Available.HeaderText = "Available";
            this.Available.Name = "Available";
            this.Available.ReadOnly = true;
            this.Available.Width = 60;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(686, 136);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 8;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(777, 12);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(93, 28);
            this.logOutButton.TabIndex = 9;
            this.logOutButton.Text = "Log out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.filteredShowsGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seatsBox);
            this.Controls.Add(this.buyerNameBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.showsGrid);
            this.Name = "mainWindow";
            this.Text = "mainWindow";
            ((System.ComponentModel.ISupportInitialize) (this.showsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.filteredShowsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button logOutButton;

        private System.Windows.Forms.Button Search;

        private System.Windows.Forms.DataGridViewTextBoxColumn Available;

        private System.Windows.Forms.DataGridViewTextBoxColumn Hour;
        private new System.Windows.Forms.DataGridViewTextBoxColumn Location;

        private System.Windows.Forms.DataGridViewTextBoxColumn Artist;

        private System.Windows.Forms.DataGridView filteredShowsGrid;

        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoldColumn;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox buyerNameBox;
        private System.Windows.Forms.TextBox seatsBox;

        private System.Windows.Forms.DataGridView showsGrid;

        #endregion
    }
}