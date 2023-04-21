using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using JavieraCanalesET.Models;
namespace JavieraCanalesET.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            List<UsuarioView> lista;
            using (BDPruebaJCEntities db= new BDPruebaJCEntities())
            {
                lista= (
                    from a in db.Usuario select new UsuarioView
                    {
                        Id = a.id,
                        Nombre = a.nombre,
                        Apellido= a.apellido,
                        Edad= a.edad.ToString(),
                        Fono = a.fono.ToString(),
                        Direccion = a.direccion
                    }
                    ).ToList();
            }
            return View(lista);
        }

        public ActionResult Agregar()
        {
            return View();
        }
        public ActionResult Agregar1(Usuario model)
        {
            using (BDPruebaJCEntities db= new BDPruebaJCEntities())
            {
                var UserTable = new Usuario();
                UserTable.nombre= model.nombre;
                UserTable.apellido= model.apellido;
                UserTable.edad= model.edad;
                UserTable.fono= model.fono;
                UserTable.direccion= model.direccion;
                db.Usuario.Add(UserTable);
                db.SaveChanges();
            }
            return Redirect("~/Usuarios/Index");
        }

        public ActionResult Editar(int id)
        {
            UsuarioView model= new UsuarioView();
            using (BDPruebaJCEntities db = new BDPruebaJCEntities())
            {
                var UserTable = db.Usuario.Find(id);
                model.Nombre = UserTable.nombre;
                model.Apellido = UserTable.apellido;
                model.Edad = UserTable.edad.ToString();
                model.Fono = UserTable.fono.ToString();
                model.Direccion = UserTable.direccion;
                model.Id = UserTable.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(Usuario model)
        {
            using (BDPruebaJCEntities db = new BDPruebaJCEntities())
            {
                var UserTable = db.Usuario.Find(model.id);
                UserTable.nombre = model.nombre;
                UserTable.apellido = model.apellido;
                UserTable.edad = model.edad;
                UserTable.fono = model.fono;
                UserTable.direccion = model.direccion;
                db.Entry(UserTable).State= System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect("~/Usuarios/Index");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (BDPruebaJCEntities db = new BDPruebaJCEntities())
            {
                var UserTable = db.Usuario.Find(id);
                db.Usuario.Remove(UserTable);
                db.SaveChanges();
            }
                return Redirect("~/Usuarios/Index");
        }
    }
}