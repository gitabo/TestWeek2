using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek2.Lib
{
    public class PerishableGood : IGood
    {
        public int CodiceMerce { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public DateTime DataRicevimento { get; set; }
        public int Quantita { get; set; }

        public DateTime DataScadenza { get; set; }

        public ModalitaConservazione Conservazione { get; set; }

        public PerishableGood(int codice, string descr, double prezzo, int quantita, DateTime scadenza, ModalitaConservazione conservazione)
        {
            CodiceMerce = codice;
            Descrizione = descr;
            Prezzo = prezzo;
            Quantita = quantita;
            DataRicevimento = DateTime.Now;
            DataScadenza = scadenza;
            Conservazione = conservazione;
        }

        public override string ToString()
        {
            return $"Codice: {CodiceMerce} Descrizione: {Descrizione} Prezzo: {Prezzo}" +
                $"Data Ricevimento: {DataRicevimento.ToShortDateString()} Quantita: {Quantita}" +
                $"Data di scadenza : {DataScadenza.ToShortDateString()} Conservazione: " +
                $"{Conservazione.ToString()}";
        }
    }
}
