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
            var anexResIndiv = acessarModulo.FindElementByClassName("TfrmReserva");
            var anexEstd = anexResIndiv.FindElementByName("Estada");
            var allEdits = anexEstd.FindElementsByTagName("Edit");

            Debug.WriteLine($"\nQuantidade de Campos TEdit da Estada: {allEdits.Count}");

            var cNoites = allEdits.ElementAt(2);
            new Actions(acessarModulo).MoveToElement(cNoites).DoubleClick().Perform();
            cNoites.Clear();
            cNoites.SendKeys("3");
        }

        public void PreencherCamposUh()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnUhOcupado).Click();

            Elementos.EncontraElementoName(acessarModulo, "Tipo de UH Estadia");
            Elementos.EncontraElementoClassName(acessarModulo, appObjectsVhf.caixaTexto).SendKeys("STND");

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
            Elementos.EncontraElementosClassName(acessarModulo, "TBitBtn").ElementAt(46).Click();

            var allEditsHosp = acessarModulo.FindElementsByTagName("Edit");

            Debug.WriteLine($"\nQuantidade de Campos TEdit da Estada: {allEditsHosp.Count}");

            Elementos.EncontraElementosClassName(acessarModulo, "TEdit").ElementAt(19).SendKeys("TEEST");
            Elementos.EncontraElementosClassName(acessarModulo, "TEdit").ElementAt(20).SendKeys("TWO");

            Elementos.EncontraElementosClassName(acessarModulo, "TBitBtn").ElementAt(47).Click();
        }


        public void InserirDocConfirmacao()
        {
            Elementos.EncontraElementoName(acessarModulo, "Documento de Confirmação");

            Elementos.EncontraElementoClassName(acessarModulo, "TEdit").SendKeys("EM");

            Elementos.EncontraElementoName(acessarModulo, "Confirmar").Click();

            Elementos.EncontraElementosClassName(acessarModulo, "TwwDBEdit").ElementAt(7).SendKeys("teste@gmail.com");

            //Elementos.EncontraElementoName(acessarModulo, appObjectsVhf.btnConfirmar).Click();

        }
    }
}
