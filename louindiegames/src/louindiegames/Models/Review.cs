using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace louindiegames.Models
{
    public class Review
    {
        [ScaffoldColumn(false)]
        public int ReviewID { get; set; }

        // [Required]
        //  [Display(Name= "User Name")]
        //  public string UserName { get; set; }


      //  [ScaffoldColumn(false)]
      //  public int Id { get; set; }

        //Navigation Property
       // public virtual ApplicationUser UserName { get; set; }

        [ScaffoldColumn(false)]
        public int GameID { get; set; }

        public virtual Game Game { get; set; }

        public string ReviewContent { get; set; }

        public string ReviewTitle { get; set; }

      //  public virtual ICollection<Review> Games { get; set; }
    }
}