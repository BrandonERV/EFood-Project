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
    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [Required]
    public string ClientName { get; set; }

    [Required]
    public string Adress { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string PaymentType { get; set; }

    [Required]
    public string CardType { get; set; }

    [Required]
    public bool IsCard { get; set; }

    [Required]
    public bool IsPayCheck { get; set; }

    [Required]
    public bool IsPayCash { get; set; }

    public string CardNumber { get; set; }

    public string PayCheckNumber { get; set; }

    public string PayCheckBankAccountNumber { get; set; }




}
