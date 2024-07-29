using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaximaTech.Infra.RelationalData.Entity
{
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public bool Deleted { get; set; }
       
        [Required]
        public Guid DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public DepartmentEntity Department { get; set; }
    }
}