using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vegetables
{
    public partial class Form1 : Form
    {
        List<Vegetable> vegSalad;
        double sumCalorific = 0;

        public Form1()
        {
            InitializeComponent();
            vegSalad = new List<Vegetable>();
            Init();
        }

        private void Init()
        {
            // овощи
            comboBox3.Items.Add("Фасоль");
            comboBox3.Items.Add("Морковь");
            comboBox3.Items.Add("Лук зелёный");
            comboBox3.Items.Add("Лук репчатый");
            comboBox3.Items.Add("Горошек");
            comboBox3.Items.Add("Перец");

            // критерии сортировки
            comboBox1.Items.Add("по сорту");
            comboBox1.Items.Add("по калорийности");
            comboBox1.Items.Add("по весу");

            // критерии поиска
            comboBox2.Items.Add("варёные");
            comboBox2.Items.Add("маринованные");
            comboBox2.Items.Add("свежие");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран добавляемый овощ!", "Ошибка");
                return;
            }
            switch (comboBox3.SelectedItem.ToString())
            {
                case "Фасоль":
                    AddBeans addBeans = new AddBeans(vegSalad, listBox1);
                    addBeans.ShowDialog();
                    break;
                 case "Морковь":
                    AddCarrot addCarrot = new AddCarrot(vegSalad, listBox1);
                    addCarrot.ShowDialog();
                    break;
                case "Лук зелёный":
                    AddGreenOnion addGreenOnion = new AddGreenOnion(vegSalad, listBox1);
                    addGreenOnion.ShowDialog();
                    break;
                case "Лук репчатый":
                    AddRepOnion addRepOnion = new AddRepOnion(vegSalad, listBox1);
                    addRepOnion.ShowDialog();
                    break;
                 case "Горошек":
                    AddPeas addPeas = new AddPeas(vegSalad, listBox1);
                    addPeas.ShowDialog();
                    break;
                case "Перец":
                    AddPepper addPepper = new AddPepper(vegSalad, listBox1);
                    addPepper.ShowDialog();
                    break;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            countCalorific();
        }

        // подсчёт калорийности
        public void countCalorific()
        {
            sumCalorific = 0;
            for (int i = 0; i < vegSalad.Count; i++)
            {
                sumCalorific += vegSalad[i].calorificValue;
            }
            textBox1.Text = sumCalorific.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран критерий сортировки!", "Ошибка");
                return;
            }
            listBox1.Items.Clear();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "по сорту":
                    vegSalad.Sort(new Vegetable.sortComparer());
                    break;
                case "по калорийности":
                    vegSalad.Sort(new Vegetable.calorificValueComparer());
                    break;
                case "по весу":
                    vegSalad.Sort(new Vegetable.weightComparer());
                    break;
            }
            for (int i = 0; i < vegSalad.Count; i++)
            {
                string res = vegSalad[i].sort + " " + vegSalad[i].calorificValue + " " +
                    vegSalad[i].weight + " " + vegSalad[i].cost + " ";
                if (vegSalad[i] is Beans)
                    res += ((Beans)vegSalad[i]).countPerGlass + " " + (((Beans)vegSalad[i]).isSeed ? "бобовая" : "стручковая") + " " 
                        + (((Beans)vegSalad[i]).isMarinated ? "маринованный" : "не маринованный") + " " +
                        (((Beans)vegSalad[i]).isBoiled ? "варёная" : "не варёная");
                if (vegSalad[i] is Pepper)
                    res += ((Pepper)vegSalad[i]).SpicyLevel + " " + (((Pepper)vegSalad[i]).isPepperSpicy ? "острый" : "не острый") + " " + 
                        (((Pepper)vegSalad[i]).isMarinated ? "маринованный" : "не маринованный") + " " + (((Pepper)vegSalad[i]).isFresh ? "свежий" :
                        "не свежий");
                if (vegSalad[i] is Peas)
                    res += ((Peas)vegSalad[i]).peasCount + " " + ((Peas)vegSalad[i]).pDim + " " + (((Peas)vegSalad[i]).isMarinated ? "маринованный" : "не маринованный") +
                        " " + (((Peas)vegSalad[i]).isBoiled ? "варёный" : "не варёный");
                if (vegSalad[i] is Carrot)
                    res += ((Carrot)vegSalad[i]).carrotLength + " " + ((Carrot)vegSalad[i]).carotinLevel + " " +
                        (((Carrot)vegSalad[i]).isBoiled ? "варёная" : "не варёная") + " " + (((Carrot)vegSalad[i]).isFresh ? "свежая" : "не свежая");
                if (vegSalad[i] is RepOnion)
                    res += ((RepOnion)vegSalad[i]).circleCount + " " + ((RepOnion)vegSalad[i]).onionTone + " " +
                        ((RepOnion)vegSalad[i]).dDim + " " + ((RepOnion)vegSalad[i]).stingLevel +  " " +
                        ((RepOnion)vegSalad[i]).flavor + " " + (((RepOnion)vegSalad[i]).isMarinated ? "маринованный" : "не маринованный") + " " + 
                        (((RepOnion)vegSalad[i]).isFresh ? "свежий" : "не свежий");
                if (vegSalad[i] is GreenOnion)
                    res += ((GreenOnion)vegSalad[i]).arrowCount + " " + ((GreenOnion)vegSalad[i]).arrowLength + " " +
                        ((GreenOnion)vegSalad[i]).bittLevel + " " + ((GreenOnion)vegSalad[i]).stingLevel +
                        " " + ((GreenOnion)vegSalad[i]).flavor + " " + (((GreenOnion)vegSalad[i]).isMarinated ? "маринованный" : "не маринованный") + " " +
                        (((GreenOnion)vegSalad[i]).isFresh ? "свежий" : "не свежий");

                listBox1.Items.Add(res);
            }
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            string result = "";
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран критерий поиска!", "Ошибка");
                return;
            }
            switch (comboBox2.SelectedItem.ToString())
            {
                case "варёные":
                    for (int i = 0; i < vegSalad.Count; i++)
                    {
                        if (vegSalad[i] is IBoiledVegetable) // если овощ может быть варёным
                        {
                            if ((vegSalad[i] as IBoiledVegetable).isBoiled) // проверяем, варёный или нет
                                result += vegSalad[i].sort + " (вес: " + vegSalad[i].weight +
                                    ", калорийность: " + vegSalad[i].calorificValue +
                                    ", цена: " + vegSalad[i].cost + ")\n";
                        }
                    }
                    break;
                case "маринованные":
                    for (int i = 0; i < vegSalad.Count; i++)
                    {
                        if (vegSalad[i] is IMarinatedVegetable) // если овощ может быть маринованным
                        {
                            if ((vegSalad[i] as IMarinatedVegetable).isMarinated) // проверяем, маринованный или нет
                                result += vegSalad[i].sort + " (вес: " + vegSalad[i].weight +
                                    ", калорийность: " + vegSalad[i].calorificValue + 
                                    ", цена: " + vegSalad[i].cost + ")\n";
                        }
                    }
                    break;
                case "свежие":
                    for (int i = 0; i < vegSalad.Count; i++)
                    {
                        if (vegSalad[i] is IFreshVegetable) // если овощ может быть свежим
                        {
                            if ((vegSalad[i] as IFreshVegetable).isFresh) // проверяем, свежий или нет
                                result += vegSalad[i].sort + " (вес: " + vegSalad[i].weight +
                                    ", калорийность: " + vegSalad[i].calorificValue +
                                    ", цена: " + vegSalad[i].cost + ")\n";
                        }
                    }
                    break;
            }
            MessageBox.Show(result, "Результат поиска");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            vegSalad.Clear();
        }

        private void сохранитьСалатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream writerFileStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(writerFileStream, vegSalad);
                writerFileStream.Close();
            }
        }

        private void открытьСалатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                FileStream readerFileStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                vegSalad = (List<Vegetable>)bf.Deserialize(readerFileStream);
                readerFileStream.Close();

                for (int i = 0; i < vegSalad.Count; i++)
                {
                    string res = vegSalad[i].sort + " " + vegSalad[i].calorificValue + " " +
                        vegSalad[i].weight + " " + vegSalad[i].cost + " ";
                    if (vegSalad[i] is Beans)
                        res += ((Beans)vegSalad[i]).countPerGlass + " " + (((Beans)vegSalad[i]).isSeed ? "бобовая" : "стручковая") + " "
                            + (((Beans)vegSalad[i]).isMarinated ? "маринованный" : "не маринованный") + " " +
                            (((Beans)vegSalad[i]).isBoiled ? "варёная" : "не варёная");
                    if (vegSalad[i] is Pepper)
                        res += ((Pepper)vegSalad[i]).SpicyLevel + " " + (((Pepper)vegSalad[i]).isPepperSpicy ? "острый" : "не острый") + " " +
                            (((Pepper)vegSalad[i]).isMarinated ? "маринованный" : "не маринованный") + " " + (((Pepper)vegSalad[i]).isFresh ? "свежий" :
                            "не свежий");
                    if (vegSalad[i] is Peas)
                        res += ((Peas)vegSalad[i]).peasCount + " " + ((Peas)vegSalad[i]).pDim + " " + (((Peas)vegSalad[i]).isMarinated ? "маринованный" : "не маринованный") +
                            " " + (((Peas)vegSalad[i]).isBoiled ? "варёный" : "не варёный");
                    if (vegSalad[i] is Carrot)
                        res += ((Carrot)vegSalad[i]).carrotLength + " " + ((Carrot)vegSalad[i]).carotinLevel + " " +
                            (((Carrot)vegSalad[i]).isBoiled ? "варёная" : "не варёная") + " " + (((Carrot)vegSalad[i]).isFresh ? "свежая" : "не свежая");
                    if (vegSalad[i] is RepOnion)
                        res += ((RepOnion)vegSalad[i]).circleCount + " " + ((RepOnion)vegSalad[i]).onionTone + " " +
                            ((RepOnion)vegSalad[i]).dDim + " " + ((RepOnion)vegSalad[i]).stingLevel + " " +
                            ((RepOnion)vegSalad[i]).flavor + " " + (((RepOnion)vegSalad[i]).isMarinated ? "маринованный" : "не маринованный") + " " +
                            (((RepOnion)vegSalad[i]).isFresh ? "свежий" : "не свежий");
                    if (vegSalad[i] is GreenOnion)
                        res += ((GreenOnion)vegSalad[i]).arrowCount + " " + ((GreenOnion)vegSalad[i]).arrowLength + " " +
                            ((GreenOnion)vegSalad[i]).bittLevel + " " + ((GreenOnion)vegSalad[i]).stingLevel +
                            " " + ((GreenOnion)vegSalad[i]).flavor + " " + (((GreenOnion)vegSalad[i]).isMarinated ? "маринованный" : "не маринованный") + " " +
                            (((GreenOnion)vegSalad[i]).isFresh ? "свежий" : "не свежий");

                    listBox1.Items.Add(res);
                }
            }

        }




    }
}
