using NapistaTests.Config;
using NapistaTests.Models;

namespace NapistaTests.Login
{
    public class LoginPage
    {
        protected readonly AppiumHelper Helper;
        public int permissionCount = 0;
        public int presentationCount = 0;

        public LoginPage(AppiumHelper helper)
        {
            Helper = helper;
        }

        public void FornecerPermissao()
        {

            while (Helper.ValidarSeElementoExistePorId("com.android.packageinstaller:id/permission_allow_button"))
            {
                Helper.ClicarBotaoPorId("com.android.packageinstaller:id/permission_allow_button");
                permissionCount++;

            }
        }

        public void VisualizarTelasDeApresentacao()
        {
            var elem = Helper.ValidarSeElementoExistePorXPath("//android.widget.Button[contains(@text,'Próximo') or contains(@text, 'Vamos começar')]");
            while (Helper.ValidarSeElementoExistePorXPath("//android.widget.Button[contains(@text,'Próximo') or contains(@text, 'Vamos começar')]"))
            {
                Helper.ClicarPorXPath("//android.widget.Button[contains(@text,'Próximo') or contains(@text, 'Vamos começar')]");

            }

        }

        public void IrParaTelaAutenticacao()
        {
            Helper.ClicarPorXPath("//android.view.View[@text='Já tenho conta']");
        }

        public void PreecherFormularioLogin(Usuario usuario)
        {

            Helper.PreencherTextBoxPorXPath("//android.widget.EditText[@text='Seu e-mail']", usuario.Email);
            Helper.PreencherTextBoxPorXPath("//android.widget.EditText[@text='Senha']", usuario.Password);

        }

        public void PreecherEmailDeSenhaEsquecida(string email)
        {

            Helper.PreencherTextBoxPorXPath("//android.widget.EditText[contains(@text, 'email')]", email);

        }

        public bool ValidarTelaAtualPorTextoEmBotao(string texto)
        {
            return Helper.ValidarSeElementoExistePorXPath($"//android.widget.Button[@text='{texto}']");
        }

        public bool ValidarTelaAtualPorTextoEmView(string texto)
        {
            return Helper.ValidarSeElementoExistePorXPath($"//android.view.View[contains(@text,'{texto}')]");
        }

        public bool ValidarPreenchimentoFormularioLogin(Usuario usuario)
        {
            if (!Helper.ObterValorTextBoxPorXPath("//android.widget.EditText[contains(@text, 'Seu e-mail')]").Contains(usuario.Email)) return false;

            return true;
        }

        public void AcessarConta()
        {
            Helper.ClicarPorXPath("//android.widget.Button[@text='Acessar conta']");
        }

        public void ClicarEmEsqueciSenha()
        {
            Helper.ClicarPorXPath("//android.view.View[contains(@text,'Esqueceu')]");
        }

        public void ClicarEmResetarSenha()
        {
            Helper.ClicarPorXPath("//android.widget.Button[contains(@text,'Resetar')]");
        }

        public void ClicarEmNaoSeiLogin()
        {
            Helper.ClicarPorXPath("//android.view.View[contains(@text,'Não sei')]");
        }
    }
}
