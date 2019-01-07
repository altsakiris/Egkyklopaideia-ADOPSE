using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Egkyklopaideia
{
    public partial class FirstCustomControl : UserControl
    {
        //int count = source.Split('/').Length - 1;
        SqlConn conn = new SqlConn();
        List<GroupBox> groupBoxes = new List<GroupBox>();
        List<Label> LabeList = new List<Label>();
        List<Button> ButtonList = new List<Button>();
        public FirstCustomControl()
        {
            InitializeComponent();
            groupBoxes.Add(groupBox1);
            groupBoxes.Add(groupBox2);
            groupBoxes.Add(groupBox3);
            LabeList.Add(label1);
            LabeList.Add(label2);
            LabeList.Add(label3);
            ButtonList.Add(button1);
            ButtonList.Add(button2);
            ButtonList.Add(button3);
            Populate_Main_form();
        }
        
        private void Populate_Main_form()
        {
            int i = 0,c=0,y=0;
            foreach (var groupbox in groupBoxes)
            {
                groupbox.Text = "This is box number " + (i+1);
                i++;
            }
            foreach (var label in LabeList)
            {
                label.Text = "Label " + (c + 1);
                c++;
            }
            foreach (var button in ButtonList)
            {
                button.Text = "btn" + (y + 1);
                y++;
            }
        }
       

        private void FirstCustomControl_Load(object sender, EventArgs e)
        {

        }
    }
}
