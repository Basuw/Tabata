using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTest
{
    public class fav
    {
        public fav(List<Exos> exosList, List<Programs> progsList) {
            ProgsList = progsList;
            ExosList = exosList;
        }

        private List<Exos> exosList;
        public List<Exos> ExosList { get { return exosList; } set { exosList = value; } }

        private List<Programs> progsList;
        public List<Programs> ProgsList { get { return progsList; } set { progsList = value; } }

    }
}
