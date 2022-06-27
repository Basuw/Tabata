using ClassTest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [DataContract]
    public class UserPrgm
    {
        public UserPrgm(User usr, List<Programs> prgmList)
        {
            Usr = usr;
            PrgmList = prgmList;
        }

        [DataMember]
        public User Usr { get; set; }

        [DataMember]
        public List<Programs> PrgmList { get; set; }
    }
}
