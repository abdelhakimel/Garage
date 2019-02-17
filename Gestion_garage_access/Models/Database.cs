namespace Gestion_garage_access.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Database : DbContext
    {
      // public virtual DbSet<Car> Cars { get; set; }
       public virtual DbSet<Piece> Pieces { get; set; }
       public virtual DbSet<Entreprise> Entreprises { get; set; }
       public virtual DbSet<Employer> Employers { get; set; }
       public virtual DbSet<Bon> Bons { get; set; }
       public virtual DbSet<SaleClass> Sales { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}