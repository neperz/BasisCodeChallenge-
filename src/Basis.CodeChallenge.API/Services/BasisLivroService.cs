using AutoMapper;
using Basis.CodeChallenge.API.Services.Interfaces;
using Basis.CodeChallenge.API.ViewModels.Livro;
using Basis.CodeChallenge.Domain.Interfaces.Notifications;
using Basis.CodeChallenge.Domain.Interfaces.Repository;
using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Domain.Models.Repository;
using Basis.CodeChallenge.Domain.Validation.LivroValidation;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.CodeChallenge.API.Services;

public class BasisLivroService : IBasisLivroService
{
    private readonly IBasisLivroRepository _BasisLivroRepository;
    private readonly IDomainNotification _domainNotification;

    private readonly IMapper _mapper;
    private readonly ConcurrentDictionary<int, BasisLivroViewModel> _cache;
    public BasisLivroService(
        IBasisLivroRepository BasisLivroRepository,
        ConcurrentDictionary<int, BasisLivroViewModel> cache,
        IDomainNotification domainNotification,

        IMapper mapper)
    {
        _BasisLivroRepository = BasisLivroRepository;
        _domainNotification = domainNotification;

        _mapper = mapper;
        _cache = cache;
    }

    public async Task<IEnumerable<BasisLivroViewModel>> GetAllAsync()
    {
        var BasisLivros = _mapper.Map<IEnumerable<BasisLivroViewModel>>(await _BasisLivroRepository.GetAllAsync());

        return BasisLivros;
    }

    public async Task<BasisLivroViewModel> GetByIdAsync(BasisLivroCodIdViewModel BasisLivroVM)
    {
        if (_cache.TryGetValue(BasisLivroVM.CodL, out BasisLivroViewModel Livro))
        {
            return Livro;
        }
        else
        {
            Livro = _mapper.Map<BasisLivroViewModel>(await _BasisLivroRepository.GetByIdAsync(BasisLivroVM.CodL));
            _cache.TryAdd(BasisLivroVM.CodL, Livro);
        }
        return Livro;
    }
    public async Task<BasisLivroViewModel> GetByEditoraAsync(BasisLivroEditoraViewModel BasisLivroVM)
    {
        return _mapper.Map<BasisLivroViewModel>(await _BasisLivroRepository.GetByEditoralAsync(BasisLivroVM.Editora));
    }
    public async Task<BasisLivroViewModel> GetByTituloAsync(BasisLivroTituloViewModel BasisLivroVM)
    {
        return _mapper.Map<BasisLivroViewModel>(await _BasisLivroRepository.GetByTituloAsync(BasisLivroVM.Titulo));
    }
    public async Task<BasisLivroViewModel> AddAsync(BasisLivroViewModel BasisLivroVM)
    {
        BasisLivroViewModel viewModel = null;

        var model = _mapper.Map<Livro>(BasisLivroVM);

        var validation = await new BasisLivronsertValidation(_BasisLivroRepository).ValidateAsync(model);

        if (!validation.IsValid)
        {
            _domainNotification.AddNotifications(validation);
            return viewModel;
        }
        var dbModel = _mapper.Map<LivroDb>(model);
        _BasisLivroRepository.Add(dbModel);
        _cache.TryAdd(model.CodL, BasisLivroVM);
      

        viewModel = _mapper.Map<BasisLivroViewModel>(model);

        return viewModel;
    }

    public async Task UpdateAsync(BasisLivroViewModel BasisLivroVM)
    {
        var model = _mapper.Map<Livro>(BasisLivroVM);

        var validation = await new BasisLivroUpdateValidation().ValidateAsync(model);

        if (!validation.IsValid)
        {
            _domainNotification.AddNotifications(validation);
            return;
        }
        var dbModel = _mapper.Map<LivroDb>(model);
        _BasisLivroRepository.Update(dbModel);
        if (_cache.TryGetValue(BasisLivroVM.CodL, out var value))
        {
            _cache.TryUpdate(BasisLivroVM.CodL, BasisLivroVM, value);
        }
   
    }

    public async Task RemoveAsync(BasisLivroViewModel BasisLivroVM)
    {
        var model = _mapper.Map<Livro>(BasisLivroVM);

        var validation = await new BasisLivroDeleteValidation().ValidateAsync(model);

        if (!validation.IsValid)
        {
            _domainNotification.AddNotifications(validation);
            return;
        }
        var dbModel = _mapper.Map<LivroDb>(model);
        _BasisLivroRepository.Remove(dbModel);

        _cache.TryRemove(model.CodL, out var _);

    
    }
}
