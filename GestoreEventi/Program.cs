// See https://aka.ms/new-console-template for more information
using GestoreEventi;
//setto il mio costruttore
string nomeEvento;

int capienzaEvento;
Console.Write("Nome dell'evento: ");
nomeEvento = Console.ReadLine();
Console.Write("Data dell'evento: ");
DateTime dataDellEvento = DateTime.Parse(Console.ReadLine());
Console.Write("Capienza massima di persone che possono entrare: ");
capienzaEvento = int.Parse(Console.ReadLine());

Evento cantante = new Evento(nomeEvento, dataDellEvento, capienzaEvento);
Evento teatro = new Evento("teatro", DateTime.Parse("28/12/2022"), 800);
try
{
    cantante.prenotaPosti();
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Mi dispiace ma " + e.ParamName + " ha detto " + e.Message);
    
}

try
{
    cantante.DisdiciPosti();
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Mi dispiace ma " + e.ParamName + " ha detto " + e.Message);

}

ProgrammaEventi eventi = new ProgrammaEventi("Tour dei balocchi");
eventi.AggiungiEvento(cantante);
eventi.AggiungiEvento(teatro);
eventi.ContatoreEventi();
eventi.StampaListaEventi();
