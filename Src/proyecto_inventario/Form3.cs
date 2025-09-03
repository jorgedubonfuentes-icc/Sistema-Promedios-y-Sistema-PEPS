using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_inventario
{
    public partial class frmpeps : Form
    {

        //Conexion a la base de datos en mysql
        string conexionStr = "server=localhost;user=root;password=admin123;database=db_proyecto_programacion;";

        public frmpeps()
        {
            InitializeComponent();
            ConfigurarColumnasDGV();
        }

        //Cargar funciones al iniciar el formulario
        private void frmpeps_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasDGV();
            CargarMovimientosPEPS();
            LlenarComboTipoMovimiento();
        }

        //Funcion para llenar el cmb 
        private void LlenarComboTipoMovimiento()
        {
            cmbTipoPEPS.Items.Clear();
            cmbTipoPEPS.Items.Add("Compra");
            cmbTipoPEPS.Items.Add("Venta");
            cmbTipoPEPS.SelectedIndex = -1;
        }

        //Funcion para limpiar el formulario
        private void LimpiarFormulario()
        {
            dtpFechaPEPS.Value = DateTime.Today;
            cmbTipoPEPS.SelectedIndex = -1;
            txtCantidadPEPS.Clear();
            txtValorUnitarioPEPS.Clear();
        }

        //Boton Salir
        private void btnsalirPEPS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Funcion para configuar el DGV
        private void ConfigurarColumnasDGV()
        {
            dgvmovimientoPEPS.Columns.Clear();

            //Asignar un id a las columnas pero que no sea visible
            dgvmovimientoPEPS.Columns.Add("Id", "ID");
            dgvmovimientoPEPS.Columns["Id"].Visible = false;

            dgvmovimientoPEPS.Columns.Add("Fecha", "Fecha");
            dgvmovimientoPEPS.Columns.Add("Concepto", "Concepto");

            dgvmovimientoPEPS.Columns.Add("EntradasCantidad", "Entradas - Cantidad");
            dgvmovimientoPEPS.Columns.Add("EntradasValorUnidad", "Entradas - Valor Unidad");
            dgvmovimientoPEPS.Columns.Add("EntradasValorTotal", "Entradas - Valor Total");

            dgvmovimientoPEPS.Columns.Add("SalidasCantidad", "Salidas - Cantidad");
            dgvmovimientoPEPS.Columns.Add("SalidasValorUnidad", "Salidas - Valor Unidad");
            dgvmovimientoPEPS.Columns.Add("SalidasValorTotal", "Salidas - Valor Total");

            dgvmovimientoPEPS.Columns.Add("SaldosCantidad", "Saldos - Cantidad");
            dgvmovimientoPEPS.Columns.Add("SaldosValorUnidad", "Saldos - Valor Unidad");
            dgvmovimientoPEPS.Columns.Add("SaldosValorTotal", "Saldos - Valor Total");

            dgvmovimientoPEPS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // Almacenar los datos de cada lote de inventario para el metodo PEPS (Fecha, Cantidad, Valor Unitario/Total)
        public class LoteInventario
        {
            public DateTime Fecha { get; set; }
            public int Cantidad { get; set; }
            public decimal ValorUnitario { get; set; }
            public decimal ValorTotal => Cantidad * ValorUnitario;
        }

        //Boton para Agregar registros a la Base de datos
        private void btnAgregarPEPS_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFechaPEPS.Value;
            string tipo = cmbTipoPEPS.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Selecciona tipo de movimiento");
                return;
            }

            if (!int.TryParse(txtCantidadPEPS.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida");
                return;
            }

            decimal valorUnitario = 0;
            if (tipo == "Compra")
            {
                if (!decimal.TryParse(txtValorUnitarioPEPS.Text.Trim(), out valorUnitario) || valorUnitario <= 0)
                {
                    MessageBox.Show("Valor unitario inválido");
                    return;
                }
            }

            using (MySqlConnection conexion = new MySqlConnection(conexionStr))
            {
                conexion.Open();

                // Insertar el movimiento
                string insertQuery = "INSERT INTO movimientos_peps (fecha, tipo, cantidad, valor_unitario) VALUES (@fecha, @tipo, @cantidad, @valorUnitario)";
                using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conexion))
                {
                    cmdInsert.Parameters.AddWithValue("@fecha", fecha);
                    cmdInsert.Parameters.AddWithValue("@tipo", tipo);
                    cmdInsert.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdInsert.Parameters.AddWithValue("@valorUnitario", valorUnitario);
                    cmdInsert.ExecuteNonQuery();
                }
            }

            // Actualizar la tabla
            CargarMovimientosPEPS();
            LimpiarFormulario();
        }

        //Funcion para cargar los movimientos en el DGV
        private void CargarMovimientosPEPS()
        {
            dgvmovimientoPEPS.Rows.Clear();

            // Lista principal para manejar el inventario 
            List<LoteInventario> inventario = new List<LoteInventario>();

            using (MySqlConnection conexion = new MySqlConnection(conexionStr))
            {
                conexion.Open();
                string query = "SELECT * FROM movimientos_peps ORDER BY fecha ASC, id ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        DateTime fecha = reader.GetDateTime("fecha");
                        string tipo = reader.GetString("tipo");
                        int cantidad = reader.GetInt32("cantidad");
                        decimal valorU = reader.GetDecimal("valor_unitario");

                        // Variables para el DataGridView
                        int entradasCantidad = 0;
                        decimal entradasValorU = 0;
                        decimal entradasValorTotal = 0;

                        int salidasCantidad = 0;
                        decimal salidasValorU = 0;
                        decimal salidasValorTotal = 0;

                        if (tipo == "Compra")
                        {
                            // Agregar al inventario
                            var nuevoLote = new LoteInventario
                            {
                                Fecha = fecha,
                                Cantidad = cantidad,
                                ValorUnitario = valorU
                            };
                            inventario.Add(nuevoLote);

                            entradasCantidad = cantidad;
                            entradasValorU = valorU;
                            entradasValorTotal = cantidad * valorU;
                        }
                        else if (tipo == "Venta")
                        {
                            salidasCantidad = cantidad;
                            int cantidadRestante = cantidad;
                            decimal costoVenta = 0;

                            var lotesOrdenados = inventario.OrderBy(l => l.Fecha).ToList();
                            foreach (var lote in lotesOrdenados)
                            {
                                if (cantidadRestante <= 0) break;

                                int cantidadUsar = Math.Min(cantidadRestante, lote.Cantidad);
                                costoVenta += cantidadUsar * lote.ValorUnitario;

                                lote.Cantidad -= cantidadUsar;
                                cantidadRestante -= cantidadUsar;
                            }

                            // Eliminar lotes vacíos después del recorrido
                            inventario = inventario.Where(l => l.Cantidad > 0).ToList();

                            if (cantidadRestante > 0)
                            {
                                MessageBox.Show($"No hay suficiente inventario para la venta del {fecha.ToShortDateString()}. Faltan {cantidadRestante} unidades.");
                            }

                            salidasValorTotal = costoVenta;
                            salidasValorU = cantidad > 0 ? costoVenta / cantidad : 0;
                        }

                        // Calcular saldos (sumando solo los lotes que quedan)
                        int saldosCantidad = inventario.Sum(l => l.Cantidad);
                        decimal saldosValorTotal = inventario.Sum(l => l.ValorTotal);
                        decimal saldosValorU = saldosCantidad > 0 ? saldosValorTotal / saldosCantidad : 0;

                        // Agregar fila al DataGridView
                        dgvmovimientoPEPS.Rows.Add(
                            id,
                            fecha.ToShortDateString(),
                            tipo,
                            entradasCantidad,
                            entradasValorU.ToString("C"),
                            entradasValorTotal.ToString("C"),
                            salidasCantidad,
                            salidasValorU.ToString("C"),
                            salidasValorTotal.ToString("C"),
                            saldosCantidad,
                            saldosValorU.ToString("C"),
                            saldosValorTotal.ToString("C")
                        );
                    }
                }
            }

        }

        //Boton de Elimnar registro
        private void btnEliminarPEPS_Click(object sender, EventArgs e)
        {
            if (dgvmovimientoPEPS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un registro para eliminar.");
                return;
            }

            //ID en la primera columna oculto
            int movimientoId;
            if (!int.TryParse(dgvmovimientoPEPS.SelectedRows[0].Cells[0].Value?.ToString(), out movimientoId))
            {
                MessageBox.Show("No se pudo obtener el ID del movimiento.");
                return;
            }

            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este movimiento?", "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionStr))
                {
                    conexion.Open();

                    string query = "DELETE FROM movimientos_peps WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", movimientoId);
                        cmd.ExecuteNonQuery();
                    }
                }

                CargarMovimientosPEPS();
                MessageBox.Show("Movimiento eliminado correctamente.");
            }

        }
    }
}
