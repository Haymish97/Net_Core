using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblCategory
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Image { get; set; }

    public int? No { get; set; }

    public int? IdType { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<TblBlog> TblBlogs { get; set; } = new List<TblBlog>();

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
