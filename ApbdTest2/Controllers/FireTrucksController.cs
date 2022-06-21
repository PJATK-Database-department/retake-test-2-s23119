using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApbdTest2.Models;
using APBDTest2Retake.Services;

namespace ApbdTest2.Controllers
{
    public class FireTrucksController : Controller
    {
        private readonly IDbService _dbService;

        public FireTrucksController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{idFiretruck}")]
        public async Task<IActionResult> GetFireTruckASync([FromRoute] int idFiretruck)
        {

        }
    }
}

