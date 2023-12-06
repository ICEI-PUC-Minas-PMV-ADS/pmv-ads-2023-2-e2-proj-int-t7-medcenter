using medcenter_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace medcenter_backend.Controllers
{
    public class FeedbackControler : Controller
    {
        AppDbContext context;
        public FeedbackControler()
        {
			context = new AppDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {   FeedbackViewModel model = new FeedbackViewModel();
            model.Answer=Common.GetAnswer();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create (FeedbackViewModel model ) {
           if (ModelState.IsValid)
            {
                context.Feedbacks.Add(new Feedback() { Answer = model.Select, Comment = model.Comment, Email = model.Email, FullName = model.FullName});
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
			model.Answer = Common.GetAnswer();
			return View(model);
        }
       
    }
}
