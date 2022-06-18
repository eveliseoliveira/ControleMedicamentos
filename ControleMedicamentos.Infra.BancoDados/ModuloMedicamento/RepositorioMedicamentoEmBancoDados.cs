using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados.Compartilhado;
using ControleMedicamentos.Infra.BancoDados.ModuloMedicamento;

namespace ControleMedicamento.Infra.BancoDados.ModuloMedicamento
{
    public class RepositorioMedicamentoEmBancoDados :
        RepositorioBase<Medicamento, ValidadorMedicamento, MapeadorMedicamento>
    {
        protected override string sqlInserir =>
            @"INSERT INTO TBMEDICAMENTO
                (
                    [NOME],
                    [DESCRIVAO],
                    [LOTE],
                    [VALIDADE],
                    [QUANTIDADEDISPONIVEL],
                    [FORNECEDOR_ID]
                )
             VALUES
                (
                 @NOME,
                 @DESCRICAO,
                 @LOTE,
                 @VALIDACAO,
                 @QUANTIDADEDISPONIVEL,
                 @FORNECEDOR
                 ); SELECT SCOPE_IDENTITY();";


        protected override string sqlEditar =>
            @"UPDATE [TBMEDICAMENTO]
                SET
                    [NOME] = @NOME,
                    [DESCRICAO] = @DESCRICAO,
                    [LOTE] = @LOTE,
                    [VALIDADE] = @VALIDADE,
                    [QUANTIDADEDISPONIVEL] = @QUANTIDADEDISPONIVEL,
                    [FORNECEDOR_ID] = @FORNECEDOR_ID
                WHERE  [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBMEDICAMENTO]
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT
                    [NOME],
                    [DESCRIVAO],
                    [LOTE],
                    [VALIDADE],
                    [QUANTIDADEDISPONIVEL],
                    [FORNECEDOR_ID]
                FROM
                    [TBMEDICAMENTO]";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                    [NOME],
                    [DESCRIVAO],
                    [LOTE],
                    [VALIDADE],
                    [QUANTIDADEDISPONIVEL],
                    [FORNECEDOR_ID]
                FROM
                    [TBMEDICAMENTO]
                WHERE 
                    [ID] = @ID";
    }
}
