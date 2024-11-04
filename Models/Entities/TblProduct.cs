using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblProduct
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public int? IdUnit { get; set; }

    public int? IdBrand { get; set; }

    public int? IdCategory { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? ImageName { get; set; }

    public int? Status { get; set; }

    public virtual TblProductBrand? IdBrandNavigation { get; set; }

    public virtual TblCategory? IdCategoryNavigation { get; set; }

    public virtual TblProductUnit? IdUnitNavigation { get; set; }

    public virtual ICollection<TblBillDetail> TblBillDetails { get; set; } = new List<TblBillDetail>();
}
