using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItHealth.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string Nombre { get; set; }

    [Editable(false)]
    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
