namespace EXPRACU2_LANCHIPA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    //instanciar
    using System.Linq;
    using System.Data.Entity;

    [Table("Persona")]
    public partial class Persona
    {
        [Key]
        public int persona_id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        public bool sexo { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_nac { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(250)]
        public string direccion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }


        //Metodo Listar
        public List<Persona> Listar()
        {
            var objPersona = new List<Persona>();
            try
            {
                using (var db = new Modelo_Examen())
                {
                    objPersona = db.Persona.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objPersona;
        }

        //Metodo Obtener
        public Persona Obtener(int id)//retorna solo un objeto
        {
            var objPersona = new Persona();
            try
            {
                using (var db = new Modelo_Examen())
                {
                    objPersona = db.Persona
                                    .Where(x => x.persona_id == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objPersona;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Modelo_Examen())
                {
                    if (this.persona_id > 0)//sis existe un valor mayor a cero es porque existe registro
                    {
                        db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        //SINO EXISTE EL REGISTRO LO GRABA(nuevo)
                        db.Entry(this).State = System.Data.Entity.EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //metodo Eliminar 
        public void Eliminar()
        {
            try
            {
                using (var db = new Modelo_Examen())
                {
                    db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
