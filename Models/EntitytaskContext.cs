﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TaskEntityFramework.Models
{
    public class EntitytaskContext:DbContext
    {
        public EntitytaskContext() : base("DefaultConnection") { }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}