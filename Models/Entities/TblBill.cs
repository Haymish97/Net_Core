using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblBill
{
    public int Id { get; set; }

    public Guid? IdUser { get; set; }

    public decimal? Payment { get; set; }

    public int? IdType { get; set; }

    public string? Code { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpadtedDate { get; set; }

    public int? Status { get; set; }

    public virtual TblUser? IdUserNavigation { get; set; }

    public virtual ICollection<TblBillDetail> TblBillDetails { get; set; } = new List<TblBillDetail>();
}
