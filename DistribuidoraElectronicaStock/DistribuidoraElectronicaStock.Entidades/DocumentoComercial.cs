using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraElectronicaStock.Entidades
{
    public abstract class DocumentoComercial
    {
        private int _id;
        private Usuario _usuario;
        private DateTime _fecha;
        private decimal _montoTotal;

        public int Id { get => _id; set => _id = value; }
        public Usuario Usuario { get => _usuario; set => _usuario = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public decimal MontoTotal { get => _montoTotal; set => _montoTotal = value; }

        public DocumentoComercial() { }

        public DocumentoComercial(int id, Usuario usuario, DateTime fecha, decimal montoTotal)
        {
            _id = id;
            _usuario = usuario;
            _fecha = fecha;
            _montoTotal = montoTotal;
        }

        //Abstracto para que cada clase calcule su total
        public abstract decimal CalcularTotal();

        public override string ToString() => $"#{_id} — {_usuario?.Nombre} — {_fecha:dd/MM/yyyy} — ${_montoTotal:N2}";
    }
}
