using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Core.Model;
using Inventario.WEB.Models.Cuenta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Inventario.WEB.Controllers
{
    public class CuentaController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ILogger<CuentaController> _logger;
        public CuentaController(UserManager<Usuario> userManager,
          SignInManager<Usuario> signInManager,
          RoleManager<IdentityRole> roleManager,
          ILogger<CuentaController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVm login)
        {
            string returnUrl = login.ReturnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    login.Usuario,
                    login.Contrasena,
                    login.PersistirCookie,
                    false);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("El usuario se encuentra bloqueado.");
                    ModelState.AddModelError(string.Empty, "Ha ocurrido un error con el Suscrito.");
                    return View(login);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Las credenciales ingresadas no son válidas.");
                    return View(login);
                }
            }
            return View(login);
        }
        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            returnUrl = returnUrl ?? Url.Content("~/");

            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Registro(string returnUrl = null)
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro()
        {
            bool existeRolAdmin = await _roleManager.RoleExistsAsync("admin");

            if (existeRolAdmin == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
            }

            Usuario usuario = new Usuario()
            {
                Email = "ar929092@gmail.com",
                UserName = "admin",
                
            };

            var result = await _userManager.CreateAsync(usuario, "enohp4407$");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(usuario, "admin");
            }

            AddErrors(result);

            return RedirectToAction(nameof(Login));
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}