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
        public VentaRepuestos() { }
        public VentaRepuestos(string nom, string dir)
        {
            this._listaProductos = new List<Repuesto>();
            this._nombreComercio = nom;
            this._direccion = dir;
        }

        public void AgregarRepuesto(int cod, string nom, double pre, int stock, int codcat)
        {

            try
            {
                this.Repuestos.Add(new Repuesto(cod, nom, pre, stock, codcat));
            }
            catch { throw new Exception("\nError al agregar repuesto\n"); }
        }

        public void QuitarRepuesto (int cod)
        {
                int quitados = 0;
                foreach (Repuesto rep in this.Repuestos)
                {
                    if (rep.Codigo == cod)
                    {
                        this.Repuestos.Remove(rep);
                        quitados += 1;
                    }
                }
                if (quitados == 0)
                {
                    throw new Exception("\nNo hay repuesto a quitar\n");
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
                throw new Exception("\nNo hay repuesto a cambiar de precio\n");
            }
        }
        public void AgregarStock(int cod, int cant)
        {
  
                int stockeado = 0;
                foreach (Repuesto rep in this.Repuestos)
                {
                    if (rep.Codigo == cod)
                    {
                        rep.Stock += cant;
                        stockeado += 1;
                    }
                }
                if (stockeado == 0)
                {
                    throw new Exception("\nNo hay repuesto a stockear\n");
                }
 
        }
        public void QuitarStock(int cod, int cant)
        {
                int stockeado = 0;
                foreach (Repuesto rep in this.Repuestos)
                {
                    if (rep.Codigo == cod)
                    {

                        if ((rep.Stock-cant) < 0)
                            throw new StockNegativoException("\nEl stock no puede ser menor a 0\n");

                        else rep.Stock -= cant;
                    stockeado += 1;
                    }
                }
                if (stockeado == 0)
                {
                    throw new Exception("\nNo hay repuesto a stockear\n");
                }

        }
        public List<Repuesto> TraerPorCategoria(int cod)
        {
            List<Repuesto> listado = new List<Repuesto>();
            foreach (Repuesto rep in this.Repuestos)
            {
                if (rep.GetCategoria.Codigo == cod)
                {
                    listado.Add(rep);
                }
            }
            return listado;
        }
        public override string ToString()
        {
            return this._listaProductos.ToString();
        }

    }
}
