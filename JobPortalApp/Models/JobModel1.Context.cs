﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobPortalApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JobPortalEntities : DbContext
    {
        public JobPortalEntities()
            : base("name=JobPortalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aplikim> Aplikims { get; set; }
        public virtual DbSet<Aplikuesi> Aplikuesis { get; set; }
        public virtual DbSet<Kompania> Kompanias { get; set; }
        public virtual DbSet<Lloji> Llojis { get; set; }
        public virtual DbSet<PozicionPune> PozicionPunes { get; set; }
        public virtual DbSet<Rezervim> Rezervims { get; set; }
        public virtual DbSet<ROLI> ROLIs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}