using System;
using System.Collections.Generic;

namespace DPA.Practica0123200299.CORE.Core.Entities;

public partial class Carrera
{
    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public string? Facultad { get; set; }

    public int? DuracionAnios { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Curso> Curso { get; set; } = new List<Curso>();

    public virtual ICollection<Estudiante> Estudiante { get; set; } = new List<Estudiante>();
}
