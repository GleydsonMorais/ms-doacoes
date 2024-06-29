using Moq;
using ms_pessoa_domain.Dtos.Login;
using ms_pessoa_domain.Dtos.Pessoa;
using ms_pessoa_domain.Services;
using ms_pessoa_infra.Entity;
using ms_pessoa_infra.Interfaces.Repositories;
using ms_pessoa_unit_test.Mock;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace ms_pessoa_unit_test
{
    public class PessoaServiceTest
    {
        #region CadastraPessoaAsync
        [Theory, ClassData(typeof(CadastraPessoaAsyncReqMock))]
        public async Task CadastraPessoaAsync_Sucesso(CadastraPessoaReqDto dto)
        {
            //Arrange
            var _pessoaRepository = new Mock<IPessoaRepository>();

            _pessoaRepository.Setup(x => x.InsertAsync(It.IsAny<Pessoa>())).Returns(Task.CompletedTask);
            _pessoaRepository.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var service = new PessoaService(_pessoaRepository.Object);

            //Act
            var retorno = await service.CadastraPessoaAsync(dto);

            //Assert
            Assert.True(retorno.Succeeded);
            Assert.NotNull(retorno.Result);
            Assert.Null(retorno.Message);
        }

        [Theory, ClassData(typeof(CadastraPessoaAsyncReqMock))]
        public async Task CadastraPessoaAsync_CPFNUll(CadastraPessoaReqDto dto)
        {
            //Arrange
            var mensagemErro = "O campo CPF é obrigatório!";

            var _pessoaRepository = new Mock<IPessoaRepository>();

            _pessoaRepository.Setup(x => x.InsertAsync(It.IsAny<Pessoa>())).Returns(Task.CompletedTask);
            _pessoaRepository.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var service = new PessoaService(_pessoaRepository.Object);

            dto.CPF = null;

            //Act
            var retorno = await service.CadastraPessoaAsync(dto);

            //Assert
            Assert.False(retorno.Succeeded);
            Assert.Null(retorno.Result);
            Assert.Equal(mensagemErro, retorno.Message);
        }

        [Theory, ClassData(typeof(CadastraPessoaAsyncReqMock))]
        public async Task CadastraPessoaAsync_NomeNUll(CadastraPessoaReqDto dto)
        {
            //Arrange
            var mensagemErro = "O campo Nome é obrigatório!";

            var _pessoaRepository = new Mock<IPessoaRepository>();

            _pessoaRepository.Setup(x => x.InsertAsync(It.IsAny<Pessoa>())).Returns(Task.CompletedTask);
            _pessoaRepository.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var service = new PessoaService(_pessoaRepository.Object);

            dto.Nome = null;

            //Act
            var retorno = await service.CadastraPessoaAsync(dto);

            //Assert
            Assert.False(retorno.Succeeded);
            Assert.Null(retorno.Result);
            Assert.Equal(mensagemErro, retorno.Message);
        }

        [Theory, ClassData(typeof(CadastraPessoaAsyncReqMock))]
        public async Task CadastraPessoaAsync_SenhaNUll(CadastraPessoaReqDto dto)
        {
            //Arrange
            var mensagemErro = "O campo Senha é obrigatório!";

            var _pessoaRepository = new Mock<IPessoaRepository>();

            _pessoaRepository.Setup(x => x.InsertAsync(It.IsAny<Pessoa>())).Returns(Task.CompletedTask);
            _pessoaRepository.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var service = new PessoaService(_pessoaRepository.Object);

            dto.Senha = null;

            //Act
            var retorno = await service.CadastraPessoaAsync(dto);

            //Assert
            Assert.False(retorno.Succeeded);
            Assert.Null(retorno.Result);
            Assert.Equal(mensagemErro, retorno.Message);
        }

        [Theory, ClassData(typeof(CadastraPessoaAsyncReqMock))]
        public async Task CadastraPessoaAsync_EmailNUll(CadastraPessoaReqDto dto)
        {
            //Arrange
            var mensagemErro = "O campo Email é obrigatório!";

            var _pessoaRepository = new Mock<IPessoaRepository>();

            _pessoaRepository.Setup(x => x.InsertAsync(It.IsAny<Pessoa>())).Returns(Task.CompletedTask);
            _pessoaRepository.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var service = new PessoaService(_pessoaRepository.Object);

            dto.Email = null;

            //Act
            var retorno = await service.CadastraPessoaAsync(dto);

            //Assert
            Assert.False(retorno.Succeeded);
            Assert.Null(retorno.Result);
            Assert.Equal(mensagemErro, retorno.Message);
        }
        #endregion

        #region AlterarSenhaAsync
        [Theory, ClassData(typeof(AlterarSenhaAsyncReqMock))]
        public async Task AlterarSenhaAsync_Sucesso(string cpf, AlterarSenhaReqDto dto)
        {
            //Arrange
            var _pessoaRepository = new Mock<IPessoaRepository>();

            _pessoaRepository.Setup(x => x.GetByCPF(It.IsAny<string>())).Returns(Task.FromResult(PessoaMock.PessoaResMock()));
            _pessoaRepository.Setup(x => x.Update(It.IsAny<Pessoa>()));
            _pessoaRepository.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var service = new PessoaService(_pessoaRepository.Object);

            //Act
            var retorno = await service.AlterarSenhaAsync(cpf, dto);

            //Assert
            Assert.True(retorno.Succeeded);
            Assert.NotNull(retorno.Result);
            Assert.Null(retorno.Message);
        }

        [Theory, ClassData(typeof(AlterarSenhaAsyncReqMock))]
        public async Task AlterarSenhaAsync_CPFNull(string cpf, AlterarSenhaReqDto dto)
        {
            //Arrange
            var mensagemErro = "O campo CPF é obrigatório!";
            
            var _pessoaRepository = new Mock<IPessoaRepository>();

            _pessoaRepository.Setup(x => x.GetByCPF(It.IsAny<string>())).Returns(Task.FromResult(PessoaMock.PessoaResMock()));
            _pessoaRepository.Setup(x => x.Update(It.IsAny<Pessoa>()));
            _pessoaRepository.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var service = new PessoaService(_pessoaRepository.Object);

            cpf = null;

            //Act
            var retorno = await service.AlterarSenhaAsync(cpf, dto);

            //Assert
            Assert.False(retorno.Succeeded);
            Assert.Null(retorno.Result);
            Assert.Equal(mensagemErro, retorno.Message);
        }

        [Theory, ClassData(typeof(AlterarSenhaAsyncReqMock))]
        public async Task AlterarSenhaAsync_SenhaAntigaNull(string cpf, AlterarSenhaReqDto dto)
        {
            //Arrange
            var mensagemErro = "O campo Senha Antiga é obrigatório!";

            var _pessoaRepository = new Mock<IPessoaRepository>();

            _pessoaRepository.Setup(x => x.GetByCPF(It.IsAny<string>())).Returns(Task.FromResult(PessoaMock.PessoaResMock()));
            _pessoaRepository.Setup(x => x.Update(It.IsAny<Pessoa>()));
            _pessoaRepository.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var service = new PessoaService(_pessoaRepository.Object);

            dto.SenhaAntiga = null;

            //Act
            var retorno = await service.AlterarSenhaAsync(cpf, dto);

            //Assert
            Assert.False(retorno.Succeeded);
            Assert.Null(retorno.Result);
            Assert.Equal(mensagemErro, retorno.Message);
        }

        [Theory, ClassData(typeof(AlterarSenhaAsyncReqMock))]
        public async Task AlterarSenhaAsync_SenhaNovaNull(string cpf, AlterarSenhaReqDto dto)
        {
            //Arrange
            var mensagemErro = "O campo Senha Nova é obrigatório!";

            var _pessoaRepository = new Mock<IPessoaRepository>();

            _pessoaRepository.Setup(x => x.GetByCPF(It.IsAny<string>())).Returns(Task.FromResult(PessoaMock.PessoaResMock()));
            _pessoaRepository.Setup(x => x.Update(It.IsAny<Pessoa>()));
            _pessoaRepository.Setup(x => x.SaveAsync()).Returns(Task.CompletedTask);

            var service = new PessoaService(_pessoaRepository.Object);

            dto.SenhaNova = null;

            //Act
            var retorno = await service.AlterarSenhaAsync(cpf, dto);

            //Assert
            Assert.False(retorno.Succeeded);
            Assert.Null(retorno.Result);
            Assert.Equal(mensagemErro, retorno.Message);
        }
        #endregion
    }
}