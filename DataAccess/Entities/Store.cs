﻿using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Store
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Inventory> Inventories { get; set; } = new();
}