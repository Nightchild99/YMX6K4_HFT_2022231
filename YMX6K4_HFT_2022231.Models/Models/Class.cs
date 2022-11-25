using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YMX6K4_HFT_2022231.Models.Models
{
    public enum Type { tank=1, melee=2, ranged=3, caster=4, support=5, healer=6, various=7 }

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

        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }

        public Class()
        {
            this.Players = new HashSet<Player>();
        }

        public Class(string line)
        {
            string[] datas = line.Split('#');
            ID = int.Parse(datas[0]);
            Name = datas[1];
            switch (datas[2])
            {
                case "tank":
                    Type = Type.tank;
                    break;
                case "melee":
                    Type = Type.melee;
                    break;
                case "ranged":
                    Type = Type.ranged;
                    break;
                case "caster":
                    Type = Type.caster;
                    break;
                case "support":
                    Type = Type.support;
                    break;
                case "healer":
                    Type = Type.healer;
                    break;
                case "various":
                    Type = Type.various;
                    break;
            }
            if (datas[3] == "0")
            {
                Allowed = false;
            }
            else
            {
                Allowed = true;
            }
        }

        public override bool Equals(object obj)
        {
            Class b = obj as Class;

            if (b == null)
            {
                return false;
            }
            else
            {
                return b.ID == this.ID
                    && b.Name == this.Name
                    && b.Type == this.Type
                    && b.Allowed == this.Allowed;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ID, this.Type);
        }
    }
}
