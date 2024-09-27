using SL2_proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SL2_proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Persona nuevaPersona = new Persona
                {
                    Id = int.Parse(textBoxID.Text),
                    Nombre = textBoxNombre.Text,
                    Apellido = textBoxApellido.Text,
                    FechaNacimiento = dateTimeFechaNac.Value,
                    Sexo = Convert.ToChar(comboBoxSexo.Text)
                };

                // Crear una instancia de PersonaDataBase
                PersonaDataBase personaDb = new PersonaDataBase();

                // Llamar al método para insertar la nueva persona
                personaDb.InsertarPersona(nuevaPersona);
                MessageBox.Show("Persona insertada correctamente.");

                //Limpiar controles
                textBoxID.Clear();
                textBoxNombre.Clear();
                textBoxApellido.Clear();
                dateTimeFechaNac.Value = DateTime.Now;
                comboBoxSexo.Text = "";
            }

            catch (FormatException ex)
            {
                // Si ocurre un error de formato, por ejemplo al convertir texto en número
                MessageBox.Show("Error de formato: " + ex.Message);
            }

            catch (Exception ex)
            {
                // Captura cualquier otro tipo de excepción que pueda ocurrir
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }
    }
}
