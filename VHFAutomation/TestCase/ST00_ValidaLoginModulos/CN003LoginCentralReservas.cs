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

    public class CN003LoginCentralReservas : SessaoMain
    {
        
        public CN003LoginCentralReservas()
        {

        }

        AppObjects appObjectsCentralR = new AppObjects();

        public void ValidaLoginCentralReservas()
        {
            #region Inicialização do módulo Central de Reservas
            AppiumOptions session3 = new AppiumOptions();
            session3.AddAdditionalCapability("app", dirAplicacaoCentralReservas);

            acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session3);


            ParamRegistroSistema();

            #endregion

            #region Usuário e Pass Sistema

            WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(20));
            
            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexLogin = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Manage().Window.Equals(appObjectsCentralR.titleTelaLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsCentralR.caixaTexto).ElementAt(0).SendKeys(appObjectsCentralR.userSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsCentralR.caixaTexto).ElementAt(1).SendKeys(appObjectsCentralR.passSys);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsCentralR.btnConfirmar).Click();
            #endregion

        }

        public void ConferenciaTelaPrincipalCentralReservas()
        {
            #region Conferência Tela Principal da Central de Reservas

            Thread.Sleep(2000);

            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexCr = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexCr.Title.ToString();

            var titleScreenCentralRes = acessarModulo.FindElementByClassName(appObjectsCentralR.scrTelaPrincipal);

            bool screenCentralRes = false;
            WindowsElement titleValidado = null;

            if(titleScreenCentralRes.Text.StartsWith(appObjectsCentralR.titleTelaPrincCentralRes))
            {
                screenCentralRes = true;
                titleValidado = titleScreenCentralRes;
                Debug.WriteLine("Tela Principal da Central de Reservas inicializada com sucesso.");
            }

            Assert.IsTrue(screenCentralRes, "Tela Principal da Central de Reservas não inicializada.");

            #endregion

        }

        public void CN003TearDown()
        {
            if (acessarModulo != null)
            {
                acessarModulo.Quit();
            }

        }

    }
}