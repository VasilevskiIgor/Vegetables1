using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables
{
    // зелёный лук (OK)
    // сериализуемый (для сохранения коллекции в файл)
    [Serializable]
    class GreenOnion : Onion
    {
        int _arrowCount; // кол-во стрелок
        int _arrowLength; // средняя длина стрелок
        int _bittLevel; // уровень горькости

        public int arrowCount
        {
            get
            {
                return _arrowCount;
            }
            set
            {
                _arrowCount = value;
            }
        }

        public int arrowLength
        {
            get
            {
                return _arrowLength;
            }
            set
            {
                _arrowLength = value;
            }
        }

        public int bittLevel
        {
            get
            {
                return _bittLevel;
            }
            set
            {
                _bittLevel = value;
            }
        }
    }
}
