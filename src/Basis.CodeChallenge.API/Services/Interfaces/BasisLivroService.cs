using Basis.CodeChallenge.API.ViewModels.Livro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.CodeChallenge.API.Services.Interfaces;

public interface IBasisLivroService
{
    Task<IEnumerable<BasisLivroViewModel>> GetAllAsync();
    Task<BasisLivroViewModel> GetByIdAsync(BasisLivroCodIdViewModel BasisLivroVM);

    Task RemoveAsync(BasisLivroViewModel BasisLivroVM);
    Task UpdateAsync(BasisLivroViewModel BasisLivroVM);
    Task<BasisLivroViewModel> AddAsync(BasisLivroViewModel BasisLivroVM);
    Task<BasisLivroViewModel> GetByEditoraAsync(BasisLivroEditoraViewModel BasisLivroVM);
    Task<BasisLivroViewModel> GetByTituloAsync(BasisLivroTituloViewModel BasisLivroVM);


}
