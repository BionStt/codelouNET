using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace louindiegames.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Game.Any())
            {
                var twoscoopgames = context.Creator.Add(
                    new Creator { CreatorName = "Two Scoop Games" }).Entity;
                var roaringcatgames = context.Creator.Add(
                    new Creator { CreatorName = "Roaring Cat Games" }).Entity;
                var mintchipleaf = context.Creator.Add(
                    new Creator { CreatorName = "Mint Chip Leaf" }).Entity;

                context.Game.AddRange(
                    new Game()
                    {
                        Title = "Desserts Kill Your Daddy",
                        Creator = twoscoopgames
                    },

                     new Game()
                    {
                    Title = "Saturday Morning Destruction!!!",
                        Creator = roaringcatgames
                    },

                     new Game()
                    {
                    Title = "PSHNGGG!",
                        Creator = mintchipleaf
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
