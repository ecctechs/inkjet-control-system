using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deksomboon_Inkjet.UserControls;

namespace Deksomboon_Inkjet
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            SidePanel.Height = btnUCproduct.Height;
            SidePanel.Top = btnUCproduct.Top;
            ucProduct uc = new ucProduct();
            UserControl1(uc);
        }

        public void UserControl1(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUCproduct_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUCproduct.Height;
            SidePanel.Top = btnUCproduct.Top;
            ucProduct uc = new ucProduct();
            UserControl1(uc);
        }

        private void btnUCemployee_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUCemployee.Height;
            SidePanel.Top = btnUCemployee.Top;
            ucEmployee uc = new ucEmployee();
            UserControl1(uc);
        }

        private void btnUClocation_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUClocation.Height;
            SidePanel.Top = btnUClocation.Top;
            ucLocation uc = new ucLocation();
            UserControl1(uc);
        }

        private void btnUCinkjet_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUCinkjet.Height;
            SidePanel.Top = btnUCinkjet.Top;
            ucInkjet uc = new ucInkjet();
            UserControl1(uc);
        }

        private void btnUCorder_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUCorder.Height;
            SidePanel.Top = btnUCorder.Top;
            ucOrder uc = new ucOrder();
            UserControl1(uc);
        }

        private void btnUCorderview_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUCorderview.Height;
            SidePanel.Top = btnUCorderview.Top;
            ucOrderView uc = new ucOrderView();
            UserControl1(uc);
        }

        private void btnUCorderlog_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUCorderlog.Height;
            SidePanel.Top = btnUCorderlog.Top;
            ucOrderLog uc = new ucOrderLog();
            UserControl1(uc);
        }

        private void btnUCauth_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUCauth.Height;
            SidePanel.Top = btnUCauth.Top;
            ucAuthLog uc = new ucAuthLog();
            UserControl1(uc);
        }
    }
}
