using ExamenPrimera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenPrimera.Controllers
{
    public class ProductoController : Controller
    {
        EXAMENPRIMERAEntities cnx;
        public ProductoController()
        {
            cnx = new EXAMENPRIMERAEntities();
        }
        public ActionResult Formulario()
        {
            return View();
        }
        public ActionResult Guardar(string nombreproducto, string codbarra, string familia, string precio, string descuento, string descripcion)
        {

            ExamenPrimera.Models.Productos ingresoproductos = new ExamenPrimera.Models.Productos()
            {
                NombreProducto = nombreproducto,
                CodBarra = codbarra,
                Familia = familia,
                Precio = precio,
                Descuento = descuento,
                Descripcion = descripcion
            };

            cnx.Productos.Add(ingresoproductos);
            cnx.SaveChanges();

            return View("Listado", ListadoProductos());
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
        public ActionResult ListadoClientes()
        {
            ClienteController ctl = new ClienteController();
            ActionResult resultado2 = ctl.Listado();
            return resultado2;
        }
        public ActionResult Listado()
        {

            return View("Listado", ListadoProductos());
        }
        public ActionResult Ficha(int id)
        {
            Productos vaca = (Productos)cnx.Productos.Where(x => x.IDProducto.Equals(id)).First();

            return View("Ficha", vaca);
        }
        public ActionResult Eliminar(string nombre)
        {

            cnx.Productos.Remove(cnx.Productos.Where(x => x.IDProducto.Equals(nombre)).First());
            cnx.SaveChanges();
            return View("Listado", cnx.Productos.ToList());
        }



        private List<ExamenPrimera.Models.Productos> ListadoProductos()
        {

            cnx.Database.Connection.Open();
            List<ExamenPrimera.Models.Productos> vacas = cnx.Productos.ToList();

            cnx.Database.Connection.Close();

            return vacas;
        }
    }
}