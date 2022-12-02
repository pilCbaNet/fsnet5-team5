using System;
using System.Collections.Generic;

namespace MiBilleteraWebApi.Models
{
    public partial class Moneda
    {
        public Moneda()
        {
            Billeteras = new HashSet<Billetera>();
            Operaciones = new HashSet<Operacione>();
        }

        public int IdMoneda { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Tipo { get; set; } = null!;

        public virtual ICollection<Billetera> Billeteras { get; set; }
        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
