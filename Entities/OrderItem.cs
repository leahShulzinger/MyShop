﻿using System;
using System.Collections.Generic;

namespace Entities;

public partial class OrderItem
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quentity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
