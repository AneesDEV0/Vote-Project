using VotingProject.Bl;
using Microsoft.AspNetCore.Mvc;
using VotingProject.Models;
using Microsoft.IdentityModel.Tokens;


namespace VotingProject.Controllers
{
 
    public class HomeController : Controller
    {
        ClsVote clsVote = new ClsVote();
        ClsvoteResultResult clsVoteResult = new ClsvoteResultResult();
        public IActionResult Index()
        {
            return View(clsVote.GetAll());
        }

        public IActionResult Save(TbVoteResult result)
        {
            if (result.PersonNote.IsNullOrEmpty())
            {
                result.PersonNote = "No Notes";
            }
            clsVoteResult.Save(result);
                return RedirectToAction("Index");  
        }

    }
}
