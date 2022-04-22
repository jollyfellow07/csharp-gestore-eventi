using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Evento
    {
        public string titolo { get; set; }
        public DateTime dataEvento { get; set; }

        public readonly int postiTotali = 1000;
        public int postiPrenotati = 0;
        public int postiADisposizione;

        /******   COSTRUTTORE  *********/
        public Evento(string titolo, DateTime dataEvento, int postiADisposizione)
        {
            this.titolo = titolo;
            this.postiADisposizione = postiADisposizione;
            this.dataEvento = dataEvento;
            try
            {
                SetDataEvento(); //MI ACCERTO CHE NON ABBIA INSERITO UNA DATA GIA PASSATA
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Mi dispiace ma " + e.ParamName + " ha detto " + e.Message);
                CambioDataEvento();
            }
            try
            {
                SetPostiADisposizione(); //MI ACCERTO CHE I POSTI DISPONIBILI NON SUPERANO LA CAPIENZA MASSIMA DEL MIO TEATRO
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Mi dispiace ma " + e.ParamName + " ha detto " + e.Message);
                CambiaPostiADisposizione();
            }
        }

        /********  SETTER & GETTER    ******/
        
        public DateTime GetDataEvento()
        {
            return dataEvento;
        }

        public int GetPostiPrenotati()
        {
            return postiPrenotati;
        }
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
                    SetPostiADisposizione();//LANCIO UN METODO CHE SI ACCERTA CHE NON SUPERO LA CAPIENZA MASSIMA DEL MIO TEATRO
                }
                catch (ArgumentOutOfRangeException e) //NEL CASO IL METODO SIA VERO LANCIO LA MIA ECCEZIONE
                {
                    Console.WriteLine("Mi dispiace ma " + e.ParamName + " ha detto " + e.Message);
                }

            } while (postiADisposizione < 0);
            return postiADisposizione;
        }

        public DateTime CambioDataEvento()//METODO CHE MI CAMBIA LA DATA NEL CASO ABBIA INSERITO UNA DATA DEL PASSATO
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
        //METODO PER PRENOTARE I POSTI
        public int prenotaPosti()
        {
            Console.WriteLine("Vuoi prenotare dei posti?[si/no]");
            string risposta;
            bool condizione = true;
            //INSERISCO IL DO WHILE FINCHE CHE MI CICLA FINCHE NON INSERISCO UNA RISPOSTA CORRETTA
            do
            {
                risposta = Console.ReadLine();
                switch (risposta)
                {
                    case "si":
                        int posti;
                        Console.Write("Inserisci quanti posti vuoi prenotare? : ");
                        posti = int.Parse(Console.ReadLine());
                        //INSERISCO UN IF CHE MI CONFRONTA CON OP.LOGICI SE IL VALORE CHE INSERISCO RISPETTA LE CONDIZIONI
                        if (postiPrenotati < postiADisposizione && posti < postiADisposizione && posti > 0)
                             {
                              postiPrenotati += posti;
                            Console.WriteLine("Posti disponibili: " + (postiADisposizione - postiPrenotati));
                            Console.WriteLine("Posti Prenotati: " + postiPrenotati);
                            }
                            else if (posti < 0)
                            {
                                throw new ArgumentOutOfRangeException("posti", "non puo avere un valore negativo");
                            }
                            else
                            {
                                Console.WriteLine("mi dispiace i posti che vuoi prenotare non sono disponibili!");
                            }
                        condizione = false;
                        break;

                    case "no":
                        Console.WriteLine("Hai deciso di non prenotare nessun posto\n\n");
                        Console.WriteLine("Posti disponibili: " + (postiADisposizione - postiPrenotati));
                        Console.WriteLine("Posti Prenotati: " + postiPrenotati);
                        condizione = false;
                        break;
                    default:
                        Console.WriteLine("Non hai inserito una scelta corretta, riprova!");
                        break;
                }
            } while (condizione == true);
            return postiPrenotati;
        }

        public int DisdiciPosti()
        {
            Console.WriteLine("Vuoi disdire dei posti?[si/no]");
            string risposta;
            bool condizione = true;
            do
            {
                risposta = Console.ReadLine();
                switch (risposta)
                {
                    case "si":
                        int posti;
                        Console.Write("Inserisci quanti posti vuoi disdire? : ");
                        posti = int.Parse(Console.ReadLine());
                        if (postiPrenotati < postiADisposizione && posti < postiADisposizione && posti > 0)
                        {
                            postiPrenotati = postiPrenotati - posti;
                            //INSERISCO UN ULTERIORE IF PER CONTROLLARE SE IL VALORE DEI POSTI PRENOTATI NON SIA NEGATIVO 
                            if (postiPrenotati >= 0)
                            {
                                Console.WriteLine("posti prenotati " + postiPrenotati);
                                Console.WriteLine("posti disponibili: " + (postiADisposizione - postiPrenotati));
                            }
                            else if (postiPrenotati < 0)
                            {
                                postiPrenotati = 0;
                                Console.WriteLine("i posti che stai disdicendo superano la capienza massima del teatro");
                                Console.WriteLine("i posti disponibili sono tornati alla capazienza massima, ora sono: " + postiADisposizione);
                                Console.WriteLine("posti prenotati " + postiPrenotati);
                            }
                            //SE I POSTI CHE INSERISCO SONO NEGATIVI LANCIO UN ECCEZIONE
                        }
                        else if (posti < 0)
                        {
                            throw new ArgumentOutOfRangeException("posti", "non puo avere un valore negativo");
                        }
                            //FINE ECCEZIONE
                        else
                        {
                            Console.WriteLine("mi dispiace i posti che vuoi disdire non sono disponibili!");
                        }
                        condizione = false;
                        break;
                        
                    case "no":
                        Console.WriteLine("OK! VA BENE. \n\n");
                        Console.WriteLine("posti prenotati " + postiPrenotati);
                        Console.WriteLine("posti disponibili: " + (postiADisposizione - postiPrenotati));
                        condizione = false;
                        break;
                    default:
                        Console.WriteLine("Non hai inserito una scelta corretta, riprova!");
                        break;
                }
            } while (condizione == true);

            return postiPrenotati;
        }
        //Stampa della mia lista
        public override string ToString()
        {
            string rappresentazioneInStringa = "";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            rappresentazioneInStringa += "\t" + dataEvento.ToString("dd/MM/yyyy") + " - " + titolo + "\n";
            return rappresentazioneInStringa;
        }
    }
}
