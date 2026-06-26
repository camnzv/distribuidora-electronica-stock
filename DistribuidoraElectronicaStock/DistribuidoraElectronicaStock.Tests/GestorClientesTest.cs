using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistribuidoraElectronicaStock.BBL;
using DistribuidoraElectronicaStock.Entidades;

namespace DistribuidoraElectronicaStock.Tests
{
    [TestClass]
    public class GestorClientesTest
    {
        [TestMethod]
        public void AgregarCliente_CuitVacio_RetornaMenosUno()
        {
            // Creo el gestor que quiero probar
            GestorClientes gestor = new GestorClientes();

            // Creo un cliente con el CUIT vacío
            Cliente cliente = new Cliente();
            cliente.Cuit = "";
            cliente.RazonSocial = "Empresa";

            // Llamo al método
            int resultado = gestor.AgregarCliente(cliente);

            // Compruebo que devuelva -1
            Assert.AreEqual(-1, resultado);
        }
    }
}