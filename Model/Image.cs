using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiSample.Model
{
    [Table("Image")]
    public partial class Image
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public byte[] Data { get; set; } = null!;
        [StringLength(10)]
        public string Type { get; set; } = null!;
    }
}
