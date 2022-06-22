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

    public class CN002LoginVHFCaixa : SessaoMain
    {
        
        public CN002LoginVHFCaixa()
        {

        }

        AppObjects appObjectsVhfCaixa = new AppObjects();

        public void ValidaLoginVHFCaixa()
        {
            #region Inicialização do módulo VHF Caixa
            AppiumOptions session2 = new AppiumOptions();
            session2.AddAdditionalCapability("app", dirAplicacaoVHFCaixa);

            acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session2);
            

            ParamRegistroSistema();

            #endregion


            #region Usuário e Pass Sistema

            WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(60));

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhfCaixa.titleTelaLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhfCaixa.TEdit).ElementAt(0).SendKeys( appObjectsVhfCaixa.userSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhfCaixa.TEdit).ElementAt(1).SendKeys( appObjectsVhfCaixa.passSys);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhfCaixa.btnConfirmar).Click();

            #endregion

            

            #region Seleciona Empresa

            Elementos.EncontraElementoClassName(acessarModulo, appObjectsVhfCaixa.comboBoxLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhfCaixa.comboBoxLogin).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhfCaixa.comboBoxLogin).ElementAt(0).SendKeys( appObjectsVhfCaixa.empresaSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhfCaixa.comboBoxLogin).ElementAt(0).SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(acessarModulo,  appObjectsVhfCaixa.btnConfirmar).Click();

            #endregion

        }

        public void ConferenciaTelaPrincipalVHFCaixa() 
        {
            #region Conferência Tela Principal VHF Caixa

            WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(60));

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhfCaixa.scrTelaCartaoConsCaixa);

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhfCaixa.btnCancelar).Click();

            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexCaixa = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexCaixa.Title.ToString();

            var titleScreenOperaCaixa = acessarModulo.FindElementByClassName(appObjectsVhfCaixa.scrTelaPrincipalCAIXA);

            bool screenOpeCaixa = false;
            WindowsElement titleVhfCaixa = null;

            if (titleScreenOperaCaixa.Text.StartsWith(appObjectsVhfCaixa.titleTelaPrincVHFCaixa))
            {
                screenOpeCaixa = true;
                titleVhfCaixa = titleScreenOperaCaixa;
                Debug.WriteLine("Tela Principal do VHF Caixa inicializada com sucesso.");                

            }

            Assert.IsTrue(screenOpeCaixa, "Tela Principal do VHF Caixa não inicializada");

            #endregion
        }

        public void CN002TearDown()
        {
            if (acessarModulo != null)
            {
                acessarModulo.Quit();
            }

        }

    }
}