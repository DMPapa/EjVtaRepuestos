﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjVtaRepuestos.Entidades
{
    class Repuesto
    {
        private int _codigo;
        private string _nombre;
        private double _precio;
        private int _stock;
        private Categoria _categoria;
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
        public double Precio
        {
            get { return this._precio; }
            set { this._precio = value; }
        }
        public int Stock
        {
            get { return this._stock; }
            set 
            { 
                this._stock = value;
                if (this._stock <0)
                {
                    throw new Exception("El stock no puede ser menor a 0");
                }    
            }
        }
        public Categoria CategoriaRepuesto
        {
            get { return this._categoria; }
            set { this._categoria = value; }
        }

        public Repuesto (int cod, string nom, double pre, int stock, Categoria cat)
        {
            this._codigo = cod;
            this._nombre = nom;
            this._precio = pre;
            this._stock = stock;
            this._categoria = cat;
            
        }
        public override string ToString()
        {
            return ("C: " + this.Codigo + " - Nombre: " + this.Nombre + " - Precio : " + this.Precio + " - Stock: " + this.Stock);
        }

    }
}