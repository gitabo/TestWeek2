using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek2.Lib
{
    public interface IGood
    {
        int CodiceMerce { get; set; }
        string Descrizione { get; set; }
        double Prezzo { get; set; }
        DateTime DataRicevimento { get; set; }
        int Quantita { get; set; }


    }
}
