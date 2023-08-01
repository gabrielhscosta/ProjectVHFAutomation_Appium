﻿using VHFAutomation.CommonMethods;
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

    public class CN_CancelarReservaGrupo : SessaoMain
    {

        public CN_CancelarReservaGrupo()
        {

        }

        public void CancelarReservaGrupo()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();

            funcComuns.ChamarAtalho("e", "g", "n");

            funcComuns.PrimeiraEtapaCancelarReservaGrupo();

            funcComuns.ValidarSituacaoResGrupo();

            validacoes.ValidaStatusReservaGrp(6);

            funcComuns.SairTela();

            funcComuns.LoopingCancelamentoReservasGrupo();

            funcComuns.ValidarTelaPrincipalVhf();
        }
    }
}