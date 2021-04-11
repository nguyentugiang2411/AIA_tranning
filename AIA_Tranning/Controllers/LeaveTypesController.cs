using AIA_Tranning.Common;
using AIA_Tranning.Data;
using AIA_Tranning.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AIA_Tranning.Controllers
{
    public class LeaveTypesController : Controller
    {
        private ILeaveTypesService _service;

        public LeaveTypesController(ILeaveTypesService service) {
            _service = service;
        }

        // GET: LeaveTypesController
        public ActionResult Index()
        {
            List<LeaveType> leaveTypes = _service.getAll().ToList();
            return View(leaveTypes);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            LeaveType leaveType = _service.getById(id);
            return View(leaveType);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveType collection)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return View(collection);
                }

                bool isSuccess = _service.create(collection);

                if (!isSuccess) {
                    ModelState.AddModelError(AIAConstant.ERROR, AIAMessage.ERROR);
                    return View(collection);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            LeaveType leaveType = _service.getById(id);
            return View(leaveType);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LeaveType collection)
        {
            try
            {
                bool isExist = _service.isExist(id);
                if (!isExist) {
                    ModelState.AddModelError(AIAConstant.ERROR, AIAMessage.NOT_EXIST);
                    return View(collection);
                }

                bool isSuccess = _service.update(collection);

                if (!isSuccess) {
                    // Show error and rollback
                    ModelState.AddModelError(AIAConstant.ERROR, AIAMessage.ERROR);
                    return View(collection);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveType collection)
        {
            try
            {
                bool isExist = _service.isExist(id);
                if (!isExist) {
                    ModelState.AddModelError(AIAConstant.ERROR, AIAMessage.NOT_EXIST);
                    return View(collection);
                }

                bool isSuccess = _service.delete(collection);
                if (!isSuccess) {
                    ModelState.AddModelError(AIAConstant.ERROR, AIAMessage.ERROR);
                    return View(collection);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
