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

    public class CN004LoginEvento : SessaoMain
    {
        
        public CN004LoginEvento()
        {

        }

        AppObjects appObjectsEvento = new AppObjects();

        public void ValidaLoginEvento()
        {
            #region Inicialização do módulo Evento
            AppiumOptions session4 = new AppiumOptions();
            session4.AddAdditionalCapability("app", dirAplicacaoEvento);

            acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session4);


            ParamRegistroSistema();

            #endregion



            #region Usuário e Pass Sistema

            WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(20));
            
            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexLogin = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Manage().Window.Equals(appObjectsEvento.titleTelaLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsEvento.TEdit).ElementAt(0).SendKeys(appObjectsEvento.userSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsEvento.TEdit).ElementAt(1).SendKeys(appObjectsEvento.passSys);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsEvento.btnConfirmar).Click();
            #endregion

            

            #region Seleciona Empresa

            Elementos.EncontraElementoClassName(acessarModulo, appObjectsEvento.TwwDBLookupCombo);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsEvento.TwwDBLookupCombo).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsEvento.TwwDBLookupCombo).ElementAt(0).SendKeys(appObjectsEvento.empresaSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsEvento.TwwDBLookupCombo).ElementAt(0).SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(acessarModulo, appObjectsEvento.btnConfirmar).Click();

            #endregion

        }

        public void ConferenciaTelaPrincipalEvento() 
        {
            #region Conferência Tela Principal do Evento

            Thread.Sleep(1000);

            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexEv = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexEv.Title.ToString();

            var titleScreenEvento = acessarModulo.FindElementByClassName(appObjectsEvento.scrTelaPrincipal);

            bool screenEvento = false;
            WindowsElement titleValidado = null;

            if (titleScreenEvento.Text.StartsWith(appObjectsEvento.titleTelaPrincEvento))
            {
                screenEvento = true;
                titleValidado = titleScreenEvento;
                Debug.WriteLine("Tela Principal do Evento inicializada com sucesso.");
            }

            Assert.IsTrue(screenEvento, "Tela Principal do Evento não inicializada.");

            #endregion

        }

        public void CN004TearDown()
        {
            if (acessarModulo != null)
            {
                acessarModulo.Quit();
            }

        }

    }
}