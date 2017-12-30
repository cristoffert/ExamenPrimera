using ExamenPrimera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenPrimera.Controllers
{
    public class ClienteController : Controller
    {
        EXAMENPRIMERAEntities cnx;
        public ClienteController()
        {
            cnx = new EXAMENPRIMERAEntities();
        }
        public ActionResult Formulario()
        {
            return View();
        }
        public ActionResult Guarda(string rut, string nombrecliente, string apellido, string direccion, string tipo)
        {

            ExamenPrimera.Models.Clientes ingresoclientes = new ExamenPrimera.Models.Clientes()
            {
                Rut = rut,
                NombreCliente = nombrecliente,
                ApellidoCliente = apellido,
                Direccion = direccion,
                Tipo = tipo
            };

            cnx.Clientes.Add(ingresoclientes);
            cnx.SaveChanges();

            return View("Listado", ListadoClientes());
        }
        public ActionResult Listado()
        {

            return View("Listado", ListadoClientes());
        }
        public ActionResult Ficha(int id)
        {
            Clientes vaca = (Clientes)cnx.Clientes.Where(x => x.IDCliente.Equals(id)).First();

            return View("Ficha", vaca);
        }
        public ActionResult Eliminar(string nombre)
        {

            cnx.Clientes.Remove(cnx.Clientes.Where(x => x.IDCliente.Equals(nombre)).First());
            cnx.SaveChanges();
            return View("Listado", cnx.Clientes.ToList());
        }



        private List<ExamenPrimera.Models.Clientes> ListadoClientes()
        {

            cnx.Database.Connection.Open();
            List<ExamenPrimera.Models.Clientes> vacas = cnx.Clientes.ToList();

            cnx.Database.Connection.Close();

            return vacas;
        }
    }
}