using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassTest
{
    [DataContract]
    public abstract class Sport
    {
        public Sport(string name, int difficulty, bool favorite, string image, ref User usr, Enum.Types typeList, List<Enum.Muscles> muscleList, Enum.PartieCorp partiCrps) {
            Name = name;
            Difficulty = difficulty;
            Favorite = favorite;
            Image = image;
            Usr = usr;
            TypeList = typeList;
            MuscleList = muscleList;
            PartiCrps = partiCrps;
            Init();

        }
        [DataMember]
        public string StarImg1 { get { return starImg1; } set { starImg1 = value; } }
        private string starImg1;
        [DataMember]

        public string StarImg2 { get { return starImg2; } set { starImg2 = value; } }
        private string starImg2;
        [DataMember]

        public string StarImg3 { get { return starImg3; } set { starImg3 = value; } }
        private string starImg3;
        [DataMember]

        public string HeartImg { get { return heartImg; } set { heartImg = value; } }
        private string heartImg;
        [DataMember]

        public Enum.PartieCorp PartiCrps { get { return partiCrps; } set { partiCrps = value; } }
        private Enum.PartieCorp partiCrps;
        [DataMember]

        public double Cal { get { return cal; } set { cal = value; } }
        private double cal;
        [DataMember]

        public Enum.Types TypeList { get { return typeList; } set { typeList = value; } }
        private Enum.Types typeList;

        [DataMember]

        public List<Enum.Muscles> MuscleList { get { return muscleList; } set { muscleList = value; } }
        private List<Enum.Muscles> muscleList;
        [DataMember]

        public User Usr { get { return usr; } set { usr = value; } }
        private User usr;
        [DataMember]

        public string Name { get { return name; } set { name = value; } }
        private string name;

        [DataMember]

        public int Difficulty { get { return difficulty; } set { difficulty = value; } }
        private int difficulty;
        [DataMember]

        public bool Favorite { get { return favorite; } set { favorite = value; } }
        private bool favorite;
        [DataMember]

        public string Image { get { return image; } set { image = value; } }
        private string image;

        public override string ToString()
        {
            return $"{name} {difficulty} {favorite} {image}";
        }
        
        public bool Equals(Sport other)
        {
            return Name == other.Name;
        }
        public void Init()
        {
            if (!favorite)
            {
                HeartImg = "icon/emptyHeart.png";
            }
            else HeartImg = "icon/heart.png";
            if ( difficulty == 1)
            {
                starImg1= "icon/star.png";
                starImg2 = "icon/emptyStar.png";
                starImg3 = "icon/emptyStar.png";
            }
            if (difficulty == 2)
            {
                starImg1 = "icon/star.png";
                starImg2 = "icon/star.png";
                starImg3 = "icon/emptyStar.png";
            }
            if (difficulty == 3)
            {
                starImg1 = "icon/star.png";
                starImg2 = "icon/star.png";
                starImg3 = "icon/star.png";
            }
        }
    }
}
