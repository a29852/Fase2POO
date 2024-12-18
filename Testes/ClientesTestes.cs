using Dados;
using BO;
using Regras;
namespace Testes
{
    [TestClass]
    public class ClientesTestes
    {

        [TestMethod]
        public void TesteRegistarCliente()
        {
            Cliente cliente = new Cliente(1, "Jo�o", 123, 22, "M");

            bool resultado = Clientes.RegistarCliente(cliente);

            Assert.IsTrue(resultado, "Cliente deveria ser adicionado com sucesso");
        }

        [TestMethod]
        public void TestePequisarCliente()
        {
            Cliente cliente = new Cliente(1, "Maria", 123, 22, "F");
            Clientes.RegistarCliente(cliente);

            Cliente resultado = Clientes.PequisarCliente(1);

            Assert.IsNotNull(resultado, "Cliente deveria ser encontrado"); //IsNotNull, verifica se um objeto nao � null
        }

        [TestMethod]
        public void TestePequisarClienteNaoExiste()
        {
            Cliente resultado = Clientes.PequisarCliente(999); 

            Assert.IsNull(resultado, "O m�todo deveria retornar null quando o cliente n�o existe");
        }

       

        [TestMethod]
        public void TesteCompararCliente()
        {
            Cliente cliente = new Cliente(1, "Maria", 123, 22, "F");
            Clientes.RegistarCliente(cliente);

            bool existe = Clientes.CompararCliente(cliente);

            Assert.IsTrue(existe, "O cliente deveria existir na lista");   //IsTrue, verifica se o resultado � verdadeiro
        }


        [TestMethod]
        public void TesteRegistarClienteComDadosInvalidos()
        {
            // Arrange
            Cliente clienteInvalido = new Cliente(0, "", -1, -1, "X"); // dados inv�lidos

            // Act
            bool resultado = Clientes.RegistarCliente(clienteInvalido);

            // Assert
            Assert.IsFalse(resultado, "O cliente nao deveria ser adicionado com sucesso");
        }

    }
}