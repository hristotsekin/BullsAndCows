using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BullsAndCowsASPnet.ViewModels
{
    public class InputAndRoundsViewModel
    {
        public InputAndRoundsViewModel()
        {
            ListOfAllGameRounds = new GamePlayListViewModel();
            GamePlayViewModel = new GamePlayViewModel();
        }
        
        public GamePlayListViewModel ListOfAllGameRounds { get; set; }
        public GamePlayViewModel GamePlayViewModel { get; set; }

        public int UniqueNumberSize { get; set; }
        public int RoundsCounter { get; set; }

        public int Points { get; set; }
    }
}