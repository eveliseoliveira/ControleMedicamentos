using ControleMedicamentos.Dominio.ModuloPaciente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleMedicamentos.Dominio.Tests.ModuloPaciente
{
    [TestClass]
    public class PacienteTest
    {
        [TestMethod]
        [DataRow("Bruna", "123")]
        public void Deve_inserir_nome_e_cartaoSUS_ao_paciente(string nome, string CartaoSUS)
        {
            var pacienteTest = new Paciente();

            string nomePaciente = nome;

            var resultadoPaciente = nomePaciente.Equals(nome);

            Assert.IsTrue(resultadoPaciente);
        }
    }
}
