using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seiton.Models;

namespace Seiton.Controllers
{
    public class UsuariosController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly AppDBContext _context;

        public UsuariosController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());


        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeUsuario,Email,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }


        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
                return NotFound();

            var dados =  await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();
            
            return View(dados);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Usuario usuario) 
        {
           if (id != usuario.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
                return View();
        }
    }
}
