using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bugz_B_Gon.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        public string ProjectName { get; set; }

        public string Comments { get; set; }

        public string Status { get; set; }

        public string Date { get; set; }
    }

    public class ProjectDBContext : DbContext
    {
        public DbSet<ProjectModel> Projects { get; set; }
    }
}