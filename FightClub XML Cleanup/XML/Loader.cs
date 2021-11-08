using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FightClub_XML_Cleanup.XML
{
    class Loader
    {

        string directory = $"{System.IO.Directory.GetCurrentDirectory()}\\XML\\Source";
        FileInfo[] files;
        public Loader()
        {
            files = new DirectoryInfo(directory).GetFiles();
        }
    }
}
