using NapistaTests.Config;
using NapistaTests.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NapistaTests.Login
{
    public class LoginPage
    {
        protected readonly AppiumHelper Helper;
        public int permissionCount = 0;
        public string UltimaPágina;
        public LoginPage(AppiumHelper helper)
        {
            Helper = helper;
        }

        public void FornecerPermissao()
        {
            var element = Helper.ObterTextoElementoPorId("com.android.packageinstaller:id/permission_allow_button");
           
            while (Helper.ValidarSeElementoExistePorId("com.android.packageinstaller:id/permission_allow_button"))
            {
                Helper.ClicarBotaoPorId("com.android.packageinstaller:id/permission_allow_button");
                permissionCount++;

            }
        }

        public void VisualizarTelasDeApresentacao()
        {
            Helper.ClicarPorXPath("//android.widget.Button[@text='Próximo']");
            Helper.ClicarPorXPath("//android.widget.Button[@text='Próximo']");
            Helper.ClicarPorXPath("//android.widget.Button[@text='Vamos começar']");

        }

        public void IrParaTelaAutenticacao()
        {
            Helper.ClicarPorXPath("//android.view.View[@Tex='Já tenho conta'");
        }

        public void PreecherFormularioLogin(Usuario usuario)
        {
           var emailElement =  Helper.ObterElementoPorXPath("//android.widget.EditText[@text='Seu e-mail']");
            var senhaElement = Helper.ObterElementoPorXPath("//android.widget.EditText[@text='Senha']");
        }

        public bool ValidarTelaAtualPorTextoEmBotao(string texto)
        {
            return Helper.ValidarSeElementoExistePorXPath($"//android.widget.Button[@text='{texto}']");
        }

        public bool ValidarTelaAtualPorTextoEmView(string texto)
        {
            return Helper.ValidarSeElementoExistePorXPath($"//android.view.View[@text='{texto}']");
        }
    }
}
