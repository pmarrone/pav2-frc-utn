using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datos
{
    public class Cliente : Persona
    {
        public Cliente()
        {
        }
        public int IdCliente { get; set; }
        public string Cuit { get; set; }

        private bool tieneCasaPropia;
        public bool TieneCasaPropia
        {
            get { return tieneCasaPropia; }
            set { tieneCasaPropia = value; }
        }

        private int creditoMaximo;
        public int CreditoMaximo
        {
            get { return creditoMaximo; }
            set { creditoMaximo = value; }
        }



        // 03) Agregar Persona como clase base de  cliente y definir los siguientes propiedades
        // IdCliente 
        // NumeroDocumento  (persona)
        // Cuit (solo numeros sin guiones)
        // FechaNacimiento (persona)
        // Sexo (persona) F,M
        // TieneCasaPropia  booleano
        // CreditoMaximo  decimal


        public void Grabar()
        {
            throw new NotImplementedException();
        }
    }
    interface IPersistencia
    {
        void Grabar();

    }
}