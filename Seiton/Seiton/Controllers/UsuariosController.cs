using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seiton.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;


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

        //  LOGIN
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {

            var dados = await _context.Usuarios.FirstOrDefaultAsync
                (u => u.NomeUsuario == usuario.NomeUsuario);

            if (dados == null || string.IsNullOrEmpty(usuario.Senha) || string.IsNullOrEmpty(dados.Senha))
            {
                ViewBag.Message = "*Usuário e/ou senha inválidos!";
                return View();
            }

            bool senhaOk = BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha);


            if (senhaOk)
            {

                var claims = new List<Claim> 
                {
                    new Claim(ClaimTypes.Name, dados.NomeUsuario),
                    new Claim(ClaimTypes.NameIdentifier, dados.Id.ToString())
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);

                return RedirectToAction("Logado", "Logados");
            }

            else
            {
                ViewBag.Message = "*Usuário e/ou senha inválidos!";
            }

            return View();
        }


        //  LOGOUT 

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, NomeUsuario, Email, Senha, ConfirmacaoSenha")] Usuario usuario) {
            if (ModelState.IsValid) {
                // Verifique se o nome de usuário já existe no banco de dados.
                if (_context.Usuarios.Any(u => u.NomeUsuario == usuario.NomeUsuario)) {
                    ModelState.AddModelError(string.Empty, "*O nome de usuário já está em uso. Escolha outro nome de usuário.");
                    return View(usuario);
                }

                if (usuario.Senha == usuario.ConfirmacaoSenha) {
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                }
                else {
                    ModelState.AddModelError(string.Empty, "*A senha e a confirmação de senha não coincidem.");
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeUsuario,Email,Senha,ConfirmacaoSenha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.NomeUsuario),
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
                    };

                    var usuarioIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                    var props = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(principal, props);

                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    _context.Add(usuario);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Logado", "Logados");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'AppDbContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool UsuarioExists(int id)
        {
          return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
