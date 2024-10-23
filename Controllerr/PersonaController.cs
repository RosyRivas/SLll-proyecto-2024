using System;
using System.Collections.Generic;
using SL2_proyecto.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL2_proyecto.Controllerr
{
 
    
        public class PersonaController
        {
            private PersonaDataBase db = new PersonaDataBase();

            // Este método llama a la base de datos y obtiene la lista de personas
            public List<Persona> ObtenerPersonas()
            {
                return db.ObtenerPersonas();
            }

            // Lógica para agregar una nueva persona
            public void AgregarPersona(string nombre, string apellido, string fechaNacimiento, string sexo)
            {
                Persona persona = new Persona
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    FechaNacimiento = DateTime.Parse(fechaNacimiento),
                    Sexo = sexo[0]  // Convierte a char ('M' o 'F')
                };

                db.InsertarPersona(persona);
            }

            // Lógica para eliminar una persona por ID
            public void EliminarPersona(int id)
            {
                db.EliminarPersona(id);
            }

            // Lógica para modificar una persona existente
            public void ModificarPersona(int id, string nombre, string apellido, string fechaNacimiento, string sexo)
            {
                Persona persona = new Persona
                {
                    Id = id,
                    Nombre = nombre,
                    Apellido = apellido,
                    FechaNacimiento = DateTime.Parse(fechaNacimiento),
                    Sexo = sexo[0]  // Convierte a char ('M' o 'F')
                };

                db.ModificarPersona(persona);
            }
        }
    }

