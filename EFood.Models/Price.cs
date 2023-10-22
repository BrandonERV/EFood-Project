using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;
public partial class Price
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public int PriceTypeId { get; set; }

    [ForeignKey("PriceTypeId")]
    public PriceType PriceType { get; set; }
}
