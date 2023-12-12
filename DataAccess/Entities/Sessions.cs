using System.ComponentModel.DataAnnotations;

namespace ACCA_Backend.DataAccess.Entities
{
    public partial class Sessions
    {
        [Key]
        public int SessionId { get; set; }

        public int UserId { get; set; }

        [Required]

        public string UserToken { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime ExpirationDate { get; set; }
        public int TypeId { get; set; }
    }
}