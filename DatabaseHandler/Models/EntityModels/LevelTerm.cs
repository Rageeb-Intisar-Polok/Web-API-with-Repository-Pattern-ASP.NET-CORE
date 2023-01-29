using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseHandler.Models.EntityModels
{
    public class LevelTerm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelTermId { get; set; }
        public int Level { get; set; }
        public string Term { get; set; }
    }
}
