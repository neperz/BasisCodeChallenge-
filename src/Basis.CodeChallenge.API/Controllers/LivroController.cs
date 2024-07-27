using Basis.CodeChallenge.API.Services.Interfaces;
using Basis.CodeChallenge.API.ViewModels.Livro;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.CodeChallenge.API.Controllers;
// TODO: Host a web API for the Livro to call to manage the Livros
[ApiController]
[Produces("application/json")]
[Route("api/v1/Livros")]
[OpenApiTag("Livro")]
public class LivroController : ControllerBase
{
    private readonly IBasisLivroService _BasisLivroService;

    public LivroController(IBasisLivroService BasisLivroService)
    {
        _BasisLivroService = BasisLivroService;
    }

    /// <summary>
    /// List of Livros.
    /// </summary>
    /// <remarks>
    /// Returns a list of all Livros.
    /// </remarks>
    /// <response code="200">Returns a list of Livros.</response>
    /// <response code="400">Request error.</response>
    /// <response code="401">Access denied.</response>
    /// <response code="500">API internal error.</response>

    [ProducesResponseType(typeof(IEnumerable<BasisLivroViewModel>), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 401)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BasisLivroViewModel>>> GetAll() => Ok(await _BasisLivroService.GetAllAsync());


    /// <summary>
    /// Livro by Id.
    /// </summary>
    /// <remarks>
    /// Returns a Livro by Id.
    /// </remarks>
    /// <param name="BasisLivro">The "id" parameter of the Livro.</param>
    /// <response code="200">Returns an Livro.</response>
    /// <response code="204">Livro not found.</response>
    /// <response code="400">Request error.</response>
    /// <response code="401">Access denied.</response>
    /// <response code="500">API internal error.</response>

    [ProducesResponseType(typeof(BasisLivroViewModel), 200)]
    [ProducesResponseType(typeof(void), 204)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 401)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpGet("{id}")]
    public async Task<ActionResult<BasisLivroViewModel>> GetById([FromQuery] BasisLivroCodIdViewModel BasisLivro)
    {
        var BasisLivroVM = await _BasisLivroService.GetByIdAsync(BasisLivro);

        if (BasisLivroVM == null)
        {
            return NotFound();
        }

        return Ok(BasisLivroVM);
    }

    /// <summary>
    /// Livro by Titulo.
    /// </summary>
    /// <remarks>
    /// Returns a Livro by Titulo.
    /// </remarks>
    /// <param name="BasisLivro">The "titulo" parameter of the Livro.</param>
    /// <response code="200">Returns a list of Livros.</response>
    /// <response code="204">Not found.</response>
    /// <response code="400">Request error.</response>
    /// <response code="401">Access denied.</response>
    /// <response code="500">API internal error.</response>

    [ProducesResponseType(typeof(IEnumerable<BasisLivroViewModel>), 200)]
    [ProducesResponseType(typeof(void), 204)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 401)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpGet("titulo/{titulo}")]
    public async Task<ActionResult<BasisLivroViewModel>> GetByTitulo([FromQuery] BasisLivroTituloViewModel BasisLivro)
    {
        var BasisLivroVM = await _BasisLivroService.GetByTituloAsync(BasisLivro);

        if (BasisLivroVM == null)
        {
            return NoContent();
        }

        return Ok(BasisLivroVM);
    }
    /// <summary>
    /// Livro por editora
    /// </summary>
    /// <remarks>
    /// Retorna o livro pela editora
    /// </remarks>
    /// <param name="BasisLivro">The "editora" parameter of the Livro.</param>
    /// <response code="200">Returns a list of Livros.</response>
    /// <response code="204">Not found.</response>
    /// <response code="400">Request error.</response>
    /// <response code="401">Access denied.</response>
    /// <response code="500">API internal error.</response>

    [ProducesResponseType(typeof(IEnumerable<BasisLivroViewModel>), 200)]
    [ProducesResponseType(typeof(void), 204)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 401)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpGet("Editora/{Editora}")]
    public async Task<ActionResult<BasisLivroViewModel>> GetByEditora([FromQuery] BasisLivroEditoraViewModel BasisLivro)
    {

        var BasisLivroVM = await _BasisLivroService.GetByEditoraAsync(BasisLivro);

        if (BasisLivroVM == null)
        {
            return NoContent();
        }

        return Ok(BasisLivroVM);
    }

    /// <summary>
    /// Livro creation.
    /// </summary>
    /// <remarks>
    /// Creates a new Livro.
    /// </remarks>
    /// <param name="BasisLivro">The "Livro" parameter.</param>
    /// <response code="201">Record created.</response>
    /// <response code="204">Livro not found.</response>
    /// <response code="400">Request error.</response>
    /// <response code="401">Access denied.</response>
    /// <response code="500">API internal error.</response>
    [ProducesResponseType(typeof(BasisLivroViewModel), 201)]
    [ProducesResponseType(typeof(void), 204)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 401)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpPost]
    public async Task<ActionResult<BasisLivroViewModel>> PostLivroAsync([FromBody] BasisLivroViewModel BasisLivro)
    {
        if (BasisLivro == null || string.IsNullOrWhiteSpace(BasisLivro.Titulo))
        {
            return NoContent();
        }

        return Created(nameof(PostLivroAsync), await _BasisLivroService.AddAsync(BasisLivro).ConfigureAwait(false));
    }

    /// <summary>
    /// Livro update.
    /// </summary>
    /// <remarks>
    /// Updates a Livro.
    /// </remarks>
    /// <param name="id">The "CodL" parameter of the Livro.</param>
    /// <param name="BasisLivro">The "Livro" parameter.</param>
    /// <response code="202">Record created.</response>
    /// <response code="204">Livro not found.</response>
    /// <response code="400">Request error.</response>
    /// <response code="401">Access denied.</response>
    /// <response code="500">API internal error.</response>

    [ProducesResponseType(typeof(void), 202)]
    [ProducesResponseType(typeof(void), 204)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 401)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpPut("{id}")]
    public async Task<ActionResult> PutLivro([FromRoute] int id, [FromBody] BasisLivroViewModel BasisLivro)
    {

        if (BasisLivro == null || BasisLivro.CodL != id)
            return BadRequest();


        var BasisLivroVM = await _BasisLivroService.GetByIdAsync(new BasisLivroCodIdViewModel(id));

        if (BasisLivroVM == null)
            return NoContent();


        await _BasisLivroService.UpdateAsync(BasisLivro).ConfigureAwait(false);

        return Accepted();
    }

    /// <summary>
    /// Livro deletion.
    /// </summary>
    /// <remarks>
    /// Deletes a Livro.
    /// </remarks>
    /// <param name="BasisLivro">The "id" parameter of the Livro.</param>
    /// <response code="202">Record created.</response>
    /// <response code="204">Livro not found.</response>
    /// <response code="400">Request error.</response>
    /// <response code="401">Access denied.</response>
    /// <response code="500">API internal error.</response>
    [ProducesResponseType(typeof(void), 202)]
    [ProducesResponseType(typeof(void), 204)]
    [ProducesResponseType(typeof(ProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 401)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLivro([FromQuery] BasisLivroCodIdViewModel BasisLivro)
    {

        var BasisLivroVM = await _BasisLivroService.GetByIdAsync(BasisLivro);

        if (BasisLivroVM == null)
        {
            return NoContent();
        }

        await _BasisLivroService.RemoveAsync(BasisLivroVM).ConfigureAwait(false);

        return Accepted();
    }
}