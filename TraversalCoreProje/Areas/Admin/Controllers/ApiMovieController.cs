﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using System.Threading.Tasks;
using System.Collections.Generic;
using TraversalCoreProje.Areas.Admin.Models;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ApiMovieController : Controller
    {
        List<ApiMovieViewModel> apiMovies = new List<ApiMovieViewModel>();
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "fc692c7576msh025da59d3435bc3p1389a1jsn48869b61382c" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovies = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(apiMovies);
            }
        }
    }
}
