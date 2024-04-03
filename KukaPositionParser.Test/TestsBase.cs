using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KukaPositionParser.Test
{
    public abstract class TestsBase : IDisposable
    {

        public string TestDirectory { get; }
        protected TestsBase()
        {
            // Get Test Directory
            var directory = new DirectoryInfo("../../../TestFiles");
            TestDirectory = directory.FullName;



        }
        public void Dispose()
        {

        }
    }
}
