using PatriaFabricaMuebles.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PatriaFabricaMuebles.Entidades;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAOTest
{
    
    
    /// <summary>
    ///This is a test class for MaterialDAOTest and is intended
    ///to contain all MaterialDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MaterialDAOTest
    {

        private Material material = new Material();
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            

        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }
        //
        #endregion


        [TestMethod()]
        public void MaterialDAOProbarTodo()
        {
            material.Denominacion = "Material de Prueba";
            material.Caracteristicas = "Esto es una prueba";
            material.StockAsign = 10;
            material.StockMin = 5;
            material.StockReal = 100;
            UnidadMedida unidad = new UnidadMedida();
            unidad.UdMedida = 1;
            material.UdMedida = unidad;

            int? id = MaterialDAO.Insert(material);
            Assert.IsNotNull(id);
            Material materialDB = MaterialDAO.GetById(id.Value);
            Assert.IsNotNull(materialDB);
            
            Assert.AreEqual(id.Value, materialDB.IdMaterial);
            Assert.AreEqual("Metros", materialDB.UdMedida.Nombre);            
            materialDB.UdMedida.UdMedida = 2;

            materialDB.StockAsign = 99;
            materialDB.StockMin = 10;
            materialDB.StockReal = 2000;
            materialDB.Denominacion = "Fruta";
            materialDB.Caracteristicas = "Material Modificado";

            MaterialDAO.Update(materialDB);
            materialDB = MaterialDAO.GetById(materialDB);
            Assert.AreEqual("Kilos", materialDB.UdMedida.Nombre);
            Assert.AreEqual("Material Modificado", materialDB.Caracteristicas);
            Assert.AreEqual(99, materialDB.StockAsign);
            Assert.AreEqual(10, materialDB.StockMin);
            Assert.AreEqual(2000, materialDB.StockReal);

            List<Material> materiales = MaterialDAO.GetAll();
            foreach (Material materialLista in materiales)
            {
                Assert.IsNotNull(MaterialDAO.GetById(materialLista));
            }


            MaterialDAO.Delete(materialDB);         

            Assert.IsNull(MaterialDAO.GetById(id.Value));
            

        }

        /// <summary>
        ///A test for MaterialDAO Constructor
        ///</summary>
        [TestMethod()]
        public void MaterialDAOConstructorTest()
        {
            MaterialDAO target = new MaterialDAO();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            Material item = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = MaterialDAO.Delete(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExtractData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DAO.dll")]
        public void ExtractDataTest()
        {
            SqlDataReader reader = null; // TODO: Initialize to an appropriate value
            Material expected = null; // TODO: Initialize to an appropriate value
            Material actual;
            actual = MaterialDAO_Accessor.ExtractData(reader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            List<Material> expected = null; // TODO: Initialize to an appropriate value
            List<Material> actual;
            actual = MaterialDAO.GetAll();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetById
        ///</summary>
        [TestMethod()]
        public void GetByIdTest()
        {
            Material item = null; // TODO: Initialize to an appropriate value
            Material expected = null; // TODO: Initialize to an appropriate value
            Material actual;
            actual = MaterialDAO.GetById(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            Material item = null; // TODO: Initialize to an appropriate value
            Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> actual;
            actual = MaterialDAO.Insert(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadParameters
        ///</summary>
        [TestMethod()]
        [DeploymentItem("DAO.dll")]
        public void LoadParametersTest()
        {
            Material item = null; // TODO: Initialize to an appropriate value
            List<SqlParameter> expected = null; // TODO: Initialize to an appropriate value
            List<SqlParameter> actual;
            actual = MaterialDAO_Accessor.LoadParameters(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Material item = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = MaterialDAO.Update(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
