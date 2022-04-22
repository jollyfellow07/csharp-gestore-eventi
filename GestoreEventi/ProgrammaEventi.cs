using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi 
{
    internal class ProgrammaEventi
    {
        string titolo;
        List<Evento> eventi = new List<Evento>();

        public ProgrammaEventi(string titolo, List<Evento> eventi)
        {
            this.titolo = titolo;
            this.eventi = eventi;
        }
    }
}
