using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseHandler.Models.EntityModels
{
    public class Officials
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? OfficialNo { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public int? IndividualId { get; set; }
        public Users? Individual { get; set; }
    }
}
