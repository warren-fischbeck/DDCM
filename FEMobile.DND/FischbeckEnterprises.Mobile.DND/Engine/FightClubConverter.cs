using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FischbeckEnterprises.Mobile.DND.Engine
{
    class FightClubConverter
    {
        private string _directory;
        private FileInfo[] _files;

        public FightClubConverter()
        {
            this._directory  = $"{System.IO.Directory.GetCurrentDirectory()}\\FightClubXML";
            this._files = new DirectoryInfo(_directory).GetFiles();
        }
    }
}
