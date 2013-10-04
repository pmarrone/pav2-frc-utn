using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMueblesOBJ
{
    public class Material
    {
        #region -- Atributos --

        int idMaterial;
        string denominacion, caracteristicas;
        float stockMin, stockReal, stockAsign;
        UnidadMedida udMedida;

        #endregion

        #region -- Propiedades --

        public int IdMaterial
        {
            get { return idMaterial; }
            set { idMaterial = value; }
        }

        public string Denominacion
        {
            get { return denominacion; }
            set { denominacion = value; }
        }

        public string Caracteristicas
        {
            get { return caracteristicas; }
            set { caracteristicas = value; }
        }

        public float StockMin
        {
            get { return stockMin; }
            set { stockMin = value; }
        }

        public float StockReal
        {
            get { return stockReal; }
            set { stockReal = value; }
        }

        public float StockAsign
        {
            get { return stockAsign; }
            set { stockAsign = value; }
        }

        public UnidadMedida UdMedida
        {
            get { return udMedida; }
            set { udMedida = value; }
        }

        #endregion

        #region -- Constructores --

        public Material()
        { }

        public Material(int pidMaterial, string pdenom, string pcaract, float pstockM, float pstockR, float pstockA, UnidadMedida pudMed)
        {
            idMaterial = pidMaterial;
            denominacion = pdenom;
            caracteristicas = pcaract;
            stockMin = pstockM;
            stockReal = pstockR;
            stockAsign = pstockA;
            udMedida = pudMed;            
        }
        
        #endregion

    }
}