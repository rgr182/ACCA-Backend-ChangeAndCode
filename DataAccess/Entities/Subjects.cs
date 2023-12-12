using System.ComponentModel.DataAnnotations;

namespace ACCA_Backend.DataAccess.Entities
{
    public class Subjects
    {
        [Key]
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Schedule { get; set; }
    }
}
