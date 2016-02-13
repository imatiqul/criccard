namespace Exact.Criccard.Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class CriccardModel : DbContext
    {
        // Your context has been configured to use a 'CriccardModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Exact.Criccard.Domain.Entities.CriccardModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CriccardModel' 
        // connection string in the application configuration file.
        public CriccardModel()
            : base("name=CriccardModel")
        {
            Initialize();
        }

        public CriccardModel(string connectionString)
            : base(connectionString)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }



        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Over> Overs { get; set; }
        public virtual DbSet<Bowl> Bowls { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}