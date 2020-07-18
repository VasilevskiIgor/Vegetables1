using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables
{
    // класс "Овощ" - базовый класс в иерархии 
    // сериализуемый (для сохранения коллекции в файл)
    [Serializable]
    public class Vegetable
    {
        string _sort; // сорт овоща
        double _calorificValue; // калорийность
        double _weight; // вес
        double _cost; // цена

        public string sort
        {
            get
            {
                return _sort;
            }
            set
            {
                _sort = value;
            }
        }

        public double calorificValue
        {
            get
            {
                return _calorificValue;
            }
            set
            {
                _calorificValue = value;
            }
        }
        
        public double weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        public double cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

        // для сортировки используем стандартный интерфейс IComparer<T>

        // сортировка по сорту
        public class sortComparer : IComparer<Vegetable>
        {
            public int Compare(Vegetable x, Vegetable y)
            {
                if (x != null && y != null)
                {
                    return string.Compare(x.sort, y.sort);
                }
                else
                    throw new ArgumentException("Параметр не является экземпляром Vegetable!");
            }
        }

        // сортировка по калорийности
        public class calorificValueComparer : IComparer<Vegetable>
        {
            public int Compare(Vegetable x, Vegetable y)
            {
                if (x != null && y != null)
                {
                    if (x.calorificValue < y.calorificValue)
                        return -1;
                    else
                        if (x.calorificValue > y.calorificValue)
                            return 1;
                        else
                            return 0;
                }
                else
                    throw new ArgumentException("Параметр не является экземпляром Vegetable!");
            }
        }


        // сортировка по весу
        public class weightComparer : IComparer<Vegetable>
        {
            public int Compare(Vegetable x, Vegetable y)
            {
                if (x != null && y != null)
                {
                    if (x.weight < y.weight)
                        return -1;
                    else
                        if (x.weight > y.weight)
                            return 1;
                        else
                            return 0;
                }
                else
                    throw new ArgumentException("Параметр не является экземпляром Vegetable!");
            }
        }
    }
}
