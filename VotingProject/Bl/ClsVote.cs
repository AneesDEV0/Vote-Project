using Microsoft.EntityFrameworkCore;
using VotingProject.Models;

namespace VotingProject.Bl
{
    public class ClsVote
    {
        VoteContext context = new VoteContext();

        public List<TbVote> GetAll()
        {
            try
            {
                var votes = context.TbVote.Include(v => v.Options).Include(r=>r.VoteResults).OrderBy(s => s.VoteName).ToList();
                return votes;
            }
            catch
            {
                return new List<TbVote>();
            }
        }

        public TbVote GetById(int id)
        {
            try
            {
                var vote = context.TbVote.FirstOrDefault(a => a.VoteId == id);
                return vote;
            }
            catch
            {
                return new TbVote();
            }
            
        }
        public bool Save(TbVote vote)
        {

            try
            {
                if (vote.VoteId == 0)
                {
                    context.TbVote.Add(vote);
                }
                else
                {
                    context.Entry(vote).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                context.TbVote.Remove(GetById(id));
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
        public int GetVotesCount()
        {
            return context.TbVote.Count();
        }
        public int GettotalParticipants()
        {
            return context.TbVoteResult
            .Select(r => r.PersonName)
            .Distinct()
            .Count();
        }

        

    }
}
