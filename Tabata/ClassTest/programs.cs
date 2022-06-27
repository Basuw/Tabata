using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassTest
{
    [DataContract]
    public class Programs : Sport
    {
        public Programs(string name, int difficulty, bool favorite, string image, int exercieDuration, int restDuration, List<Exos> exosList, ref User usr, Enum.Types typeList, List<Enum.Muscles> muscleList, Enum.PartieCorp partiCrps) : base(name, difficulty, favorite, image, ref usr, typeList,muscleList,partiCrps)
        {
            ExerciceDuration = exercieDuration;
            RestDuration = restDuration;
            ExosList = exosList;
            if (restDuration > 0) { tailleTab = ((int)exosList.Count * 2) - 1; }
            else { tailleTab = (int)exosList.Count; }
        }
        [DataMember]
        public List<Enum.Muscles> MusclesList { get; set; }
        private List<Enum.Muscles> musclesList= new List<Enum.Muscles>() { };
        [DataMember]

        public int TailleTab { get { return tailleTab; } set { tailleTab = value; } }
        private int tailleTab;
        [DataMember]

        public int ExerciceDuration { get { return exercieDuration; } set { exercieDuration = value; } }
        private int exercieDuration;
        [DataMember]
        public int RestDuration { get { return restDuration; } set { restDuration = value; } }
        private int restDuration;
        [DataMember]
        public List<Exos> ExosList { get { return exosList; } set { exosList = value; } }
        private List<Exos> exosList;

        public string listSTringName()
        {
            string oui = "";
            foreach(Exos name in exosList)
            {
                oui += name + ", ";
            }
            return oui;
        }

        public string listStringMuscle()//Création string de tous les muscles
        {
            string oui = "";
            foreach (Enum.Muscles mus in musclesList)
            {
                oui += mus + ", ";
            }
            return oui;
        }
        public override string ToString()
        {
            string oui = listSTringName();
            string non = listStringMuscle();
            return base.ToString() + $" {exercieDuration}; {oui}; {restDuration}; {non}";
        }

        public void Start()
        {
            DateTime dateTime = DateTime.Now;
            Usr.Cal += Cal;
            Usr.ProgHistory.Add(dateTime, this);
            //Ref chrono + pop list of the Exos on the side
        }

        public string CalculDurée()
        {
            TimeSpan dureeSec = TimeSpan.FromSeconds(exercieDuration * exosList.Count());
            return string.Format("{0:D2}m:{1:D2}s", dureeSec.Minutes,dureeSec.Seconds);
        }

        public void changeFav(string sportName, ReadOnlyCollection<Programs> sportList, List<Programs> sportFav)
        {
            foreach (Programs sport in sportList)
            {
                if (sport.Name == sportName)
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
