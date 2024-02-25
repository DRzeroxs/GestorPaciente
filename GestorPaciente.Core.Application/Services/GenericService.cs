﻿using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;


namespace GestorPaciente.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Entity> : IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);

            entity = await _repository.AddAsync(entity);

            SaveViewModel SaveVm = _mapper.Map<SaveViewModel>(entity);

            return SaveVm;

        }

        public async Task Update(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);

            await _repository.UpdateAsync(entity, id);
        }

        public async Task Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
            var entityList = await _repository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(entityList);
        }

        public async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);

            SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);

            return vm;
        }

        
    }
}