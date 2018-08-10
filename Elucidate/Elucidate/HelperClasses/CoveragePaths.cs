using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elucidate.HelperClasses
{
    public enum PathTypeEnum { Source, Content, Parity }

    public class CoveragePath
    {
        public string Path { get; set; }
        public PathTypeEnum PathType { get; set; }
    }

}
