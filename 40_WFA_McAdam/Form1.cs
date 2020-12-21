using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _40_WFA_McAdam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ADDS ITEMS TO MENU ON LOAD

            cmbMenu.Items.Add("McChicken");
            cmbMenu.Items.Add("Whooper");
            cmbMenu.Items.Add("Big King");
            cmbMenu.Items.Add("Texas Smoke House");
        }
        int price = 0;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            //MAKING A STRING FORMAT OF ALL THE OPTIONS SO WE CAN ADD THEM LATER

            //CHECKOUT PRICE

            
            if (cmbMenu.SelectedIndex == 0)
            {
                price = 15;
            }
            if (cmbMenu.SelectedIndex == 1)
            {
                price = 20;
            }
            if (cmbMenu.SelectedIndex == 2)
            {
                price =22;
            }
            if (cmbMenu.SelectedIndex == 3)
            {
                price = 30;
            }


            //MENU

            string menu = "";
            

            //SIZE
            string size = "";
            if (rbOrta.Checked == true)
            {
                size = "Orta boyut";
            }
            if (rbBuyuk.Checked == true)
            {
                size = "Büyük boyut";
                price += 2;
            }
            if (rbKing.Checked == true)
            {
                size = "King boyut";
                price += 5;
            }
            //SAUCES
            string sauce = "";
            if (chkRanch.Checked)
            {
                sauce = "-Ranch sos-";
                price += 1;
            }
            if (chkHardal.Checked)
            {
                sauce += "-Hardal sos-";
                price += 1;
            }
            if (chkCheddar.Checked)
            {
                sauce += "-Cheddar sos-";
                price += 1;
            }
            if (chkAciSos.Checked)
            {
                sauce += "-Acı sos-";
                price += 1;
            }
            if (chkBuffalo.Checked)
            {
                sauce += "-Bufalo sos-";
                price += 1;
            }
            if (chkBarbeku.Checked)
            {
                sauce += "-Barbekü sos-";
                price += 1;
            }
            //AMOUNT
            decimal adet = 0;
            adet = nudAdet.Value;
            price *= Convert.ToInt32(adet);


            //ADD
            if (cmbMenu.SelectedIndex > -1)
            {
                cmbMenu.SelectedItem.ToString();
                listBox1.Items.Add(string.Format("{0} ,{1} ,{2}, {3} tane, {4} TL", menu, size, sauce, adet, price));


            }
            if (cmbMenu.SelectedIndex == -1)
            {
                MessageBox.Show("Bir menü seçiniz");

            }
            
        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            decimal adet = nudAdet.Value;                              
            MessageBox.Show(adet.ToString() + " adet menü ve " + price.ToString() + " TL", "Siparişinizde bulunan adet ve ödemeniz gereken toplam:");
            DialogResult result = MessageBox.Show("Ödemek istiyormusunuz?" , "Devam", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is ComboBox)
                    {
                        ComboBox cb = (ComboBox)ctrl;
                        cb.SelectedIndex = -1;
                    }
                    if (ctrl is GroupBox)
                    {
                        GroupBox gbx = (GroupBox)ctrl;
                        foreach (Control gctrl in gbx.Controls)
                        {
                            if(gctrl is CheckBox)
                            {
                                CheckBox cb = (CheckBox)gctrl;
                                cb.Checked = false;
                            }
                        }
                        
                    }
                    if (ctrl is RadioButton)
                    {
                        RadioButton rb = (RadioButton)ctrl;
                        rb.Checked = false;
                    }
                    if (ctrl is NumericUpDown)
                    {
                        NumericUpDown nud = (NumericUpDown)ctrl;
                        nud.Value = 0;
                    }
                    if (ctrl is ListBox)
                    {
                        ListBox lb = (ListBox)ctrl;
                        lb.Items.Clear();
                    }
                }
            }
            else
            {
                
            }
        }
    }
}




