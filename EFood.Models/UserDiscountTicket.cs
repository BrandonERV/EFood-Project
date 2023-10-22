using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;

public partial class UserDiscountTicket
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int TicketId { get; set; }

    [ForeignKey("TicketId")]
    public DiscountTicket Ticket { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
