using System;
using System.Collections.Generic;
using VHFAutomation.Main;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VHFAutomation.PageObjects;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;

namespace VHFAutomation.CommonMethods
{
    public class FuncComuns : SessaoMain
    {
        public FuncComuns()
        {
            
        }

        AppObjects appObjects = new AppObjects();

        //public static WindowsDriver<WindowsElement> coNumRes;
        public static AppiumWebElement numRes;

        public void ChamarAtalho(string tecla1)
        {
            Elementos.EncontraElementoClassName(acessarModulo, appObjects.scrTelaPrincipal).SendKeys(Keys.Alt + tecla1);
        }

        public void AcessarSubMenu(string menu)
        {
            Elementos.EncontraElementoAutomationId(acessarModulo, menu).Click();
        }

        public void InserirNumNoites(string qtdNoites)
        {
            /* --- Início da forma de codificar!
             
            var anexEstd = acessarModulo.FindElementByName(appObjects.winEstada);

            var editNoites = anexEstd.FindElementsByClassName(appObjects.TEdit);

            var noitesEstd = editNoites.ElementAt(0);
            new Actions(acessarModulo).MoveToElement(noitesEstd).DoubleClick().Perform();
            noitesEstd.Clear();
            noitesEstd.SendKeys(appObjects.numNoites);
            */

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(9).SendKeys(qtdNoites);

        }

        public void InserirDatasEstada(string DataIni, string DataFim)
        {
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDateTimePicker).ElementAt(2).SendKeys(DataIni);
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDateTimePicker).ElementAt(1).SendKeys(DataFim);
        }

        /*
        public void PreencherCamposUh()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.btnUhOcupado).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winTipoUhEstadia);
            Elementos.EncontraElementoClassName(acessarModulo, appObjects.TEdit).SendKeys(appObjects.categUhStnd);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
        }
        */

        public void PreencherCamposUh(string botao)
        {
            Elementos.EncontraElementoName(acessarModulo, botao).Click();
            if (botao == appObjects.btnUhOcupado)
            {
                Elementos.EncontraElementoName(acessarModulo, appObjects.winTipoUhEstadia);
                Elementos.EncontraElementoClassName(acessarModulo, appObjects.TEdit).SendKeys(appObjects.categUhStnd);
                Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
            }
            else if (botao == appObjects.btnUhCobrado)
            {
                Elementos.EncontraElementoName(acessarModulo, appObjects.winTipoUhTarifa);
                Elementos.EncontraElementoClassName(acessarModulo, appObjects.TEdit).SendKeys(appObjects.categUhStnd);
                Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
            }
            else if (botao == appObjects.btnUhNumero)
            {
                Elementos.EncontraElementoName(acessarModulo, appObjects.winTipoUhQuarto);
                Elementos.EncontraElementoName(acessarModulo, appObjects.btnProcurar).Click();
                Elementos.EncontraElementoName(acessarModulo, appObjects.btnSim).Click();
                Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
            }
        }

        public void InserirDadosHosp()
        {
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TBitBtn).ElementAt(46).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winDadosPrincipais);

            var dadosHosp = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(19).SendKeys(dadosHosp.NomeFaker);
            
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(20).SendKeys(dadosHosp.SobrenomeFaker);
            
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(18).SendKeys(dadosHosp.EmailFaker);
            
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDBLookupCombo).ElementAt(1).SendKeys(dadosHosp.TratamentoHosp);
            
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDateTimePicker).ElementAt(3).SendKeys(dadosHosp.DtNascFaker);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnCidade).Click();
            Elementos.EncontraElementoName(acessarModulo, appObjects.winSelecCidade);
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(6).SendKeys(dadosHosp.CidadeFaker);
            
            Elementos.EncontraElementoName(acessarModulo, appObjects.btnProcurar).Click();
            
            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnIdioma).Click();
            Elementos.EncontraElementoName(acessarModulo, appObjects.winIdiomaHosp);
            Elementos.EncontraElementoClassName(acessarModulo, appObjects.TEdit).SendKeys(appObjects.idiomaHosp);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TBitBtn).ElementAt(46).Click();
        }

        public void InserirDocConfirmacao()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.winDocConfirmacaoRes);

            Elementos.EncontraElementoClassName(acessarModulo, appObjects.TEdit).SendKeys(appObjects.docEmail);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            var emailConfirRes = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TwwDBEdit).ElementAt(7).SendKeys(emailConfirRes.EmailFaker);
        }

        public void VisualizarOrcamentoRes()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.txtVisualOrcamento).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
        }

        public void ValidarSituacaoRes()
        {
            Debug.WriteLine($"*** Identificar janelas {acessarModulo.WindowHandles}");
            
            var winSitRes = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));
            winSitRes.Title.ToString();

            var sitRes = acessarModulo.FindElementByName(appObjects.winSitReserva);

            var editSitRes = sitRes.FindElementsByClassName(appObjects.TEdit);

            numRes = editSitRes.ElementAt(8);
            new Actions(acessarModulo).MoveToElement(numRes).DoubleClick().Perform();
            numRes.SendKeys(Keys.Control + "c");
            numRes.SendKeys(Keys.Control + "v");

            Console.WriteLine("Numero de Reserva Gerado: " + numRes.Text);
        }

        public void ValidarTelaPrincipalVhf()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.btnSair).Click();

            Elementos.EncontraElementoClassName(acessarModulo, appObjects.scrTelaPrincipal);
        }

        public void SelecionarEmpresa()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.winDadosPrincipais);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TBitBtn).ElementAt(44).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winSelecCliente);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(10).SendKeys(appObjects.docCliente);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
        }

        public void SelecionarContrato()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.winDadosPrincipais);

            Elementos.EncontraElementosName(acessarModulo, appObjects.btnContrato).ElementAt(2).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winContratoCliente);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnOK).Click();
        }
        
        public void BuscarHospComHistoricoEstada()
        {
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TBitBtn).ElementAt(46).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnDocHosp).Click();
            Elementos.EncontraElementoName(acessarModulo, appObjects.winSelecDocHosp);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(2).SendKeys(appObjects.docHospEstada);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TBitBtn).ElementAt(46).Click();

        }
    }
}
