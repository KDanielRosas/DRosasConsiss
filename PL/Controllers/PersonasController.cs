using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class PersonasController : Controller
    {
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.Personas persona)
        {
            persona.Opcion = 1;
            persona.Habilidades = (persona.HPrincipal) + " / " + (persona.HSecundaria);
            bool result = BL.Personas.CRUDPersonas(persona);

            if (result)
            {
                ViewBag.Message = "Se almacenó la información correctamente";
                return View("Modal");
            }
            else
            {
                ViewBag.Message = "Error al registrar la información";
                return View("Modal");
            }
        }
    }
}
