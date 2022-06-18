using ControleMedicamento.Infra.BancoDados.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Infra.BancoDados;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleMedicamento.Infra.BancoDados.Tests.ModuloMedicamento
{
    [TestClass]
    public class RepositorioMedicamentoEmBancoDadosTest
    {
        private Medicamento medicamento;
        private RepositorioMedicamentoEmBancoDados repositorio;

        public RepositorioMedicamentoEmBancoDadosTest()
        {
            string sql =
                @"DELETE FROM TBMEDICAMENTO;
                  DBCC CHECKIDENT (TBMEDICAMENTO, RESEED, 0)
                  DELETE FROM TBMEDICAMENTO;
                  DBCC CHECKIDENT (TBMEDICAMENTO, RESEED, 0)";

            Db.ExecutarSql(sql);
        }

        [TestMethod]
        public void Deve_inserir_medicamento()
        {
            repositorio.Inserir(medicamento);

            var medicamentoEncontrado = repositorio.SelecionarPorId(medicamento.Id);

            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(medicamento, medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_medicamento()
        {
            repositorio.Inserir(medicamento);

            medicamento.Nome = "Dorflex";
            medicamento.Descricao = "Para dor";
            medicamento.Lote = "4321";

            repositorio.Editar(medicamento);

            var medicamentoEncontrado = repositorio.SelecionarPorId(medicamento.Id);

            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(medicamento, medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_medicamento()
        {
            repositorio.Inserir(medicamento);

            repositorio.Excluir(medicamento);

            var medicamentoEncontrado = repositorio.SelecionarPorId(medicamento.Id);
            Assert.IsNull(medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_medicamento()
        {
            repositorio.Inserir(medicamento);

            var medicamentoEncontrado = repositorio.SelecionarPorId(medicamento.Id);

            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(medicamento, medicamentoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_medicamentos()
        {
            var medicamento1 = new Medicamento("Migraliv", "Dor de cabeça", "321", new System.DateTime (2022, 12, 30));
            var medicamento2 = new Medicamento("Flanax", "Anti-inflamatorio", "792", new System.DateTime (2023, 02, 21));
            var medicamento3 = new Medicamento("Parecetamol", "Febre", "349", new System.DateTime (2023, 09, 07));

            var repositorio = new RepositorioMedicamentoEmBancoDados();
            repositorio.Inserir(medicamento1);
            repositorio.Inserir(medicamento2);
            repositorio.Inserir(medicamento3);

            var medicamentos = repositorio.SelecionarTodos();

            Assert.AreEqual(3, medicamentos.Count);

            Assert.AreEqual(medicamento1.Nome, medicamentos[0].Nome);
            Assert.AreEqual(medicamento2.Nome, medicamentos[1].Nome);
            Assert.AreEqual(medicamento3.Nome, medicamentos[2].Nome);

        }
    }
}
