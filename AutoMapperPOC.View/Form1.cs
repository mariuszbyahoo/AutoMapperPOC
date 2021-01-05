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
        private readonly EFOrdersService _efSrv;
        private readonly XPOrdersService _xpoSrv;
        IList<Order> Orders { get; set; }
        public Form1()
        {
            _efSrv = new EFOrdersService();
            _xpoSrv = new XPOrdersService();
            Orders = new List<Order>();
            InitializeComponent();
            AutoMapperConfiguration.GetConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var orders = _efSrv.GetOrders();
            this.gridControl1.DataSource = orders;
            this.gridControl1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var orders = _xpoSrv.GetOrders();
            this.gridControl1.DataSource = orders;
            this.gridControl1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _efSrv.WygenerujWpisy();
        }
    }
}
