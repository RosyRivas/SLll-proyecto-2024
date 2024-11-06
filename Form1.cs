using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SL2_proyecto.Models;

namespace SL2_proyecto
{
    public partial class Form1 : Form
    {
        // Crear una instancia de Persona
        private PersonaDataBase PersonaController = new PersonaDataBase();
        
        public Form1()
        {
            // Inicializar el formulario
            InitializeComponent();
            // Llenar el ComboBox con los valores "M" y "F"
            comboBoxSexo.Items.Add("M");
            comboBoxSexo.Items.Add("F");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Insertar una nueva persona
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
                

                // Llamar al método para insertar la nueva persona
                PersonaController.AgregarPersona(nuevaPersona);
                MessageBox.Show("Persona insertada correctamente.");

                //Limpiar controles
                ClearFields();

                //Actualizar el listado de personas
                ListarPersonas();
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



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        //Cargar el listado al iniciar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            ListarPersonas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Modificacion de una persona existente
            try
            {
                Persona personaModificada = new Persona
                {
                    Id = int.Parse(textBoxID.Text),
                    Nombre = textBoxNombre.Text,
                    Apellido = textBoxApellido.Text
                };

                PersonaController.ModificarPersona(personaModificada);
                MessageBox.Show("Persona modificada correctamente.");

                //limpiar los campos
                ClearFields();

                //listar las personas
                ListarPersonas();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al modificar: " + ex.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            // Eliminar una persona por su ID
            try
            {
                int id = int.Parse(textBoxID.Text);
                PersonaController.EliminarPersona(id);
                MessageBox.Show("Persona eliminada correctamente.");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error de formato: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar: " + ex.Message);
            }



        }

        //Listar las personas
        private void ListarPersonas()
        {
            try
            {
                var personas = PersonaController.ObtenerPersonas();
                dataGridView1.DataSource = personas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener personas: " + ex.Message);
            }
        }

        
        private void ClearFields()
        {
            textBoxID.Clear();
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            dateTimeFechaNac.Value = DateTime.Now;
            comboBoxSexo.Text = "";
        }  
    }
}
