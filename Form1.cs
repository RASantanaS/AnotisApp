using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace AnotisApp
{
    public partial class Anotis : Form
    {
        // Constantes para nombres de columnas
        private const string COL_TITULO = "Titulo";
        private const string COL_FECHA_CREACION = "Fecha Creacion";
        private const string COL_CONTENIDO = "Contenido Nota";

        // Tabla en memoria para gestionar las notas
        private readonly DataTable notas = new DataTable();

        // Indica si estamos editando una nota existente o creando una nueva
        private bool modoEdicion = false;

        // Carpeta donde se almacenan las notas como archivos .txt
        private readonly string rutaCarpetaNotas = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "AnotisAppNotas");

        public Anotis()
        {
            InitializeComponent();
        }

        private void Anotis_Load(object sender, EventArgs e)
        {
            InicializarYCargarNotas();
        }

        // Inicializa la estructura de la tabla y carga todas las notas desde el disco
        private void InicializarYCargarNotas()
        {
            // Configurar estructura de la tabla si es necesario
            if (notas.Columns.Count == 0)
            {
                notas.Columns.Add(COL_TITULO, typeof(string));
                notas.Columns.Add(COL_FECHA_CREACION, typeof(DateTime));
                notas.Columns.Add(COL_CONTENIDO, typeof(string));
            }

            // Limpiar datos existentes
            notas.Clear();

            // Crear carpeta si no existe
            Directory.CreateDirectory(rutaCarpetaNotas);

            // Cargar notas desde archivos
            CargarNotasDesdeArchivos();

            // Ordenar por fecha (más recientes primero) y vincular al DataGridView
            DataView vista = notas.DefaultView;
            vista.Sort = $"{COL_FECHA_CREACION} DESC";
            historialDeNotas.DataSource = vista;

            // Configurar columnas del DataGridView
            ConfigurarColumnas();
        }

        // Configura la apariencia y comportamiento de las columnas del DataGridView
        private void ConfigurarColumnas()
        {
            // Orden visual: Título, Contenido, Fecha
            historialDeNotas.Columns[COL_TITULO].DisplayIndex = 0;
            historialDeNotas.Columns[COL_CONTENIDO].DisplayIndex = 1;
            historialDeNotas.Columns[COL_FECHA_CREACION].DisplayIndex = 2;

            // Hacer todas las columnas de solo lectura
            foreach (DataGridViewColumn col in historialDeNotas.Columns)
            {
                col.ReadOnly = true;
            }

            // Configurar comportamiento del DataGridView
            historialDeNotas.RowHeadersVisible = false;
            historialDeNotas.AllowUserToAddRows = false;
            historialDeNotas.AllowUserToOrderColumns = false;
            historialDeNotas.AllowUserToResizeColumns = false;
            historialDeNotas.AllowUserToResizeRows = false;
            historialDeNotas.MultiSelect = false;
        }

        // Lee todos los archivos .txt de la carpeta y los carga en la tabla
        private void CargarNotasDesdeArchivos()
        {
            string[] archivos = Directory.GetFiles(rutaCarpetaNotas, "*.txt");

            foreach (string archivo in archivos)
            {
                try
                {
                    DataRow fila = notas.NewRow();
                    fila[COL_TITULO] = Path.GetFileNameWithoutExtension(archivo);
                    fila[COL_FECHA_CREACION] = File.GetCreationTime(archivo);
                    fila[COL_CONTENIDO] = File.ReadAllText(archivo);
                    notas.Rows.Add(fila);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cargar {archivo}: {ex.Message}");
                }
            }
        }

        // Limpia los campos para crear una nueva nota
        private void btnNuevaNota_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Carga la nota seleccionada en los campos de edición
        private void btnCargarNota_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion("cargar")) return;

            try
            {
                DataRow fila = ObtenerFilaSeleccionada();
                tituloTexto.Text = fila[COL_TITULO].ToString();
                notaTexto.Text = fila[COL_CONTENIDO].ToString();
                modoEdicion = true;
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar la nota", ex.Message);
            }
        }

        // Guarda la nota actual (nueva o editada) en el disco
        private void btnGuardarNota_Click(object sender, EventArgs e)
        {
            // Validar título
            if (string.IsNullOrWhiteSpace(tituloTexto.Text))
            {
                MessageBox.Show("El título de la nota no puede estar vacío.",
                    "Título Requerido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tituloNuevo = tituloTexto.Text.Trim();
            string contenido = notaTexto.Text;
            string archivoNuevo = ObtenerRutaArchivo(tituloNuevo);

            try
            {
                // Si estamos editando y el título cambió, eliminar el archivo antiguo
                if (modoEdicion)
                {
                    EliminarArchivoAntiguo(tituloNuevo);
                }

                // Guardar el archivo
                File.WriteAllText(archivoNuevo, contenido);

                // Recargar y limpiar
                InicializarYCargarNotas();
                LimpiarCampos();

                MessageBox.Show($"Nota '{tituloNuevo}' guardada con éxito.",
                    "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("Error al guardar la nota", ex.Message);
            }
        }

        // Elimina la nota seleccionada del disco y de la tabla
        private void btnBorrarNota_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion("borrar")) return;

            try
            {
                DataRow fila = ObtenerFilaSeleccionada();
                string titulo = fila[COL_TITULO].ToString();
                string archivo = ObtenerRutaArchivo(titulo);

                // Eliminar archivo y fila
                if (File.Exists(archivo))
                {
                    File.Delete(archivo);
                }
                fila.Delete();

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MostrarError("Error al borrar la nota", ex.Message);
            }
        }

        // Permite cargar una nota haciendo doble clic en el historial
        private void historialDeNotas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCargarNota_Click(sender, e);
        }

        // ============= MÉTODOS AUXILIARES =============

        // Valida que haya una nota seleccionada en el historial
        private bool ValidarSeleccion(string accion)
        {
            if (historialDeNotas.CurrentRow == null)
            {
                MessageBox.Show($"Selecciona una nota válida para {accion}.",
                    "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Obtiene la fila DataRow de la selección actual del DataGridView
        private DataRow ObtenerFilaSeleccionada()
        {
            DataRowView rowView = (DataRowView)historialDeNotas.CurrentRow.DataBoundItem;
            return rowView.Row;
        }

        // Genera la ruta completa del archivo basándose en el título
        private string ObtenerRutaArchivo(string titulo)
        {
            string nombreLimpio = string.Join("_", titulo.Split(Path.GetInvalidFileNameChars()));
            return Path.Combine(rutaCarpetaNotas, $"{nombreLimpio}.txt");
        }

        // Elimina el archivo antiguo si el título de la nota fue modificado
        private void EliminarArchivoAntiguo(string tituloNuevo)
        {
            if (historialDeNotas.CurrentRow == null) return;

            try
            {
                DataRow fila = ObtenerFilaSeleccionada();
                string tituloAnterior = fila[COL_TITULO].ToString();

                // Solo eliminar si el título cambió
                if (tituloAnterior != tituloNuevo)
                {
                    string archivoAntiguo = ObtenerRutaArchivo(tituloAnterior);
                    if (File.Exists(archivoAntiguo))
                    {
                        File.Delete(archivoAntiguo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al limpiar archivo anterior: {ex.Message}");
            }
        }

        // Limpia los campos de texto y resetea el modo de edición
        private void LimpiarCampos()
        {
            tituloTexto.Text = "";
            notaTexto.Text = "";
            modoEdicion = false;
        }

        // Muestra un mensaje de error al usuario
        private void MostrarError(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine($"{titulo}: {mensaje}");
        }
    }
}