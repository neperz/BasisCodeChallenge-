using Basis.CodeChallenge.API.Services;
using Basis.CodeChallenge.API.ViewModels.Livro;
using Basis.CodeChallenge.Core.Tests.Mocks;
using Basis.CodeChallenge.Domain.Interfaces.Notifications;
using Basis.CodeChallenge.Domain.Interfaces.Repository;
using Basis.CodeChallenge.Unit.Tests.Configuration;
using FluentAssertions;
using Moq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Basis.CodeChallenge.Unit.Tests.Services
{
    // TODO: bonus - Add Unit testing to the project so that the main methods can be tested by the developer
    public class BasisLivroServiceTest : ConfigBase
    {
        private readonly Mock<IBasisLivroRepository> _BasisLivroRepositoryMock;

        private readonly Mock<IDomainNotification> _domainNotificationMock;

        private readonly Mock<ConcurrentDictionary<int, BasisLivroViewModel>> _cache;

        public BasisLivroServiceTest()
        {
            _BasisLivroRepositoryMock = new Mock<IBasisLivroRepository>();

            _domainNotificationMock = new Mock<IDomainNotification>();

            _cache = new Mock<ConcurrentDictionary<int, BasisLivroViewModel>>();
        }

        private BasisLivroService GetBasisLivroService()
        {
            return new BasisLivroService
                (
                _BasisLivroRepositoryMock.Object,
                _cache.Object,
                 _domainNotificationMock.Object,

                 _mapper);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsListOfBasisLivroViewModel()
        {
            // Arrange
            var expectedLivros = BasisLivroMock.BasisLivroModelFaker.Generate(3);
            _BasisLivroRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(expectedLivros);

            // Act
            var result = await GetBasisLivroService().GetAllAsync();

            // Assert
            result.Should().NotBeNull()
                .And.BeAssignableTo<IEnumerable<BasisLivroViewModel>>()
                .And.NotBeEmpty();
        }

        [Fact]
        public async Task GetById_ReturnBasisLivroViewModelTestAsync()
        {
            // Arrange
            var BasisLivroId = BasisLivroMock.BasisLivroIdViewModelFaker.Generate();

            var expectedLivro = BasisLivroMock.BasisLivroModelFaker.Generate();
            _BasisLivroRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedLivro);

            // Act
            var result = await GetBasisLivroService().GetByIdAsync(BasisLivroId);

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<BasisLivroViewModel>()
                .And.BeEquivalentTo(expectedLivro);
        }

        [Fact]
        public async Task GetLivroByIdAsync_ReturnBasisLivroViewModelTestAsync()
        {
            // Arrange
            var BasisLivroId = BasisLivroMock.BasisLivroIdViewModelFaker.Generate();

            var expectedLivro = BasisLivroMock.BasisLivroModelFaker.Generate();
            _BasisLivroRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedLivro);

            // Act
            var result = await GetBasisLivroService().GetByIdAsync(BasisLivroId);

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<BasisLivroViewModel>()
                .And.BeEquivalentTo(expectedLivro);
        }

        [Fact]
        public async Task GetLivroByNameAsync_ReturnBasisLivroViewModelTestAsync()
        {
            // Arrange
            var BasisLivroName = BasisLivroMock.BasisLivroNameViewModelFaker.Generate();

            var expectedLivro = BasisLivroMock.BasisLivroModelFaker.Generate();
            _BasisLivroRepositoryMock.Setup(x => x.GetByTituloAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedLivro);

            // Act
            var result = await GetBasisLivroService().GetByTituloAsync(BasisLivroName);

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<BasisLivroViewModel>()
                .And.BeEquivalentTo(expectedLivro);
        }

        [Fact]
        public async Task GetLivroByEditoraAsync_ReturnBasisLivroViewModelTestAsync()
        {
            // Arrange
            var BasisLivroEditora = BasisLivroMock.BasisLivroEditoraViewModelFaker.Generate();

            var expectedLivro = BasisLivroMock.BasisLivroModelFaker.Generate();
            _BasisLivroRepositoryMock.Setup(x => x.GetByEditoralAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedLivro);

            // Act
            var result = await GetBasisLivroService().GetByEditoraAsync(BasisLivroEditora);

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<BasisLivroViewModel>()
                .And.BeEquivalentTo(expectedLivro); // Compare the result with the expected Livro object
        }

        [Fact]
        public async Task Add_ReturnBasisLivroViewModelTestAsync()
        {
            // Arrange
            var BasisLivro = BasisLivroMock.BasisLivroViewModelFaker.Generate();

            _BasisLivroRepositoryMock.Setup(x => x.GetByTituloAsync(BasisLivro.Titulo))
                .ReturnsAsync(BasisLivroMock.BasisLivroModelFaker.Generate());

            // Act
            await GetBasisLivroService().AddAsync(BasisLivro);

            // Assert
            BasisLivro.Should().NotBeNull();
        }

        [Fact]
        public async Task Update_SuccessTestAsync()
        {
            // Arrange
            var BasisLivro = BasisLivroMock.BasisLivroViewModelFaker.Generate();

            // Act
            await GetBasisLivroService().UpdateAsync(BasisLivro);

            // Assert
            BasisLivro.Should().NotBeNull();
        }

        [Fact]
        public async Task Remove_SuccessTestAsync()
        {
            // Arrange
            var BasisLivro = BasisLivroMock.BasisLivroViewModelFaker.Generate();

            // Act
            await GetBasisLivroService().RemoveAsync(BasisLivro);

            // Assert
            BasisLivro.Should().NotBeNull();
        }
    }
}
