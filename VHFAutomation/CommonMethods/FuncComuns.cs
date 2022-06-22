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

        AppObjects appObjectsVhf = new AppObjects();

        public void ChamarAtalho(string tecla1)
        {
            Elementos.EncontraElementoClassName(acessarModulo, appObjectsVhf.scrTelaPrincipal).SendKeys(Keys.Alt + tecla1);
        }

        public void AcessarSubMenu(string menu)
        {
            Elementos.EncontraElementoAutomationId(acessarModulo, menu).Click();
        }

        public void InserirNumNoites()
        {
            var anexResIndiv = acessarModulo.FindElementByClassName(appObjectsVhf.scrTelaReserva);
            var anexEstd = anexResIndiv.FindElementByName(appObjectsVhf.winEstada);
            var allEdits = anexEstd.FindElementsByTagName(appObjectsVhf.tagEdit);

            Debug.WriteLine($"\nQtd de campos Edit da Estada: {allEdits.Count}");

            var cNoites = allEdits.ElementAt(2);
            new Actions(acessarModulo).MoveToElement(cNoites).DoubleClick().Perform();
            cNoites.Clear();
            cNoites.SendKeys(appObjectsVhf.numNoites);
        }

        public void PreencherCamposUh()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnUhOcupado).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.winTipoUhEstadia);
            Elementos.EncontraElementoClassName(acessarModulo, appObjectsVhf.caixaTexto).SendKeys(appObjectsVhf.categUhStnd);

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnConfirmar).Click();
        }

        /*
            
            Elementos.EncontraElementoName(sessionVHF, "numero").Click();
            Elementos.EncontraElementoName(sessionVHF, "Seleciona UH");
            //var tmp = Elementos.EncontraElementosClassName(sessionVHF, "TEdit");
            Elementos.EncontraElementoName(sessionVHF, "Procurar").Click();
            Elementos.EncontraElementoName(sessionVHF, "Sim").Click();
            Elementos.EncontraElementoName(sessionVHF, "Confirmar").Click();
        */

        public void InserirDadosHosp()
        {
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.TBitBtn).ElementAt(46).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.winDadosPrincipais);

            //var allEditsHosp = acessarModulo.FindElementsByClassName("TEdit");

            //FindElementsByTagName(appObjectsVhf.tagEdit);
            //Debug.WriteLine($"\nQtd de campos Edit Dados do Hospede: {allEditsHosp.Count}");

            //var dataNascHosp = acessarModulo.FindElementsByClassName("TCMDateTimePicker");

            //var allLookupCombo = acessarModulo.FindElementsByClassName("TCMDBLookupCombo");

            var dadosHosp = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.caixaTexto).ElementAt(19).SendKeys(dadosHosp.NomeFaker);
            
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.caixaTexto).ElementAt(20).SendKeys(dadosHosp.SobrenomeFaker);
            
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.caixaTexto).ElementAt(18).SendKeys(dadosHosp.EmailFaker);
            
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.TCMDBLookupCombo).ElementAt(1).SendKeys(dadosHosp.TratamentoHosp);
            
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.TCMDateTimePicker).ElementAt(3).SendKeys(dadosHosp.DtNascFaker);

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnCidade).Click();
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.winSelecCidade);
            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.caixaTexto).ElementAt(6).SendKeys(dadosHosp.CidadeFaker);
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnProcurar).Click();
            
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnConfirmar).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnIdioma).Click();
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.winIdiomaHosp);
            Elementos.EncontraElementoClassName(acessarModulo, appObjectsVhf.caixaTexto).SendKeys(appObjectsVhf.idiomaHosp);

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnConfirmar).Click();
        }

        public void ConfirmarInsercaoDadosHosp()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.winDadosPrincipais);

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.TBitBtn).ElementAt(46).Click();
        }

        public void InserirDocConfirmacao()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.winDocConfirmacaoRes);

            Elementos.EncontraElementoClassName(acessarModulo, appObjectsVhf.caixaTexto).SendKeys(appObjectsVhf.tipoDocConfirmacao);

            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnConfirmar).Click();

            var emailConfirRes = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(acessarModulo, appObjectsVhf.TwwDBEdit).ElementAt(7).SendKeys(emailConfirRes.EmailFaker);

            //Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnConfirmar).Click();

        }
    }
}
