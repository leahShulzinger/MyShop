﻿using System;
using System.Collections.Generic;

namespace Entities;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string? ProductName { get; set; }

    public double Price { get; set; }

    public string? Image { get; set; }

    public string? Descraption { get; set; }

    public int? Quentity { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
