using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseHandler.Models.EntityModels
{
    public class Students
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? StudentNo { get; set; }
        public int? IndividualId { get; set; }
        public Users? Individual { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int LevelTermId { get; set; }
        public LevelTerm? LevelTerm { get; set; }

    }
}
