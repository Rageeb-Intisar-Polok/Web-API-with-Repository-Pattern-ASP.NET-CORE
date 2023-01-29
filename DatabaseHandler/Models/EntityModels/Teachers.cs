using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseHandler.Models.EntityModels
{
    public class Teachers
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? TeacherNo { get; set; }
        public int? IndividualId { get; set; }
        public Users? Individual { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string? Designation { get; set; } = "Unknown";
    }
}
