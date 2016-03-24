using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace louindiegames.Models
{
    public class GameVM
    {
        public Game game { get; set; }

        public Creator creator { get; set; }

    }
}
