using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Evento
    {
        public string titolo { get; set; }
        public DateTime dataEvento { get; set; }

        public readonly int postiTotali = 150;
        public readonly int postiprenotati = 0;
        public int postiADisposizione;

                                    /******   COSTRUTTORE  *********/
        public Evento(string titolo, DateTime dataEvento, int postiADisposizione)
        {
           this.titolo=titolo;

            
            try
            {
                SetDataEvento();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Mi dispiace ma " + e.ParamName + " ha detto " + e.Message);
                CambioDataEvento();
            }
            try
            {
                SetPostiADisposizione();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Mi dispiace ma " + e.ParamName + " ha detto " + e.Message);
                CambiaPostiADisposizione();
            }
        }

                                    /********  SETTER & GETTER    ******/
        public void SetTitolo()
        {
            if (titolo == null)
            {
                throw new ArgumentNullException("titolo", " non può essere un valore nullo");
            }
        }
        public void SetDataEvento()
        {
            if (dataEvento < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("dataEvento", "non puo essere una data del passato ");
            }
        }
        public void SetPostiADisposizione()
        {
            if (postiADisposizione > postiTotali)
            {

                Console.WriteLine("Mi dispiace ma i posti a disposizione non possono superare i posti totali del nostro teatro!");
                Console.WriteLine("i posti totali a disposizione sono stati settati automaticamente a  " + postiTotali);
                postiADisposizione = postiTotali;
            }
            else if (postiADisposizione < 0)
            {
                throw new ArgumentOutOfRangeException("postiADisposizione ", " non può essere un valore negativo");
            }
        }
                                        /******METODI*******/
                                        
        public int CambiaPostiADisposizione()
        {
            do
            {
                Console.Write("Inserisci la nuova data per l'appuntamento: ");

                int cambioPostiADisposizione = int.Parse(Console.ReadLine());



                this.postiADisposizione = cambioPostiADisposizione;
                try
                {
                    SetPostiADisposizione();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Mi dispiace ma " + e.ParamName + " ha detto " + e.Message);
                }

            } while (postiADisposizione < 0);
            return postiADisposizione;
        }
        public DateTime CambioDataEvento()
        {
            do
            {
                Console.Write("Inserisci la nuova data per l'appuntamento: ");

                DateTime cambioDellAppuntamento = DateTime.Parse(Console.ReadLine());



                this.dataEvento = cambioDellAppuntamento;
                try
                {
                    SetDataEvento();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Mi dispiace ma " + e.ParamName + " ha detto " + e.Message);
                }

            } while (dataEvento < DateTime.Now);
            return dataEvento;
        }
    }
    
}
