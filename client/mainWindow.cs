using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using chat.client;
using client;
using festival.client;
using festival.model;
using festival.services;
namespace FESTIVAL_CS
{
    public partial class mainWindow : Form
    {
     
        private FestivalClientCtrl ctrl;
        public LoginWindow win { get; set; }

        public mainWindow(FestivalClientCtrl festivalClientCtrl)
        {
            InitializeComponent();
            this.ctrl = festivalClientCtrl;
            initView();
            ctrl.updateEvent += userUpdate;
        }
        
        public void initView()
        {
            showsGrid.Rows.Clear();
            showsGrid.CellFormatting += new DataGridViewCellFormattingEventHandler(showsGrid_CellFormatting);

            Show[] shows = ctrl.findAllShows();
            foreach (Show sh in shows)
            {
                showsGrid.Rows.Add(sh.ID,sh.artist.name,sh.location,sh.date,sh.totalSeats-sh.soldSeats,sh.soldSeats);
            }

        }
        private void showsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = showsGrid.Rows[e.RowIndex];// get you required index
            if(Int32.Parse(row.Cells[4].Value.ToString())==0)
                row.DefaultCellStyle.BackColor = Color.Red;
        }
        private void buyTicketsButton_Click(object sender, EventArgs e)
        {
            try
            {
                int showId = Int32.Parse(showsGrid.SelectedRows[0].Cells[0].Value.ToString());
                int tickets = Int32.Parse(seatsBox.Text);
                string buyerName = buyerNameBox.Text;
                this.ctrl.buyTickets(new Ticket(showId,buyerName,tickets));
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FestivalException se)
            {
                MessageBox.Show(se.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }public delegate void MyDelegate();
        public void userUpdate(object sender, FestivalUserEventArgs e)
        {
            if (e.UserEventType==FestivalUserEvent.TicketBought)
            {
                Trace.WriteLine("do nothing");
                showsGrid.BeginInvoke(new MyDelegate(update),null);
                //showsGrid.BeginInvoke((Action) delegate { showsGrid.Rows.Clear();} );
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {
            filteredShowsGrid.Rows.Clear();
            DateTime date = dateTimePicker1.Value;
            IEnumerable shows = ctrl.findAllShowsByDate(date);
            foreach (Show sh in shows)
            {
                filteredShowsGrid.Rows.Add(sh.artist.name,sh.location,sh.date.Hour.ToString() + ":"+ sh.date.Minute.ToString()+":"+sh.date.Second.ToString(),sh.totalSeats-sh.soldSeats);
            }
        }

        public void update()
        {
            initView();
            Trace.WriteLine("updated");
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.ctrl.logout();
            this.Hide();
            win.Show();
        }
    }
}