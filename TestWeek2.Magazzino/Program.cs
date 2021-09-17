using System;
using TestWeek2.Lib;

namespace TestWeek2.Magazzino
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d = new DateTime(2022, 6, 1);
            ElectronicGood eg = new ElectronicGood(1234, "PS5", 500, 100, "Sony");
            PerishableGood pg = new PerishableGood(1235, "Milk", 1, 150, d, ModalitaConservazione.FRIDGE);
            SpiritDrinkGood sdg = new SpiritDrinkGood(1236, "Birra", 3, 200, TipoDrink.OTHER, 4);

            Warehouse<IGood> magazzino = new(Guid.NewGuid(), "Via Roma 23");

            magazzino = magazzino + eg;

            magazzino.StockList();

        }
    }
}
