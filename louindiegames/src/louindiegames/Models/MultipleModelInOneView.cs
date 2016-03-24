using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace louindiegames.ViewModels
{
    public class ViewModel
    {
        public IEnumerable<louindiegames.Models.Game> Games { get; set; }
        public IEnumerable<louindiegames.Models.Creator>  Creators { get; set; }
        public IEnumerable<louindiegames.Models.Review> Reviews { get; set; }
    }
}
