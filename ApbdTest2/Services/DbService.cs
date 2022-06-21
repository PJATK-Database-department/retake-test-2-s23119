using ApbdTest2.DTOs;
using ApbdTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Action = ApbdTest2.Models.Action;

namespace APBDTest2Retake.Services
{
    public class DbService : IDbService
    {
        private readonly s23119Context _dbContext;

        public DbService(s23119Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GetFireTruckResponse> GetFiretruckAsync(int idFiretruck)
        {
            return await _dbContext.FireTrucks.Where(x => x.IdFireTruck == idFiretruck).Include(fta => fta.FireTruckActions).ThenInclude(a => a.IdActionNavigation).ThenInclude(fa => fa.FirefighterActions)
                .Select(x => new GetFireTruckResponse
                {
                    FireTruck = new FireTruckDTO
                    {
                        IdFireTruck = x.IdFireTruck,
                        OperationalNumber = x.OperationalNumber,
                        SpecialEquipment = x.SpecialEquipment
                    },
                    FireTruckActions = x.FireTruckActions.Select(x => new ActionDTO
                    {
                        StartTime = x.IdActionNavigation.StartTime,
                        EndTime = x.IdActionNavigation.EndTime,
                        NumberOfFirefighters = x.IdActionNavigation.FirefighterActions.ToList().Count(),
                        VehicleAssigned = x.AssignmentDate
                    }).OrderByDescending(x => x.EndTime).ToList()
                }).SingleOrDefaultAsync();
        }

        public async Task<bool> DoesFireTruckExistAsync(int idFiretruck)
        {
            return await _dbContext.FireTrucks.AnyAsync(x => x.IdFireTruck == idFiretruck);
        }

        public async Task UpdateActionEndDateAsync(int idAction, DateTime newEndDate) 
        {
           var action = new Action { EndTime = newEndDate};
           _dbContext.Actions.Attach(action);
           _dbContext.Entry(action).CurrentValues.SetValues(action);
           await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesActionExistAsync(int idAction)
        {
            return await _dbContext.Actions.AnyAsync(x => x.IdAction == idAction);
        }

        public async Task<bool> IsActionEndDateEmptyAsync(int idAction)
        {
            var action = await _dbContext.Actions.SingleOrDefaultAsync(x => x.IdAction == idAction);
            return action.EndTime == null;
        }

        public async Task<bool> IsNewActionDateEarlierAsync(int idAction, DateTime newEndDate)
        {
            var action = await _dbContext.Actions.SingleOrDefaultAsync(x => x.IdAction == idAction);
            return action.EndTime > newEndDate;
        }



    }
}
