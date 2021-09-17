using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestWeek2.Lib
{
    public delegate void FileReaderStartDelegate(string fileName);
    public delegate void FileReaderProgressDelegate(int n);
    public class FileReader
    {
        public event FileReaderStartDelegate FileReaderStarted;
        public event FileReaderProgressDelegate FileReaderProgress;

        int nReadLines = 0;
        public List<IGood> GetGoods(string path)
        {
            List<IGood> goods = new List<IGood>();
            try
            {
                using StreamReader reader = File.OpenText(path);

                if (FileReaderStarted != null)
                    FileReaderStarted(path);

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    //Console.WriteLine(data[0]);

                    if (data == null || data.Length < 6 || data.Length > 7)
                        throw new GoodException("Errore nel formato dei dati");

                    if (data[0].Equals("Electronics"))
                    {
                        bool success = int.TryParse(data[1], out int id);

                        if(!success)
                            throw new GoodException("Errore lettura riga");

                        try
                        {
                            ElectronicGood eg = new ElectronicGood(id, data[2], double.Parse(data[3]),
                                int.Parse(data[4]), data[5]);
                            goods.Add(eg);
                        }
                        catch(FormatException)
                        {
                            throw new GoodException("Errore lettura riga");
                        }
                        
                    }
                    else if (data[0].Equals("Perishable"))
                    {
                        //split della data per creare un DateTime
                        string[] dateString = data[5].Split("/");

                        if(dateString.Length != 3)
                            throw new GoodException("Errore lettura data di scadenza");

                        try
                        {
                            DateTime date = new DateTime(int.Parse(dateString[0]), int.Parse(dateString[1]),
                                int.Parse(dateString[2]));
                            Enum.TryParse(data[6], out ModalitaConservazione cons);
                            PerishableGood pg = new PerishableGood(int.Parse(data[1]), data[2], double.Parse(data[3]),
                                int.Parse(data[4]), date, cons);
                            goods.Add(pg);
                        }
                        catch(FormatException)
                        {
                            throw new GoodException("Errore lettura riga");
                        }
                        

                    }
                    else if (data[0].Equals("Spirit"))
                    {
                        try { 
                            Enum.TryParse(data[5], out TipoDrink tipo);
                            SpiritDrinkGood sdg = new SpiritDrinkGood(int.Parse(data[1]), data[2], double.Parse(data[3]),
                                int.Parse(data[4]), tipo, int.Parse(data[6]));
                            goods.Add(sdg);
                        }
                        catch(FormatException)
                        {
                            throw new GoodException("Errore lettura riga");
                        }
                        
                    }
                    else //se non è nessuno dei tre tipi
                        throw new GoodException("Tipo merce non riconosciuto");

                    nReadLines++;
                    if (FileReaderProgress != null)
                        FileReaderProgress(nReadLines);

                }

                return goods; 
            }
            catch (IOException ex)
            {
                throw new Exception(
                    $"Error Processing file {path}.",
                    ex);
                
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Generic Error Processing file {path}.",
                    ex);
                
            }
        }
    }
}
