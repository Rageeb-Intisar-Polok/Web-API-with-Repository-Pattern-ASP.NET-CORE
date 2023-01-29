using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseHandler.Models.EntityModels
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndividualID { get; set; }
        public string UserType { get; set; } = "Unknown";
        public string ID { get; set; } = "Unknown";
        public string Name { get; set; } = "Unknown";
        public string? Email { get; set; } = "Unknown";
        public string? Phone { get; set; } = "Unknown";
        public string? ConnectionListAndLastMessageJson { get; set; } = "{}";
    }
}
