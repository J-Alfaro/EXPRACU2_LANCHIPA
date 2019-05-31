using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EXPRACU2_LANCHIPA.Models;

namespace EXPRACU2_LANCHIPA.Controllers
{    
    public class PersonaController : Controller
    {
        //Instanciar la clase Semestre
        private Persona objPersona = new Persona();
        // Accion Index
        public ActionResult Index()
        {
            return View(objPersona.Listar());
        }
        // Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Persona() //agrega un nuevo objeto
                            : objPersona.Obtener(id)
                );
        }
        //Action Guardar
        public ActionResult Guardar(Persona objPersona)
        {
            if (ModelState.IsValid)
            {
                objPersona.Guardar();
                return Redirect("~/Persona");
            }
            else
            {
                return View("~/Views/Persona/AgregarEditar");
            }
        }
        // Accion Ver
        public ActionResult Ver(int id)
        {
            return View(objPersona.Obtener(id));
        }        
        //Action Eliminar
        public ActionResult Eliminar(int id)
        {
            objPersona.persona_id = id;
            objPersona.Eliminar();
            return Redirect("~/Persona");
        }

    }
}