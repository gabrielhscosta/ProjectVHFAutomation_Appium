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

    public class CN0103InserirReservaComUmPaxComHistóricoDeHospedeEComEmpresaEContrato : SessaoMain
    {
        
        public CN0103InserirReservaComUmPaxComHistóricoDeHospedeEComEmpresaEContrato()
        {

        }

        AppObjects appObjects = new AppObjects();

        public void CN0103InserirReservaComUmPaxComHistoricoDeHospedeEComEmpresaEContrato()
        {
            #region Inserção de uma reserva individual com um hóspede sem histórico estada

            FuncComuns funcComuns = new FuncComuns();
            RealizaConsultas realizaConsultas = new RealizaConsultas();
            Validacoes validacoes = new Validacoes();

            funcComuns.ChamarAtalho("e");

            funcComuns.AcessarSubMenu(appObjects.subMenuIndividual);

            funcComuns.InserirNumNoites("6");

            funcComuns.PreencherCamposUh(appObjects.btnUhOcupado);

            funcComuns.SelecionarEmpresa();

            funcComuns.SelecionarContrato();

            funcComuns.BuscarHospComHistoricoEstada();

            funcComuns.InserirDocConfirmacao();

            funcComuns.VisualizarOrcamentoRes();

            funcComuns.ValidarSituacaoRes();

            realizaConsultas.SelectValidarReservaGerada();

            realizaConsultas.SelectValidarNumeroLinhasOrcamento(6);

            //realizaConsultas.ValidarFnrhMovimentoHospede();

            validacoes.ValidaOrcamento("stnd", 1);

            funcComuns.ValidarTelaPrincipalVhf();

            #endregion
        }

        public void CN0103TearDown()
        {
            if (acessarModulo != null)
            {
                //acessarModulo.Quit();
            }

        }

    }
}