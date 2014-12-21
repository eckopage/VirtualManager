using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCG.ProductComparer.Core {
    abstract class CompareTemplate<T> where T: Interfaces.ICompareRepository   {
        protected virtual void DoContext();
        
    }
}
