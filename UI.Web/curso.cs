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
    
    public partial class curso
    {
        public curso()
        {
            this.alumnos_inscripciones = new HashSet<alumnos_inscripciones>();
            this.docentes_cursos = new HashSet<docentes_cursos>();
        }
    
        public int id_curso { get; set; }
        public int id_materia { get; set; }
        public int id_comision { get; set; }
        public int anio_calendario { get; set; }
        public int cupo { get; set; }
    
        public virtual ICollection<alumnos_inscripciones> alumnos_inscripciones { get; set; }
        public virtual comisione comisione { get; set; }
        public virtual materia materia { get; set; }
        public virtual ICollection<docentes_cursos> docentes_cursos { get; set; }
    }
}
