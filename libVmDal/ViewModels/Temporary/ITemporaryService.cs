using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.DataAccessLayer.Common;

namespace VM.DataAccessLayer.ViewModels.Temporary {
    public interface ITemporaryService : IService {
        List<TemporaryViewModel> GetTemporary();
    }
}
