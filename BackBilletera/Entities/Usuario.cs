using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Billeteras = new HashSet<Billetera>();
            Operacions = new HashSet<Operacion>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pasword { get; set; } = null!;
        public DateTime FechaAlta { get; set; }
        public DateTime? FehcaBaja { get; set; }

        public virtual ICollection<Billetera> Billeteras { get; set; }
        public virtual ICollection<Operacion> Operacions { get; set; }
    }
}
