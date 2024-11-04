using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblBlog
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? ImageName { get; set; }

    public int? IdCategory { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? Status { get; set; }

    public virtual TblCategory? IdCategoryNavigation { get; set; }
}
