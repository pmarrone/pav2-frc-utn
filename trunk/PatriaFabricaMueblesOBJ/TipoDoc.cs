using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMueblesOBJ
{
    public class TipoDoc
    {

#region -- Atributos --

        int id;
        string descrip;

#endregion

#region -- Propiedades --

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descrip
        {
            get { return descrip; }
            set { descrip = value; }
        }

#endregion

#region -- Constructores --

        public TipoDoc()
        { }

        public TipoDoc(int pid, string pdescrip)
        {
            id = pid;
            descrip = pdescrip;
        }
#endregion
        
    }
}