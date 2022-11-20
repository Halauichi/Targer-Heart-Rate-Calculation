using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Your name: Husam Alauichi
//Description: Heart Rate calculation
//Date Created: 9/7/2020


namespace TargetHeartRateCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        // close window
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // clear window
        private void btnClear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            txtAge.Clear();
            comboBox1.SelectedIndex = 0;
            txtAge.Focus();
        }


        // load form 
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtAge;
            comboBox1.Items.Add("-Select an Activity-");
            comboBox1.Items.Add("Moderate");
            comboBox1.Items.Add("Vigorous");
            comboBox1.SelectedIndex = 0;
        }

        private void btnDisplayTHR_Click(object sender, EventArgs e)

        {
            listView1.Items.Clear();

            if (txtAge.Text == String.Empty)
            {
                MessageBox.Show("Age field can not be empty");
                txtAge.Focus();
            }
            else if (Convert.ToInt32(txtAge.Text) > 100 || (Convert.ToInt32(txtAge.Text) < 1) || (Convert.ToInt32(txtAge.Text) == 0))
            {
                MessageBox.Show("Please enter a number between 1 & 100");
                txtAge.Focus();
            }
           
            else if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an activity");
            }
            else
            {
                double HeartRate = 220 - Convert.ToInt32(txtAge.Text);
                decimal lowEnd = (int)(HeartRate * .50);
                decimal hiEnd = (int)(HeartRate * .70);
                decimal VhiEnd = (int)(HeartRate * .85);
                //System.Math.Round(VhiEnd ,1 );
                if (comboBox1.SelectedIndex == 1)
                {
                    listView1.Items.Add(txtAge.Text);
                    listView1.Items[0].SubItems.Add($"{HeartRate} (bpm)");
                    listView1.Items[0].SubItems.Add($"{comboBox1.SelectedItem}");
                    listView1.Items[0].SubItems.Add($"{System.Math.Round(lowEnd, 1)}  to {System.Math.Round(hiEnd,1)} (beats per minute)");

                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    
                    listView1.Items.Add(txtAge.Text);
                    listView1.Items[0].SubItems.Add($"{HeartRate} (bpm)");
                    listView1.Items[0].SubItems.Add($"{comboBox1.SelectedItem}");
                    listView1.Items[0].SubItems.Add($"{System.Math.Round(hiEnd,1)}  to {System.Math.Round(VhiEnd,1)} (beats per minute)");
                    
                }
            }
        }

     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
