//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ecole_management_data
{
    using System;
    using System.Collections.Generic;
    
    public partial class professeurs
    {
        public professeurs()
        {
            this.professeur_cours = new HashSet<professeur_cours>();
        }
    
        public int id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    
        public virtual ICollection<professeur_cours> professeur_cours { get; set; }
    }
}
