using System.ComponentModel.DataAnnotations;

namespace VotingProject.Models
{
    public class TbVoteResult
    {
        [Key]
        public int VoterResultId { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Job")]
        public string PersonJob { get; set; }

        [Required(ErrorMessage = "Please Enter Your Experence")]
        public int PersonExperence { get; set; }
        public string PersonNote { get; set; } = "No Notes";

        public TbVote Vote { get; set; }
        public TbVoteOption Option { get; set; }
        public int VoteId { get; set; }
        public int OptionId { get; set; }

    }
}
