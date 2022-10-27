using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMX6K4_HFT_2022231.Models
{
    public enum Type {tank, melee, ranged, caster, support, healer}
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]
        public string Name { get; set; }

        public Type Type { get; set; }

        [Required]
        public bool Allowed { get; set; }
    }
}
