//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI.Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class plane
    {
        public plane()
        {
            this.comisiones = new HashSet<comisione>();
            this.materias = new HashSet<materia>();
            this.usuarios = new HashSet<usuario>();
        }
    
        public int id_plan { get; set; }
        public string desc_plan { get; set; }
        public int id_especialidad { get; set; }
    
        public virtual ICollection<comisione> comisiones { get; set; }
        public virtual especialidade especialidade { get; set; }
        public virtual ICollection<materia> materias { get; set; }
        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
