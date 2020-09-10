using BullsAndCowsASPnet.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Antlr.Runtime.Misc;
using BullsAndCowsASPnet.GLL;
using Newtonsoft.Json;

namespace BullsAndCowsASPnet.Controllers
{
    public class GameController : Controller
    {
        private GameNumbers gameNumbers;
        //private GameSettingsViewModel gameSettingsViewModel;
        private InputAndRoundsViewModel inputAndRoundsViewModel;
        //private string uniqueNumber;


        public GameController()
        {
            gameNumbers = new GameNumbers();
            inputAndRoundsViewModel = new InputAndRoundsViewModel();
        }

        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GameSettings()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GameSettings(GameSettingsViewModel g)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("Play", "Game", g);
            }

            GameSettingsViewModel defaultModel = new GameSettingsViewModel();
            defaultModel.HowManyDigits = 4;

            return View();


        }

        

        public ActionResult Play(GameSettingsViewModel g)
        {


            inputAndRoundsViewModel.ListOfAllGameRounds.UniqueNumber = gameNumbers.UniqueNumberGenerator(g.HowManyDigits);
            inputAndRoundsViewModel.UniqueNumberSize = g.HowManyDigits;

            return View(inputAndRoundsViewModel);
        }

        private void IsNum(ModelStateDictionary modelState, InputAndRoundsViewModel game){
        
            if (!gameNumbers.isValidUserNumber(game.GamePlayViewModel.UserAssumptionNumber, game.UniqueNumberSize))
            {
                modelState.AddModelError("UserAssumptionNumber", String.Format("You need to enter {0} digits unique number", game.UniqueNumberSize));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Play([Bind(Include = "GamePlayViewModel, UniqueNumberSize")]InputAndRoundsViewModel game)
        {

            IsNum(ModelState, game);

            string jsonReturnObj = Request.Form["ListOfAllGameRounds"];
            inputAndRoundsViewModel.ListOfAllGameRounds = JsonConvert.DeserializeObject<GamePlayListViewModel>(jsonReturnObj);
            string jsonRdounds = Request.Form["ListOfRounds"];
            inputAndRoundsViewModel.ListOfAllGameRounds.Rounds = JsonConvert.DeserializeObject<List<GamePlayViewModel>>(jsonRdounds);


            if (ModelState.IsValid)
            {

                inputAndRoundsViewModel.ListOfAllGameRounds.Rounds.Add(new GamePlayViewModel
                {
                    UserAssumptionNumber = game.GamePlayViewModel.UserAssumptionNumber,
                    Bulls = gameNumbers.Bulls(inputAndRoundsViewModel.ListOfAllGameRounds.UniqueNumber, game.GamePlayViewModel.UserAssumptionNumber),
                    Cows = gameNumbers.Cows(inputAndRoundsViewModel.ListOfAllGameRounds.UniqueNumber, game.GamePlayViewModel.UserAssumptionNumber),
                    IsWantedNumber = inputAndRoundsViewModel.ListOfAllGameRounds.UniqueNumber.Equals(game.GamePlayViewModel.UserAssumptionNumber) ? true : false
                });

                game.GamePlayViewModel.UserAssumptionNumber = null;

            }



            
            return View(inputAndRoundsViewModel);
        }

        
    }
}