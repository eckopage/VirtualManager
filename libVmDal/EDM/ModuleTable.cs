//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VM.DataAccessLayer.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class ModuleTable
    {
        public ModuleTable()
        {
            this.ModuleProjectAssociation = new HashSet<ModuleProjectAssociation>();
        }
    
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public string ModuleDLLname { get; set; }
        public System.DateTime Created { get; set; }
        public string Version { get; set; }
        public string DeveloperName { get; set; }
        public bool StableVersion { get; set; }
        public Nullable<System.DateTime> UpdatedDLL { get; set; }
        public string PathToDLL { get; set; }
    
        public virtual ICollection<ModuleProjectAssociation> ModuleProjectAssociation { get; set; }
    }
}
