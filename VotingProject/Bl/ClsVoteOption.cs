using VotingProject.Models;

namespace VotingProject.Bl
{
    public class ClsVoteOption
    {
        VoteContext context = new VoteContext();

        public List<TbVoteOption> GetAll()
        {
            try
            {
                var voteOptions = context.TbVoteOption.OrderBy(s => s.OptionName).ToList();
                return voteOptions;
            }
            catch
            {
                return new List<TbVoteOption>();
            }
        }

        public TbVoteOption GetById(int id)
        {
            try
            {
                var voteOption = context.TbVoteOption.FirstOrDefault(a => a.VoteOptionId == id);
                return voteOption;
            }
            catch
            {
                return new TbVoteOption();
            }

        }
        public bool Save(TbVoteOption option)
        {

            try
            {
                if (option.VoteOptionId == 0)
                {
                    context.TbVoteOption.Add(option);
                }
                else
                {
                    context.Entry(option).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                context.TbVoteOption.Remove(GetById(id));
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
