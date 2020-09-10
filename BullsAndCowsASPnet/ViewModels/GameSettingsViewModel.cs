using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BullsAndCowsASPnet.ViewModels
{
    public class GameSettingsViewModel
    {
        [DisplayName("Level of difficulties: ")]
        [Range(10, 20)]
        public int GameDifficulty { get; set; }
        [DisplayName("How many digits you want to guess?")]
        [Range(4,8)]
        public int HowManyDigits { get; set; }

        public bool isIncludeZero { get; set; } = true;
    }
}