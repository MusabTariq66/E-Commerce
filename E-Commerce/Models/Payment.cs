using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? UserId { get; set; }

    public int? OrderId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentStatus { get; set; }

    public virtual Order? Order { get; set; }

    public virtual User? User { get; set; }
}
