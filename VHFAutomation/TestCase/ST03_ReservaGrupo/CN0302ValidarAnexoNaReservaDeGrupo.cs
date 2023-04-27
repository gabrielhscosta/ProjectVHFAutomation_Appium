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

    public class CN0302ValidarAnexoNaReservaDeGrupo : SessaoMain
    {
        
        public CN0302ValidarAnexoNaReservaDeGrupo()
        {

        }

        AppObjects appObjects = new AppObjects();

        public void ValidarAnexoNaReservaDeGrupo()
        {
            #region Validar anexo na reserva de grupo

            FuncComuns funcComuns = new FuncComuns();
            RealizaConsultas realizaConsultas = new RealizaConsultas();
            
            funcComuns.ChamarAtalho("e", "g", "i");

            funcComuns.InserirNomeGrupo();

            funcComuns.InserirNumNoitesResGrupo("7");

            funcComuns.SelecionarEmpresaResGrupo();

            funcComuns.SelecionarContratoResGrupo();

            funcComuns.InserirDocConfirmacaoResGrupo();

            funcComuns.SelecionarAbreMasterResGrupo();

            funcComuns.InserirAnexoResGrupo();

            //funcComuns.ValidarTelaPrincipalVhf();

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