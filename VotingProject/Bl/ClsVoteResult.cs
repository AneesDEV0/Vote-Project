using VotingProject.Models;

namespace VotingProject.Bl
{
    public class ClsvoteResultResult
    {
        VoteContext context = new VoteContext();

        public List<TbVoteResult> GetAll()
        {
            try
            {
                var voteResults = context.TbVoteResult.OrderBy(s => s.PersonName).ToList();
                return voteResults;
            }
            catch
            {
                return new List<TbVoteResult>();
            }
        }

        public TbVoteResult GetById(int id)
        {
            try
            {
                var voteResult = context.TbVoteResult.FirstOrDefault(a => a.VoterResultId == id);
                return voteResult;
            }
            catch
            {
                return new TbVoteResult();
            }

        }
        public bool Save(TbVoteResult voteResult)
        {

            try
            {
                if (voteResult.VoterResultId == 0)
                {
                    context.TbVoteResult.Add(voteResult);
                }
                else
                {
                    context.Entry(voteResult).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                context.SaveChanges();

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                context.TbVoteResult.Remove(GetById(id));
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }

    }
}
