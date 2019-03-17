using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MyDbInitializer: DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var area1 = new Area { Text = "New Territories" };
            var area2 = new Area { Text = "Kowloon" };
            var area3 = new Area { Text = "Hong Kong Island" };

            context.Areas.AddRange(new Area[] { area1, area2, area3 });

            context.SaveChanges();
        }
    }
}