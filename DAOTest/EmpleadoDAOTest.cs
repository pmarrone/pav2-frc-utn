using PatriaFabricaMuebles.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PatriaFabricaMuebles.Entidades;
using System.Collections.Generic;
using System.Configuration;

namespace DAOTest
{
    
    
    /// <summary>
    ///This is a test class for EmpleadoDAOTest and is intended
    ///to contain all EmpleadoDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmpleadoDAOTest
    {

        Empleado empleado;
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
        //    ConfigurationManager.ConnectionStrings.Add(new ConnectionStringSettings("Muebles", @"Data Source=TERMINATORWIN7\SQLEXPRESS;Initial Catalog=Muebles;Integrated Security=True"));
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            empleado = new Empleado();
            empleado.Apellido = "Perez";
           
            empleado.FechaAlta = DateTime.Now;
            empleado.FechaNac = DateTime.Now;

            empleado.Legajo = 153;
            empleado.Nombre = "Carlitos";
            empleado.NroDoc = 10;
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }
        //
        #endregion


        /// <summary>
        ///A test for EmpleadoDAO Constructor
        ///</summary>
        [TestMethod()]
        public void EmpleadoDAOConstructorTest()
        {
            EmpleadoDAO target = new EmpleadoDAO();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            Assert.IsNotNull(EmpleadoDAO.GetById(empleado.Legajo));
            EmpleadoDAO.Delete(empleado);
            Assert.IsNull(EmpleadoDAO.GetById(empleado.Legajo));
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            List<Empleado> expected = null; // TODO: Initialize to an appropriate value
            List<Empleado> actual;
            actual = EmpleadoDAO.GetAll();
            Assert.Inconclusive("Verify the correctness of this test method.");                    
        }


        [TestMethod()]
        public void GetByIdTest()
        {
            Empleado empleadoDesdeBD = EmpleadoDAO.GetById(empleado.Legajo);
            Assert.AreEqual(empleado.Apellido, empleadoDesdeBD.Apellido);
            Assert.AreEqual(empleado.Nombre, empleadoDesdeBD.Nombre);
            Assert.AreEqual(empleado.NroDoc, empleadoDesdeBD.NroDoc);
            Assert.AreEqual(empleado.Legajo, empleadoDesdeBD.Legajo);

            empleadoDesdeBD = EmpleadoDAO.GetById(100000);
            Assert.IsNull(empleadoDesdeBD);
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {            
            int legajo = EmpleadoDAO.Insert(empleado);
            Assert.AreEqual<int>(empleado.Legajo, legajo);   
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            empleado = EmpleadoDAO.GetById(empleado.Legajo);
            DateTime fecha = DateTime.Now;

            Assert.AreNotEqual("Cacho", empleado.Nombre);
            Assert.AreNotEqual("Gomez", empleado.Apellido);
            Assert.AreNotEqual(fecha, empleado.FechaAlta);
            Assert.AreNotEqual("12345", empleado.NroDoc);

            Empleado empleado2 = new Empleado();
            empleado2.Legajo = empleado.Legajo;
            empleado2.Nombre = "Cacho";
            empleado2.Apellido = "Gomez";
            empleado2.NroDoc = 12345;
            empleado2.FechaAlta = fecha;

            EmpleadoDAO.Update(empleado2);

            empleado2 = EmpleadoDAO.GetById(empleado2.Legajo);

            Assert.AreEqual("Cacho", empleado2.Nombre);
            Assert.AreEqual("Gomez", empleado2.Apellido);
            Assert.AreEqual(fecha.Date, empleado2.FechaAlta.Date);
            Assert.AreEqual(12345, empleado2.NroDoc);
                        
        }
    }
}
