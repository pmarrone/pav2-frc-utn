using PatriaFabricaMuebles.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PatriaFabricaMuebles.Entidades;
using System.Collections.Generic;

namespace DAOTest
{
    
    
    /// <summary>
    ///This is a test class for RolDAOTest and is intended
    ///to contain all RolDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RolDAOTest
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
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            Rol pRol = new Rol(); // TODO: Initialize to an appropriate value
            pRol.IdRol = 74;
            pRol.Descrip = "Analista";

            RolDAO.Insert(pRol);

            RolDAO.Delete(pRol);
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            List<Rol> expected = null; // TODO: Initialize to an appropriate value
            List<Rol> actual;
            actual = RolDAO.GetAll();
            Assert.AreNotEqual(actual, expected);   
        }

        /// <summary>
        ///A test for GetById
        ///</summary>
        [TestMethod()]
        public void GetByIdTest()
        {
            Rol actual;

            Rol pRol = new Rol(); // TODO: Initialize to an appropriate value
            pRol.IdRol = 73;
            pRol.Descrip = "Admin";

            RolDAO.Insert(pRol);

            actual = RolDAO.GetById(pRol.IdRol);

            Assert.AreEqual(pRol.IdRol, actual.IdRol);
            Assert.AreEqual(pRol.Descrip, actual.Descrip);
            
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            Rol pRol = new Rol(); // TODO: Initialize to an appropriate value
            pRol.IdRol = 70;
            pRol.Descrip = "Admin";
            

            int actual;
            actual = RolDAO.Insert(pRol);
            Assert.AreEqual(70, actual);           
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            String strNombreAnterior;
            Rol pRol = new Rol(); // TODO: Initialize to an appropriate value
            pRol.IdRol = 71;
            pRol.Descrip = "Admin";

            RolDAO.Insert(pRol);

            strNombreAnterior = pRol.Descrip;
            pRol.Descrip = "Operador";
            RolDAO.Update(pRol);
            Assert.AreNotEqual(strNombreAnterior, pRol.Descrip);
        }
    }
}
