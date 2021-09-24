using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAssignment
{
    // [Table ("Employees", Schema="dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   // this is default option 
        public int EmpId { get; set; }

        [Required]
        [Column(TypeName="varchar(50)")]
        public string Name{ get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string ImagePath { get; set; }

        [NotMapped]
        public string ViewType { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public Department Department { get; set; }  // navigation property
    }
}