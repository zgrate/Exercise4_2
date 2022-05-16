using AsyncCallbackService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceClient2.ServiceReference1;
using WcfServiceClient2.ServiceReference2;
using WcfServiceClient2.ServiceReference5;

namespace WcfServiceClient2
{




    public partial class Okienko1 : Form
    {

        class ComplexCalculatorCallback : IComplexCallback
        {
            public Okienko1 okienko;
            public ComplexCalculatorCallback(Okienko1 okienko)
            {
                this.okienko = okienko;
            }

            public void CalculationResult(string operation, AsyncComplexNumber result)
            {
                okienko.setResult(result.RealValue, result.ImaginaryValue);
            }
        }
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

        public void setResult(double real, double imaginary)
        {
            realResult.Text = real.ToString();
            imaginaryResult.Text = imaginary.ToString();
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
                        setResult(result1.real, result1.imag);
                    }
                    else
                    {
                        //TODO Multiplication
                        //ComplexNum result1 = client1.(cnum1, cnum2);

                    }


                }
                else
                {
                    ComplexCalculatorCallback myCbBHandler = new ComplexCalculatorCallback(this);
                    InstanceContext instanceContext = new InstanceContext(myCbBHandler);
                    AsyncComplexCalculatorClient client3 = new AsyncComplexCalculatorClient(instanceContext);
                    client3.AddComplex()''

                }






            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Okienko1_Load(object sender, EventArgs e)
        {

        }
    }
}
