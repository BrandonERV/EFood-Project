using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;
public partial class ProductPrice
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int PriceId { get; set; }

    [ForeignKey("PriceId")]
    public Price Price { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}
