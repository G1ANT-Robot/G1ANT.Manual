using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Manual.Sync
{
    public class Section
    {
        public List<string> Sections { get; set; } = new List<string>();
        public List<string> Files { get; set; } = new List<string>();
        public List<string> Tooltips { get; set; } = new List<string>();
        public List<string> Addons { get; set; } = new List<string>();
    }
}
