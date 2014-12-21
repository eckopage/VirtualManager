using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.DataAccessLayer.Common;

namespace VM.DataAccessLayer.ViewModels.Temporary {
    public class TemporaryService : ITemporaryService {
        private IAppDatabaseContext _context;

        public TemporaryService(IAppDatabaseContext context) {
            _context = context;
        }

        /// <summary>
        /// Gets all temporary enities from database.
        /// </summary>
        /// <returns>List of temporaries</returns>
        public List<TemporaryViewModel> GetTemporary() {
            using(var db = _context.CreateNewMainContext()) {
                // add 2 records if empty table
                if(!db.TemporaryTable.Any()) {
                    var temporaryModel = db.TemporaryTable.Create();
                    temporaryModel.Name = "Test 1";
                    db.TemporaryTable.Add(temporaryModel);

                    temporaryModel = db.TemporaryTable.Create();
                    temporaryModel.Name = "Test 2";
                    db.TemporaryTable.Add(temporaryModel);

                    var isOk = db.SaveChanges();
                    Debug.Assert(isOk > 0, "Data has been not saved.");// stop on condition false
                }

                var table = db.TemporaryTable.Select(a =>
                    new TemporaryViewModel {
                        Id = a.Id,
                        Name = a.Name
                    }).ToList();

                return table;
            }
        }
    }
}