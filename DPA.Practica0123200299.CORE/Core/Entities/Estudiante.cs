using System;
using System.Collections.Generic;

namespace DPA.Practica0123200299.CORE.Core.Entities;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string? CorreoInstitucional { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public int? IdCarrera { get; set; }

    public virtual Carrera? IdCarreraNavigation { get; set; }

    public virtual ICollection<Matricula> Matricula { get; set; } = new List<Matricula>();
}
