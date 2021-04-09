using AIA_Tranning.Contracts;
using AIA_Tranning.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.Controllers
{
    public class LeaveTypesController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveTypesController(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: LeaveTypesController
        public ActionResult Index()
        {
            List<LeaveType> leaveTypes = _unitOfWork.leaveTypes.findAll().ToList();
            return View(_mapper.Map<List<LeaveType>, List<LeaveType>>(leaveTypes));
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            LeaveType leaveType = _unitOfWork.leaveTypes.findById(id);
            return View(_mapper.Map<LeaveType, LeaveType>(leaveType));
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

                LeaveType leaveType = _mapper.Map<LeaveType>(collection);
                leaveType.DateCreated = DateTime.Now;

                bool isSuccess = _unitOfWork.leaveTypes.create(leaveType);

                if (!isSuccess) {
                    ModelState.AddModelError("Error", "Error");
                    return View(collection);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            LeaveType leaveType = _unitOfWork.leaveTypes.findById(id);
            return View(_mapper.Map<LeaveType, LeaveType>(leaveType));
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LeaveType collection)
        {
            try
            {
                bool isExist = _unitOfWork.leaveTypes.isExist(id);
                if (!isExist) {
                    ModelState.AddModelError("Error", "Not Exist");
                    return View(collection);
                }

                LeaveType leaveType = _mapper.Map<LeaveType>(collection);
                bool isSuccess = _unitOfWork.leaveTypes.update(leaveType);

                if (!isSuccess) {
                    // Show error and rollback
                    ModelState.AddModelError("Error", "Error");
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
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
