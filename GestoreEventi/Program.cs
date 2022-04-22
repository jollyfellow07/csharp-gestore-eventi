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

