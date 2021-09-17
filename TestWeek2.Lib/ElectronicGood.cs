using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek2.Lib
{
    public class ElectronicGood : IGood
    {
        public int CodiceMerce { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public DateTime DataRicevimento { get; set; }
        public int Quantita { get; set; }
        public string Produttore { get; set; }

        public ElectronicGood(int codice, string descr, double prezzo, int quantita, string produttore)
        {
            CodiceMerce = codice;
            Descrizione = descr;
            Prezzo = prezzo;
            DataRicevimento = DateTime.Now;
            Quantita = quantita;
            Produttore = produttore;
        }

        public override string ToString()
        {
            return $"Codice: {CodiceMerce} Descrizione: {Descrizione} Prezzo: {Prezzo}" +
                $"Data Ricevimento: {DataRicevimento.ToShortDateString()} Quantita: {Quantita}" +
                $"Produttore : {Produttore}";
        }
    }
}
