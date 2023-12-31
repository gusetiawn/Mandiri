﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssetManagementClient.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Menu/RequestItem")]
        public IActionResult RequestItem()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;
            var firstName = jwt.Claims.First(c => c.Type == "FirstName").Value;
            var lastName = jwt.Claims.First(c => c.Type == "LastName").Value;
            ViewData["id"] = id;
            ViewData["firstName"] = firstName;
            ViewData["lastName"] = lastName;
            return View();
        }


        [Route("Settings/Profile/Employee")]
        public IActionResult YourAccount()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;
            var firstName = jwt.Claims.First(c => c.Type == "FirstName").Value;
            var lastName = jwt.Claims.First(c => c.Type == "LastName").Value;
            ViewData["id"] = id;
            ViewData["firstName"] = firstName;
            ViewData["lastName"] = lastName;

            return View();
        }

        [Route("Settings/Security/Employee")]
        public IActionResult Security()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;
            var firstName = jwt.Claims.First(c => c.Type == "FirstName").Value;
            var lastName = jwt.Claims.First(c => c.Type == "LastName").Value;
            ViewData["id"] = id;
            ViewData["firstName"] = firstName;
            ViewData["lastName"] = lastName;
            return View();
        }

        [Route("Settings/Employee")]
        public IActionResult Settings()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;
            var firstName = jwt.Claims.First(c => c.Type == "FirstName").Value;
            var lastName = jwt.Claims.First(c => c.Type == "LastName").Value;
            ViewData["id"] = id;
            ViewData["firstName"] = firstName;
            ViewData["lastName"] = lastName;
            return View();
        }

        [HttpGet]
        public String Get()
        {
            var token = HttpContext.Session.GetString("token");
            ViewData["token"] = token;

            var jwtReader = new JwtSecurityTokenHandler();
            var jwt = jwtReader.ReadJwtToken(token);
            var id = jwt.Claims.First(c => c.Type == "Id").Value;

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:44395/API/RequestItems/" + id).Result;
            var apiResponse = response.Content.ReadAsStringAsync();
            return apiResponse.Result;
        }
    }
}
