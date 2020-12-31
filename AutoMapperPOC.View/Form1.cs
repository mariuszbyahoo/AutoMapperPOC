using AutoMapper;
using AutoMapperPOC.DAL.EF;
using AutoMapperPOC.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoMapperPOC.View
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private readonly EFOrdersService _srv;
        IList<Order> Orders { get; set; }
        public Form1()
        {
            _srv = new EFOrdersService();
            Orders = new List<Order>();
            InitializeComponent();
            AutoMapperConfiguration.GetConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = _srv.GetOrders();
            this.gridControl1.Refresh();
        }
    }
}
