using ApbdTest2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDTest2Retake.Services
{
    public interface IDbService
    {
        Task<GetFireTruckResponse> GetFiretruckAsync(int idFiretruck);
        Task<bool> DoesFireTruckExistAsync(int idFiretruck);
        Task UpdateActionEndDateAsync(int idAction, DateTime newEndDate);
        Task<bool> DoesActionExistAsync(int idAction);
        Task<bool> IsActionEndDateEmptyAsync(int idAction);
        Task<bool> IsEndActionDateEarlierAsync(int idAction, DateTime newEndDate);

    }

}
