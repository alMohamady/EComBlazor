using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.Exceptions
{
    public class ItemNotFoundEx(string msg): Exception(msg)
    {
    }
}
