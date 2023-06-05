using System;
using System.Collections.Generic;

namespace webapi.DB;

public partial class Venta
{
    public int Id { get; set; }

    public string CodigoPelicula { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public string Clasificacion { get; set; } = null!;

    public string Asiento { get; set; } = null!;
}
