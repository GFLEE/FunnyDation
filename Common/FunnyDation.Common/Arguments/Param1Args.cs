using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common
{
    public class Param1Args<T> : EventArgs
    {
        public Param1Args(T pram)
        {
            this.Param = pram;
        }

        public T Param { get; set; }
    }
}
