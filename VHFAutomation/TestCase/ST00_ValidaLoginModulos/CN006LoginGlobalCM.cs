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

    public class CN006LoginGlobal : SessaoMain
    {
        
        public CN006LoginGlobal()
        {

        }

        AppObjects appObjectsGlobal = new AppObjects();

        public void ValidaLoginGlobal()
        {
            #region Inicialização do módulo GlobalCM
            AppiumOptions session6 = new AppiumOptions();
            session6.AddAdditionalCapability("app", dirAplicacaoGlobal);

            acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session6);


            ParamRegistroSistema();

            #endregion



            #region Usuário e Pass Sistema

            WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(20));
            
            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexLogin = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Manage().Window.Equals(appObjectsGlobal.titleTelaLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsGlobal.TEdit).ElementAt(0).SendKeys(appObjectsGlobal.userSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsGlobal.TEdit).ElementAt(1).SendKeys(appObjectsGlobal.passSys);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsGlobal.btnConfirmar).Click();
            #endregion

            

            #region Seleciona Empresa

            Elementos.EncontraElementoClassName(acessarModulo, appObjectsGlobal.comboBoxLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsGlobal.comboBoxLogin).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsGlobal.comboBoxLogin).ElementAt(0).SendKeys(appObjectsGlobal.empresaSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsGlobal.comboBoxLogin).ElementAt(0).SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(acessarModulo, appObjectsGlobal.btnConfirmar).Click();

            #endregion

        }

        public void ConferenciaTelaPrincipalGlobal() 
        {
            #region Conferência Tela Principal do Global

            Thread.Sleep(1000);

            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexFt = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexFt.Title.ToString();

            var titleScreenGlobal = acessarModulo.FindElementByClassName(appObjectsGlobal.scrTelaPrincipal);

            bool screenGlobal = false;
            WindowsElement titleValidado = null;

            if (titleScreenGlobal.Text.StartsWith(appObjectsGlobal.titleTelaPrincGlobal))
            {
                screenGlobal = true;
                titleValidado = titleScreenGlobal;
                Debug.WriteLine("Tela Principal do Global CM inicializada com sucesso.");
            }

            Assert.IsTrue(screenGlobal, "Tela Principal do Global CM não inicializada.");

            #endregion

        }

        public void CN006TearDown()
        {
            if (acessarModulo != null)
            {
                acessarModulo.Quit();
            }

        }

    }
}