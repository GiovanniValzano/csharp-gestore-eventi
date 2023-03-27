using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Evento
    {
        public Evento(string titolo, string data, string maxCapienza)
        {
            if (string.IsNullOrEmpty(titolo))
            {
                throw new Exception("Il titolo non può essere vuoto.");
            }
            Titolo = titolo;
            DateTime dataConvertita;
            if (!DateTime.TryParse(data, out dataConvertita))
            {
                throw new Exception("La data non è stata inserita nel formato corretto (dd,MM,yyyy)");
            }
            if (dataConvertita < DateTime.Now)
            {
                throw new Exception("Non è possibile inserire una data passata.");
            }
            Data = dataConvertita;
            int maxCapienzaCon;
            if (!int.TryParse(maxCapienza, out maxCapienzaCon))
            {
                throw new Exception("Il numero dei posti non è stato inserito correttamente");
            }
            if (maxCapienzaCon < 0)
            {
                throw new Exception("Il nomero di posti disponibili deve essere maggiore di 0.");
            }
            MaxCapienza = maxCapienzaCon;
            NumPrenotazioni = 0;
        }

        public string Titolo { get; set; }
        public DateTime Data { get; set; }
        public int MaxCapienza { get; init; }
        public int NumPrenotazioni { get; private set; }

        public void PrenotaPosti(int postiPrenotati)
        {
            NumPrenotazioni += postiPrenotati;
        }

        public void DisdiciPosti(int postiDisdetti)
        {
            NumPrenotazioni -= postiDisdetti;
        }

        public override string ToString()
        {
            var data = Data.ToString("dd/MM/yyyy"); ;
            string res = $"{data} - {Titolo}";
            return res;
        }
    }

    public class Conferenza : Evento
    {
        public Conferenza(string titolo, string data, string maxCapienza, string relatore, string prezzo) : base(titolo, data, maxCapienza)
        {
            if (string.IsNullOrEmpty(relatore))
            {
                throw new Exception("Il titolo non può essere vuoto.");
            }

            Relatore = relatore;
            if (string.IsNullOrEmpty(prezzo))
            {
                throw new Exception("Il prezzo non può essere vuoto.");
            }
            double intPrice;
            if (!double.TryParse(prezzo, out intPrice))
            {
                throw new Exception("Il prezzo non è stato inserito correttamente");
            }
            Price = intPrice;
        }

        public string Relatore { get; set; }
        public double Price { get; set; }

        public string PrezzoFormattato()
        {
            var priceForm = Price.ToString("0.00");
            return priceForm;
        }

        public override string ToString()
        {
            var priceFor = Price.ToString("0.00");
            return $"{base.Data.ToString("dd/MM/yyyy")} - {base.Titolo} - {Relatore} - {priceFor}$";
        }
    }
}
