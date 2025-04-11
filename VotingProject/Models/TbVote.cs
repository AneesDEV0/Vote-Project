using System.ComponentModel.DataAnnotations;

namespace VotingProject.Models
{
    public class TbVote
    {
        public TbVote()
        {
            VoteResults = new HashSet<TbVoteResult>();
            Options = new List<TbVoteOption>();
        }
        [Key]
        public int VoteId { get; set; }
        public string VoteName { get; set; }
        [MaxLength(300)]
        public string VoteDescription { get; set; }
        public ICollection<TbVoteResult> VoteResults { get; set; }
        public List<TbVoteOption> Options { get; set; }
    }
}
