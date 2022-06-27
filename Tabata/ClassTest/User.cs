using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace ClassTest
{
    [DataContract]
    public class User
    {
        public User(string image, string firstname, string lastname, DateTime birthDate, double weight, double height, string sexe, int sportFrequency ,string sportPractice, string goal, int trainingGoal, double weightGoal, List<Exos> exoFav, List<Programs> progFav, Dictionary<DateTime, Programs> progHistory, int objHebdo, double cal=0)
        {

            Firstname = firstname;
            Lastname = lastname;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
            Sexe = sexe;
            SportPractice = sportPractice;
            SportFrequency = sportFrequency;
            Goal = goal;
            TrainingGoal = trainingGoal;
            WeightGoal = weightGoal;
            ExoFav = exoFav;
            ProgFav = progFav;
            Cal = cal;
            ProgHistory = progHistory;
            ObjHebdo = objHebdo;
            Image = image;
        }
        public User(User usr)
        {
            this.firstname = usr.firstname;
            this.lastname = usr.lastname;
            this.birthDate = usr.birthDate;
            this.weight = usr.weight;
            this.height = usr.height;
            this.Sexe = usr.Sexe;
            this.SportPractice = usr.SportPractice;
            this.SportFrequency = usr.SportFrequency;
            this.Goal = usr.Goal;
            this.TrainingGoal = usr.TrainingGoal;
            this.WeightGoal = usr.WeightGoal;
            this.ExoFav = usr.ExoFav;
            this.ProgFav = usr.ProgFav;
            this.Cal = usr.Cal;
            this.ProgHistory = usr.ProgHistory;
            this.ObjHebdo =usr.ObjHebdo;
            this.Image = usr.Image;
        }
        [DataMember(Order = 16)]
        public string Image { get { return image; } set { image = value; } }
        private string image;


        [DataMember (EmitDefaultValue =false, Order =15)]
        public double Cal { get; set; }

        [DataMember(Order = 11)]
        public int ObjHebdo { get { return objHebdo; } set { objHebdo = value; } }
        int objHebdo;

        [DataMember(Order = 12)]
        public Dictionary<DateTime, Programs> ProgHistory { get; set; }
        private Dictionary<DateTime, Programs> progHistory = new Dictionary<DateTime, Programs>();

        [DataMember(Order = 13)]
        public List<Exos> ExoFav { get { return exoFav; } set { exoFav = value; } }
        private List<Exos> exoFav;

        [DataMember(Order = 14)]
        public List<Programs> ProgFav { get { return progFav; } set { progFav = value; } }
        private List<Programs> progFav;

        [DataMember (Order =0)]
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        private string firstname;

        [DataMember(Order = 1)]
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        private string lastname;

        [DataMember(Order = 2)]
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        private DateTime birthDate;

        [DataMember(Order = 3)]
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private double weight;

        [DataMember(Order = 4)]
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        private double height;

        [DataMember(Order = 5)]
        public string Sexe
        {
            get { return sexe; }
            set { sexe = value; }
        }
        private string sexe;

        [DataMember(Order = 6)]
        public int SportFrequency
        {
            get { return sportFrequency; }
            set { sportFrequency = value; }
        }
        private int sportFrequency;

        [DataMember(Order = 7)]
        public string SportPractice
        {
            get { return sportPractice; }
            set { sportPractice = value; }
        }
        private string sportPractice;

        [DataMember(Order = 8)]
        public string Goal
        {
            get { return goal; }
            set { goal = value; }
        }
        private string goal;

        [DataMember(Order = 9)]
        public int TrainingGoal
        {
            get { return trainingGoal; }
            set { trainingGoal = value; }
        }
        private int trainingGoal;

        [DataMember(Order = 10)]
        public double WeightGoal
        {
            get { return weightGoal; }
            set { weightGoal = value; }
        }

        private double weightGoal;

        public int AgeCalcul()
        {
                // Age théorique
            int age = DateTime.Now.Year - BirthDate.Year;

            // Date de l'anniversaire de cette année
            DateTime DateAnniv = new DateTime(DateTime.Now.Year, BirthDate.Month, BirthDate.Day);

                // Si pas encore passé, retirer 1 an
                if (DateAnniv > DateTime.Now)
                    age--;

            return age;
        }

        public override string ToString()
        {
            return $"{firstname} {lastname} né le {birthDate})";
        }
        public void AddFav(Sport sportFav)
        {
            if (sportFav.Favorite == true)
            {
                if (sportFav is Exos)
                {
                    Exos exo = (Exos)sportFav;
                    exoFav.Add(exo);
                }
                if (sportFav is Programs)
                {
                    Programs prog = (Programs)sportFav;
                    progFav.Add(prog);
                }
            }
        }
        public void RemoveFav(Sport sportFav)
        {
            if (sportFav.Favorite == false)
            {
                if (sportFav is Exos)
                {
                    for (int i=0; i < exoFav.Count; i++)
                    {
                        if (exoFav[i]==(Exos)sportFav)
                        {
                            exoFav.RemoveAt(i);
                        }
                    }
                }
                if (sportFav is Programs)
                {
                    for (int i = 0; i < progFav.Count; i++)
                    {
                        if (progFav[i] == (Programs)sportFav)
                        {
                            progFav.RemoveAt(i);
                            return;
                        }
                    }
                }
            }
        }

/*        public void affList(List<Programs> list)
        { 
            foreach (Programs sportFav in list)
            {
                Console.WriteLine(sportFav);
            }
        }
        public void affList(List<Exos> list)
        {
            foreach (Exos sportFav in list)
            {
                Console.WriteLine(sportFav);
            }
        }*/
        public List<Programs> research(List<Programs> list, string researchName)
        {
            List<Programs> ret = new List<Programs>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Contains(researchName, StringComparison.CurrentCultureIgnoreCase))
                {
                    //Console.WriteLine("Trouvé");
                    ret.Add(list[i]);
                }
            }
            return ret;
        }
        public List<Exos> research(List<Exos> list, string researchName)
        {
            List<Exos> ret = new List<Exos>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Contains(researchName, StringComparison.CurrentCultureIgnoreCase))
                {
                    //Console.WriteLine("Trouvé");
                    ret.Add(list[i]);
                }
            }
            return ret;
        }

        public List<Exos> Tri(List<Exos> list, int difficulty, Enum.Muscles muscl, Enum.Types typ)//Tri les exos en fonction de 3 variales : types, muscles, difficulty
        {
            List<Exos> ret = new List<Exos>();
            foreach(Exos item in list)
            {
                if (item.TypeList==typ && item.MuscleList.Contains(muscl)&&difficulty==item.Difficulty)//cas ou tous les champs sont renseignés
                {
                    ret.Add(item);
                }
                if (typ==Enum.Types.All && item.MuscleList.Contains(muscl) && difficulty == item.Difficulty)//all types
                {
                    ret.Add(item);
                }
                if (item.TypeList==typ && muscl==Enum.Muscles.All && difficulty == item.Difficulty)//all muscles
                {
                    ret.Add(item);
                }
                if (item.TypeList == typ && item.MuscleList.Contains(muscl) && difficulty == 0)//Si la difficulté est nulle =0
                {
                    ret.Add(item);
                }
                if (item.TypeList==typ && muscl == Enum.Muscles.All && difficulty == 0)//Si la difficulté estnulle =0 + all muscles
                {
                    ret.Add(item);
                }
                if (typ == Enum.Types.All && item.MuscleList.Contains(muscl) && difficulty == 0)//Si la difficulté estnulle =0 + all types
                {
                    ret.Add(item);
                }
                if (typ == Enum.Types.All && muscl == Enum.Muscles.All && difficulty == item.Difficulty)// all types, all muscles
                {
                    ret.Add(item);
                }
                if (typ == Enum.Types.All && muscl == Enum.Muscles.All && difficulty == 0) // all types, all muscles, all difficulty
                {
                    ret.Add(item);
                }
            }
            return ret;
        }

        public List<Programs> Tri(List<Programs> list, int difficulty, Enum.Muscles muscl, Enum.Types typ)
        {
            List<Programs> ret = new List<Programs>();
            foreach (Programs item in list)
            {
                if (item.TypeList==typ && item.MuscleList.Contains(muscl) && difficulty == item.Difficulty)//cas ou tous les champs sont renseignés
                {
                    ret.Add(item);
                }
                if (typ == Enum.Types.All && item.MuscleList.Contains(muscl) && difficulty == item.Difficulty)//all types
                {
                    ret.Add(item);
                }
                if (item.TypeList==typ && muscl == Enum.Muscles.All && difficulty == item.Difficulty)//all muscles
                {
                    ret.Add(item);
                }
                if (item.TypeList==typ && item.MuscleList.Contains(muscl) && difficulty == 0)//Si la difficulté est nulle =0
                {
                    ret.Add(item);
                }
                if (item.TypeList==typ && muscl == Enum.Muscles.All && difficulty == 0)//Si la difficulté estnulle =0 + all muscles
                {
                    ret.Add(item);
                }
                if (typ == Enum.Types.All && item.MuscleList.Contains(muscl) && difficulty == 0)//Si la difficulté estnulle =0 + all types
                {
                    ret.Add(item);
                }
                if (typ == Enum.Types.All && muscl == Enum.Muscles.All && difficulty == item.Difficulty)// all types, all muscles
                {
                    ret.Add(item);
                }
                if (typ == Enum.Types.All && muscl == Enum.Muscles.All && difficulty == 0) // all types, all muscles, all difficulty
                {
                    ret.Add(item);
                }
            }
            return ret;
        }
        public double IMC()
        {
            return Math.Round(weight/(Height*Height)*10000, 1);
        }
    }
}