using AutoMapper;
using Ecommerce.Common.Dtos;
using Ecommerce.Infrastructure.Entities.Base;
using Ecommerce.Infrastructure.Repository;
using Ecommerce.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services.Base
{
    public abstract class BaseService<T, T2, T3, T4> where T : BaseEntity<T4>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<T> _repository;
        public readonly IMapper _mapper;

        protected BaseService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repository = unitOfWork.CreateRepository<T>();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<T2> GetByIdAsync(T4 id)
        {
            var result = await _repository.FirstOrDefaultAsync(x => x.Id.ToString() == id.ToString() && !x.Deleted).ConfigureAwait(false);
            return _mapper.Map<T2>(result);
        }

        public async Task<IEnumerable<T2>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true)
        {
            var result = await _repository.GetAllAsync(x => !x.Deleted, page, limit, orderBy, ascending);
            return _mapper.Map<IEnumerable<T2>>(result);
        }

        public async Task<(bool status, T4 id)> PostAsync(T2 entity)
        {
            var obj = _mapper.Map<T>(entity);
            _repository.Insert(obj);
            var status = await _unitOfWork.SaveAsync();
            return (status, obj.Id);
        }

        public async Task<bool> PutAsync(T4 id, T3 entity)
        {
            var existingEntity = await _repository.FirstOrDefaultAsync(x => x.Id.ToString() == id.ToString()).ConfigureAwait(false);
            if (existingEntity is null) return false;

            _mapper.Map(entity, existingEntity);
            _repository.Update(existingEntity);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteAsync(T4 id)
        {
            var existingEntity = await _repository.FirstOrDefaultAsync(x => x.Id.ToString() == id.ToString()).ConfigureAwait(false);
            if (existingEntity is null) return false;
            _repository.Delete(existingEntity);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteLogicAsync(DeletedInfo<T4> entity)
        {
            var existingEntity = await _repository.FirstOrDefaultAsync(x => x.Id.ToString() == entity.Id.ToString()).ConfigureAwait(false);
            if (existingEntity is null) return false;
            existingEntity.ModificationDate = DateTime.Now;
            existingEntity.Deleted = true;
            _repository.Update(existingEntity);
            return await _unitOfWork.SaveAsync();
        }
    }
}