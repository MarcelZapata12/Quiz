using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class EmpleadoController : Controller
    {
        IEmpleadoHelper _empleadoHelper;

        public EmpleadoController(IEmpleadoHelper empleadoHelper)
        {
            _empleadoHelper = empleadoHelper;
        }

        // GET: EmpleadoController
        public ActionResult Index()
        {
            var result = _empleadoHelper.GetEmpleados();
            return View(result);
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            var result = _empleadoHelper.GetEmpleado(id);
            return View(result);
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoViewModel empleado)
        {
            try
            {
                _empleadoHelper.Add(empleado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _empleadoHelper.GetEmpleado(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmpleadoViewModel empleado)
        {
            try
            {
                if (id != empleado.EmpleadoId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _empleadoHelper.Update(empleado);
                    return RedirectToAction(nameof(Index));
                }
                return View(empleado);
            }
            catch
            {
                return View(empleado);
            }
        }

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _empleadoHelper.GetEmpleado(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmpleadoViewModel empleado)
        {
            try
            {
                _empleadoHelper.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(empleado);
            }
        }
    }
}
