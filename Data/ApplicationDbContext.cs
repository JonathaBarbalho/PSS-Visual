﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PSS_Visual.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSS_Visual.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Cidade> Cidades { get; set; }
    }
}
