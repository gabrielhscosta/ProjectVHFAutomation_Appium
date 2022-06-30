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

namespace VHFAutomation.CommonMethods
{
    public class FuncComuns : SessaoMain
    {
        public FuncComuns()
        {
            
        }

        AppObjects appObjects = new AppObjects();

        public void ChamarAtalho(string tecla1)
        {
            Elementos.EncontraElementoClassName(acessarModulo, appObjects.scrTelaPrincipal).SendKeys(Keys.Alt + tecla1);
        }

        public void AcessarSubMenu(string menu)
        {
            Elementos.EncontraElementoAutomationId(acessarModulo, menu).Click();
        }

        public void InserirNumNoites()
        {
            /*
            var anexResIndiv = acessarModulo.FindElementByClassName(appObjects.scrTelaReserva);
            var anexEstd = anexResIndiv.FindElementByName(appObjects.winEstada);
            var allEdits = anexEstd.FindElementsByTagName(appObjects.tagEdit);

            Debug.WriteLine($"\nQtd de campos Edit da Estada: {allEdits.Count}");

            var cNoites = allEdits.ElementAt(2);
            new Actions(acessarModulo).MoveToElement(cNoites).DoubleClick().Perform();
            cNoites.Clear();
            cNoites.SendKeys(appObjects.numNoites);
            */

            var anexEstd = acessarModulo.FindElementByName(appObjects.winEstada);

            var editNoites = anexEstd.FindElementsByClassName(appObjects.TEdit);

            var noitesEstd = editNoites.ElementAt(0);
            new Actions(acessarModulo).MoveToElement(noitesEstd).DoubleClick().Perform();
            noitesEstd.Clear();
            noitesEstd.SendKeys(appObjects.numNoites);
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
                Elementos.EncontraElementoClassName(acessarModulo, appObjects.TEdit).SendKeys(appObjects.categUhSuite);
                Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
            }
            else if (botao == appObjects.btnUhCobrado)
            {
                Elementos.EncontraElementoName(acessarModulo, appObjects.winTipoUhTarifa);
                Elementos.EncontraElementoClassName(acessarModulo, appObjects.TEdit).SendKeys(appObjects.categUhSuite);
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

            //var allEditsHosp = acessarModulo.FindElementsByClassName("TEdit");

            //FindElementsByTagName(appObjects.tagEdit);
            //Debug.WriteLine($"\nQtd de campos Edit Dados do Hospede: {allEditsHosp.Count}");

            //var dataNascHosp = acessarModulo.FindElementsByClassName("TCMDateTimePicker");

            //var allLookupCombo = acessarModulo.FindElementsByClassName("TCMDBLookupCombo");

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
        }

        public void ConfirmarInsercaoDadosHosp()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.winDadosPrincipais);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TBitBtn).ElementAt(46).Click();
        }

        public void InserirDocConfirmacao()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.winDocConfirmacaoRes);

            Elementos.EncontraElementoClassName(acessarModulo, appObjects.TEdit).SendKeys(appObjects.tipoDocConfirmacao);

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

        }

    }
}
