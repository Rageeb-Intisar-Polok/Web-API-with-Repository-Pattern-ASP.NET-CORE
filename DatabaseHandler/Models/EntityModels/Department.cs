using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseHandler.Models.EntityModels
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = "Unknown";
        public string DepartmentNameShortForm { get; set; } = "Unknown";
    }
}
