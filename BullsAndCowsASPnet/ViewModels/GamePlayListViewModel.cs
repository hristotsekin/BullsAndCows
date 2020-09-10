using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCowsASPnet.ViewModels
{
    public class GamePlayListViewModel
    {

        public GamePlayListViewModel()
        {
            Rounds = new List<GamePlayViewModel>();
        }
        public string GuessNumber { get; set; }
        public string UniqueNumber { get; set; }
        public int Points { get; set; }
        public List<GamePlayViewModel> Rounds{ get; set; }

    }
}