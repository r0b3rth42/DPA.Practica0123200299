using System;
using System.Collections.Generic;

namespace DPA.Practica0123200299.CORE.Core.Entities;

public partial class DetalleMatricula
{
    public int IdDetalle { get; set; }

    public int? IdMatricula { get; set; }

    public int? IdCurso { get; set; }

    public decimal? NotaFinal { get; set; }

    public string? Estado { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }

    public virtual Matricula? IdMatriculaNavigation { get; set; }
}
