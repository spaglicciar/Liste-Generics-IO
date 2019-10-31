using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    [Serializable]
    public class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataDiNascita { get; set; }

        public Persona()
        {

        }

        public Persona(string nome, string cognome, DateTime dataDiNascita)
        {
            Nome = nome;
            Cognome = cognome;
            DataDiNascita = dataDiNascita;
        }

        public override string ToString()
        {
            return string.Format("Nome: {0}, Cognome: {1}, Data di nascita: {2:d}", 
                Nome, 
                Cognome, 
                DataDiNascita);
        }
    }
}
