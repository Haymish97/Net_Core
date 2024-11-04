using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblProductBrand
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
