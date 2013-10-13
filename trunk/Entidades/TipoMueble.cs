using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMuebles.Entidades
{
    public class TipoMueble
    {
        #region -- Atributos --

        int idTipoMueble;
        string descrip;
        
        #endregion

        #region -- Propiedades --
        
        public int IdTipoMueble
        {
            get { return idTipoMueble; }
            set { idTipoMueble = value; }
        }
        
        public string Descrip
        {
            get { return descrip; }
            set { descrip = value; }
        }
        
        #endregion

        #region -- Constructores --

        public TipoMueble()
        { }

        public TipoMueble(int pidTipoMueble, string pdescrip)
        {
            idTipoMueble = pidTipoMueble;
            descrip = pdescrip;
        }
        
        #endregion
        
    }
}