using DvldBusinessTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class LDLapplicationInfo : UserControl
    {
        private int DLDid = -1; 
        public LDLapplicationInfo()
        {
            InitializeComponent();
        }

        public void setDldId(int ID)
        {
            DLDid = ID;
        }

        public void reload()
        {
            LBid.Text = DLDid.ToString();
            string ClassName = "";
            int passedTest = -1; 
            application.GetLDLpersonDetails(this.DLDid, ref ClassName, ref passedTest);
            LBpassedTest.Text = passedTest.ToString() + "/3";
            LBAppliedL.Text = ClassName;
            linkLabel1.Enabled = false; 
        }

        private void LDLapplicationInfo_Load(object sender, EventArgs e)
        {
            reload();
        }
    }
}
