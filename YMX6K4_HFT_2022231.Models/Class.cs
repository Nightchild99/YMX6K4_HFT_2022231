﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMX6K4_HFT_2022231.Models
{
    public enum Type {tank, melee, ranged, caster, support, healer, various}

    [Table("Classes")]
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

        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        public Class()
        {
            Players = new HashSet<Player>();
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
    }
}
