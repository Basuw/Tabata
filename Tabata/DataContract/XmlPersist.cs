using ClassTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace DataContract
{
    public class XmlPersist : IPersistanceManager
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(),"XML");
        public string FileName { get; set; } = "Tabata.xml";
        public (User usr, ReadOnlyCollection<Exos> exo, ReadOnlyCollection<Programs> prg) LoadData()
        {
            if (!Directory.Exists(FilePath))
            {
                throw new FileNotFoundException("File note found");
            }
            var serializer = new DataContractSerializer(typeof(User));
            User usr;
            using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
            {
                usr = serializer.ReadObject(s) as User;
            }
            List<Exos> exo = new List<Exos>();
            List<Programs> prg = new List<Programs>();
            ReadOnlyCollection<Exos> exos = new ReadOnlyCollection<Exos>(exo);
            ReadOnlyCollection<Programs> prgm = new ReadOnlyCollection<Programs>(prg);
            return (usr, exos, prgm);
        }
        public void SaveData(User usr, ReadOnlyCollection<Exos> exo, ReadOnlyCollection<Programs> prg)
        {
            var serializer = new DataContractSerializer(typeof(User));
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, usr);
                }
            }
        }


        /*        public void SaveData(User usr, ReadOnlyCollection<Exos> exo, ReadOnlyCollection<Programs> prg)
                {
                    var serializer = new DataContractSerializer(typeof(UserPrgm));
                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }
                    List<Programs> programs = new List<Programs>();
                    foreach (Programs prgm in prg)
                    {
                        programs.Add(prgm);
                    }
                    UserPrgm usrprgm = new(usr, programs);
                    var settings = new XmlWriterSettings() { Indent = true };
                    using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
                    {
                        using (XmlWriter writer = XmlWriter.Create(tw, settings))
                        {
                            serializer.WriteObject(writer, usrprgm);
                        }
                    }
                }
                public (User usr, ReadOnlyCollection<Exos> exo, ReadOnlyCollection<Programs> prg) LoadData()
                {
                    if (!Directory.Exists(FilePath))
                    {
                        throw new FileNotFoundException("File note found");
                    }
                    var serializer = new DataContractSerializer(typeof(UserPrgm));
                    UserPrgm usrprgm;
                    using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
                    {
                        usrprgm = serializer.ReadObject(s) as UserPrgm;
                    }
                    List<Exos> exo = new List<Exos>();

                    List<Exos> exfv = new List<Exos>();
                    List<Programs> prgfv = new List<Programs>();
                    ReadOnlyCollection<Exos> exos = new ReadOnlyCollection<Exos>(exo);
                    ReadOnlyCollection<Programs> prgm = new ReadOnlyCollection<Programs>(usrprgm.PrgmList);
                    return (usrprgm.Usr, exos, prgm);
                }*/
    }
}
