using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;

public partial class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    public int PaymentProcessorId { get; set; }

    [ForeignKey("PaymentProcessorId")]
    public PaymentProcessor PaymentProcessor { get; set; }

    [ForeignKey("StatusId")]
    public Status Status { get; set; }

    [Required]
    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    public string ClientName { get; set; }

    public string Adress { get; set; }

    public string PhoneNumber { get; set; }



}
