using System;
using System.Collections.Generic;
using TestWeek2.Lib;

namespace MagazzinoConsole
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

            magazzino = magazzino + eg;//prova inserimento

            string read = String.Empty;

            List<IGood> goods = new List<IGood>();

            string path = @"C:\Users\mauro.abozzi\source\repos\TestWeek2\goods.txt";

            //input da file
            try { 
                FileReader reader = new();
                reader.FileReaderStarted += Reader_FileReaderStarted;
                reader.FileReaderProgress += Reader_FileReaderProgress;
                goods = reader.GetGoods(path);
            }
            catch(GoodException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            foreach (IGood g in goods)
                magazzino = magazzino + g;

            magazzino = magazzino - eg;//controllo rimozione

            Console.WriteLine("");
            Console.WriteLine("Inserisci una merce: (q per uscire)");

            //input da console
            //while (Console.ReadLine() != "q")
            //{
            //    Console.WriteLine("Inserisci una merce: (q per uscire)");

            //    while (!read.Equals("Electronic") || !read.Equals("Perishable") || !read.Equals("Spirit"))
            //    {
            //        Console.WriteLine("Insrisci il tipo di bene: Electronic, Perishable o Spirit");
            //        read = Console.ReadLine();
            //    }

            //    try
            //    {
            //        Console.WriteLine("Inserisci id: ");
            //        int id = Console.Read();
            //        Console.WriteLine("Inserisci descrizione: ");
            //        string descrizione = Console.ReadLine();
            //        Console.WriteLine("Inserisci prezzo: ");
            //        double prezzo = Console.Read();
            //        Console.WriteLine("Inserisci quantità: ");
            //        int quantita = Console.Read();



            //        switch (read)
            //        {
            //            case "Electronic":
            //                Console.WriteLine("Inserisci produttore: ");
            //                string produttore = Console.ReadLine();
            //                ElectronicGood eg1 = new ElectronicGood(id, descrizione, prezzo, quantita, produttore);
            //                break;
            //            case "Perishable":
            //                Console.WriteLine("Inserisci anno di scadenza: ");
            //                int aa = Console.Read();
            //                Console.WriteLine("Inserisci mese di scadenza: ");
            //                int mm = Console.Read();
            //                Console.WriteLine("Inserisci giorno di scadenza: ");
            //                int gg = Console.Read();
            //                Console.WriteLine("Inserisci tipo di conservazione: ");
            //                int t = Console.Read();
            //                PerishableGood perGood = new PerishableGood(id, descrizione, prezzo, quantita, new DateTime(aa, mm, gg),
            //                    Enum.TryParse(t, out ModalitaConservazione cons));
                         
            //                break;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new GoodException("Formato dati errato");
            //    }

            //}

            magazzino.StockList();
        }

        private static void Reader_FileReaderProgress(int n)
        {
            Console.WriteLine($"Letta riga {n}");
            Console.WriteLine();
        }

        private static void Reader_FileReaderStarted(string fileName)
        {
            Console.WriteLine($"File {fileName} Processing STARTED.");
            Console.WriteLine();
        }

    }

    
}
