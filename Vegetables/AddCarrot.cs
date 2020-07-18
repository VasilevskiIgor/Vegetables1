using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vegetables
{
    public partial class AddCarrot : Form
    {
        List<Vegetable> vegSalad;
        ListBox listBox1;

        public AddCarrot(List<Vegetable> vegSalad, ListBox listBox1)
        {
            InitializeComponent();
            this.vegSalad = vegSalad;
            this.listBox1 = listBox1;
            comboBox1.Items.Add("Варёная");
            comboBox1.Items.Add("Свежая");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
                textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" ||
                 textBox7.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Заполнены не все поля", "Ошибка");
                return;
            }

            Carrot c = new Carrot();
            c.sort = textBox1.Text;
            c.calorificValue = Double.Parse(textBox2.Text);
            c.weight = Double.Parse(textBox3.Text);
            c.cost = Double.Parse(textBox4.Text);
            c.carrotLength = Int32.Parse(textBox5.Text);
            c.circleDim = Int32.Parse(textBox6.Text);
            c.carotinLevel = Int32.Parse(textBox7.Text);
            c.isBoiled = (comboBox1.SelectedIndex == 0);
            c.isFresh = (comboBox1.SelectedIndex == 1);
            vegSalad.Add(c);

            listBox1.Items.Add(c.sort + " " + c.calorificValue + " " + c.weight + " " + c.cost + " " +
                c.carrotLength + " " + c.carotinLevel + " " + (c.isBoiled ? "варёная" : "не варёная")+  " " 
                + (c.isFresh ? "свежая" : "не свежая"));
            this.Close();
        }


    }
}
