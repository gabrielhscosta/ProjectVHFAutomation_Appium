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

    public class CN0101InserirReservaCom01HospedeNovoSemHistoricoeEmpresa : SessaoMain
    {
        
        public CN0101InserirReservaCom01HospedeNovoSemHistoricoeEmpresa()
        {

        }

        AppObjects appObjectsVhf = new AppObjects();

        public void InserirReservaCom01HospedeNovoSemHistoricoeEmpresa()
        {
            #region Inserção de uma reserva individual com 1 hóspede sem histórico estada

            FuncComuns funcComuns = new FuncComuns();

            funcComuns.ChamarAtalho("e");

            funcComuns.AcessarSubMenu(appObjectsVhf.subMenuIndividual);

            funcComuns.InserirNumNoites();

            funcComuns.PreencherCamposUh();

            funcComuns.InserirDadosHosp();

            funcComuns.InserirDocConfirmacao();

            

            #endregion
        }

        public void CN0101TearDown()
        {
            if (acessarModulo != null)
            {
                //acessarModulo.Quit();
            }

        }

    }
}