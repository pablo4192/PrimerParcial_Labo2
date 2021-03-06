using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        string nombre;
        string apellido;
        string cuit;
        int numeroCliente;
        bool poseeCuenta;
        float saldo; 

        static int ultimoNumeroCliente;

        

        static Cliente()
        {
            ultimoNumeroCliente = 0;
        }

        private Cliente()
        {
            ultimoNumeroCliente++;
            numeroCliente = ultimoNumeroCliente;
            this.poseeCuenta = false; 
            this.saldo = 0;
        }

        public Cliente(string nombre, string apellido, string cuit): this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cuit = cuit;
            
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }


        public int NumeroCliente
        {
            get { return numeroCliente; }
        }

        public bool PoseeCuenta
        {
            get { return poseeCuenta; }
            set { poseeCuenta = value; }
        }

        public float Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }


        

    }
}
