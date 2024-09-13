using Libreria.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Persona
{
    public class Usuario
    {
        public string Name { get; set; }
        public long Password { get; set; }
        public long NumeroDeTarjeta {get; set; }
        public int MesVencimiento { get; set; }
        public int AnioVencimiento { get; set; }
        public int CodigoDeSeguridad { get; set; } 
        public Usuario(string name,long password,long numeroDeTarjeta,int mes,int anio,int codigoSeguridad)
        {
            Name = name;
            Password = password;
            NumeroDeTarjeta = numeroDeTarjeta;
            MesVencimiento = mes;
            AnioVencimiento = anio;
            CodigoDeSeguridad=codigoSeguridad;

        }

    }
}

