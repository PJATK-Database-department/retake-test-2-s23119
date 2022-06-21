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
    public class ActionsController : Controller
    {
        private readonly IDbService _dbService;

        public ActionsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("{idAction}")]
        public async Task<IActionResult> UpdateUpdateActionEndDateAsync([FromRoute] int idAction, [FromBody] DateTime newEndTime)
        {
            if (!await _dbService.DoesActionExistAsync(idAction)) 
            {
                return NotFound();
            }
            if (!await _dbService.IsActionEndDateEmptyAsync(idAction))
            {
                return Conflict();
            }
            if (!await _dbService.IsEndActionDateEarlierAsync(idAction, newEndTime))
            {
                return BadRequest();
            }
            
            await _dbService.UpdateActionEndDateAsync(idAction, newEndTime);
            return StatusCode(201);
        }
    }
}

