using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaximaTech.Infra.RelationalData.Entity
{
    public class DepartmentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }
      
        public ICollection<ProductEntity> Products { get; set; }
    }
}