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

    public class CN0107FazerReservaPeloGridDeDisponibilidade : SessaoMain
    {
        
        public CN0107FazerReservaPeloGridDeDisponibilidade()
        {

        }

        AppObjects appObjects = new AppObjects();

        public void FazerReservaPeloGridDeDisponibilidade()
        {
            #region Inserção de uma reserva individual com um hóspede sem histórico estada

            FuncComuns funcComuns = new FuncComuns();
            RealizaConsultas realizaConsultas = new RealizaConsultas();

            funcComuns.ChamarAtalho("c", "t");

            funcComuns.AcessarSubMenu(appObjects.subMenuGridDisponibilidade);

            funcComuns.InserirResGridDispo();

            funcComuns.InserirDadosHospDaReservaPeloGrid();

            funcComuns.InserirDocConfirmacaoDaReservaPeloGrid();

            funcComuns.ValidarSituacaoRes();

            realizaConsultas.SelectValidarReservaGerada();

            realizaConsultas.SelectValidarNumeroLinhasOrcamento(5);

            funcComuns.ValidarTelaPrincipalVhf();

            funcComuns.ValidarTelaPrincipalVhf();

            #endregion
        }

        public void CN0107TearDown()
        {
            if (acessarModulo != null)
            {
                //acessarModulo.Quit();
            }

        }

    }
}