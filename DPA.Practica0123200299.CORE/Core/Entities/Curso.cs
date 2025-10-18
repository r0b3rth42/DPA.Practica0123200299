using System;
using System.Collections.Generic;

namespace DPA.Practica0123200299.CORE.Core.Entities;

public partial class Curso
{
    public int IdCurso { get; set; }

    public string NombreCurso { get; set; } = null!;

    public int Creditos { get; set; }

    public int? Ciclo { get; set; }

    public int? IdCarrera { get; set; }

    public int? IdProfesor { get; set; }

    public virtual ICollection<DetalleMatricula> DetalleMatricula { get; set; } = new List<DetalleMatricula>();

    public virtual Carrera? IdCarreraNavigation { get; set; }

    public virtual Profesor? IdProfesorNavigation { get; set; }
}
