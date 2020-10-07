using NapistaTests.Config;
using NapistaTests.Models;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace NapistaTests.Login
{
    [Binding]
    public class LoginSteps
    {
        private readonly AutomationMobileFixture fixture;
        private readonly LoginPage _loginPage;

        public LoginSteps(AutomationMobileFixture fixture)
        {
            this.fixture = fixture;
            _loginPage = new LoginPage(fixture.BrowserHelper);
        }

        [Given(@"que o Usuário acesse o aplicativo dando as permissões necessárias")]
        public void DadoQueOUsuarioAcesseOAplicativoDandoAsPermissoesNecessarias()
        {
            _loginPage.FornecerPermissao();

            Assert.Equal(3, _loginPage.permissionCount);
        }
        
        [Given(@"visualize as telas inicias de apresentação")]
        public void DadoVisualizeAsTelasIniciasDeApresentacao()
        {
            var quantidadeTelasApresentacao = 3;
            _loginPage.VisualizarTelasDeApresentacao();

            Assert.Equal(quantidadeTelasApresentacao, _loginPage.presentationCount);

        }

        [Given(@"Visualize tela de Login")]
        public void DadoVisualizeTelaDeLogin()
        {
           var result = _loginPage.ValidarTelaAtualPorTextoEmBotao("Ainda não tenho conta");

            Assert.True(result);
        }


        [When(@"o usuário clicar em Já tenho Conta")]
        public void QuandoOUsuarioClicarEmJaTenhoConta()
        {
            _loginPage.IrParaTelaAutenticacao();
        }



        [When(@"Preencher os dados do formulário do login")]
        public void QuandoPreencherOsDadosDoFormularioDoLogin(Table table)
        {
            var usuario = new Usuario()
            {
                Email = "testedasilva1@grr.la",
                Password = "qee123"
            };
            _loginPage.PreecherFormularioLogin(usuario);

           var result =  _loginPage.ValidarPreenchimentoFormularioLogin(usuario);

            Assert.True(result);

        }

       
        
        [When(@"Clicar no botão Acessar Conta")]
        public void QuandoClicarNoBotaoAcessarConta()
        {
            _loginPage.AcessarConta();
        }
        
        [Then(@"será redirecionado para tela inicial do aplicativo")]
        public void EntaoSeraRedirecionadoParaTelaInicialDoAplicativo()
        {
            var result = _loginPage.ValidarTelaAtualPorTextoEmView("Seja bem vindo!");

            Assert.True(result, "Alguma coisa saiu errado na validação da tela!");
        }

        
    }
}
