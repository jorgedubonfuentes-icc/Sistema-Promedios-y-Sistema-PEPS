using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proyecto_inventario
{
    public partial class frmcosto : Form
    {

        //Variables que usaremos en el programa
        int saldoCantidad = 0; 
        decimal saldoTotal = 0;
        decimal costoPromedio = 0;

        //Conexion a la base de datos
        string conexionStr = "server=localhost;user=root;password=admin123;database=db_proyecto_programacion;";

        public frmcosto()
        {
            InitializeComponent();
            //Llamar al menu
            frminicio frm = new frminicio();
            frm.Show();
        }

        //Boton de Salir
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Configurar el dgv al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {

            dgvMovimientos.Columns.Clear();

            dgvMovimientos.Columns.Add("Id", "ID");
            dgvMovimientos.Columns["Id"].Visible = false;

            dgvMovimientos.Columns.Add("Fecha", "Fecha");
            dgvMovimientos.Columns.Add("Tipo", "Tipo");

            dgvMovimientos.Columns.Add("EntradaCantidad", "Entrada");
            dgvMovimientos.Columns.Add("EntradaValUnitario", "Val. Unit.");
            dgvMovimientos.Columns.Add("EntradaValTotal", "Val. Total");

            dgvMovimientos.Columns.Add("SalidaCantidad", "Salida");
            dgvMovimientos.Columns.Add("SalidaValUnitario", "Val. Unit.");
            dgvMovimientos.Columns.Add("SalidaValTotal", "Val. Total");

            dgvMovimientos.Columns.Add("SaldoCantidad", "Saldo");
            dgvMovimientos.Columns.Add("CostoPromedio", "Costo Prom.");
            dgvMovimientos.Columns.Add("SaldoTotal", "Saldo Total");


            cmbTipo.Items.Add("Compra");
            cmbTipo.Items.Add("Venta");


            CargarMovimientosDesdeBD();
        }

        //Funcion para cargar los datos desde la DB
        private void CargarMovimientosDesdeBD()
        {
            dgvMovimientos.Rows.Clear();
            dgvMovimientos.Columns.Clear();

            // Definir columnas manualmente en orden correcto
            dgvMovimientos.Columns.Add("Id", "ID");
            dgvMovimientos.Columns["Id"].Visible = false;

            dgvMovimientos.Columns.Add("Fecha", "Fecha");
            dgvMovimientos.Columns.Add("Tipo", "Tipo");

            dgvMovimientos.Columns.Add("EntradaCantidad", "Entrada");
            dgvMovimientos.Columns.Add("EntradaValUnitario", "Val. Unit.");
            dgvMovimientos.Columns.Add("EntradaValTotal", "Val. Total");

            dgvMovimientos.Columns.Add("SalidaCantidad", "Salida");
            dgvMovimientos.Columns.Add("SalidaValUnitario", "Val. Unit.");
            dgvMovimientos.Columns.Add("SalidaValTotal", "Val. Total");

            dgvMovimientos.Columns.Add("SaldoCantidad", "Saldo");
            dgvMovimientos.Columns.Add("CostoPromedio", "Costo Prom.");
            dgvMovimientos.Columns.Add("SaldoTotal", "Saldo Total");

            decimal saldoCantidad = 0;
            decimal saldoTotal = 0;
            decimal costoPromedio = 0;
            decimal costoTotalVentas = 0;

            using (MySqlConnection conexion = new MySqlConnection(conexionStr))
            {
                conexion.Open();
                string query = "SELECT * FROM movimientos ORDER BY Fecha ASC";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime fecha = reader.GetDateTime("Fecha");
                    string tipo = reader.GetString("Tipo");
                    int cantidad = reader.GetInt32("Cantidad");
                    decimal valorUnitario = reader.GetDecimal("ValorUnitario");
                    decimal valorTotal = cantidad * (tipo == "Compra" ? valorUnitario : costoPromedio);

                    int entrada = 0, salida = 0;
                    decimal entradaValU = 0, entradaValT = 0;
                    decimal salidaValU = 0, salidaValT = 0;

                    if (tipo == "Compra")
                    {
                        entrada = cantidad;
                        entradaValU = valorUnitario;
                        entradaValT = valorTotal;

                        saldoCantidad += cantidad;
                        saldoTotal += valorTotal;
                    }
                    else
                    {
                        salida = cantidad;
                        salidaValU = costoPromedio;
                        salidaValT = cantidad * costoPromedio;

                        saldoCantidad -= cantidad;
                        saldoTotal -= salidaValT;

                        costoTotalVentas += salidaValT;
                    }

                    costoPromedio = saldoCantidad > 0 ? saldoTotal / (decimal)saldoCantidad : 0;

                    dgvMovimientos.Rows.Add(
                        reader.GetInt32("id"),
                        fecha.ToShortDateString(),
                        tipo,
                        entrada, entradaValU.ToString("C"), entradaValT.ToString("C"),
                        salida, salidaValU.ToString("C"), salidaValT.ToString("C"),
                        saldoCantidad,
                        costoPromedio.ToString("C"),
                        saldoTotal.ToString("C")
                    );
                }
                reader.Close();
            }

            lblCostoVentas.Text = $"El costo de Ventas con el método de promedio ponderado es {costoTotalVentas:C}";
        }

        //Funcion para el boton Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;
            string tipo = cmbTipo.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Selecciona tipo de movimiento");
                return;
            }

            txtCantidad.Text = txtCantidad.Text.Trim();
            txtValorUnitario.Text = txtValorUnitario.Text.Trim();

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida");
                return;
            }

            decimal valorUInput = 0;

            if (tipo == "Compra" && !decimal.TryParse(txtValorUnitario.Text, out valorUInput))
            {
                MessageBox.Show("Valor unitario inválido");
                return;
            }

            decimal valorUnitario = 0;

            // Si es venta, consultar inventario actual desde la BD
            if (tipo == "Venta")
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionStr))
                {
                    conexion.Open();
                    string consulta = "SELECT " +
                        "(SELECT IFNULL(SUM(Cantidad), 0) FROM movimientos WHERE Tipo = 'Compra') - " +
                        "(SELECT IFNULL(SUM(Cantidad), 0) FROM movimientos WHERE Tipo = 'Venta') AS InventarioActual;";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                    {
                        object resultado = cmd.ExecuteScalar();
                        int inventarioActual = Convert.ToInt32(resultado);

                        if (cantidad > inventarioActual)
                        {
                            MessageBox.Show("No hay suficiente inventario para esta venta.");
                            return;
                        }
                    }
                }
            }

            // Obtener costo promedio actual para ventas 
            if (tipo == "Venta")
            {
                // Lo dejamos en 0, se actualiza luego en Cargarmovimientos
                valorUnitario = 0;
            }
            else
            {
                valorUnitario = valorUInput;
            }

            // Insertar en base de datos
            using (MySqlConnection conexion = new MySqlConnection(conexionStr))
            {
                conexion.Open();
                string query = "INSERT INTO movimientos (Fecha, Tipo, Cantidad, ValorUnitario) VALUES (@fecha, @tipo, @cantidad, @valor)";
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@valor", valorUnitario);
                    cmd.ExecuteNonQuery();
                }
            }

            // Limpiar campos
            txtCantidad.Clear();
            txtValorUnitario.Clear();
            cmbTipo.SelectedIndex = -1;

            // Recargar DataGridView 
            CargarMovimientosDesdeBD();
        }

        //Boton de Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMovimientos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila para eliminar.");
                return;
            }

            DataGridViewRow fila = dgvMovimientos.SelectedRows[0];
            int id = Convert.ToInt32(fila.Cells["ID"].Value);

            DialogResult result = MessageBox.Show("¿Seguro que quieres eliminar este movimiento?", "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionStr))
                {
                    conexion.Open();
                    string query = "DELETE FROM movimientos WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Limpiar y recargar todo
                dgvMovimientos.Rows.Clear();
                CargarMovimientosDesdeBD();
                MessageBox.Show("Registro eliminado correctamente.");
            }
        }
    }
}
