using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTest
{
    public class Exos: Sport
    {
        public Exos(string name, int difficulty, bool favorite, string image, string description, Enum.Types typeList, List<Enum.Muscles> muscleList, ref User usr, Enum.PartieCorp partiCrps, double cal =0) : base(name, difficulty, favorite, image,ref usr, typeList, muscleList,partiCrps)
        {
            Description = description;
            Cal = cal;
        }

        private string description;
        public string Description { get { return description; } set { description = value; } }

        public string listSTringMuscles()
        {
            string oui = "";
            foreach (Enum.Muscles name in MuscleList)
            {
                oui += name+ ", ";
            }
            return oui;
        }
        public override string ToString()
        {
            string non = listSTringMuscles();
            return base.ToString() + $" {description} ;{non}, {TypeList}";        
        }

        public void changeFav(string exoName, ReadOnlyCollection<Exos> sportList, List<Exos> sportFav)
        {
            foreach (Exos sport in sportList)
            {
                if (sport.Name == exoName)
                {
                    if (sport.Favorite)
                    {
                        sport.Favorite = false;
                        sport.HeartImg = "icon/emptyHeart.png";
                        sportFav.Remove(sport);
                    }
                    else
                    {
                        sport.Favorite = true;
                        sport.HeartImg = "icon/heart.png";
                        sportFav.Add(sport);
                    }
                    return;
                }
            }
        }

    }
}
