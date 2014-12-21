using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCG.ProductComparer.Repositories {
    class CompareRepository: Core.CompareTemplate<Interfaces.ICompareRepository> {
        protected override void DoContext() {
            base.DoContext();
        } 
    }
}
