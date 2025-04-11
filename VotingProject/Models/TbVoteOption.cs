using System.ComponentModel.DataAnnotations;

namespace VotingProject.Models
{
    public class TbVoteOption
    {
        public TbVoteOption()
        {

            Results = new HashSet<TbVoteResult>();
        }
        [Key]
        public int VoteOptionId { get; set; }
        [Required(ErrorMessage = "Please Enter Vote Name")]
        public string OptionName { get; set; }
		
		public TbVote Vote { get; set; }
        public int VoteId { get; set; }
        public ICollection<TbVoteResult> Results { get; set; }
    }
}
