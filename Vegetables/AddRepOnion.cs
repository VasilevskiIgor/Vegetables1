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
    public partial class AddRepOnion : Form
    {
        List<Vegetable> vegSalad;
        ListBox listBox1;

        public AddRepOnion(List<Vegetable> vegSalad, ListBox listBox1)
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
            textBox7.Text == "" || textBox8.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Заполнены не все поля", "Ошибка");
                return;
            }
            RepOnion ro = new RepOnion();
            ro.sort = textBox1.Text;
            ro.calorificValue = Double.Parse(textBox2.Text);
            ro.weight = Double.Parse(textBox3.Text);
            ro.cost = Double.Parse(textBox4.Text);
            ro.circleCount = Int32.Parse(textBox5.Text);
            ro.onionTone = textBox6.Text;
            ro.dDim = Double.Parse(textBox7.Text);
            ro.stingLevel = Int32.Parse(textBox9.Text);
            ro.flavor = textBox8.Text;
            ro.isMarinated = (comboBox1.SelectedIndex == 0);
            ro.isFresh = (comboBox1.SelectedIndex == 1);
            vegSalad.Add(ro);

            listBox1.Items.Add(ro.sort + " " + ro.calorificValue + " " + ro.weight + " " + ro.cost + " " +
                ro.circleCount + " " + ro.onionTone + " " + ro.dDim + " " + ro.stingLevel +
                " " + ro.flavor + " " + (ro.isMarinated ? "маринованный" : "не маринованный") + " " + 
                (ro.isFresh ? "свежий" : "не свежий"));
            this.Close();
        }
    }
}
