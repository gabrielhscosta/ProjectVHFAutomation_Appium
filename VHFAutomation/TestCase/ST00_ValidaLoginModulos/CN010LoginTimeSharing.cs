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

    public class CN010LoginTimeSharing : SessaoMain
    {
        
        public CN010LoginTimeSharing()
        {

        }

        AppObjects appObjectsTs = new AppObjects();

        public void ValidaLoginTimeSharing()
        {
            #region Inicialização do módulo TimeSharing
            AppiumOptions session10 = new AppiumOptions();
            session10.AddAdditionalCapability("app", dirAplicacaoTimeSharing);

            acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session10);


            ParamRegistroSistema();

            #endregion



            #region Usuário e Pass Sistema

            //WebDriverWait waitLogin = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(60));
            
            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexLogin = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexLogin.Title.ToString();
            anexLogin.Manage().Window.Equals("TimeSharing");
            
            Thread.Sleep(1000);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsTs.caixaTexto).ElementAt(0).SendKeys(appObjectsTs.userSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsTs.caixaTexto).ElementAt(1).SendKeys(appObjectsTs.passSys);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsTs.btnConfirmar).Click();
            #endregion

            

            #region Seleciona Empresa

            Elementos.EncontraElementoClassName(acessarModulo, appObjectsTs.comboBoxLogin);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsTs.comboBoxLogin).ElementAt(0).Clear();
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsTs.comboBoxLogin).ElementAt(0).SendKeys(appObjectsTs.empresaSys);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsTs.comboBoxLogin).ElementAt(0).SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(acessarModulo, appObjectsTs.btnConfirmar).Click();

            #endregion


            #region Seleciona Agência TS

            var selecAgencia = Elementos.EncontraElementoClassName(acessarModulo, appObjectsTs.comboBoxAgenciaTS);

            //Elementos.EncontraElementosClassName(acessarModulo, appObjectsTs.comboBoxAgenciaTS).ElementAt(0).Clear();
            //Elementos.EncontraElementosClassName(acessarModulo, appObjectsTs.comboBoxAgenciaTS).ElementAt(0).SendKeys(appObjectsTs.agenciaTs);
            //Elementos.EncontraElementosClassName(acessarModulo, appObjectsTs.comboBoxAgenciaTS).ElementAt(0).SendKeys(Keys.Tab);


            //FindElementByClassName("TwwPopupGrid");
            //REST ASSESSORIA JURÍDICA LTDA
                        

            selecAgencia.SendKeys(Keys.Down);
            selecAgencia.Click();

            var listAgenc = selecAgencia.FindElementsByTagName(appObjectsTs.comboBoxGridTs);
            Debug.WriteLine($"*** Agências Cadastradas: {listAgenc.Count}");

            foreach(var indexAgenc in listAgenc)
            {
                if(indexAgenc.Text == "REST ASSESSORIA JURÍDICA LTDA")
                {
                    indexAgenc.Click();
                }
            }
            

            Elementos.EncontraElementoName(acessarModulo, appObjectsTs.btnConfirmar).Click();


            #endregion

        }

        public void ConferenciaTelaPrincipalTimeSharing() 
        {
            #region Conferência Tela Principal do TimeSharing

            Thread.Sleep(1000);

            Debug.WriteLine($"*** Identificador da janela: {acessarModulo.WindowHandles}");

            var anexTs = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            anexTs.Title.ToString();

            var titleScreenTs = acessarModulo.FindElementByClassName(appObjectsTs.scrTelaPrincipal);

            bool screenTs = false;
            WindowsElement titleValidado = null;

            if (titleScreenTs.Text.StartsWith(appObjectsTs.titleTelaPrincipalTS))
            {
                screenTs = true;
                titleValidado = titleScreenTs;
                Debug.WriteLine("Tela Principal do TimeSharing inicializada com sucesso.");
            }

            Assert.IsTrue(screenTs, "Tela Principal do TimeSharing não inicializada.");

            #endregion

        }
    }
}