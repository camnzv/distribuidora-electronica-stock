using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public enum EstadoOrdenCompra  //internamente es un entero 0,1,2
    {
        Pendiente,
        Parcial,
        Completada
    }
    //if (orden.Estado == EstadoOrdenCompra.Pendiente) { mostrar la orden }
    

    public class OrdenCompra
    {
        private int _idOrdenCompra;
        private Proveedor _proveedor;
        private Usuario _usuario;
        private decimal _montoTotal;
        private DateTime _fechaEmision;
        private DateTime? _fechaRecepcion;//puede ser null, cuando todavía no se recibió el pedido
        private EstadoOrdenCompra _estado;
        private List<OrdenCompraDetalle> _detalle;

        public int IdOrdenCompra
        {
            get => _idOrdenCompra;
            set => _idOrdenCompra = value;
        }
        public Proveedor Proveedor
        {
            get => _proveedor;
            set => _proveedor = value;
        }
        public Usuario Usuario
        {
            get => _usuario;
            set => _usuario = value;
        }
        public decimal MontoTotal
        {
            get => _montoTotal;
            set => _montoTotal = value;
        }
        public DateTime FechaEmision
        {
            get => _fechaEmision;
            set => _fechaEmision = value;
        }
        public DateTime? FechaRecepcion  // nullable: OC pendiente no tiene fecha aún
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

        public OrdenCompra()
        {
            _detalle = new List<OrdenCompraDetalle>();
        }

        public OrdenCompra(int idOrdenCompra, Proveedor proveedor, Usuario usuario, decimal montoTotal, DateTime fechaEmision, DateTime? fechaRecepcion, EstadoOrdenCompra estado)
        {
            _idOrdenCompra = idOrdenCompra;
            _proveedor = proveedor;
            _usuario = usuario;
            _montoTotal = montoTotal;
            _fechaEmision = fechaEmision;
            _fechaRecepcion = fechaRecepcion;
            _estado = estado;
            _detalle = new List<OrdenCompraDetalle>();
        }

        public override string ToString()
        {
            return $"Orden Compra #{_idOrdenCompra} - {_proveedor.RazonSocial} ( {_estado} )";
        }
    }
}
