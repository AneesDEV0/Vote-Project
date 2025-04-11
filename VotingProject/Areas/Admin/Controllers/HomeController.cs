using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotingProject.Bl;
using VotingProject.Models;

namespace VotingProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		ClsVote clsVote = new ClsVote();
		ClsVoteOption voteOption = new ClsVoteOption();
		ClsvoteResultResult clsvoteResult = new ClsvoteResultResult();
        public IActionResult Index()
		{
            int voteCount = clsVote.GetVotesCount();
			int totalParticipants = clsVote.GettotalParticipants();
		
            ViewBag.TotalParticipants = totalParticipants;
            ViewBag.VoteCount = voteCount;
            return View();
		}

        public IActionResult List()
        {
            return View(clsVote.GetAll());
        }

        public IActionResult Edit(int id)
		{
			return View(new TbVote());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Save(TbVote vote)
		{
			//if (!ModelState.IsValid)
			//{
			//	return View("Edit", vote);
			//}
			clsVote.Save(vote);
			return RedirectToAction("Index"); // edit to List

		}

		public IActionResult Delete(int id)
		{
		
			clsVote.Delete(id);
			return RedirectToAction("List");
		}


	}
}
