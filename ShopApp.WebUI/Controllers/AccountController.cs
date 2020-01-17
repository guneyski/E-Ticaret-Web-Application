using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Extensions;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;
        private ICartService _cartService;
        public AccountController(ICartService cartService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
            _cartService = cartService;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //generate token
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });

                //send email
                await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Onaylayınız.", $"Lütfen hesabınızı onaylamak için linke <a href='http://localhost:5000{callbackUrl}'>tıklayınız.</a)");

                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesap Onayı",
                    Message = "Lütfen e-posta adresinize gelen link ile hesabınızı onaylayınız.",
                    Css = "warning"
                });

                return RedirectToAction("Login", "Account");
            }

            TempData.Put("message", new ResultMessage()
            {
                Title = "Kullanıcı Kaydı",
                Message = "Bilinmeyen hata oluştu lütfen tekrar deneyiniz. Galiba böyle bir hesap var..",
                Css = "warning"
            });
            //ModelState.AddModelError("", "Bilinmeyen hata oluştu lütfen tekrar deneyiniz. Galiba böyle bir hesap var.");
            return View(model);
        }
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Kullanıcı Girişi",
                    Message = "Böyle bir kullanıcı bulunamadık.",
                    Css = "warning"
                });
                //ModelState.AddModelError("", "Bu e-posta ile daha önce hesap oluşturulmamış.");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Kullanıcı Girişi",
                    Message = "Lütfen hesabınızı kayıt olduğunuz e-posta adresine gelen link ile onaylayınız.",
                    Css = "warning"
                });
                //ModelState.AddModelError("", "Lütfen hesabınızı kayıt olduğunuz e-posta adresine gelen link ile onaylayınız.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
            {
                return Redirect("~/");
            }

            TempData.Put("message", new ResultMessage()
            {
                Title = "Kullanıcı Girişi",
                Message = "E-posta veya parola yanlış lütfen kontrol ediniz.",
                Css = "warning"
            });
            //ModelState.AddModelError("", "E-posta veya parola yanlış");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData.Put("message", new ResultMessage()
            {
                Title = "Oturum kapatıldı",
                Message = "Oturumunuzu güvenli bir şekilde kapattınız.",
                Css = "success"
            });
            return Redirect("~/");
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesap Onayı",
                    Message = "Hesap onayı için bilgileriniz yanlış.",
                    Css = "danger"
                });
                return Redirect("~/");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    //create cart object
                    _cartService.InitializeCart(user.Id);

                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Hesap Onayı",
                        Message = "Hesabınız başarıyla onaylanmıştır. Hesap bilgilerinizle giriş yapabilirsiniz.",
                        Css = "success"
                    });
                    return RedirectToAction("Login");
                }
            }

            TempData.Put("message", new ResultMessage()
            {
                Title = "Hesap Onayı",
                Message = "Üzgünüz. Hesabınız onaylanamadı.",
                Css = "danger"
            });
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Parolamı Unuttum",
                    Message = "Bilgileriniz eksik veya hatalı.",
                    Css = "danger"
                });
                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Parolamı Unuttum",
                    Message = "Üzgünüz. Bu e-posta adresine sahip bir kullanıcı bulunamadı.",
                    Css = "danger"
                });
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                token = code
            });

            //send email
            await _emailSender.SendEmailAsync(Email, "Parola Sıfırlama", $"Parolanızı sıfırlamak için linke <a href='http://localhost:5000{callbackUrl}'>tıklayınız.</a)");

            TempData.Put("message", new ResultMessage()
            {
                Title = "Parolamı Unuttum",
                Message = "Parola yenilemek için e-posta hesabınıza mail gönderildi.",
                Css = "warning"
            });

            return RedirectToAction("Login", "Account");
        }
        public IActionResult ResetPassword(string token)
        {
            if (token == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var model = new ResetPasswordModel { Token = token };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Parola yenileme başarılı",
                    Message = "Parola başarıyla yenilendi giriş yapabilirsiniz.",
                    Css = "warning"
                });
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }
    }
}