using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleMVCApp.Models;

namespace SampleMVCApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly SampleMVCAppContext _context;

        public PostsController(SampleMVCAppContext context)
        {
            _context = context;
        }

        // GET: People
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Post.ToListAsync());
        }
        
        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId, Subject, Content")] Post post)
        {
            if(ModelState.IsValid){
                _context.Add(post);
                await _context.SaveChangesAsync();   
                return RedirectToAction(nameof(Index)); 
            }

            return View(post);
        }

    }
}
