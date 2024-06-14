using System;
using System.Collections.Generic;

namespace exo10._06.Models;

public partial class Auteur
{
    public int IdAuteur { get; set; }

    public string NomAuteur { get; set; } = null!;

    public string PrenomAuteur { get; set; } = null!;

    public virtual ICollection<Livre> Livres { get; set; } = new List<Livre>();
}
