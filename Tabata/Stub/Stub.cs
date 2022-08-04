using ClassTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Stub
{
    public class Stub : IPersistanceManager
    {
        public (User usr, ReadOnlyCollection<Exos> exo, ReadOnlyCollection<Programs> prg) LoadData()
        {
            User usr = ChargeUser();
            Console.WriteLine(usr);
            List<Exos> exfv = new List<Exos>();
            List<Programs> prgfv = new List<Programs>();
            List<Exos> exo = ChargeExos(usr);
            List<Programs> prg = ChargePrograms(usr, exo);
            ReadOnlyCollection<Exos> exos = new ReadOnlyCollection<Exos>(exo);
            ReadOnlyCollection<Programs> prgm = new ReadOnlyCollection<Programs>(prg);
            return (usr, exos, prgm);
        }

        public void SaveData(User usr, ReadOnlyCollection<Exos> exo, ReadOnlyCollection<Programs> prg)
        {
            Debug.WriteLine("Sauvegarde demandée");
        }
        public User ChargeUser()
        {
            List<Exos> exoFav = new List<Exos> { };
            List<Programs> progFav = new List<Programs> { };
            DateTime dateTime = DateTime.Now;
            Dictionary<DateTime,Programs> dico=new Dictionary<DateTime, Programs>();
            User usr = new("icon/profilPic.png","Bastien", "Jacquelin", new DateTime(2003, 04, 09), 60, 182, "Male", 3, "Modéré", "Prise de Masse", 5, 65, exoFav, progFav, dico,1,500) ;
            return usr;
        }
        public List<Exos> ChargeExos(User usr)
        {
            List<ClassTest.Enum.Muscles> muscleTorse = new List<ClassTest.Enum.Muscles>() { ClassTest.Enum.Muscles.Triceps, ClassTest.Enum.Muscles.Pectoraux };
            List<ClassTest.Enum.Muscles> musclesSquat = new List<ClassTest.Enum.Muscles>() { ClassTest.Enum.Muscles.Quadriceps, ClassTest.Enum.Muscles.Fessier };
            List<ClassTest.Enum.Muscles> musclesFentes = new List<ClassTest.Enum.Muscles>() { ClassTest.Enum.Muscles.Quadriceps, ClassTest.Enum.Muscles.Isquio };
            List<ClassTest.Enum.Muscles> musclesCrunch = new List<ClassTest.Enum.Muscles>() { ClassTest.Enum.Muscles.Abdos };

            Exos pompes = new Exos("Pompes", 2, false, "img/pompe.jpg", "Pour realiser des pompes....", ClassTest.Enum.Types.Cardio, muscleTorse, ref usr, ClassTest.Enum.PartieCorp.Haut_Du_Corps,1);
            Exos squats = new Exos("Squats", 1, false, "img/squat.jpg", "Pour realiser des squats....", ClassTest.Enum.Types.Force, musclesSquat, ref usr, ClassTest.Enum.PartieCorp.Haut_Du_Corps, 1);
            Exos fentes = new Exos("Fentes", 2, false, "img/fente.jpg", "Pour realiser des fentes....", ClassTest.Enum.Types.Cardio, musclesFentes, ref usr,ClassTest.Enum.PartieCorp.Haut_Du_Corps, 1);
            Exos crunch = new Exos("Crunchs", 3, true, "img/crunch.png", "Pour realiser des crunch....", ClassTest.Enum.Types.Endurance, musclesCrunch, ref usr,ClassTest.Enum.PartieCorp.Haut_Du_Corps,0.05);
            List<Exos> ex = new List<Exos>() { pompes, squats, fentes, crunch };
            return ex;
        }
        public List<Programs> ChargePrograms(User usr, List<Exos> list)
        {
            List<ClassTest.Enum.Muscles> muscleListP1 = new List<ClassTest.Enum.Muscles>() { ClassTest.Enum.Muscles.Triceps, ClassTest.Enum.Muscles.Pectoraux };

            Programs prog1 = new("P1", 1, false, "img/squat.jpg", 4, 2, list, ref usr, ClassTest.Enum.Types.Cardio, muscleListP1, ClassTest.Enum.PartieCorp.Haut_Du_Corps);
            Programs prog2 = new("P2", 2, true, "img/squat.jpg", 45, 15, list, ref usr, ClassTest.Enum.Types.Force, muscleListP1, ClassTest.Enum.PartieCorp.Haut_Du_Corps);
            Programs prog3 = new("P3", 3, false, "img/squat.jpg", 45, 15, list, ref usr, ClassTest.Enum.Types.Cardio, muscleListP1, ClassTest.Enum.PartieCorp.Haut_Du_Corps);
            Programs prog4 = new("P4", 2, true, "img/squat.jpg", 23, 15, list, ref usr, ClassTest.Enum.Types.Endurance, muscleListP1, ClassTest.Enum.PartieCorp.Bas_du_corps);
            Programs prog5 = new("P5", 3, false, "img/squat.jpg", 45, 15, list, ref usr, ClassTest.Enum.Types.Cardio, muscleListP1, ClassTest.Enum.PartieCorp.Full_Body);

            List<Programs> programs = new List<Programs>() { prog1, prog2, prog3, prog4, prog5 };
            return programs;
        }
    }
}
