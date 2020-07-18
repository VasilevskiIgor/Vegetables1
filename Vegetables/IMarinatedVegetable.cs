using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetables
{
    // интерфейс для маринованных овощей
    interface IMarinatedVegetable
    {
        bool isMarinated { get; set; } // маринованный или нет
    }
}
