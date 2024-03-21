using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Register
{
    public int RegisterId { get; set; }

    public string Username { get; set; } = null!;
    //public string Lastname { get; set; }

    //public string Address { get; set; }
    public string Email { get; set; } = null!;
    //public int PhoneNum { get; set; }
    //public DateTime DOB { get; set; }

    public string PasswordHash { get; set; } = null!;

    public DateTime? RegistrationDate { get; set; }
}
