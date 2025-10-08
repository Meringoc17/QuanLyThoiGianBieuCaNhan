using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN
{
    public partial class FormEvents : Form
    {
        public FormEvents(DateTime date, List<MyEvent> events)
        {
            InitializeComponent();
            lblDate.Text = "Sự kiện ngày " + date.ToString("dd/MM/yyyy");

            if (events.Count > 0)
            {
                foreach (MyEvent ev in events)
                {
                    lstEvents.Items.Add(
                        ev.Start.ToString("HH:mm") + " - " +
                        ev.End.ToString("HH:mm") + " " +
                        ev.Title
                    );
                }
            }
            else
            {
                lstEvents.Items.Add("Không có sự kiện.");
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
