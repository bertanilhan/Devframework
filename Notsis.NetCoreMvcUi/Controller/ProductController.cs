using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notsis.Business.Abstract;
using Notsis.Core.CrossCuttingConcerns.Security;
using Notsis.Entities.Concrete;
using Notsis.NetCoreMvcUi.Models;

namespace Notsis.NetCoreMvcUi.Controller
{
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IProductService _productService;
        private readonly IServiceProvider _provider;
        public ProductController(IProductService productService, IServiceProvider provider)
        {
            _productService = productService;
            _provider = provider;
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(new ProductListViewModel
            {
                Products = _productService.GetList()
            });
            
        }

        public IActionResult Add()
        {
            _productService.Add(new Product{CategoryId = 1, ProductName = "Elma",UnitPrice = 22});
            return Content("Added");
        }


        public IActionResult SingIn()
        {
            var userIdentity = new Identity()
            {
                Name = "Bertan",
                LastName = "İlhan",
                Email = "bertanilhan@gmail.com",
                Password = "123456",
                Roles = new []{"Admin"}
            };


            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.AuthorizationDecision,"Product.Read"),
                new Claim(ClaimTypes.AuthorizationDecision,"Product.Write"),
                new Claim(ClaimTypes.AuthorizationDecision,"Category.Read"),
                new Claim(ClaimTypes.Role,"Admin")
            };
            

            var claimsIdentity = new ClaimsIdentity(userIdentity);

            //claims, CookieAuthenticationDefaults.AuthenticationScheme olmaz ise [Authrize] çalışmıyor
            var claimsIdentity2 = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(new[]
            {
                claimsIdentity,
                claimsIdentity2
            });
            

            //CookieAuthenticationDefaults.AuthenticationScheme şeması HttpContext.User'ın default data çektiği cookiedir.
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);


            //Thread safe olmadığı için kayboluyor.
            //Thread.CurrentPrincipal = claimsPrincipal;

            return Content("Singed");
        }
    }
}