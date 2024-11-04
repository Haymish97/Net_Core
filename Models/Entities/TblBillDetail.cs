using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblBillDetail
{
    public int IdBill { get; set; }

    public Guid IdProduct { get; set; }

    public int? Quantity { get; set; }

    public decimal? Total { get; set; }

    public virtual TblBill IdBillNavigation { get; set; } = null!;

    public virtual TblProduct IdProductNavigation { get; set; } = null!;
}
