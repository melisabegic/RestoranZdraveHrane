﻿using IB150218.Util;
using IB150218_APII.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IB150218.Vjezba
{
    public partial class Vjezba4 : Form
    {

        WebAPIHelper proizvodiService = new WebAPIHelper("http://localhost:54596/", "api/Proizvodi");
        WebAPIHelper vrstaProizvodaService = new WebAPIHelper("http://localhost:54596/", "api/VrsteProizvoda");

        public Vjezba4()
        {
            InitializeComponent();
        }

        private void Vjezba4_Load(object sender, EventArgs e)
        {
            BindVrstaProizvoda();
            //BindData();
        }

        private void BindVrstaProizvoda()
        {
            HttpResponseMessage response = vrstaProizvodaService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<VrsteProizvoda> vrsteProizvoda = response.Content.ReadAsAsync<List<VrsteProizvoda>>().Result;
                vrsteProizvoda.Insert(0, new VrsteProizvoda());
                vrsteProizvoda[0].Naziv = "Odaberite vrste proizvoda";
                comboBox1.DataSource = vrsteProizvoda;
                comboBox1.DisplayMember = "Naziv";
                comboBox1.ValueMember = "VrstaID";
            }
        }

        private void BindData()
        {
            HttpResponseMessage response = proizvodiService.GetResponse();
            if (response.IsSuccessStatusCode)
            {
                List<AllProizvodiVjezba1_Result> proizvodi = response.Content.ReadAsAsync<List<AllProizvodiVjezba1_Result>>().Result;
                dataGridView1.DataSource = proizvodi;
                //   dataGridView1.AutoGenerateColumns = false;
                //  dataGridView1.Columns[0].Visible = false;
            }
            else
            {
                MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0 && textBox1.Text == "")
            {
                BindData();
            }
            if (comboBox1.SelectedIndex != 0 && textBox1.Text == "")
            {
                int VrstaID = Convert.ToInt32(comboBox1.SelectedValue);
                if (VrstaID == 0 )
                {
                    BindData();
                                    }
                else 
                {
                    HttpResponseMessage response = proizvodiService.GetActionResponse("ProizvodiByVrstaID", VrstaID);
                    if (response.IsSuccessStatusCode)
                    {
                        List<Select_ByVrstaProizvoda_Result> proizvodi = response.Content.ReadAsAsync<List<Select_ByVrstaProizvoda_Result>>().Result;
                        dataGridView1.DataSource = proizvodi;
                        //  dataGridView1.AutoGenerateColumns = false;
                        //  dataGridView1.Columns[0].Visible = false;
                    }
                    
                    else
                    {
                        MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);

                    }
                }
            }
            else if (comboBox1.SelectedIndex == 0 && textBox1.Text != "")
            {
                HttpResponseMessage response = proizvodiService.GetActionResponse("Proizvodi_SelectByNaziv", textBox1.Text.Trim());
                if (response.IsSuccessStatusCode)
                {
                    List<esp_Proizvodi_SelectByNaziv_Result> proizvodiName = response.Content.ReadAsAsync<List<esp_Proizvodi_SelectByNaziv_Result>>().Result;
                    dataGridView1.DataSource = proizvodiName;
                    //  dataGridView1.AutoGenerateColumns = false;
                    //  dataGridView1.Columns[0].Visible = false;
                }

                else
                {
                    MessageBox.Show("Error Code:" + response.StatusCode + "Message:" + response.ReasonPhrase);

                }
            }
        }
    }
}
