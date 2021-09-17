using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek2.Lib
{
    public class SpiritDrinkGood : IGood
    {
        public int CodiceMerce { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public DateTime DataRicevimento { get; set; }
        public int Quantita { get; set; }
        public TipoDrink Tipo { get; set; }
        public int GradazioneAlcoolica { get; set; }

        public SpiritDrinkGood(int codice, string descr, double prezzo, int quantita, TipoDrink drink, int gradazione)
        {
            CodiceMerce = codice;
            Descrizione = descr;
            Prezzo = prezzo;
            Quantita = quantita;
            DataRicevimento = DateTime.Now;
            Tipo = drink;
            GradazioneAlcoolica = gradazione;
        }

        public override string ToString()
        {
            return $"Codice: {CodiceMerce} Descrizione: {Descrizione} Prezzo: {Prezzo}" +
                $"Data Ricevimento: {DataRicevimento.ToShortDateString()} Quantita: {Quantita}" +
                $"Tipo drink: {Tipo.ToString()} Gradazione: {GradazioneAlcoolica}";


        }
    }
}
