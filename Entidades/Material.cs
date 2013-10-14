using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class Material
    {
        #region -- Atributos --

        int? idMaterial;
        string denominacion, caracteristicas;
        Decimal stockMin, stockReal, stockAsign;
        UnidadMedida udMedida;

        #endregion

        #region -- Propiedades --

        public int? IdMaterial
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

        public Decimal StockMin
        {
            get { return stockMin; }
            set { stockMin = value; }
        }

        public Decimal StockReal
        {
            get { return stockReal; }
            set { stockReal = value; }
        }

        public Decimal StockAsign
        {
            get { return stockAsign; }
            set { stockAsign = value; }
        }

        public UnidadMedida UdMedida
        {
            get { return udMedida; }
            set { udMedida = value; }
        }

        public string StockRealString
        {
            get
            {
                return String.Format("{0:0.00}", stockReal) + " " + UdMedida.Abreviactura; 
            }
        }

        public string StockAsignString
        {
            get
            {
                return String.Format("{0:0.00}", StockAsign) + " " + UdMedida.Abreviactura;
            }
        }

        public string StockMinString
        {
            get
            {
                return String.Format("{0:0.00}", StockMin) + " " + UdMedida.Abreviactura;
            }
        }

        #endregion

        #region -- Constructores --

        public Material()
        { }

        public Material(int pidMaterial, string pdenom, string pcaract, decimal pstockM, decimal pstockR, decimal pstockA, UnidadMedida pudMed)
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