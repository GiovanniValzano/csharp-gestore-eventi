using GestoreEventi;
using System.Runtime.ExceptionServices;

List<Evento> eventi = new List<Evento>();

Console.WriteLine("Benvenuti sul portale Eventi.");
Console.WriteLine("Per creare un nuovo evento è necessario inserire un titolo:");
var titolo = Console.ReadLine();
Console.WriteLine("Inserire la data dell'evento:");
var data = Console.ReadLine();
Console.WriteLine("Inserisci il numero di posti totali dell'evento:");
var postiTot = Console.ReadLine();

try
{
    var eventoSelezionato = new Evento(titolo, data, postiTot);
    eventi.Add(eventoSelezionato);
    Console.WriteLine("Evento inserito correttamente.");
    Prenotazione(eventoSelezionato);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

void Prenotazione(Evento evento)
{
    Console.WriteLine();
    Console.WriteLine("Ora è possibile preotare dei posti per questo evento. Desideri farlo? (si/NO)");
    var siNo = Console.ReadLine();

    if (siNo == "si")
    {
        Console.WriteLine("Indicare il numero di posti da voler prenotare:");
        var postiPrenotati = Console.ReadLine();
        if (int.TryParse(postiPrenotati, out int result))
        {
            if (result < evento.MaxCapienza)
            {
                evento.PrenotaPosti(result);
            }
            else
            {
                Console.WriteLine("Numero di posti non disponibile");
            }
        }
        else
        {
            Console.WriteLine("Valore inserito non valido.");
        }
    }
}