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
using OpenQA.Selenium.Appium.Interfaces;

namespace VHFAutomation.TestCase
{

    public class CN_CheckOutReservaIndividual : SessaoMain
    {

        public CN_CheckOutReservaIndividual()
        {

        }

        public void CheckOutReservaIndividual()
        {
            FuncComuns funcComuns = new FuncComuns();

            funcComuns.AbrirTelaConsultaGeral();

            funcComuns.SelecionarStatusResCheckInConsultaGeral();

            funcComuns.PrimeiraEtapaCheckOutReservaIndividual();

            funcComuns.LoopingCheckOutReservas();

            funcComuns.AcessarVHF();

            funcComuns.EncerramentoAutomaticoVhfCaixa();
        }
    }
}