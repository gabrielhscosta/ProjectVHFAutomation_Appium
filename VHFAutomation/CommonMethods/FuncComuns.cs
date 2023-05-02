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
using System.Threading;
using StringExtensionLibrary;

namespace VHFAutomation.CommonMethods
{
    public class FuncComuns : SessaoMain
    {
        public FuncComuns()
        {
            
        }

        AppObjects appObjects = new AppObjects();
        Validacoes validacoes = new Validacoes();

        //public static WindowsDriver<WindowsElement> coNumRes;
        public static AppiumWebElement numRes;
        public static AppiumWebElement numResGrp;

        public void ChamarAtalho(string tecla1, string tecla2, string tecla3 = null, string tecla4 = null)
        {
            if (tecla4 != null)
            {
                Elementos.EncontraElementoTagName(acessarModulo, appObjects.tagMenuItem).SendKeys(Keys.Alt + tecla1 + tecla2 + tecla3 + tecla4);
            }
            else if (tecla3 != null)
            {
                Elementos.EncontraElementoTagName(acessarModulo, appObjects.tagMenuItem).SendKeys(Keys.Alt + tecla1 + tecla2 + tecla3);
            }
            else
            {
                Elementos.EncontraElementoTagName(acessarModulo, appObjects.tagMenuItem);
                Elementos.EncontraElementoTagName(acessarModulo, appObjects.tagMenuItem).SendKeys(Keys.Alt + tecla1 + tecla2);
            }
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

            var allEdit = acessarModulo.FindElementsByClassName(appObjects.TwwDBEdit);

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

        public void InserirResGridDispo()
        {
            var gridDisp = acessarModulo.FindElementByClassName(appObjects.scrTelaPrincipal);

            var resDisp = gridDisp.FindElementByClassName("TfrmReservaDisp");

            var selecPeriodo = resDisp.FindElementByClassName("TStringGrid");
            
            new Actions(acessarModulo).MoveToElement(selecPeriodo, 134, 105).Click().Perform();
            new Actions(acessarModulo).MoveToElement(selecPeriodo, 329, 105).Click().Perform();

            Elementos.EncontraElementoClassName(acessarModulo, "TfrmSugereTarifa");

            Elementos.EncontraElementoName(acessarModulo, "Reservar").Click();

            Elementos.EncontraElementoClassName(acessarModulo, "TMessageForm");

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnOK).Click();

        }

        /*public void MinimizarOrc()
        {
            var panelOrc = acessarModulo.FindElementByClassName("TPanel");

            var miniOrc = panelOrc.FindElementByName("Orçamento total: R$ 1.968,77 | Pernoites: 5 | Diária média: R$ 393,75");
            miniOrc.Click();

            Elementos.EncontraElementoClassName(acessarModulo, "TMessageForm");

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnOK).Click();

        }*/

        public void InserirDadosHospDaReservaPeloGrid()
        {
            /*var allButton = acessarModulo.FindElementsByClassName(appObjects.TBitBtn);

            Debug.WriteLine($"*** Identificar index button {allButton.Count}");*/

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TBitBtn).ElementAt(55).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winDadosPrincipais);

            var dadosHosp = GeradorDadosFakes.ListaDadosFakerPessoa();

            /*var allEdit = acessarModulo.FindElementsByClassName(appObjects.TEdit);

            Debug.WriteLine($"*** Identificar index button {allEdit.Count}");

            var allDate = acessarModulo.FindElementsByClassName(appObjects.TCMDateTimePicker);

            Debug.WriteLine($"*** Identificar index button {allDate.Count}");

            var allEdit = acessarModulo.FindElementsByClassName(appObjects.TwwDBEdit);

            Debug.WriteLine($"*** Identificar index button {allEdit.Count}");*/

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(19).SendKeys(dadosHosp.NomeFaker);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(20).SendKeys(dadosHosp.SobrenomeFaker);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(18).SendKeys(dadosHosp.EmailFaker);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDBLookupCombo).ElementAt(1).SendKeys(dadosHosp.TratamentoHosp);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDateTimePicker).ElementAt(4).SendKeys(dadosHosp.DtNascFaker);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnCidade).Click();
            Elementos.EncontraElementoName(acessarModulo, appObjects.winSelecCidade);
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(6).SendKeys(dadosHosp.CidadeFaker);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnIdioma).Click();
            Elementos.EncontraElementoName(acessarModulo, appObjects.winIdiomaHosp);
            Elementos.EncontraElementoClassName(acessarModulo, appObjects.TEdit).SendKeys(appObjects.idiomaHosp);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TBitBtn).ElementAt(55).Click();
        }

        public void InserirDocConfirmacaoDaReservaPeloGrid()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.winDocConfirmacaoRes);

            Elementos.EncontraElementoClassName(acessarModulo, appObjects.TEdit).SendKeys(appObjects.docEmail);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            var emailConfirRes = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TwwDBEdit).ElementAt(9).SendKeys(emailConfirRes.EmailFaker);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
        }

        public void InserirNomeGrupo()
        {
            var dadosEmp = GeradorDadosFakes.ListaDadosFakerEmpresa();

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TwwDBEdit).ElementAt(7).SendKeys(dadosEmp.PrefixoCompany);
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TwwDBEdit).ElementAt(7).SendKeys(dadosEmp.NomeCompany);
        }

        public void InserirNumNoitesResGrupo(string qtdNoites)
        {
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(2).SendKeys(qtdNoites);
        }

        public void SelecionarEmpresaResGrupo()
        {
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TBitBtn).ElementAt(35).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winSelecCliente);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TEdit).ElementAt(10).SendKeys(appObjects.docCliente);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnProcurar).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
        }

        public void SelecionarContratoResGrupo()
        {
            Elementos.EncontraElementosName(acessarModulo, appObjects.btnContrato).ElementAt(2).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winContratoCliente);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnOK).Click();

            Elementos.EncontraElementosName(acessarModulo, appObjects.btnContrato).ElementAt(0).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winContatosCliente);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
        }

        public void InserirDocConfirmacaoResGrupo()
        {
            Elementos.EncontraElementoName(acessarModulo, "Reserva de Grupo");

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDBLookupCombo).ElementAt(4).SendKeys(appObjects.docEmail);

            var emailConfirResGrp = GeradorDadosFakes.ListaDadosFakerPessoa();

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TwwDBEdit).ElementAt(1).SendKeys(emailConfirResGrp.EmailFaker);

        }

        public void SelecionarAbreMasterResGrupo()
        {
            Elementos.EncontraElementoName(acessarModulo, "Abre Master").Click();
        }

        public void InserirAcomodacoes()
        {
            Elementos.EncontraElementoName(acessarModulo, "Incluir").Click();

            //var allTwwDBEdit = acessarModulo.FindElementsByClassName(appObjects.TwwDBEdit);
            //Debug.WriteLine($"*** Identificar os campos edit reserva grupo {allTwwDBEdit.Count}");

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TwwDBEdit).ElementAt(8).SendKeys("2");

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDBLookupCombo).ElementAt(8).SendKeys(appObjects.categUhStnd);

            acessarModulo.FindElementsByClassName(appObjects.TCMDBLookupCombo).ElementAt(8).SendKeys(Keys.Tab);

            acessarModulo.FindElementsByClassName(appObjects.TCMDBLookupCombo).ElementAt(7).SendKeys(Keys.Tab);

            Elementos.EncontraElementosName(acessarModulo, appObjects.btnConfirmar).ElementAt(1).Click();

            Elementos.EncontraElementosName(acessarModulo, appObjects.btnConfirmar).ElementAt(0).Click();
        }

        public void ValidarSituacaoResGrupo()
        {
            Thread.Sleep(5000);

            acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));

            var sitResGrp = acessarModulo.FindElementByName(appObjects.winSitReserva);

            Debug.WriteLine($"*** Identificar janelas {acessarModulo.WindowHandles}");

            var winSitResGrp = acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));

            var editSitResGrp = sitResGrp.FindElementsByClassName(appObjects.TEdit);

            numResGrp = editSitResGrp.ElementAt(4);
            new Actions(acessarModulo).MoveToElement(numResGrp).DoubleClick().Perform();
            numResGrp.SendKeys(Keys.Control + "c");
            numResGrp.SendKeys(Keys.Control + "v");

            Console.WriteLine("Numero de Reserva Gerado: " + numResGrp.Text);
        }

        public void InserirAnexoResGrupo()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.winSitReserva);

            Elementos.EncontraElementoName(acessarModulo, "Anexos").Click();

            acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));

            var cadasAnexo = acessarModulo.FindElementByName("Cadastro de Anexos");

            new Actions(acessarModulo).MoveToElement(cadasAnexo, 544, 54).Click().Perform();

            Thread.Sleep(3000);

            acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.ElementAt(0));

            var selecAnexo = acessarModulo.FindElementByName("Selecione Anexo");

            //Elementos.EncontraElementoAutomationId(acessarModulo, "1148").SendKeys(appObjects.direcAnexo);

            //StringExtensions.ReverseSlash("C:\\Users\\gabriel.dacosta\\Source\\Repos\\QA-VHF\\VHF\\DocAnexo\\logo_totvs.jpg", 1);

            //appObjects.direcAnexo.ToTextElements();

            var newDirec = @"C:\Users\gabriel.dacosta\Source\Repos\QA-VHF\VHF\DocAnexo\logo_totvs.jpg";

            selecAnexo.FindElementByAccessibilityId("1148").SendKeys(newDirec.ReverseSlash(0)); //Format("\\")); .Replace("[", "\\")

            Elementos.EncontraElementoName(acessarModulo, "Abrir").Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

        }

        public void AbrirTelaConsultaGeral()
        {
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TBitBtn).ElementAt(6).Click();
        }

        public void SelecionarStatusResConfirmadaConsultaGeral()
        {
            var cGeral = acessarModulo.FindElementByName(appObjects.winConsultaGeral);
            
            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TComboBox).ElementAt(1).SendKeys(appObjects.statusResConfirmada);

            cGeral.SendKeys(Keys.Tab);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnProcurar).Click();
        }

        public void CancelarReservaIndividual()
        {
            var cGeral = acessarModulo.FindElementByName(appObjects.winConsultaGeral);

            //Clica na primeira linha de reserva na consulta geral
            new Actions(acessarModulo).MoveToElement(cGeral, 1080, 148).Click().Perform();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnCancelar).Click();

            Elementos.EncontraElementoClassName(acessarModulo, appObjects.scrTMessageForm);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnSim).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winCancelamentoRes);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDBLookupCombo).ElementAt(0).SendKeys(appObjects.motivoCancRes);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoClassName(acessarModulo, appObjects.scrTMessageForm);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnOK).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnNao).Click();
        }

        public void LoopingCancelamentoReservas()
        {
            for(int i = 0; i < 5; i++)
            {
                CancelarReservaIndividual();
                Console.WriteLine("Reserva individual cancelada com sucesso");
            }
        }

        public void PrimeiraEtapaCancelarReservaGrupo()
        {
            acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());

            var cancResGrp = acessarModulo.FindElementByName(appObjects.winCancelarResGrupo);

            cancResGrp.FindElementsByClassName(appObjects.TBitBtn).ElementAt(0).Click();

            acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());

            var winSelec = acessarModulo.FindElementByClassName(appObjects.scrMontaSelect);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnProcurar).Click();

            //Clica na primeira linha da lista de reserva grupo
            new Actions(acessarModulo).MoveToElement(winSelec, 344, 128).Click().Perform();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoClassName(acessarModulo, appObjects.scrTMessageForm);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnSim).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winCancelamentoResGrupo);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDBLookupCombo).ElementAt(0).SendKeys(appObjects.motivoCancRes);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
        }

        public void CancelarReservaGrupo()
        {
            acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());

            var cancResGrp = acessarModulo.FindElementByName(appObjects.winCancelarResGrupo);

            cancResGrp.FindElementsByClassName(appObjects.TBitBtn).ElementAt(0).Click();

            acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());

            var winSelec = acessarModulo.FindElementByClassName(appObjects.scrMontaSelect);

            //Clica na primeira linha da lista de reserva grupo
            new Actions(acessarModulo).MoveToElement(winSelec, 344, 128).Click().Perform();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();

            Elementos.EncontraElementoClassName(acessarModulo, appObjects.scrTMessageForm);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnSim).Click();

            Elementos.EncontraElementoName(acessarModulo, appObjects.winCancelamentoResGrupo);

            Elementos.EncontraElementosClassName(acessarModulo, appObjects.TCMDBLookupCombo).ElementAt(0).SendKeys(appObjects.motivoCancRes);

            Elementos.EncontraElementoName(acessarModulo, appObjects.btnConfirmar).Click();
        }

        public void LoopingCancelamentoReservasGrupo()
        {
            for (int i = 0; i < 6; i++)
            {
                CancelarReservaGrupo();
                ValidarSituacaoResGrupo();
                validacoes.ValidaStatusReservaGrp(6);
                SairTela();
                Console.WriteLine("Reserva de grupo cancelada com sucesso");
            }
        }

        public void SairTela()
        {
            Elementos.EncontraElementoName(acessarModulo, appObjects.btnSair).Click();
        }
    }
}
