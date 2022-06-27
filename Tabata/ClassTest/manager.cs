using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ClassTest
{
    public partial class Manager
    {
        public Manager(IPersistanceManager stub, IPersistanceManager xml)
        {
            Stub = stub;
            Xml = xml;
            DataLoad();
            exoSelect = exoSelected();
            progExoSelect = null;
            progSelect = prgmSelected();

            listExoReco.Add(ListExo[0]);
            listExoReco.Add(ListExo[1]);

            listProgReco.Add(ListPrgm[0]);
            listProgReco.Add(ListPrgm[1]);
        }

        /// <summary>
        /// Dépendances sur le gestionnaire de persistance
        /// </summary>
        public IPersistanceManager Stub { get; /*private*/ set; }
        public IPersistanceManager Xml { get; /*private*/ set; }


        /// <summary>
        /// Liste contenant les exos et les sports favoris + user
        /// </summary>


        /// <summary>
        /// Test 
        /// </summary>

        public Programs progSelect { get; set; }
        public Exos exoSelect { get; set; }
        public Exos progExoSelect { get; private set; }
        public User User { get; private set; }

        public List<Exos> ListExoReco { get { return listExoReco; }  set { listExoReco = value; } }
        List<Exos> listExoReco = new() { };

        public List<Programs> ListProgReco { get { return listProgReco; } set { listProgReco = value; } }
        List<Programs> listProgReco = new List<Programs> { };

        public List<Exos> ExoFav { get { return exoFav; } set { exoFav = value; } }
        List<Exos> exoFav = new List<Exos> { };

        public List<Programs> ProgFav { get { return progFav; } set { progFav = value; } }
        List<Programs> progFav = new List<Programs> { };

        /// <summary>
        /// Dépendances sur liste de sport
        /// </summary>

        public ReadOnlyCollection<Exos> ListExo { get; private set; }
        ReadOnlyCollection<Exos> listExo;

        public ReadOnlyCollection<Programs> ListPrgm { get; private set; }
        ReadOnlyCollection<Programs> listPrgm;



        public Exos exoSelected()
        {
            return ListExo[0];
        }

        public Programs prgmSelected()
        {
            return ListPrgm[0];
        }

        public void DataLoad()
        {
            var data = Xml.LoadData();
            var dataStub = Stub.LoadData();
            List<Exos> lexo = new List<Exos>();
            List<Programs> lprgm = new List<Programs>();

            foreach (Exos ex in dataStub.exo)
            {
                lexo.Add(ex);
                if (ex.Favorite) exoFav.Add(ex);
            }
            foreach (Programs prog in dataStub.prg)
            {
                lprgm.Add(prog);
                if (prog.Favorite) progFav.Add(prog);
            }

            ListPrgm = new ReadOnlyCollection<Programs>(lprgm);
            ListExo = new ReadOnlyCollection<Exos>(lexo);
            User = new(data.usr);
        }

        public void DataSave()
        {
            Xml.SaveData(User, ListExo, ListPrgm);
        }

    }
}
