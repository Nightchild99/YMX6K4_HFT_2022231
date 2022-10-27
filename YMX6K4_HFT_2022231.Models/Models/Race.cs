using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMX6K4_HFT_2022231.Models.Models
{
    [Table("Races")]
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

        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        public Race()
        {
            Players = new HashSet<Player>();
        }

        public Race(string line)
        {
            string[] datas = line.Split('#');
            ID = int.Parse(datas[0]);
            Name = datas[1];
            Source = datas[2];
            if (datas[3] == "0")
            {
                Allowed = false;
            }
            else
            {
                Allowed = true;
            }
        }
    }
}
