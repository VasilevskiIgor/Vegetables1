using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables

{
    // Морковь - варёная или свежая
    // сериализуемый (для сохранения коллекции в файл)
    [Serializable]
    class Carrot : Vegetable, IBoiledVegetable, IFreshVegetable
    {
        int _carrotLength; // длина морковки
        int _circleAvgDim; // средний диаметр сечения
        int _carotinLevel; // содержание каротина

        // для интерфейсов IBoiledVegetable и IFreshVegetable
        bool _isBoiled;
        bool _isFresh;

        public bool isBoiled
        {
            get
            {
                return _isBoiled;
            }
            set
            {
                _isBoiled = value;
            }
        }

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

        public int carrotLength
        {
            get
            {
                return _carrotLength;
            }
            set
            {
                _carrotLength = value;
            }
        }

        public int circleDim
        {
            get
            {
                return _circleAvgDim;
            }
            set
            {
                _circleAvgDim = value;
            }
        }

        public int carotinLevel
        {
            get
            {
                return _carotinLevel;
            }
            set
            {
                _carotinLevel = value;
            }
        }
    }
}
