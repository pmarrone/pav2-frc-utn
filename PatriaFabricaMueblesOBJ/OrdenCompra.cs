using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriaFabricaMueblesOBJ
{
    public class OrdenCompra
    {
        #region -- Atributos --

        int idOrdenCpra;
        DateTime fechaHora;
        float montoTotal;
        Empleado legajoEncargCpra;

        #endregion

        #region -- Propiedades --

        public int IdOrdenCpra
        {
            get { return idOrdenCpra; }
            set { idOrdenCpra = value; }
        }

        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        public float MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        public Empleado LegajoEncargCpra
        {
            get { return legajoEncargCpra; }
            set { legajoEncargCpra = value; }
        }
        
        #endregion

        #region -- Constructores --

        public OrdenCompra()
        { }

        public OrdenCompra(int pidOrdenCpra, DateTime pfechaHora, float pmontoT, Empleado plegEC)
        {
            idOrdenCpra = pidOrdenCpra;
            fechaHora = pfechaHora;
            montoTotal = pmontoT;
            legajoEncargCpra = plegEC;
        }


        #endregion
    }
}