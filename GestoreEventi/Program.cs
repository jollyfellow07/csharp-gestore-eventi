// See https://aka.ms/new-console-template for more information
using GestoreEventi;
//setto il mio costruttore

string nomeEvento;

int capienzaEvento;
Console.Write("Nome dell'evento: ");
nomeEvento = Console.ReadLine();
Console.Write("Data dell'evento: ");
DateTime dataDellEvento = DateTime.Now;
try
{
    dataDellEvento = DateTime.Parse(Console.ReadLine());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
Console.Write("Capienza massima di persone che possono entrare: ");
capienzaEvento = 0;
try
{
    capienzaEvento = int.Parse(Console.ReadLine());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    capienzaEvento = -2;
}
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

Console.WriteLine("Premi un tasto per continuare");
Console.ReadKey();
Console.Clear();

Console.WriteLine("Inserisci il nome del tuo programma di Eventi");
string nomeProgrammaEvento = Console.ReadLine();
ProgrammaEventi tour = new ProgrammaEventi(nomeProgrammaEvento);
tour.aggiungiPiuEventi();
tour.StampaListaEventi();
Console.WriteLine("Inserisci una data da confrontare!");
DateTime data = DateTime.Now;
try
{
    data = DateTime.Parse(Console.ReadLine());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);

}
tour.StampaSoloDateUguali(data);

Console.WriteLine("Premi un tasto per continuare");
Console.ReadKey();
Console.Clear();


Console.WriteLine("****************BONUS***************");
//NOME CONFERENZA
string nomeEventoConferenza;
Console.Write("Nome dell'evento: ");
nomeEventoConferenza = Console.ReadLine();
//DATA CONFERENZA
Console.Write("Data dell'evento: ");
DateTime dataDellEventoConferenza = DateTime.Now;
try
{
    dataDellEventoConferenza = DateTime.Parse(Console.ReadLine());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
//CAPIENZA CONFERENZA
Console.Write("Capienza massima di persone che possono entrare: ");
int capienzaEventoConferenza = 0;
try
{
    capienzaEventoConferenza = int.Parse(Console.ReadLine());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    capienzaEventoConferenza = -2;
}
//NOME RELATORE
Console.Write("Inserisci il relatore della conferenza: ");
string? nomeRelatore = Console.ReadLine();
//PREZZO BIGLIETTO IN EURO
Console.Write("Inserisci il prezzo in euro (0.00): ");
double prezzoBiglietto = double.Parse(Console.ReadLine());
Conferenza Napoli = new Conferenza(nomeEventoConferenza, dataDellEventoConferenza, capienzaEventoConferenza, nomeRelatore, prezzoBiglietto);
tour.AggiungiEvento(Napoli);
tour.StampaListaEventi();