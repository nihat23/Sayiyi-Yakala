using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dinamik_nerne_ekleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int artipuan = 0, eksipuan = 0;

        void button()
        {
            int sayac = 0;
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    sayac++;
                    Button Btn = new Button();
                    Btn.Size = new Size(48, 48);
                    Btn.Location = new Point(j * 48 + 5, i * 48 + 5);
                    Btn.Name = sayac.ToString();
                    Btn.ForeColor = Color.Black;
                    Btn.Text = sayac.ToString();
                    panel1.Controls.Add(Btn);
                    Btn.Click += Btn_Click;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            button();

        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (int.Parse(btn.Text) == int.Parse(label1.Text))
            {
                artipuan++;
                btn.BackColor = Color.Red;
                label4Kirmizi.Text = artipuan.ToString();
            }
            else
            {
                eksipuan++;
                btn.BackColor = Color.Blue;
                label5Mavi.Text = eksipuan.ToString();
            }
            //MessageBox.Show(((Button)sender).Text + ". Butuna Tıkladınız..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        Random random = new Random();

        private void button1Basla_Click(object sender, EventArgs e)
        {
           
            try
            {
                int sskor = Convert.ToInt32(textBox1.Text);

                if (sskor >= 0)
                {                   
                    timer1.Start();
                    textBox1.ReadOnly = true;
                    button1Basla.Enabled = false;
                    panel1.Enabled = true;
                    artipuan = 0;
                    eksipuan = 0;
                    label4Kirmizi.Text = artipuan.ToString();
                    label5Mavi.Text = eksipuan.ToString();
                    
                }
                else
                {

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen Sayısal Bir deger giriniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        } 
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = random.Next(0, 100).ToString();

            if (int.Parse(textBox1.Text) == int.Parse(label4Kirmizi.Text))
            {
                timer1.Stop();
                button1Basla.Enabled = true;
                textBox1.ReadOnly = false;
                artipuan = 0;
                eksipuan = 0;                
                panel1.Enabled = false;
                MessageBox.Show("Tebrikler Kazandınız..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                



            }
           if (int.Parse(textBox1.Text) == int.Parse(label5Mavi.Text))
            {
                timer1.Stop();
                button1Basla.Enabled = true;
                textBox1.ReadOnly = false;
                artipuan = 0;
                eksipuan = 0;               
                panel1.Enabled = false;
                MessageBox.Show("Üzgünüz Kaybettiniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                 

            }
        }
    }
}
