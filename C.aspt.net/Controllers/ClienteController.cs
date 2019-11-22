using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace C.aspt.net.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult buscaCliente()
        {
            try
            {

                CNCliente clientes = new CNCliente();
                IEnumerable<CECliente> data = clientes.listarCliente();
                return Json(data);
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {

            }

        }

        [HttpPost]
        public JsonResult insCliente(string xml)
        {
            try
            {
                CNCliente clientes = new CNCliente();
                IEnumerable<CECliente> data = clientes.insCliente(xml);
                return Json(data);
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {

            }

        }


    }


}