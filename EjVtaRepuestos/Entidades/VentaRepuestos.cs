using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EjVtaRepuestos.Entidades
{
    class VentaRepuestos
    {
        private List<Repuesto> _listaProductos;
        private string _nombreComercio;
        private string _direccion;

        public string NombreComercio
        {
            get { return this._nombreComercio; }
            set { this._nombreComercio = value; }
        }
        public string Direccion
        {
            get { return this._direccion; }
            set { this._direccion = value; }
        }
        public List<Repuesto> Repuestos
        {
            get { return this._listaProductos; }
            set { this._listaProductos = value; }
        }
        public VentaRepuestos(string nom, string dir)
        {
            this._listaProductos = new List<Repuesto>();
            this._nombreComercio = nom;
            this._direccion = dir;
        }

        public void AgregarRepuesto(int cod, string nom, double pre, int stock, Categoria cat)
        {

            try
            {
                this.Repuestos.Add(new Repuesto(cod, nom, pre, stock, cat));
            }
            catch { throw new Exception("Error al agregar repuesto"); }
        }

        public void QuitarRepuesto (int cod)
        {
            int quitados = 0;
            foreach (Repuesto rep in this._listaProductos)
            {
                if (rep.Codigo == cod)
                {
                    this.Repuestos.Remove(rep);
                    quitados += 1;
                }
            }
            if (quitados == 0)
            {
                throw new Exception("No hay repuesto a quitar");
            }    
        }
        public void ModificarPrecio (int cod, double precio)
        {
            int cambiados = 0;
            foreach (Repuesto rep in this.Repuestos)
            {
                if (rep.Codigo == cod)
                {
                    rep.Precio = precio;
                    cambiados += 1;
                }    
            }
            if (cambiados == 0)
            {
                throw new Exception("No hay repuesto a cambiar de precio");
            }
        }
        public void AgregarStock(int cod, int cant)
        {
            int stockeado = 0;
            foreach(Repuesto rep in this.Repuestos)
            {
                if (rep.Codigo == cod)
                {
                    rep.Stock += cant;
                    stockeado += 1;
                }    
            }
            if (stockeado == 0)
            {
                throw new Exception("No hay repuesto a stockear");
            }
        }
        public void QuitarStock(int cod, int cant)
        {
            int stockeado = 0;
            foreach (Repuesto rep in this.Repuestos)
            {
                if (rep.Codigo == cod)
                {
                    rep.Stock -= cant;
                    stockeado += 1;
                }
            }
            if (stockeado == 0)
            {
                throw new Exception("No hay repuesto a stockear");
            }
        }
        public List<Repuesto> TraerPorCategoria(int cod)
        {
            List<Repuesto> listado = new List<Repuesto>();
            foreach (Repuesto rep in this.Repuestos)
            {
                if (rep.CategoriaRepuesto.Codigo == cod)
                {
                    listado.Add(rep);
                }
            }
            return listado;
        }
    }
}
