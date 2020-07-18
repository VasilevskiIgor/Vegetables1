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
    public partial class AddBeans : Form
    {
        List<Vegetable> vegSalad;
        ListBox listBox1;

        public AddBeans(List<Vegetable> vegSalad, ListBox listBox1)
        {
            InitializeComponent();
            this.vegSalad = vegSalad;
            this.listBox1 = listBox1;
            comboBox2.Items.Add("Да");
            comboBox2.Items.Add("Нет");
            comboBox1.Items.Add("Маринованная");
            comboBox1.Items.Add("Варёная");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || 
                textBox4.Text == "" || textBox5.Text == "" || comboBox1.SelectedIndex == -1
            || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Заполнены не все поля", "Ошибка");
                return;
            }
            Beans b = new Beans();
            b.sort = textBox1.Text;
            b.calorificValue = Double.Parse(textBox2.Text);
            b.weight = Double.Parse(textBox3.Text);
            b.cost = Double.Parse(textBox4.Text);
            b.countPerGlass = Int32.Parse(textBox5.Text);
            b.isSeed = (comboBox2.SelectedIndex == 0);
            b.isMarinated = (comboBox1.SelectedIndex == 0);
            b.isBoiled = (comboBox1.SelectedIndex == 1);
            vegSalad.Add(b);
            listBox1.Items.Add(b.sort + " " + b.calorificValue + " " + b.weight + " " + b.cost + " " +
                b.countPerGlass + " " + (b.isSeed ? "бобовая": "стручковая") + " " +
                (b.isMarinated ? "маринованная" : "не маринованная") + 
                " " + (b.isBoiled ? "варёная" : "не варёная"));
            this.Close();
        }

    }
}
