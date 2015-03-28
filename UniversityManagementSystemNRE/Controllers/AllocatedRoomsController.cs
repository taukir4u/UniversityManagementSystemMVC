using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemNRE.Models;

namespace UniversityManagementSystemNRE.Controllers
{ 
    public class AllocatedRoomsController : Controller
    {
        private UniMenSysDbContext db = new UniMenSysDbContext();

        //
        // GET: /AllocatedRooms/

        public ViewResult Index()
        {
            var allocatedroomdbset = db.AllocatedRoomDbSet.Include(a => a.Course).Include(a => a.Room).Include(a => a.WeekDay);
            return View(allocatedroomdbset.ToList());
        }

        //
        // GET: /AllocatedRooms/Details/5

        public ViewResult Details(int id)
        {
            AllocatedRoom allocatedroom = db.AllocatedRoomDbSet.Find(id);
            return View(allocatedroom);
        }

        //
        // GET: /AllocatedRooms/Create

        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode");
            ViewBag.CourseID = new SelectList("", "CourseID", "CourseCode");
            ViewBag.RoomID = new SelectList(db.RoomDbSet, "RoomID", "RoomNo");
            ViewBag.WeekDayID = new SelectList(db.WeekDayDbSet, "WeekDayID", "DayName");
            return View();
        } 

        //
        // POST: /AllocatedRooms/Create

        [HttpPost]
        public ActionResult Create(AllocatedRoom allocatedroom)
        {
            

            if (ModelState.IsValid)
            {
                db.AllocatedRoomDbSet.Add(allocatedroom);
                db.SaveChanges();
                   
               
                return RedirectToAction("Index");
            }
           
            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode");
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", allocatedroom.CourseID);
            ViewBag.RoomID = new SelectList(db.RoomDbSet, "RoomID", "RoomNo", allocatedroom.RoomID);
            ViewBag.WeekDayID = new SelectList(db.WeekDayDbSet, "WeekDayID", "DayName", allocatedroom.WeekDayID);
            return View(allocatedroom);
        }

        public PartialViewResult LoadCourseDropDown(int? departmentID)
        {
            if (departmentID != null)
                ViewBag.CourseID = new SelectList(db.CourseDbSet.Where(c => c.DepartmentID == departmentID), "CourseID", "CourseCode");
            return PartialView("~/Views/AllocatedRooms/_LoadCourseDropDown.cshtml");
        }

        

        public ActionResult ViewRoomAllocation()
        {
            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode");
            List<Course> CourseList = db.CourseDbSet.ToList();

            foreach (var aCourse in CourseList)
            {
                aCourse.AllocatedRoomList
                    = db.AllocatedRoomDbSet.Include(a => a.Room).Include(a => a.WeekDay)
                    .Where(a => a.CourseID == aCourse.CourseID).ToList();
            }

            return View(CourseList);
        }

        public PartialViewResult RoomFilter(int? departmentID)
        {
            List<Course> CourseList;
            if (departmentID != null)
            {
                CourseList = db.CourseDbSet.Where(c => c.DepartmentID == departmentID).ToList(); 
            }
            else
            {
                CourseList = db.CourseDbSet.ToList();
            }

            foreach (var aCourse in CourseList)
            {
                aCourse.AllocatedRoomList
                    = db.AllocatedRoomDbSet.Include(a => a.Room).Include(a => a.WeekDay)
                    .Where(a => a.CourseID == aCourse.CourseID).ToList();
            }

            return PartialView("~/Views/AllocatedRooms/_RoomFilter.cshtml", CourseList);
        }

        //
        // GET: /AllocatedRooms/Edit/5
 
        public ActionResult Edit(int id)
        {
            AllocatedRoom allocatedroom = db.AllocatedRoomDbSet.Find(id);
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", allocatedroom.CourseID);
            ViewBag.RoomID = new SelectList(db.RoomDbSet, "RoomID", "RoomNo", allocatedroom.RoomID);
            ViewBag.WeekDayID = new SelectList(db.WeekDayDbSet, "WeekDayID", "DayName", allocatedroom.WeekDayID);
            return View(allocatedroom);
        }

        //
        // POST: /AllocatedRooms/Edit/5

        [HttpPost]
        public ActionResult Edit(AllocatedRoom allocatedroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allocatedroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", allocatedroom.CourseID);
            ViewBag.RoomID = new SelectList(db.RoomDbSet, "RoomID", "RoomNo", allocatedroom.RoomID);
            ViewBag.WeekDayID = new SelectList(db.WeekDayDbSet, "WeekDayID", "DayName", allocatedroom.WeekDayID);
            return View(allocatedroom);
        }

        //
        // GET: /AllocatedRooms/Delete/5
 
        public ActionResult Delete(int id)
        {
            AllocatedRoom allocatedroom = db.AllocatedRoomDbSet.Find(id);
            return View(allocatedroom);
        }

        //
        // POST: /AllocatedRooms/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            AllocatedRoom allocatedroom = db.AllocatedRoomDbSet.Find(id);
            db.AllocatedRoomDbSet.Remove(allocatedroom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}