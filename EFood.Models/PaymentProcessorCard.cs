using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;
public partial class PaymentProcessorCard
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CardId { get; set; }

    [Required]
    public int PaymentProcessorId { get; set; }

    [ForeignKey("CardId")]
    public Card Card { get; set; }

    [ForeignKey("PaymentProcessorId")]
    public PaymentProcessor PaymentProcessor { get; set; }
}
