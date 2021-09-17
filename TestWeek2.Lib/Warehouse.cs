using System;
using System.Collections;
using System.Collections.Generic;

namespace TestWeek2.Lib
{
    //Il program si trova in MagazzinoConsole
    public class Warehouse<T> : IEnumerable<T> where T : IGood
    {
        public Guid IdMagazzino { get; set; }
        public string Indirizzo { get; set; }
        public double ImportoTotaleGiacenza { get; set; }
        public DateTime DataUltimaOperazione { get; set; }

        private List<T> merci = new List<T>();


        public Warehouse(Guid id, string address)
        {
            IdMagazzino = id;
            Indirizzo = address;
            ImportoTotaleGiacenza = 0;
            DataUltimaOperazione = DateTime.Now;
        }

        

        

        public static Warehouse<T> operator +(Warehouse<T> w, T good)
        {
            w.merci.Add(good);
            w.ImportoTotaleGiacenza += (good.Prezzo)*(good.Quantita);
            w.DataUltimaOperazione = DateTime.Now;

            return w;

        }

        public static Warehouse<T> operator -(Warehouse<T> w, T good)
        {
            w.merci.Remove(good);
            w.ImportoTotaleGiacenza -= good.Prezzo * good.Quantita;
            w.DataUltimaOperazione = DateTime.Now;

            return w;

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in merci)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void StockList()
        {
            Console.WriteLine($"Dati magazzino {IdMagazzino}: ");
            Console.WriteLine($"Indirizzo : {Indirizzo} Importo totale merci in giacenza: {ImportoTotaleGiacenza}");
            Console.WriteLine($"Data ultima operazione: { DataUltimaOperazione.ToShortDateString()}");
            Console.WriteLine("Merci in giacenza: ");
            foreach (T m in merci)
                Console.WriteLine(m.ToString());
        }
    }
}
