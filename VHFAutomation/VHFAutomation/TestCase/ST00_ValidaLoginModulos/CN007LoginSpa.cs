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
using Microsoft.Win32;

namespace VHFAutomation.TestCase
{

    public class CN007LoginSpa : SessaoMain
    {
        
        public CN007LoginSpa()
        {

        }

        AppObjects appObjectsSpa = new AppObjects();

        #region Parâmetros Registro Base Oracle
        public static void RegistraBaseHomologacaoSpa(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\SPA";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void ParamRegistroSistemaOracle()
        {
            AppObjects appObjectsSpa = new AppObjects();

            Elementos.EncontraElementoClassName(SessaoMain.acessarModulo, "TfcTreeView");

            WebDriverWait wtReg = new WebDriverWait(SessaoMain.acessarModulo, TimeSpan.FromSeconds(20));

            var mParamConex = Elementos.EncontraElementoName(SessaoMain.acessarModulo, appObjectsSpa.txtParamConexao);
            DoubleClickElement(mParamConex);

            var mConfig = Elementos.EncontraElementoName(SessaoMain.acessarModulo, appObjectsSpa.txtConfig);
            DoubleClickElement(mConfig);

            var mOracle = Elementos.EncontraElementoName(SessaoMain.acessarModulo, appObjectsSpa.txtOracle);
            DoubleClickElement(mOracle);

            Elementos.EncontraElementoName(SessaoMain.acessarModulo, appObjectsSpa.btnConfirmar).Click();

        }
        
        private static void DoubleClickElement(AppiumWebElement moveElement)
        {
            Actions actsTree = new Actions(SessaoMain.acessarModulo);
            actsTree.MoveToElement(moveElement);
            actsTree.DoubleClick();
            actsTree.Perform();
        }

        #endregion



        public void ValidaLoginSpa()
        {
            #region Inicialização do módulo Spa
            RegistraBaseHomologacaoSpa("KHOTEL", "ORACLE", "RJOSRVDBODEV001");


            AppiumOptions session7 = new AppiumOptions();
            session7.AddAdditionalCapability("app", dirAplicacaoSpa);

            acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session7);


            ParamRegistroSistemaOracle();

            #endregion



            #region Usuário e Pass Sistema

            WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(20));
            
            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexLogin = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Manage().Window.Equals(appObjectsSpa.titleTelaLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsSpa.caixaTexto).ElementAt(0).SendKeys(appObjectsSpa.userSysOracle);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsSpa.caixaTexto).ElementAt(1).SendKeys(appObjectsSpa.passSysOracle);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsSpa.btnConfirmar).Click();
            #endregion

            

            #region Seleciona Empresa

            Elementos.EncontraElementoClassName(acessarModulo, appObjectsSpa.comboBoxLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsSpa.comboBoxLogin).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsSpa.comboBoxLogin).ElementAt(0).SendKeys(appObjectsSpa.empresaSysOracle);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsSpa.comboBoxLogin).ElementAt(0).SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(acessarModulo, appObjectsSpa.btnConfirmar).Click();

            #endregion
            
        }
        
        public void ConferenciaTelaPrincipalSpa()
        {
            #region Conferência Tela Principal do SPA

            Thread.Sleep(2000);

            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexSpa = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexSpa.Title.ToString();

            var titleScreenSpa = acessarModulo.FindElementByClassName(appObjectsSpa.scrTelaPrincipal);

            bool screenSpa = false;
            WindowsElement titleValidado = null;

            if (titleScreenSpa.Text.StartsWith(appObjectsSpa.titleTelaPrincipalSPA))
            {
                screenSpa = true;
                titleValidado = titleScreenSpa;
                Debug.WriteLine("Tela Principal do SPA inicializada com sucesso.");
            }

            Assert.IsTrue(screenSpa, "Tela Principal do SPA não inicializada.");

            #endregion

        }

        public void CN007TearDown()
        {
            if (acessarModulo != null)
            {
                acessarModulo.Quit();
            }
            
        }   
        
    }
}