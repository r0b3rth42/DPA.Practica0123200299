using System;
using System.Collections.Generic;

namespace DPA.Practica0123200299.CORE.Core.Entities;

public partial class Profesor
{
    public int IdProfesor { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? CorreoInstitucional { get; set; }

    public string? Especialidad { get; set; }

    public virtual ICollection<Curso> Curso { get; set; } = new List<Curso>();
}
