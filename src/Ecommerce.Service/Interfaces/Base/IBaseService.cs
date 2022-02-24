using Ecommerce.Common.Dtos;
using Ecommerce.Infrastructure.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interfaces.Base
{
    public interface IBaseService<T2, T3, T4>
    {
        Task<T2> GetByIdAsync(T4 id);
        Task<IEnumerable<T2>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);
        Task<(bool status, T4 id)> PostAsync(T2 entity);
        Task<bool> PutAsync(T4 id, T3 entity);
        Task<bool> DeleteAsync(T4 id);
        Task<bool> DeleteLogicAsync(DeletedInfo<T4> entity);
    }
}