using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_OOP
{
    // интерфейс грузового авто
    public interface ITruck
    {
        int Power { get; set; }  // мощьность
        string Type { get; set; }  // тип
        int Axles { get; set; }  // кол-во осей
    }
}
