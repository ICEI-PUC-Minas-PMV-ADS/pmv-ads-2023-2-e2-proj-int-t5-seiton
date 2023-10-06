using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seiton.Models;
using System.Security.Claims;
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


        ///////  LOGIN ////////
       
        
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario) {

            var dados = await _context.Usuarios
                .FindAsync(usuario.Id);

            if (dados == null) {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
                return View();
            }

            bool senhaOk = BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha);

            if (senhaOk) {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, dados.NomeUsuario),
                     new Claim(ClaimTypes.NameIdentifier, dados.Id.ToString()),
                      new Claim(ClaimTypes.Role, dados.Email.ToString())
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties {

                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/");
            }

            else {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
            }

            return View();
        }


        ////////////   LOGOUT   //////////// 

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Usuarios");
        }


        ////////////////////////////////////

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
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
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
