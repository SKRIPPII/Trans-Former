using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Trans_Former
{

    public partial class Form1 : Form
    {


        class Transformer
        {
            int price;
            int kol;
            string name;
            public Transformer(int kol, int price,string name) { this.kol = kol;  this.price = price;this.name = name; }


            public int Price
            {
                get {return price;  }
                set { price = value; }
            }

            public int Kol
            {
                get { return kol; }
                set { kol = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }
        List<Transformer> katalog = new List<Transformer>();
        List<int> cena = new List<int>();
        public Form1()
            {


                InitializeComponent();

            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                cena.Add((i + 5) * 50);
               
            }
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                cena.Add((i + 5) * 70);
            }

            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                cena.Add((i + 5) * 90);
            }


            for (int i = 0; i < comboBox4.Items.Count; i++)
            {
                cena.Add((i + 5) * 120);
            }
        }

            private void Form1_Load(object sender, EventArgs e) // картинка при загрузке формы
            {
                Form2 form = new Form2();
                form.Show();
                form.Update();
                System.Threading.Thread.Sleep(5000);
                form.Close();
            
             }

        private void button1_Click(object sender, EventArgs e)
        {
            int kol;
            bool ifkol = int.TryParse(textBox1.Text.Trim(), out kol);
            if(ifkol && comboBox1.SelectedIndex > -1 && textBox1.Text.Length > 0)
            {
                Transformer transformer = new Transformer(kol,cena[comboBox1.SelectedIndex] * kol,comboBox1.SelectedItem.ToString());
                katalog.Add(transformer);
                Print(katalog);
                comboBox1.SelectedIndex = -1;

            }

            if (ifkol && comboBox2.SelectedIndex > -1 && textBox1.Text.Length > 0)
            {
                Transformer transformer = new Transformer(kol, cena[comboBox2.SelectedIndex] * kol, comboBox2.SelectedItem.ToString());
                katalog.Add(transformer);
                Print(katalog);
                comboBox2.SelectedIndex = -1;

            }


            if (ifkol && comboBox3.SelectedIndex > -1 && textBox1.Text.Length > 0)
            {
                Transformer transformer = new Transformer(kol, cena[comboBox3.SelectedIndex]*kol, comboBox3.SelectedItem.ToString());
                katalog.Add(transformer);
                Print(katalog);
                comboBox3.SelectedIndex = -1;

            }

            if (ifkol && comboBox4.SelectedIndex > -1 && textBox1.Text.Length > 0)
            {
                Transformer transformer = new Transformer(kol, cena[comboBox4.SelectedIndex]*kol, comboBox4.SelectedItem.ToString());
                katalog.Add(transformer);
                Print(katalog);
                comboBox4.SelectedIndex = -1;

            }
        }


        void Print(List<Transformer> print)
        {
            listBox2.Items.Clear();
           foreach(var i in print)
            {
                listBox2.Items.Add(i.Name + " " +  i.Kol + " шт " + i.Price * i.Kol + " руб");
            }
        }


     

        void Sum(List<Transformer> katsum)//посчитать сумму
        {
            int sum = 0;
            foreach (Transformer item in katsum)
            {
                sum += item.Kol * item.Price;
            }
            MessageBox.Show("Итого: " + sum.ToString());
        }

        private void button2_Click(object sender, EventArgs e) // удалить
        {
            if(listBox2.SelectedIndex > -1)
            {
                katalog.RemoveAt(listBox2.SelectedIndex);
                Print(katalog);
                Sum(katalog);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sum(katalog);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) // Сохранить
        {
            const string sPath = "transformer.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBox2.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();

            MessageBox.Show("Programs saved!");
        }

        
    }


    }

