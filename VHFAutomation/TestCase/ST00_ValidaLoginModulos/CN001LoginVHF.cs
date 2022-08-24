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

    public class CN001LoginVHF : SessaoMain
    {
        
        public CN001LoginVHF()
        {

        }

        AppObjects appObjectsVhf = new AppObjects();

        public void ValidaLoginVHF()
        {
            #region Inicialização do módulo VHF
            if (acessarModulo == null)
            {
                AppiumOptions session1 = new AppiumOptions();
                session1.AddAdditionalCapability("app", dirAplicacaoVHF);

                acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session1);

            }

            ParamRegistroSistema();

            #endregion

            #region Usuário e Pass Sistema
            
            WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(60));
            
            Debug.WriteLine($"*** Identificar janelas: {acessarModulo.WindowHandles}");

            var anexLogin = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Manage().Window.Equals(appObjectsVhf.titleTelaLogin);
            

            //Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.titleTelaLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.TEdit).ElementAt(0).SendKeys(appObjectsVhf.userSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.TEdit).ElementAt(1).SendKeys(appObjectsVhf.passSys);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnConfirmar).Click();

            #endregion

            

            #region Seleciona Empresa

            Elementos.EncontraElementoClassName(acessarModulo, appObjectsVhf.comboBoxLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.comboBoxLogin).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.comboBoxLogin).ElementAt(0).SendKeys(appObjectsVhf.empresaSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.comboBoxLogin).ElementAt(0).SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnConfirmar).Click();

            #endregion


            #region Janela Atenção

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.txtAlertAtencao);
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnOK).Click();

            #endregion

        }

        public void ConferenciaTelaPrincipalVHF() 
        {
            #region Conferência Tela Principal VHF

            var titleScreenPrincipal = acessarModulo.FindElementByClassName(appObjectsVhf.scrTelaPrincipal);

            bool screenPrincipal = false;
            WindowsElement titleValidado = null;

            if(titleScreenPrincipal.Text.StartsWith(appObjectsVhf.titleTelaPrincipalVHF))
            {
                screenPrincipal = true;
                titleValidado = titleScreenPrincipal;
                Debug.WriteLine("Tela Principal do VHF inicializada com sucesso.");
            }

            Assert.IsTrue(screenPrincipal, "Tela Principal do VHF não inicializada.");

            #endregion

        }

        public void CN001TearDown()
        {
            if (acessarModulo != null)
            {
                //acessarModulo.Quit();
            }

        }

    }
}