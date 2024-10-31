using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItHealth.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public int TipoDocumento { get; set; }

    public string NumeroDocumento { get; set; }

    public string NombrePaciente { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string Correo { get; set; }

    public int Genero { get; set; }

    public string Direccion { get; set; }

    public string NumeroTelefono { get; set; }

    public int Activo { get; set; }

    [Editable(false)]
    public virtual Estado? ActivoNavigation { get; set; }

    [Editable(false)]
    public virtual Genero? GeneroNavigation { get; set; }

    [Editable(false)]
    public virtual TipoDocumento? TipoDocumentoNavigation { get; set; }
}
