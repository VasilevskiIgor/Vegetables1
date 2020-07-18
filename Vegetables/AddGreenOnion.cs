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
    public partial class AddGreenOnion : Form
    {
        List<Vegetable> vegSalad;
        ListBox listBox1;

        public AddGreenOnion(List<Vegetable> vegSalad, ListBox listBox1)
        {
            InitializeComponent();
            this.vegSalad = vegSalad;
            this.listBox1 = listBox1;
            comboBox1.Items.Add("Маринованный");
            comboBox1.Items.Add("Свежий");
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
            GreenOnion go = new GreenOnion();
            go.sort = textBox1.Text;
            go.calorificValue = Double.Parse(textBox2.Text);
            go.weight = Double.Parse(textBox3.Text);
            go.cost = Double.Parse(textBox4.Text);
            go.arrowCount = Int32.Parse(textBox5.Text);
            go.arrowLength = Int32.Parse(textBox6.Text);
            go.bittLevel = Int32.Parse(textBox7.Text);
            go.stingLevel = Int32.Parse(textBox9.Text);
            go.flavor = textBox8.Text;
            go.isMarinated = (comboBox1.SelectedIndex == 0);
            go.isFresh = (comboBox1.SelectedIndex == 1);
            vegSalad.Add(go);

            listBox1.Items.Add(go.sort + " " + go.calorificValue + " " + go.weight + " " + go.cost + " " +
                go.arrowCount + " " + go.arrowLength + " " + go.bittLevel + " " + go.stingLevel +
                " " + go.flavor + " " + (go.isMarinated ? "маринованный" : "не маринованный") + " " 
                + (go.isFresh ? "свежий" : "не свежий"));
            this.Close();
        }
    }
}
