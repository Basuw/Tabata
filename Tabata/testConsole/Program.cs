using System;
using ClassTest;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {


            /*            Sport sport = new Sport("Squat",1,false,"./img/squat.png");
                        Console.WriteLine(sport);*/
            //tableau
            /*          int[] tab_int=new int[1];
                        tab_int[0]=12;
                        int tab = tab_int[0];
                        const string Format = "La valeur en du 0 tab est ";
                        Console.WriteLine(Format+tab_int[0]);
                        Console.WriteLine($"{Format}{tab}");*/
            //Lecture
            /*string s = Console.ReadLine();
            Console.WriteLine(s);*/
            //Création des exos
            //List Types


            // Création list de tous les Sports
            List<Sport> sportList = new List<Sport> { };
            List<Exos> exoFav = new List<Exos> { };
            List<Programs> progFav = new List<Programs> { };



            Console.WriteLine("----Création USER----");

            //Création USER
            Dictionary<DateTime, Programs> dico = new Dictionary<DateTime, Programs>();
            User usr = new("Bastien", "Jacquelin", new DateTime(2003, 04, 09), 60, 182, "Male", 3, "Modéré", "Prise de Masse", 5, 65, exoFav, progFav, dico, 1, 500);
            Console.WriteLine(usr);





            Console.WriteLine("----Création Exos----");

            //List Muscles

            List<ClassTest.Enum.Muscles> muscleList = new List<ClassTest.Enum.Muscles>() { ClassTest.Enum.Muscles.Triceps, ClassTest.Enum.Muscles.Pectoraux };
            List<ClassTest.Enum.Muscles> musclesSquat = new List<ClassTest.Enum.Muscles>() { ClassTest.Enum.Muscles.Quadriceps, ClassTest.Enum.Muscles.Fessier };
            List<ClassTest.Enum.Muscles> musclesFentes = new List<ClassTest.Enum.Muscles>() { ClassTest.Enum.Muscles.Quadriceps, ClassTest.Enum.Muscles.Isquio };
            List<ClassTest.Enum.Muscles> musclesCrunch = new List<ClassTest.Enum.Muscles>() { ClassTest.Enum.Muscles.Abdos };


            Exos pompes = new Exos("Pompes", 2, false, "img/sqaut.png", "Pour realiser des pompes....", ClassTest.Enum.Types.Endurance, muscleList, ref usr, ClassTest.Enum.PartieCorp.Full_Body);
            Exos squats = new Exos("Squats", 1, false, "img/sqaut.png", "Pour realiser des squats....", ClassTest.Enum.Types.Endurance, musclesSquat, ref usr, ClassTest.Enum.PartieCorp.Full_Body);
            Exos fentes = new Exos("Fentes", 2, false, "img/sqaut.png", "Pour realiser des fentes....", ClassTest.Enum.Types.Endurance, musclesFentes, ref usr, ClassTest.Enum.PartieCorp.Full_Body);
            Exos crunch = new Exos("Crunchs", 1, true, "img/sqaut.png", "Pour realiser des crunch....", ClassTest.Enum.Types.Endurance, musclesCrunch, ref usr, ClassTest.Enum.PartieCorp.Full_Body);

            Console.WriteLine(pompes);
            Console.WriteLine(squats);
            Console.WriteLine(fentes);
            Console.WriteLine(crunch);



            Console.WriteLine("----Création PRGM----");

            //List Exos
            List<Exos> exosListP1 = new List<Exos>() { pompes, fentes, crunch, squats };
            List<ClassTest.Enum.Muscles> muscleListP1 = new List<ClassTest.Enum.Muscles>() { ClassTest.Enum.Muscles.Triceps, ClassTest.Enum.Muscles.Pectoraux };
            List<ClassTest.Enum.Types> typeListP1 = new List<ClassTest.Enum.Types>() { ClassTest.Enum.Types.Cardio, ClassTest.Enum.Types.Endurance };




            //Création des programmes

            //creation PRGM

            Programs prog1 = new("Programme1", 2, false, "img/squat.jpg", 45, 15, exosListP1, ref usr, ClassTest.Enum.Types.Endurance, muscleListP1, ClassTest.Enum.PartieCorp.Full_Body);

            Console.WriteLine(prog1);
            //prog1.AffichageTab();

            List<Programs> listProg = new List<Programs>() { prog1 };



            // Création des vignettes exos
            Console.WriteLine("----Création Vignettes----");

            TimeSpan exoD = TimeSpan.FromSeconds(45);
            TimeSpan exoR = TimeSpan.FromSeconds(15);
            Console.WriteLine("----Fonction de Recherche----");
            //prog
            List<Programs> tesst = usr.research(listProg, "pr");
            //usr.affList(tesst);
            //Exos
            List<Exos> tessst = usr.research(exosListP1, "po");
            //usr.affList(tessst);

            Console.WriteLine("----Fonction de TRI----");

            List<Exos> exoslisttt = usr.Tri(exosListP1, 0, ClassTest.Enum.Muscles.Quadriceps, ClassTest.Enum.Types.All);
            Console.WriteLine(exoslisttt.Count());
            //usr.affList(exoslisttt);
            Console.WriteLine("--------Persistance--------");
            Manager manager = new Manager(new Stub.Stub(), new DataContract.XmlPersist());
            manager.DataSave();

        }
    }
}