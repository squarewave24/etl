using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etl.ConsoleApp.Framework
{
    public interface IExtractor
    {
        DataTable Extract();
    }
}
