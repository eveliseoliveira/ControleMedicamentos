using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace ControleMedicamentos.Infra.BancoDados.ModuloMedicamento
{
    public class MapeadorMedicamento : MapeadorBase<Medicamento>
    {
        public override void ConfigurarParametros(Medicamento medicamento, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", medicamento.Id);
            comando.Parameters.AddWithValue("NOME", medicamento.Nome);
            comando.Parameters.AddWithValue("DESCRICRICAO", medicamento.Descricao);
            comando.Parameters.AddWithValue("LOTE", medicamento.Lote);
            comando.Parameters.AddWithValue("VALIDADE", medicamento.Validade);
            comando.Parameters.AddWithValue("QUANTIDADEDISPONIVEL", medicamento.QuantidadeDisponivel);
            comando.Parameters.AddWithValue("FORNECEDOR", medicamento.Fornecedor);

        }

        public override Medicamento ConverterRegistro(SqlDataReader leitorMedicamento)
        {
            var id = Convert.ToInt32(leitorMedicamento["ID"]);
            var nome = Convert.ToString(leitorMedicamento["NOME"]);
            var descricao = Convert.ToString(leitorMedicamento["DESCRICRICAO"]);
            var lote = Convert.ToString(leitorMedicamento["LOTE"]);
            var Validade = Convert.ToDateTime(leitorMedicamento["VALIDADE"]);
            var quantidadeDisponivel = Convert.ToInt32(leitorMedicamento["QUANTIDADEDISPONIVEL"]);
            var fornecedor = leitorMedicamento["FORNECEDOR"];

            Medicamento medicamento = new Medicamento();
            medicamento.Id = id;
            medicamento.Nome = nome;
            medicamento.Descricao = descricao;
            medicamento.Lote = lote;
            medicamento.Validade = Validade;
            medicamento.QuantidadeDisponivel = quantidadeDisponivel;
            medicamento.Fornecedor = (Fornecedor)fornecedor;

            return medicamento;
        }
    }
}
