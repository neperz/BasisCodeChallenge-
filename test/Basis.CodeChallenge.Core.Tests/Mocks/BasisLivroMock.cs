using Bogus;
using Basis.CodeChallenge.API.ViewModels.Livro;
using Basis.CodeChallenge.Domain.Models;


namespace Basis.CodeChallenge.Core.Tests.Mocks
{
    public static class BasisLivroMock
    {
        public static Faker<Livro> BasisLivroModelFaker =>
            new Faker<Livro>()
            .CustomInstantiator(x => new Livro
            (
                codL: x.Random.Int(),
                 titulo: x.Person.FirstName,
                editora: x.Person.LastName,
                edicao: x.Random.Int(),
                anoPublicacao: x.Random.Int().ToString()
            ));


        public static Faker<BasisLivroViewModel> BasisLivroViewModelFaker =>
            new Faker<BasisLivroViewModel>()
            .CustomInstantiator(x => new BasisLivroViewModel
            (
                codL: x.Random.Int(),
                 titulo: x.Person.FirstName,
                editora: x.Person.LastName,
                edicao: x.Random.Int(),
                anoPublicacao: x.Random.Int().ToString(),
                dateCreated: x.Date.Recent()
            ));

        public static Faker<BasisLivroCodIdViewModel> BasisLivroIdViewModelFaker =>
            new Faker<BasisLivroCodIdViewModel>()
            .CustomInstantiator(x => new BasisLivroCodIdViewModel
            (
                codL: x.Random.Int()
            ));

        public static Faker<BasisLivroTituloViewModel> BasisLivroNameViewModelFaker =>
            new Faker<BasisLivroTituloViewModel>()
            .CustomInstantiator(x => new BasisLivroTituloViewModel
            (
                titulo: x.Person.FirstName
            ));
        public static Faker<BasisLivroEditoraViewModel> BasisLivroEditoraViewModelFaker =>
            new Faker<BasisLivroEditoraViewModel>()
            .CustomInstantiator(x => new BasisLivroEditoraViewModel
            (
                editora: x.Person.LastName
            ));



    }
}
