﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjVtaRepuestos.Entidades
{
     class Categoria
    {
        private int _codigo;
        private string _nombre;

        public int Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public Categoria(int cod, string nom)
        {
            this._codigo = cod;
            this._nombre = nom;
        }

    }

}
