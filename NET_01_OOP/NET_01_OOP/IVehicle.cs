using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_OOP
{
    // Интерфейс транспортного средства
    public interface IVehicle
    {
        string Brand { get; set; }
        string Model { get; set; }
        int Price { get; set; }
        int CreationYear { get; set; }

    }
}
