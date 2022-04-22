using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                    /***************************************BONUS***************************************************/
namespace GestoreEventi
{
    internal class Conferenza : Evento
    {
        private string relatore { get; set; }
        private double prezzo { get; set; }
        
        public Conferenza(string titolo, DateTime dataEvento, int postiADisposizione, string relatore, double prezzo) : base(titolo, dataEvento, postiADisposizione)
        {
            this.relatore = relatore;
            this.prezzo = prezzo;
        }
        //Stampa della mia conferenza
        public override string ToString()
        {
            string rappresentazioneInStringa = "";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            prezzo = Math.Round(prezzo, 2);
            rappresentazioneInStringa += "\t" + dataEvento.ToString("dd/MM/yyyy") + " - " + titolo + " - " + relatore + " - " + prezzo + "€" + "\n";
            return rappresentazioneInStringa;
        }
    }
}

