using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables
{
    // Перец - маринованный или свежий
    // сериализуемый (для сохранения коллекции в файл)
    [Serializable]
    class Pepper : Vegetable, IMarinatedVegetable, IFreshVegetable
    {
        bool _isPepperSpicy; // острый или нет
        int _SpicyLevel; // уровень остроты

        // для интерфейсов IMarinatedVegetable и IFreshVegetable
        bool _isFresh;
        bool _isMarinated;

        public bool isFresh
        {
            get
            {
                return _isFresh;
            }
            set
            {
                _isFresh = value;
            }
        }


        public bool isMarinated
        {
            get
            {
                return _isMarinated;
            }
            set
            {
                _isMarinated = value;
            }
        }

        public bool isPepperSpicy
        {
            get
            {
                return _isPepperSpicy;
            }
            set
            {
                _isPepperSpicy = value;
            }
        }

        public int SpicyLevel
        {
            get
            {
                return _SpicyLevel;
            }
            set
            {
                _SpicyLevel = value;
            }
        }
    }
}
