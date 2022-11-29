using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Moneda
    {
        public Moneda()
        {
            Billeteras = new HashSet<Billetera>();
            Operacions = new HashSet<Operacion>();
        }

        public int IdMoneda { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Tipo { get; set; } = null!;

        public virtual ICollection<Billetera> Billeteras { get; set; }
        public virtual ICollection<Operacion> Operacions { get; set; }
    }
}
