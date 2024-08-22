using Microsoft.AspNetCore.Mvc;
using MVC.Contracts;
using MVC.Models;

namespace MVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }
        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();
            return View(leaveTypes);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM createLeave)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(createLeave);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", response.ValidationErrors);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);


            }
            return View(createLeave);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leaveType);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveType(id, leaveType);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", response.ValidationErrors);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(leaveType);
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
