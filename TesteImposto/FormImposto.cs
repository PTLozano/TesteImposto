using Imposto.Core.Service;
using Imposto.Data;
using Imposto.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteImposto.Business;
using TesteImposto.Interface;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        private Pedido pedido = new Pedido();

        public FormImposto()
        {
            InitializeComponent();
            LimpaTela();
            ResizeColumns();
        }

        private void LimpaTela()
        {
            pedido = new Pedido();

            textBoxNomeCliente.Text = string.Empty;

            cmbEstadoOrigem.DataSource = GetComboEstados();
            cmbEstadoDestino.DataSource = GetComboEstados();

            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = GetTablePedidos();
        }

        private void ResizeColumns()
        {
            dataGridViewPedidos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewPedidos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewPedidos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewPedidos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private object GetTablePedidos()
        {
            DataTable table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(decimal)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));

            return table;
        }

        private List<string> GetComboEstados()
        {
            List<string> opcoesEstados = new List<string>() { " " };
            opcoesEstados.AddRange(ManipulaEstados.Lista);

            return opcoesEstados;
        }

        private async void ButtonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            try
            {
                buttonGerarNotaFiscal.Enabled = false;

                if (!ValidaForm()) return;

                await PreenchePedido();

                await GeraNota();

                LimpaTela();

                MessageBox.Show("Operação efetuada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Houve algum erro durante a operação e não foi possível gerar a nota.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonGerarNotaFiscal.Enabled = true;
            }
        }

        private Task GeraNota()
        {
            return Task.Factory.StartNew(() =>
            {
                NotaFiscalService service = new NotaFiscalService();
                service.GerarNotaFiscal(pedido);
            });
        }

        private Task PreenchePedido()
        {
            TaskScheduler taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            return Task.Factory.StartNew(() =>
            {
                pedido.EstadoOrigem = cmbEstadoOrigem.SelectedValue as string;
                pedido.EstadoDestino = cmbEstadoDestino.SelectedValue as string;
                pedido.NomeCliente = textBoxNomeCliente.Text.Trim();

                DataTable table = dataGridViewPedidos.DataSource as DataTable;
                foreach (DataRow row in table.Rows)
                {
                    string codigoProduto = row["Codigo do produto"].ToString();
                    string nomeProduto = row["Nome do produto"].ToString();

                    if (!double.TryParse(row["Valor"]?.ToString(), out double valorItemPedido) ||
                        string.IsNullOrWhiteSpace(codigoProduto) ||
                        string.IsNullOrWhiteSpace(nomeProduto))
                        break;
                    else
                    {
                        if (!bool.TryParse(row["Brinde"]?.ToString(), out bool brinde))
                            brinde = false;

                        pedido.ItensDoPedido.Add(
                            new PedidoItem()
                            {
                                Brinde = brinde,
                                CodigoProduto = codigoProduto,
                                NomeProduto = nomeProduto,
                                ValorItemPedido = valorItemPedido
                            });
                    }
                }
            }, CancellationToken.None, TaskCreationOptions.None, taskScheduler);
        }

        private bool ValidaForm()
        {
            IEnumerable<string> resultado = ValidaCamposForm();
            if (resultado != null && resultado.Count() > 0)
            {
                string[] mensagem = resultado.Select(_ => $"-> {_}").ToArray();
                MessageBox.Show("Foram encontrados os seguintes campos em branco:\n" + string.Join("\n", mensagem), "Campos em branco", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private IEnumerable<string> ValidaCamposForm()
        {
            IValidacao validacao = new ValidacaoFormulario(this);
            return validacao.Valida();
        }

        private void DataGridViewPedidos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridViewPedidos.Rows[e.RowIndex].ErrorText = "";

            if (dataGridViewPedidos.Rows[e.RowIndex].IsNewRow || e.ColumnIndex != 2) { return; }

            string valor = e.FormattedValue.ToString();

            if (string.IsNullOrWhiteSpace(valor)) return;

            if (!double.TryParse(valor, out double newInteger) || newInteger < 0)
            {
                e.Cancel = true;
                string mensagem = "A coluna Valor somente pode conter números, o caracter vírgula e não pode ser negativo.";
                MessageBox.Show(mensagem, "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewPedidos.Rows[e.RowIndex].ErrorText = mensagem;
            }
        }
    }
}
