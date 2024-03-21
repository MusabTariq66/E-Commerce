using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Shipping
{
    public int ShippingId { get; set; }

    public int? UserId { get; set; }

    public int? OrderId { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public string? ShippingStatus { get; set; }

    public DateTime? ShippingDate { get; set; }

    public virtual Order? Order { get; set; }

    public virtual User? User { get; set; }
}
