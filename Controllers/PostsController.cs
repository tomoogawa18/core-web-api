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

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null){
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.PostId == id);

            if(post == null){
                return NotFound();
            }

            return View(post);
        }

        public async Task<IActionResult> Edit(int? id){

            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Post.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId, Subject, Content")] Post post)
        {
            if(id != post.PostId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try{
                    _context.Update(post);
                    await _context.SaveChangesAsync();

                }catch(DbUpdateConcurrencyException){
                    if(!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.PostId == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);

            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));

        }
    }
}
