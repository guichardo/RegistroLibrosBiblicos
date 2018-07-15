using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroLibroBiblicos.Entidades;
using System.Data.Entity;

namespace RegistroLibroBiblicos.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Libros> Libros { get; set; }

        public Contexto() : base("ConStr") { }
    }
}
