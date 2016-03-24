//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Data.Entity;
//using Microsoft.Extensions.DependencyInjection;

//namespace louindiegames.Models
//{
//    public static class SampleReviewData
//    {
//        public static void Initialize(IServiceProvider serviceProvider)
//        {
//            var context = serviceProvider.GetService<ApplicationDbContext>();
//            context.Database.Migrate();
//            if (!context.Review.Any())
//            {
//                context.Review.AddRange(
//                    new Review()
//                    {
//                        ReviewContent = "OMG SO COOL!!!"
//                    }
//                );
//                context.SaveChanges();
//            }
//        }
//    }
//}
