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

    public class CN005LoginFrontTurismo : SessaoMain
    {
        
        public CN005LoginFrontTurismo()
        {

        }

        AppObjects appObjectsFTurismo = new AppObjects();

        public void ValidaLoginFrontTurismo()
        {
            #region Inicialização do módulo FrontTurismo
            AppiumOptions session5 = new AppiumOptions();
            session5.AddAdditionalCapability("app", dirAplicacaoFrontTurismo);

            acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session5);


            ParamRegistroSistema();

            #endregion



            #region Usuário e Pass Sistema

            WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(60));

            Elementos.EncontraElementoName(acessarModulo, appObjectsFTurismo.titleTelaLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsFTurismo.TEdit).ElementAt(0).SendKeys(appObjectsFTurismo.userSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsFTurismo.TEdit).ElementAt(1).SendKeys(appObjectsFTurismo.passSys);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsFTurismo.btnConfirmar).Click();
            #endregion

            

            #region Seleciona Empresa

            Elementos.EncontraElementoClassName(acessarModulo, appObjectsFTurismo.comboBoxLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsFTurismo.comboBoxLogin).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsFTurismo.comboBoxLogin).ElementAt(0).SendKeys(appObjectsFTurismo.empresaSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsFTurismo.comboBoxLogin).ElementAt(0).SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(acessarModulo, appObjectsFTurismo.btnConfirmar).Click();

            #endregion

        }

        public void ConferenciaTelaPrincipalFrontTurismo() 
        {
            #region Conferência Tela Principal do FrontTurismo

            Thread.Sleep(1000);

            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexFt = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexFt.Title.ToString();

            var titleScreenFTurismo = acessarModulo.FindElementByClassName(appObjectsFTurismo.scrTelaPrincipal);

            bool screenFTurismo = false;
            WindowsElement titleValidado = null;

            if (titleScreenFTurismo.Text.StartsWith(appObjectsFTurismo.titleTelaPrincFrontTurismo))
            {
                screenFTurismo = true;
                titleValidado = titleScreenFTurismo;
                Debug.WriteLine("Tela Principal do FrontTurismo inicializada com sucesso.");
            }

            Assert.IsTrue(screenFTurismo, "Tela Principal do FrontTurismo não inicializada.");

            #endregion

        }

        public void CN005TearDown()
        {
            if (acessarModulo != null)
            {
                acessarModulo.Quit();
            }

        }

    }
}