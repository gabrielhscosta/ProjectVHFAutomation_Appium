using Microsoft.Win32;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using VHFAutomation.PageObjects;
using VHFAutomation.Main;
using OpenQA.Selenium.Support.UI;
using System;

namespace VHFAutomation.CommonMethods
{
    public class RegistroBase
    {

        public RegistroBase()
        {

        }
        public static void RegistraBaseHomologacaoVhf(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\FrontOffice";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void RegistraBaseHomologacaoVhfCaixa(string aliasServidor, string driverServidor, string nomeServidor)
        {
            string PATH = @"SOFTWARE\CM\VHFCaixa";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH, true);
            registryKey.SetValue("Alias Servidor", aliasServidor);
            registryKey.SetValue("Driver Servidor", driverServidor);
            registryKey.SetValue("Nome Servidor", nomeServidor);
            registryKey.Close();
        }

        public static void ParamRegistroSistema()
        {
            AppObjects appObjectsVhf = new AppObjects();

            Elementos.EncontraElementoClassName(SessaoMain.acessarModulo, "TfcTreeView");

            WebDriverWait wtReg = new WebDriverWait(SessaoMain.acessarModulo, TimeSpan.FromSeconds(20));

            var mParamConex = Elementos.EncontraElementoName(SessaoMain.acessarModulo, appObjectsVhf.txtParamConexao);
            DoubleClickElement(mParamConex);

            var mConfig = Elementos.EncontraElementoName(SessaoMain.acessarModulo, appObjectsVhf.txtConfig);
            DoubleClickElement(mConfig);

            var mSql = Elementos.EncontraElementoName(SessaoMain.acessarModulo, appObjectsVhf.txtSQLServer);
            DoubleClickElement(mSql);

            Elementos.EncontraElementoName(SessaoMain.acessarModulo, appObjectsVhf.btnConfirmar).Click();

        }

        //Método para realizar um Duplo Click.
        private static void DoubleClickElement(AppiumWebElement moveElement)
        {
            Actions actsTree = new Actions(SessaoMain.acessarModulo);
            actsTree.MoveToElement(moveElement);
            actsTree.DoubleClick();
            actsTree.Perform();
        }

    }   

}
