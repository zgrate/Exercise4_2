using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceClient2.ServiceReference1;
using WcfServiceClient2.ServiceReference2;

namespace WcfServiceClient2
{
    public partial class Okienko1 : Form
    {
        public Okienko1()
        {
            InitializeComponent();
            modeChoose.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void setResult(ComplexNum num)
        {
            realResult.Text = num.real.ToString();
            imaginaryResult.Text = num.imag.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double real1Val = double.Parse(real1.Text);
                double real2Val = double.Parse(real2.Text);
                double imaginary1Val = double.Parse(imaginary1.Text);
                double imaginary2Val = double.Parse(imaginary2.Text);

                bool isAddition = dodawanieRadio.Checked;
                bool contract = modeChoose.SelectedIndex == 0;


                if (contract)
                {
                    ComplexCalcClient client1 = new ComplexCalcClient("BasicHttpBinding_IComplexCalc");
                    ComplexNum cnum1 = new ComplexNum();
                    cnum1.real = real1Val;
                    cnum1.imag = imaginary1Val;
                    ComplexNum cnum2 = new ComplexNum();
                    cnum2.real = real2Val;
                    cnum2.imag = imaginary2Val;
                    if (isAddition)
                    {
                        ComplexNum result1 = client1.addCNum(cnum1, cnum2);
                        setResult(result1);
                    }
                    else
                    {
                        //TODO Multiplication
                        //ComplexNum result1 = client1.(cnum1, cnum2);

                    }


                }
                else
                {
                    AsyncServiceClient client2 = new AsyncServiceClient("BasicHttpBinding_IAsyncService");
                    
                }






            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
