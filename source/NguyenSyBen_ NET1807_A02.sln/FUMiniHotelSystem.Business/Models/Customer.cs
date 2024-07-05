using System;
using System.Collections.Generic;

namespace FUMiniHotelSystem.Business.Models;

public partial class Customer
{
    public Customer()
    {
    }

    public Customer(int CustomerId, string? CustomerFullName, string? Telephone, DateOnly? CustomerBirthday, byte? CustomerStatus)
    {
        this.CustomerId = CustomerId;
        this.CustomerFullName = CustomerFullName;
        this.Telephone = Telephone;
        this.CustomerBirthday = CustomerBirthday;
        this.CustomerStatus = CustomerStatus;
        
    } 
    public int CustomerId { get; set; }

    public string? CustomerFullName { get; set; }

    public string? Telephone { get; set; }

    public string EmailAddress { get; set; } = null!;

    public DateOnly? CustomerBirthday { get; set; }

    public byte? CustomerStatus { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<BookingReservation> BookingReservations { get; set; } = new List<BookingReservation>();
}
