using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class ProgrammaEventi
    {
        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            Eventi = new List<Evento>();
        }

        public string Titolo { get; set; }
        public List<Evento> Eventi { get; set; }

        public void AddEvento(Evento evento)
        {
            Eventi.Add(evento);
        }

        public List<Evento> FilterByData(DateTime data)
        {
            List<Evento> res = new List<Evento>();
            foreach (Evento evento in Eventi)
            {
                if (evento.Data == data)
                {
                    res.Add(evento);
                }
            }
            return res;
        }

        public int GetProgramLenght(ProgrammaEventi programma)
        {
            return programma.Eventi.Count;
        }

        public static void ClearProgramList(ProgrammaEventi programma)
        {
            programma.Eventi.Clear();
        }

        public static void GetStringProgramma(ProgrammaEventi programma)
        {
            Console.WriteLine($"Titolo del programma: {programma.Titolo}");
            Console.WriteLine();
            foreach (Evento evento in programma.Eventi)
            {
                string res = evento.ToString();
                Console.WriteLine(res.PadLeft(res.Length + 5));
            }
        }
    }
}
