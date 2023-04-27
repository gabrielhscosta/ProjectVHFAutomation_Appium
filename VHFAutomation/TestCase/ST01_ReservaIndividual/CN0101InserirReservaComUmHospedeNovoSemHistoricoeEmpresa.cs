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

    public class CN0101InserirReservaComUmHospedeNovoSemHistoricoeEmpresa : SessaoMain
    {
        
        public CN0101InserirReservaComUmHospedeNovoSemHistoricoeEmpresa()
        {

        }

        AppObjects appObjects = new AppObjects();

        public void InserirReservaComUmHospedeNovoSemHistoricoeEmpresa()
        {
            #region Inserção de uma reserva individual com um hóspede sem histórico estada

            FuncComuns funcComuns = new FuncComuns();
            RealizaConsultas realizaConsultas = new RealizaConsultas();

            funcComuns.ChamarAtalho("e", "");

            funcComuns.AcessarSubMenu(appObjects.subMenuIndividual);

            funcComuns.InserirNumNoites("6");

            funcComuns.PreencherCamposUh(appObjects.btnUhOcupado);

            funcComuns.InserirDadosHosp();

            funcComuns.InserirDocConfirmacao();

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            realizaConsultas.SelectValidarReservaGerada();

            realizaConsultas.SelectValidarNumeroLinhasOrcamento(6);

            //realizaConsultas.ValidarFnrhMovimentoHospede();

            funcComuns.ValidarTelaPrincipalVhf();

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