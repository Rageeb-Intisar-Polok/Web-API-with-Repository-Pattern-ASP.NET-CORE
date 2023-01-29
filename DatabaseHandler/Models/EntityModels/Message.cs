//   message is set non-CRUDable.


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseHandler.Models.EntityModels
{
    public class Message
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? MessageId { get; set; }
        public string? Status { get; set; }
        public string? ConnectionId { get; set; }
        public Connection? Connection { get; set; }
        public int? SenderId { get; set; }
        public Users? Sender { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Messages { get; set; }
    }
}
