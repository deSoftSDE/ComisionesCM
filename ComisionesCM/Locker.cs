using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComisionesCM
{
    public class Locker //: ILocked
    {

        public bool IsCanceled { get; set; }

        public Locker()
        {
            IsCanceled = false;
        }
    }
}
