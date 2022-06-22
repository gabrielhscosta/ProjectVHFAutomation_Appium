using VHFAutomation.CommonMethods;
using System.Linq;
using VHFAutomation.PageObjects;
using VHFAutomation.Main;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using OpenQA.Selenium;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace VHFAutomation.TestCase
{

    public class CN009LoginTelefonia : SessaoMain
    {
        
        public CN009LoginTelefonia()
        {

        }

        AppObjects appObjectsTel = new AppObjects();

        public void ValidaLoginTelefonia()
        {
            #region Inicialização do módulo Telefonia
            AppiumOptions session9 = new AppiumOptions();
            session9.AddAdditionalCapability("app", dirAplicacaoTelefonia);

            acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session9);


            ParamRegistroSistema();

            #endregion



            #region Usuário e Pass Sistema

            WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(60));
            
            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexLogin = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Manage().Window.Equals(appObjectsTel.titleTelaLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsTel.caixaTexto).ElementAt(0).SendKeys(appObjectsTel.userSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsTel.caixaTexto).ElementAt(1).SendKeys(appObjectsTel.passSys);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsTel.btnConfirmar).Click();
            #endregion

            

            #region Seleciona Empresa

            Elementos.EncontraElementoClassName(acessarModulo, appObjectsTel.comboBoxLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsTel.comboBoxLogin).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsTel.comboBoxLogin).ElementAt(0).SendKeys(appObjectsTel.empresaSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsTel.comboBoxLogin).ElementAt(0).SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(acessarModulo, appObjectsTel.btnConfirmar).Click();

            #endregion

        }

        public void ConferenciaTelaPrincipalTelefonia()
        {
            #region Conferência Tela Principal da Telefonia

            Thread.Sleep(1000);

            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexTel = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexTel.Title.ToString();

            var titleScreenTel = acessarModulo.FindElementByClassName(appObjectsTel.scrTelaPrincipal);

            bool screenTel = false;
            WindowsElement titleValidado = null;

            if (titleScreenTel.Text.StartsWith(appObjectsTel.titleTelaPrincTelefonia))
            {
                screenTel = true;
                titleValidado = titleScreenTel;
                Debug.WriteLine("Tela Principal da Telefonia inicializada com sucesso.");
            }

            Assert.IsTrue(screenTel, "Tela Principal da Telefonia não inicializada.");

            #endregion

        }

        public void CN009TearDown()
        {
            if (acessarModulo != null)
            {
                acessarModulo.Quit();
            }

        }

    }
}