using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN
{
    public partial class FormEvents : Form
    {
        public FormEvents(List<EventBase> events, DateTime date)
        {
            InitializeComponent();

            lblDate.Text = date.ToString("dd/MM/yyyy");

            foreach (EventBase ev in events)
            {
                listEvents.Items.Add(
                    ev.Title + " (" +
                    ev.Start.ToShortTimeString() + " - " +
                    ev.End.ToShortTimeString() + ")"
                );
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void FormEvents_Load(object sender, EventArgs e)
        {

        }
    }
}
