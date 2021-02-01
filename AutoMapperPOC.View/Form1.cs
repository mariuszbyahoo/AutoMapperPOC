using AutoMapperPOC.Domain;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoMapperPOC.DAL.EF;
using DevExpress.Xpo;
using AutoMapper.QueryableExtensions;

namespace AutoMapperPOC.View
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private readonly EFOrdersService _efSrv;
        private readonly XPOrdersService _xpoSrv;
        public Form1()
        {
            _efSrv = new EFOrdersService();
            _xpoSrv = new XPOrdersService();
            InitializeComponent();
            AutoMapperConfiguration.GetConfig();
            this.linqInstantFeedbackSource1.KeyExpression = nameof(Order.OID);
            this.entityInstantFeedbackSource1.KeyExpression = nameof(Order.OID);
            this.entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            this.entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;
            this.xpInstantFeedbackSource1.ResolveSession += xpInstantFeedbackSource1_ResolveSession;
            this.xpInstantFeedbackSource1.DismissSession += xpInstantFeedbackSource1_DismissSession;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = entityInstantFeedbackSource1;
            this.gridControl1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = xpInstantFeedbackSource1;
            this.gridControl1.Refresh();
        }

        private void linqButton_Click(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = linqInstantFeedbackSource1;
            this.gridControl1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            _efSrv.WygenerujWpisy();
        }

        void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            try
            {
                var _ctx = new POCContext();
                e.QueryableSource = _ctx.Orders.ProjectTo<Order>(AutoMapperConfiguration.GetConfig());
                //e.QueryableSource = _ctx.Orders.UseAsDataSource(AutoMapperConfiguration.GetConfig()).For<Order>();
                e.Tag = _ctx;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        void entityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((AutoMapperPOC.DAL.EF.POCContext)e.Tag).Dispose();
        }

        void xpInstantFeedbackSource1_ResolveSession(object sender, DevExpress.Xpo.ResolveSessionEventArgs e)
        {
            e.Session = new DevExpress.Xpo.UnitOfWork();
        }

        void xpInstantFeedbackSource1_DismissSession(object sender, DevExpress.Xpo.ResolveSessionEventArgs e)
        {
            IDisposable session = e.Session as IDisposable;
            if (session != null)
                session.Dispose();
        }

        private void linqInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((AutoMapperPOC.DAL.EF.POCContext)e.Tag).Dispose();
        }

        private void linqInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            var _ctx = new POCContext();
            //e.QueryableSource = _ctx.Orders.UseAsDataSource(AutoMapperConfiguration.GetConfig()).For<Order>();
            e.QueryableSource = _ctx.Orders.ProjectTo<Order>(AutoMapperConfiguration.GetConfig());
            e.Tag = _ctx;
        }
    }
}
