using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMX6K4_HFT_2022231.Models
{
    public class Race
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(6)]
        public string Source { get; set; }

        [Required]
        public bool Allowed { get; set; }
    }
}
