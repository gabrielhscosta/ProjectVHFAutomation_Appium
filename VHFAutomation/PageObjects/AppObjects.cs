using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHFAutomation.PageObjects
{
    public class AppObjects
    {
        #region Dados de Login
        public string userSys = ("QAFRONT");
        public string passSys = ("QAFRONT123");
        public string empresaSys = ("1-AUTOMACAO DE TESTES");
        public string userSysOracle = ("CM");
        public string passSysOracle = ("CMSOL123");
        public string empresaSysOracle = ("KHOTEL - BASE TESTE SUPORTE");
        public string idHotel = ("1");
        

        #endregion



        #region Button
        public string btnProcurar = ("Procurar");
        public string btnConfirmar = ("Confirmar");
        public string btnOK = ("OK");
        public string btnCancelar = ("Cancelar");
        public string btnSair = ("Sair");
        public string btnSim = ("Sim");
        public string btnNao = ("Não");
        public string btnEditar = ("Editar");
        public string btnVoltar = ("Voltar");
        public string btnFechar = ("Fechar");
        public string btnUhOcupado = ("ocupado");
        public string btnUhCobrado = ("cobrado");
        public string btnUhNumero = ("numero");
        public string TBitBtn = ("TBitBtn");
        public string btnCidade = ("cidade");
        public string btnIdioma = ("idioma");
        public string btnDocHosp = ("documentohospede");
        public string btnContrato = ("contrato");
        public string btnContinuar = ("Continuar");

        #endregion



        #region Componentes
        public string TEdit = ("TEdit");
        public string tagEdit = ("Edit");
        public string TwwDBEdit = ("TwwDBEdit");
        public string TCMDateTimePicker = ("TCMDateTimePicker");
        public string TCMDBLookupCombo = ("TCMDBLookupCombo");
        public string comboBoxLogin = ("TwwDBLookupCombo");
        public string abrirCombo = ("TBtnWinControl");
        public string comboBoxAgenciaTS = ("TCMDBLookupCombo");
        public string comboBoxGridTs = ("TwwPopupGrid");
        public string TComboBox = ("TComboBox");
        public string TDBEdit = ("TDBEdit");

        #endregion



        #region Menus
        public string subMenuIndividual = ("161");
        public string subMenuGridDisponibilidade = ("449");

        #endregion



        #region Screen
        public string scrTelaLogin = ("TfrmLogin");
        public string scrTelaPrincipal = ("TfrmPrincipal");
        public string scrTelaPrincipalCAIXA = ("TfrmPrincipalCAIXA");
        public string scrSelecGeral = ("TfrmSelecaoGeral");
        public string scrMontaSelect = ("TfrmMontaSelect");
        public string scrTelaReserva = ("TfrmReserva");
        public string scrTelaCartaoConsCaixa = ("TfrmCartaoConsumo");
        public string scrTMessageForm = ("TMessageForm");

        #endregion



        #region Window

        public string winEstada = ("Estada");
        public string winTipoUhEstadia = ("Tipo de UH Estadia");
        public string winTipoUhTarifa = ("Tipo de UH Tarifa");
        public string winTipoUhQuarto = ("Seleciona UH");
        public string winDadosPrincipais = ("Dados principais");
        public string winSelecCidade = ("Seleciona cidade");
        public string winIdiomaHosp = ("Idioma do Hóspede");
        public string winDocConfirmacaoRes = ("Documento de Confirmação");
        public string winSelecDocHosp = ("Seleciona documento do hóspede");
        public string winSitReserva = ("Situação da Reserva");
        public string winSelecCliente = ("Seleciona");
        public string winContratoCliente = ("Contratos da Empresa");
        public string winContatosCliente = ("Contatos");
        public string winCancelamentoRes = ("Cancelamento de Reservas");
        public string winCancelamentoResGrupo = ("Cancelamento de Reserva de Grupo");
        public string winConsultaGeral = ("Consulta Geral");
        public string winCancelarResGrupo = ("Cancelar Reserva de Grupo");
        public string winAlterarResGrupo = ("Alterar Reserva de Grupo");

        #endregion



        #region Text
        public string txtParamConexao = ("Parâmetros para conexão com o banco");
        public string txtConfig = ("Configurações");
        public string txtSQLServer = ("SQL Server");
        public string txtOracle = ("ORACLE");
        public string txtAlertAtencao = ("Atenção");
        public string titleTelaLogin = ("Login");
        public string titleTelaPrincipalVHF = ("Visual Hotal FrontOffice");
        public string titleTelaPrincVHFCaixa = ("Visual Hotal FrontOffice - CAIXA");
        public string titleTelaPrincCentralRes = ("CentralSUPER");
        public string titleTelaPrincEvento = ("Evento");
        public string titleTelaPrincFrontTurismo = ("FrontTurismo");
        public string titleTelaPrincGlobal = ("Global CM");
        public string titleTelaPrincipalSPA = ("SPA");
        public string titleTelaPrincipalSSD = ("SSD - Sistema de Segurança de Dados");
        public string titleTelaPrincTelefonia = ("Telefonia");
        public string titleTelaPrincipalTS = ("TimeSharing e Multipropriedade");
        public string txtVisualOrcamento = ("Clique para atualizar os valores do período");
        public string txtCliente = ("Cliente");
        public string txtAlertLicenca = ("Registro de Versões");

        #endregion



        #region Dados Reserva

        public string numNoites = ("3");
        public string categUhStnd = ("STND");
        public string categUhSuite = ("SUITE MASTER");
        public string idiomaHosp = ("Portugues");
        public string docEmail = ("EM");
        public string docCliente = ("77048338000148");
        public string docHospEstada = ("88180094600");
        public string statusResConfirmada = ("Confirmada");
        public string motivoCancRes = ("Cancelamento CMNet");

        #endregion



        #region Tags

        public string tagMenuItem = ("MenuItem");

        #endregion



        #region Diretorios

        //public string direcAnexo = "C:]Users]gabriel.dacosta]Source]Repos]QA-VHF]VHF]DocAnexo]logo_totvs.jpg";

        #endregion

    }
}
