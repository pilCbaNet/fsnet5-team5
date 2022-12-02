using System;
using System.Collections.Generic;

namespace MiBilleteraWebApi.Models
{
    public partial class TipoOperacione
    {
        public TipoOperacione()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int IdTipoOperacion { get; set; }
        public string NombreOperacion { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
