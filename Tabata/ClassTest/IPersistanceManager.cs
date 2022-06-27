using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ClassTest
{
    public interface IPersistanceManager
    {
        (User usr, ReadOnlyCollection<Exos> exo, ReadOnlyCollection<Programs> prg) LoadData();

        void SaveData(User usr, ReadOnlyCollection<Exos> exo, ReadOnlyCollection<Programs> prg);
    }
}
