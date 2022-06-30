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

        AppObjects appObjects = new AppObjects();

        public void InserirReservaCom01HospedeNovoSemHistoricoeEmpresa()
        {
            #region Inserção de uma reserva individual com 1 hóspede sem histórico estada

            FuncComuns funcComuns = new FuncComuns();

            funcComuns.ChamarAtalho("e");

            funcComuns.AcessarSubMenu(appObjects.subMenuIndividual);

            funcComuns.InserirNumNoites();

            funcComuns.PreencherCamposUh(appObjects.btnUhOcupado);

            funcComuns.InserirDadosHosp();

            funcComuns.ConfirmarInsercaoDadosHosp();

            funcComuns.InserirDocConfirmacao();

            funcComuns.VisualizarOrcamentoRes();

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