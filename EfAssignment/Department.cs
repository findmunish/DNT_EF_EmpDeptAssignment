using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfAssignment
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   // this is default option 
        public int DeptId { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        [NotMapped]
        public string ViewType { get; set; }

        [NotMapped]
        public string Message { get; set; }
    }
}
