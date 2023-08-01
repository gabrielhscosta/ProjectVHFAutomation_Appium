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

    public class CN_AlterarStatusDaGovernancaParaLimpo : SessaoMain
    {

        public CN_AlterarStatusDaGovernancaParaLimpo()
        {

        }

        public void AlterarStatusDaGovernancaParaLimpo()
        {
            FuncComuns funcComuns = new FuncComuns();

            funcComuns.AbrirTelaStatusDaGovernanca();

            funcComuns.AlterarStatusDaGovernanca();

            funcComuns.ValidarTelaPrincipalVhf();
        }
    }
}