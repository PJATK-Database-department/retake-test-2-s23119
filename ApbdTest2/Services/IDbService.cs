using ApbdTest2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDTest2Retake.Services
{
    public interface IDbService
    {
        public Task<GetFireTruckResponse> GetFiretruckAsync(int idFiretruck);
        public async Task<bool> DoesFireTruckExistAsync(int idFiretruck);
        public async Task UpdateActionEndDateAsync(int idAction, DateTime newEndDate);
        public async Task<bool> DoesActionExistAsync(int idAction);
        public async Task<bool> IsActionEndDateEmptyAsync(int idAction);
        public async Task<bool> IsNewActionDateEarlierAsync(int idAction, DateTime newEndDate);

    }

}
