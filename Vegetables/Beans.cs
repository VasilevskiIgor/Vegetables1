using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables
{
    // Фасоль - варёная или маринованная
    // сериализуемый (для сохранения коллекции в файл)
    [Serializable]
    class Beans : Vegetable, IMarinatedVegetable, IBoiledVegetable
    {
        int _countPerGlass; // количество на стакан
        bool _isSeed; // бобовая или нет (стручковая)

        // для интерфейсов IMarinatedVegetable и IBoiledVegetable
        bool _isMarinated;
        bool _isBoiled;


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

        public int countPerGlass
        {

            get
            {
                return _countPerGlass;
            }
            set
            {
                _countPerGlass = value;
            }
        }
        
        public bool isSeed
        {
            get
            {
                return _isSeed;
            }
            set
            {
                _isSeed = value;
            }
        }
          
    }
}
