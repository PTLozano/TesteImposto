using System.Collections.Generic;
using System.Data;
using TesteImposto.Interface;

namespace TesteImposto.Business
{
    class ValidacaoFormulario : IValidacao
    {
        private FormImposto _form;

        public IValidacao ProximaValidacao { get; set; }

        public ValidacaoFormulario(FormImposto form)
        {
            _form = form;
        }

        public IEnumerable<string> Valida(List<string> errosLista = null)
        {
            ValidacaoNomeCliente nomeCliente = new ValidacaoNomeCliente(_form);
            ValidacaoEstadoOrigem estadoOrigem = new ValidacaoEstadoOrigem(_form);
            ValidacaoEstadoDestino estadoDestino = new ValidacaoEstadoDestino(_form);
            ValidacaoDataGrid dataGrid = new ValidacaoDataGrid(_form);
            ValidacaoDataGridItem gridItem = new ValidacaoDataGridItem(_form);

            nomeCliente.ProximaValidacao = estadoOrigem;
            estadoOrigem.ProximaValidacao = estadoDestino;
            estadoDestino.ProximaValidacao = dataGrid;
            dataGrid.ProximaValidacao = gridItem;

            return nomeCliente.Valida();
        }
    }

    class ValidacaoNomeCliente : IValidacao
    {
        private FormImposto _form;

        public IValidacao ProximaValidacao { get; set; }

        public ValidacaoNomeCliente(FormImposto form)
        {
            _form = form;
        }

        public IEnumerable<string> Valida(List<string> errosLista = null)
        {
            errosLista = errosLista ?? new List<string>();

            if (string.IsNullOrWhiteSpace(_form.textBoxNomeCliente.Text))
                errosLista.Add("Nome do Cliente");

            if (ProximaValidacao != null)
                ProximaValidacao.Valida(errosLista);

            return errosLista;
        }
    }

    class ValidacaoEstadoOrigem : IValidacao
    {
        private FormImposto _form;

        public IValidacao ProximaValidacao { get; set; }

        public ValidacaoEstadoOrigem(FormImposto form)
        {
            _form = form;
        }

        public IEnumerable<string> Valida(List<string> errosLista = null)
        {
            errosLista = errosLista ?? new List<string>();

            if (string.IsNullOrWhiteSpace(_form.cmbEstadoOrigem.SelectedValue as string))
                errosLista.Add("Estado de Origem");

            if (ProximaValidacao != null)
                ProximaValidacao.Valida(errosLista);

            return errosLista;
        }
    }

    class ValidacaoEstadoDestino : IValidacao
    {
        private FormImposto _form;

        public IValidacao ProximaValidacao { get; set; }

        public ValidacaoEstadoDestino(FormImposto form)
        {
            _form = form;
        }

        public IEnumerable<string> Valida(List<string> errosLista = null)
        {
            if (errosLista == null)
                errosLista = new List<string>();

            if (string.IsNullOrWhiteSpace(_form.cmbEstadoDestino.SelectedValue as string))
                errosLista.Add("Estado de Destino");

            if (ProximaValidacao != null)
                ProximaValidacao.Valida(errosLista);

            return errosLista;
        }
    }

    class ValidacaoDataGrid : IValidacao
    {
        private FormImposto _form;

        public IValidacao ProximaValidacao { get; set; }

        public ValidacaoDataGrid(FormImposto form)
        {
            _form = form;
        }

        public IEnumerable<string> Valida(List<string> errosLista = null)
        {
            errosLista = errosLista ?? new List<string>();

            if (_form.dataGridViewPedidos.Rows.Count <= 1)
                errosLista.Add("É necessário fornecer ao menos um pedido");

            if (ProximaValidacao != null)
                ProximaValidacao.Valida(errosLista);

            return errosLista;
        }
    }

    class ValidacaoDataGridItem : IValidacao
    {
        private FormImposto _form;

        public IValidacao ProximaValidacao { get; set; }

        public ValidacaoDataGridItem(FormImposto form)
        {
            _form = form;
        }

        public IEnumerable<string> Valida(List<string> errosLista = null)
        {
            errosLista = errosLista ?? new List<string>();

            List<string> errosLinha = new List<string>();


            DataTable table = (DataTable)_form.dataGridViewPedidos.DataSource;


            foreach (DataRow row in table.Rows)
            {
                if (string.IsNullOrWhiteSpace(row["Nome do produto"]?.ToString()))
                    errosLinha.Add("- É necessário fornecer o Nome do produto");

                if (string.IsNullOrWhiteSpace(row["Codigo do produto"]?.ToString()))
                    errosLinha.Add("- É necessário fornecer o Código do produto");

                if (string.IsNullOrWhiteSpace(row["Valor"]?.ToString()))
                    errosLinha.Add("- É necessário fornecer o Valor");

                if (errosLinha.Count > 0)
                    break;
            }

            if (errosLinha.Count > 0)
            {
                errosLista.Add("Itens do pedido");
                errosLista.AddRange(errosLinha);
            }

            if (ProximaValidacao != null)
                ProximaValidacao.Valida(errosLista);

            return errosLista;
        }
    }
}
