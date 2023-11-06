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

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [Required]
    public int PriceTypeId { get; set; }

    [ForeignKey("PriceTypeId")]
    public PriceType PriceType { get; set; }

    [Required]
    public int Amount { get; set; }


}
