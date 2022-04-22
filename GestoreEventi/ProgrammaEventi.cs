using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi 
{
    internal class ProgrammaEventi
    {
       private string titolo;
       private List<Evento> eventi = new List<Evento>();
                            /*COSTRUTTORE*/
        public ProgrammaEventi(string titolo)
        {
            this.titolo = titolo;
            
        }
                            /******METODI******/
        public void AggiungiEvento(Evento evento1)
        {
            eventi.Add(evento1);
        }

        //ricontrollare metodo statico
        public void StampaListaEventi()
        {
            Console.WriteLine("Programma Evento: " + titolo);
            foreach(Evento eventoNellaLista in eventi)
            {
                Console.Write(eventoNellaLista);
            }
        }
        public void ContatoreEventi()
        {
            int i;
            for(i = 0 ; i < eventi.Count; i++)
            {

            }
            Console.WriteLine("Nella lista sono presenti " + ( i ) + " event*");
        }

    }
}
