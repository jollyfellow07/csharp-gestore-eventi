using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi 
{
    public class ProgrammaEventi
    {
       private string titolo;
       private List<Evento> eventi = new List<Evento>();
                            /*COSTRUTTORE*/
        public ProgrammaEventi(string titolo)
        {
            this.titolo = titolo;
            
        }
        /******METODI******/

        public void aggiungiPiuEventi()
        {
            Console.WriteLine("Quanti eventi vuoi aggiungere?");
            int numeroEventi = int.Parse(Console.ReadLine());



            if (numeroEventi > 0)
            {
                for (int i = 0; i < numeroEventi; i++)
                {

                    
                    Console.WriteLine("Inserisci il nome del " + (i + 1) + "° evento:");
                    string nome;
                    nome = Console.ReadLine();

                    Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy): ");
                    DateTime dataPerAppuntamento = DateTime.Parse(Console.ReadLine()); ;
                    

                    Console.WriteLine("Inserisci la capienza massima di spettatori: ");
                    int capienzaSpettatori = int.Parse(Console.ReadLine());

                    Console.Clear();
                    eventi.Add(new Evento(nome, dataPerAppuntamento, capienzaSpettatori));
                }
            }
        }

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
            Console.WriteLine("Il numero di eventi nel programma è:  " + ( i ));
        }
        /***************Metodo per stampare tutti gli eventi con la stessa data****************/
        public void StampaSoloDateUguali(DateTime dataDaConfrontare)
        {
            List<Evento> listaConfronto = new List<Evento>();
            for (int i = 0 ; i < eventi.Count; i++)
            {
                if (eventi[i].GetDataEvento() == dataDaConfrontare)
                {

                        Console.WriteLine(eventi[i]);
               
              }
            }

        }
        //Metodo per cancellare la nostra lista
        public void CancellaEventi()
        {
            bool condizione = true;
            while(condizione == true)
            {

            Console.WriteLine("Vuoi davvero cancellare la tua lista eventi?");
            string risposta = Console.ReadLine();
                switch (risposta)
                {

                    case"si":
                        eventi.Clear();
                        Console.WriteLine("Hai cancellato correttamente la tua lista. Ora la tua lista è vuota");
                        condizione = false;
                    break;

                    case "no": 
                        Console.WriteLine("Non hai cancellato la tua lista");
                        condizione=false;
                    break ;
                    default:
                        Console.WriteLine("Non hai inserito una scelta corretta, riprova!");
                    break;

                }
            }
         }

    }
}
/*
Console.WriteLine("ineserisci una data da confrontare con gli eventi programmati");
DateTime dataDaConfrontare = DateTime.Parse(Console.ReadLine());
int numberIndex = eventi.FindIndex(x => x.dataEvento == dataDaConfrontare); //PRENDO L'INDEX EVENTO CONFRONTANDO LE DATE
if (numberIndex == -1)
{
    Console.WriteLine("mi dispiace ma non ci sono eventi programmati per questa data");
}
else
{


    Console.WriteLine("IN QUESTA DATA CI SARA' QUESTO EVENTO: ");
    Console.WriteLine(eventi[numberIndex]);
    Console.ReadKey();
}*/