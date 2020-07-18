using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables
{
    // репчатый лук (OK)
    // сериализуемый (для сохранения коллекции в файл)
    [Serializable]
    class RepOnion : Onion
    {
        int _circleCount; // количество колец в салат
        string _onionTone; // оттенок луковицы
        double _dDim; // диаметр луковицы

        public int circleCount
        {
            get
            {
                return _circleCount;
            }
            set
            {
                _circleCount = value;
            }
        }

        public string onionTone
        {
            get
            {
                return _onionTone;
            }
            set
            {
                _onionTone = value;
            }
        }

        public double dDim
        {
            get
            {
                return _dDim;
            }
            set
            {
                _dDim = value;
            }
        }


    }
}
