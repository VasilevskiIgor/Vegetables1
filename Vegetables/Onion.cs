using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables
{
    // Лук - маринованный или свежий
    // сериализуемый (для сохранения коллекции в файл)
    [Serializable]
    class Onion : Vegetable, IMarinatedVegetable, IFreshVegetable
    {
        int _stingLevel; // жгучесть
        string _flavor; // аромат

        // для интерфейсов IMarinatedVegetable и IFreshVegetable
        bool _isMarinated; // маринованный или нет
        bool _isFresh;

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

        public int stingLevel
        {
            get
            {
                return _stingLevel;
            }
            set
            {
                _stingLevel = value;
            }
        }

        public string flavor
        {
            get
            {
                return _flavor;
            }
            set
            {
                _flavor = value;
            }
        }
            
    }
}
