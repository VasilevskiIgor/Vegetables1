using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables
{
    // Горошек - маринованный или варёный
    // сериализуемый (для сохранения коллекции в файл)
    [Serializable]
    class Peas : Vegetable, IMarinatedVegetable, IBoiledVegetable
    {
        int _peasCount; // горошин на столовую ложку
        int _pDim; // средний диаметр горошин

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

        public int peasCount
        {
            get
            {
                return _peasCount;
            }
            set
            {
                _peasCount = value;
            }
        }

        public int pDim
        {
            get
            {
                return _pDim;
            }
            set
            {
                _pDim = value;
            }
        }
            
    }
}
