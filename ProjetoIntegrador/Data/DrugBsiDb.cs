namespace ProjetoIntegrador.Data
{
    using ProjetoIntegrador.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DrugBsiDb : DbContext
    {
        public DrugBsiDb()
            : base("name=DrugBsiDb")
        {
            
        }
        
        public virtual DbSet<Medicamento> Medicamentos { get; set; }
        public virtual DbSet<Fabricante> Fabricantes { get; set; }
        public virtual DbSet<Quimico> Quimicos { get; set; }
        public virtual DbSet<MedicamentoQuimico> MedicamentosQuimicos { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}