using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;

public partial class OrdersProduct
{

    [Key]
    public int Id { get; set; }
    
    [Required]
    public int OrdersId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [ForeignKey("OrdersId")]
    public Order Orders { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}
