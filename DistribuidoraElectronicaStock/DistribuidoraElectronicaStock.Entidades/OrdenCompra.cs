using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public enum EstadoOrdenCompra
    {
        Pendiente,
        Parcial,
        Completada
    }

    public class OrdenCompra : DocumentoComercial
    {
        //Atributos propios de OrdenCompra
        private Proveedor _proveedor;
        private DateTime? _fechaRecepcion;
        private EstadoOrdenCompra _estado;
        private List<OrdenCompraDetalle> _detalle;

        //Propiedades propias
        public Proveedor Proveedor
        {
            get => _proveedor;
            set => _proveedor = value;
        }
        public DateTime? FechaRecepcion
        {
            get => _fechaRecepcion;
            set => _fechaRecepcion = value;
        }
        public EstadoOrdenCompra Estado
        {
            get => _estado;
            set => _estado = value;
        }
        public List<OrdenCompraDetalle> Detalle
        {
            get => _detalle;
            set => _detalle = value;
        }

        //Propiedades de compatibilidad DocumentoComercial

        public int IdOrdenCompra
        {
            get => Id;
            set => Id = value;
        }
        public DateTime FechaEmision 
        {
            get => Fecha;
            set => Fecha = value;
        }

        //Constructores
        public OrdenCompra()
        {
            _detalle = new List<OrdenCompraDetalle>();
        }

        public OrdenCompra(int idOrdenCompra, Proveedor proveedor, Usuario usuario,
                           decimal montoTotal, DateTime fechaEmision,
                           DateTime? fechaRecepcion, EstadoOrdenCompra estado)
            : base(idOrdenCompra, usuario, fechaEmision, montoTotal) 
        {
            _proveedor = proveedor;
            _fechaRecepcion = fechaRecepcion;
            _estado = estado;
            _detalle = new List<OrdenCompraDetalle>();
        }

        //método abstracto
        public override decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var d in _detalle)
                total += d.Subtotal;
            return total;
        }

        public override string ToString()
        {
            return $"OC #{Id} — {_proveedor?.RazonSocial} — {Fecha:dd/MM/yyyy}";
        }
    }
}
