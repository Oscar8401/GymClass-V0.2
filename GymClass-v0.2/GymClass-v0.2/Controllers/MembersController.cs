using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GymClass_v0._2.Models;
using GymClass_v0._2.ViewModel;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace GymClass_v0._2.Controllers
{
    /// <summary>
    /// A web API2 Controller
    /// </summary>
    [Authorize(Roles ="admin")]
    public class MembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Members
        public ActionResult Index()
        {
            List<Members> Memberlist = new List<Members>();
            foreach (var x in db.Users.ToList())
            {
                Members Member = new Members(x);
                Memberlist.Add(Member);
            }
            return View(Memberlist);
        }

        // GET: Members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationuser = db.Users.Find(id);
            if (applicationuser == null)
            {
                return HttpNotFound();
            }
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ICollection<string> rolename = userManager.GetRoles(applicationuser.Id);
            Members member = new Members(applicationuser);
            member.MemberRole = rolename;
            return View(member);
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
