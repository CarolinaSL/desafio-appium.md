using NapistaTests.Config;
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

        [Given(@"visualize as telas iniciais de apresentação")]
        public void DadoVisualizeAsTelasIniciaisDeApresentacao()
        {
            _loginPage.VisualizarTelasDeApresentacao();

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
        public void QuandoPreencherOsDadosDoFormularioDoLogin()
        {

            _loginPage.PreecherFormularioLogin(fixture.usuario);

            var result = _loginPage.ValidarPreenchimentoFormularioLogin(fixture.usuario);

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

        [Given(@"o usuário clicar em Já tenho Conta")]
        public void DadoOUsuarioClicarEmJaTenhoConta()
        {
            _loginPage.IrParaTelaAutenticacao();
        }

        [When(@"Clicar em esqueci minha senha")]
        public void QuandoClicarEmEsqueciMinhaSenha()
        {
            var result = _loginPage.ValidarTelaAtualPorTextoEmView("Esqueceu");
            _loginPage.ClicarEmEsqueciSenha();

            Assert.True(result);
        }

        [Then(@"será redirecionado para tela de recuperação de senha para preencher email")]
        public void EntaoSeraRedirecionadoParaTelaDeRecuperacaoDeSenhaParaPreencherEmail()
        {
            var result = _loginPage.ValidarTelaAtualPorTextoEmView("recuperar");

            Assert.True(result);
        }

        [Then(@"Preencherá email não válido no formulário")]
        public void EntaoPreencheraEmailNaoValidoNoFormulario()
        {
            _loginPage.PreecherEmailDeSenhaEsquecida("teste@invalido");
        }

        [Then(@"Clicará em em Resetar senha, recebendo mensagem de erro")]
        public void EntaoClicaraEmEmResetarSenhaRecebendoMensagemDeErro()
        {
            _loginPage.ClicarEmResetarSenha();
            var result = _loginPage.ValidarTelaAtualPorTextoEmView("um email válido");

            Assert.True(result, "Validação não ocorreu como esperado");
        }

        [Then(@"clicará em não sei meu login, recendo mensagem para entrar em contato com o administrador")]
        public void EntaoClicaraEmNaoSeiMeuLoginRecendoMensagemParaEntrarEmContatoComOAdministrador()
        {
            _loginPage.ClicarEmNaoSeiLogin();
            var result = _loginPage.ValidarTelaAtualPorTextoEmView("contato com o administrador");

            Assert.True(result);
        }



    }
}
