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

    public class CN008LoginSSD : SessaoMain
    {
        
        public CN008LoginSSD()
        {

        }

        AppObjects appObjectsSsd = new AppObjects();

        public void ValidaLoginSsd()
        {
            #region Inicialização do módulo SSD
            AppiumOptions session8 = new AppiumOptions();
            session8.AddAdditionalCapability("app", dirAplicacaoSsd);

            acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session8);


            ParamRegistroSistema();

            #endregion



            #region Usuário e Pass Sistema

            WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(20));
            
            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexLogin = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Manage().Window.Equals(appObjectsSsd.titleTelaLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsSsd.TEdit).ElementAt(0).SendKeys(appObjectsSsd.userSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsSsd.TEdit).ElementAt(1).SendKeys(appObjectsSsd.passSys);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsSsd.btnConfirmar).Click();
            #endregion

            

            #region Seleciona Empresa

            Elementos.EncontraElementoClassName(acessarModulo, appObjectsSsd.TwwDBLookupCombo);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsSsd.TwwDBLookupCombo).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsSsd.TwwDBLookupCombo).ElementAt(0).SendKeys(appObjectsSsd.empresaSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsSsd.TwwDBLookupCombo).ElementAt(0).SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(acessarModulo, appObjectsSsd.btnConfirmar).Click();

            #endregion

        }

        public void ConferenciaTelaPrincipalSsd() 
        {
            #region Conferência Tela Principal do SSD

            Thread.Sleep(1000);

            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexFt = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexFt.Title.ToString();

            var titleScreenSsd = acessarModulo.FindElementByClassName(appObjectsSsd.scrTelaPrincipal);

            bool screenSsd = false;
            WindowsElement titleValidado = null;

            if (titleScreenSsd.Text.StartsWith(appObjectsSsd.titleTelaPrincipalSSD))
            {
                screenSsd = true;
                titleValidado = titleScreenSsd;
                Debug.WriteLine("Tela Principal do SSD inicializada com sucesso.");
            }

            Assert.IsTrue(screenSsd, "Tela Principal do SSD não inicializada.");

            #endregion

        }

        public void CN008TearDown()
        {
            if (acessarModulo != null)
            {
                acessarModulo.Quit();
            }

        }

    }
}