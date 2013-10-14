using PatriaFabricaMuebles.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PatriaFabricaMuebles.Entidades;
using System.Collections.Generic;

namespace DAOTest
{
    
    
    /// <summary>
    ///This is a test class for ClienteDAOTest and is intended
    ///to contain all ClienteDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClienteDAOTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ClienteDAO Constructor
        ///</summary>
        [TestMethod()]
        public void ClienteDAOConstructorTest()
        {
            ClienteDAO target = new ClienteDAO();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            Cliente pCliente = new Cliente(); // TODO: Initialize to an appropriate value
            pCliente.IdCliente = 70;
            pCliente.Apellidos = "Moreno";
            pCliente.Nombres = "Hernan";
            pCliente.Telefono = 4680660;

            int actual;
            actual = ClienteDAO.Insert(pCliente);
            Assert.AreEqual(70, actual);

        }

        /// <summary>
        ///A test for Update. Se actualiza el nombre y es lo unico q se va a verificar
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            String strNombreAnterior;
            Cliente pCliente = new Cliente(); // TODO: Initialize to an appropriate value
            pCliente.IdCliente = 71;
            pCliente.Apellidos = "Moreno";
            pCliente.Nombres = "Santiago";
            pCliente.Telefono = 4680660;

            ClienteDAO.Insert(pCliente);

            strNombreAnterior = pCliente.Nombres;
            pCliente.Nombres = "Damian";
            ClienteDAO.Update(pCliente);
            Assert.AreNotEqual(strNombreAnterior, pCliente.Nombres);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            Cliente pCliente = new Cliente(); // TODO: Initialize to an appropriate value
            pCliente.IdCliente = 71;
            ClienteDAO.Delete(pCliente);           
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            List<Cliente> expected = null; // TODO: Initialize to an appropriate value
            List<Cliente> actual;
            actual = ClienteDAO.GetAll();
            Assert.AreNotEqual(actual, expected);           
        }

        /// <summary>
        ///A test for GetById
        ///</summary>
        [TestMethod()]
        public void GetByIdTest()
        {     
            Cliente actual;

            Cliente pCliente = new Cliente(); // TODO: Initialize to an appropriate value
            pCliente.IdCliente = 72;
            pCliente.Apellidos = "Moreno";
            pCliente.Nombres = "Luis";
            pCliente.Telefono = 4680660;

            ClienteDAO.Insert(pCliente);

            actual = ClienteDAO.GetById(pCliente.IdCliente);
           
            Assert.AreEqual(pCliente.Apellidos, actual.Apellidos);
            Assert.AreEqual(pCliente.Nombres, actual.Nombres);
            Assert.AreEqual(pCliente.IdCliente, actual.IdCliente);
            Assert.AreEqual(pCliente.Telefono, actual.Telefono);
        }

      
    }
}
