using System;
using System.Collections.Generic;

namespace DPA.Practica0123200299.CORE.Core.Entities;

public partial class Matricula
{
    public int IdMatricula { get; set; }

    public int? IdEstudiante { get; set; }

    public string? Periodo { get; set; }

    public DateOnly? FechaMatricula { get; set; }

    public virtual ICollection<DetalleMatricula> DetalleMatricula { get; set; } = new List<DetalleMatricula>();

    public virtual Estudiante? IdEstudianteNavigation { get; set; }
}
