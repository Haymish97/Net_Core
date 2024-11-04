using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblUser
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Cart { get; set; }

    public int? Status { get; set; }

    public int UserType { get; set; }

    public virtual ICollection<TblBill> TblBills { get; set; } = new List<TblBill>();
}
