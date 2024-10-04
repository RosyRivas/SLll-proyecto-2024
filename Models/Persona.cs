using System;


public class Persona
{
	public int id { get; set; }
	public string Nombre { get; set; }
	public string Apellido { get; set; }
	public DateTime FechaNacimiento { get; set; }
	public char Sexo {  get; set; }

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL2_proyecto.Models
{
    public class Persona
    {
        public int Id { get; set; } // Identificador único para cada persona.
        public string Nombre { get; set; } // Cadena que almacena el nombre de la persona. 
        public string Apellido { get; set; } // Cadena que alamacena el apellido de la persona.
        public DateTime FechaNacimiento { get; set; } // DateTime que almacena el nacimiento de la persona.
        public char Sexo { get; set; } // Caracter que representa el sexo de la persona (M / F).

    }
}
