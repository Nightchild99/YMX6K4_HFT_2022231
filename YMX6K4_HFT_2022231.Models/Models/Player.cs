using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace YMX6K4_HFT_2022231.Models.Models
{
    [Table("Party")]
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(30)]
        public string CharacterName { get; set; }

        [NotMapped]
        [ForeignKey(nameof(RaceID))]
        public int RaceID { get; set; }

        [NotMapped]
        [ForeignKey(nameof(ClassID))]
        public int ClassID { get; set; }

        public virtual Race Race { get; set; }

        public virtual Class Class { get; set; }

        [Required]
        public int Level { get; set; }

        public Player()
        {

        }

        public static Random rnd;
        public Player(string line)
        {
            rnd = new Random();

            string[] datas = line.Split('#');
            ID = int.Parse(datas[0]);
            Name = datas[1];
            CharacterName = datas[2];
            RaceID = int.Parse(datas[3]);
            ClassID = int.Parse(datas[4]);
            Level = rnd.Next(4, 7);
        }

        public override bool Equals(object obj)
        {
            Player b = obj as Player;

            if (b == null)
            {
                return false;
            }
            else
            {
                return this.ID == b.ID
                    && this.Name == this.Name
                    && this.CharacterName == b.CharacterName
                    && this.RaceID == b.RaceID
                    && this.ClassID == b.ClassID;
            }
        }
    }
}
