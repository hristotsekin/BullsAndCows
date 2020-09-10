using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BullsAndCowsASPnet.ViewModels
{
    public class GamePlayViewModel
    {

        [Required]
        public string UserAssumptionNumber { get; set; }
        public int Bulls { get; set; }
        public int Cows { get; set; }
        public bool IsWantedNumber { get; set; }
        public int AssumptionsCounter { get; set; } = 0;
    }
}