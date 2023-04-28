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
using static VHF.DadosYaml.DeserializedObject;

namespace VHFAutomation.TestCase.ST02_OrcamentoReserva
{
    public class CN0201FazerReservaComAlteracoesProgramadas : SessaoMain
    {
        public CN0201FazerReservaComAlteracoesProgramadas()
        {

        }

        public void FazerReservaComAlteracoesProgramadas()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();
            AppObjects appObjects = new AppObjects();


            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites("6");

            funcComuns.PreencherCamposUh(appObjects.btnUhOcupado);

            funcComuns.SelecionarEmpresa();

            funcComuns.InserirDadosHosp();

            funcComuns.InserirDocConfirmacao();

            //funcComuns.CliqueParaVisualizarValores();

            //funcComuns.AlterarParteInferiorOrcamentoRes();

            /*

            funcComuns.ValidarSituacaoRes();

            validacoes.ValidaReservaGerada();

            validacoes.ValidaNumeroLinhaDoOrc(6);

            validacoes.ValidaOrcamento("stnd", 1, 0, 0);

            funcComuns.ValidarTelaPrincipalVhf();

            */
        }
    }
}