using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;



    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string Address { get; set; } = null!;

    public string? ShippingAddress { get; set; }

    public string? BillingInformation { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();
}
