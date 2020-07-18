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
    public partial class AddPeas : Form
    {
        List<Vegetable> vegSalad;
        ListBox listBox1;

        public AddPeas(List<Vegetable> vegSalad, ListBox listBox1)
        {
            InitializeComponent();
            this.vegSalad = vegSalad;
            this.listBox1 = listBox1;
            comboBox1.Items.Add("Маринованный");
            comboBox1.Items.Add("Варёный");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
            textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" ||
            comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Заполнены не все поля", "Ошибка");
                return;
            }
            Peas p = new Peas();
            p.sort = textBox1.Text;
            p.calorificValue = Double.Parse(textBox2.Text);
            p.weight = Double.Parse(textBox3.Text);
            p.cost = Double.Parse(textBox4.Text);
            p.peasCount = Int32.Parse(textBox5.Text);
            p.pDim = Int32.Parse(textBox6.Text);
            p.isMarinated = (comboBox1.SelectedIndex == 0);
            p.isBoiled = (comboBox1.SelectedIndex == 1);
            vegSalad.Add(p);

            listBox1.Items.Add(p.sort + " " + p.calorificValue + " " + p.weight + " " + p.cost + " " +
                p.peasCount + " " + p.pDim + " " + (p.isMarinated ? "маринованный" : "не маринованный") + 
                " " + (p.isBoiled ? "варёный" : "не варёный"));
            this.Close();
        }
    }
}
