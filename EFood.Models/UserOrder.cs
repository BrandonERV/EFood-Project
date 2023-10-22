using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;
public partial class UserOrder
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrdersId { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey("OrderId")]
    public Order Orders { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
