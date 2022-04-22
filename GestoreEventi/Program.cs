// See https://aka.ms/new-console-template for more information
using GestoreEventi;
Evento cantante = new Evento("Twenty One Pilots", DateTime.Parse("12/05/2022"), 352);
try
{
    cantante.prenotaPosti();
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Mi dispiace ma " + e.ParamName + " ha detto " + e.Message);
    
}