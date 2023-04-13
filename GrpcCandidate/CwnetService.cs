using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModelServer
{
    public class CwnetService : ICwnetService
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
