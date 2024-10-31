using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItHealth.Models;

public partial class TipoDocumento
{
    public int IdTipo { get; set; }

    public string Nombre { get; set; }

    public string Abravicacion { get; set; }

    [Editable(false)] 
    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
