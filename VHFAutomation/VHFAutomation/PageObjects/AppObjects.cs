using System;
using System.Collections.Generic;
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

        #endregion



        #region Edit
        public string caixaTexto = ("TEdit");

        #endregion

        #region Menus
        public string subMenuIndividual = ("161");

        #endregion



        #region Screen
        public string scrTelaLogin = ("TfrmLogin");
        public string scrTelaPrincipal = ("TfrmPrincipal");
        public string scrTelaPrincipalCAIXA = ("TfrmPrincipalCAIXA");
        public string scrSelecGeral = ("TfrmSelecaoGeral");
        public string scrMontaSelect = ("TfrmMontaSelect");

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

        #endregion



        #region ComboBox
        public string comboBoxLogin = ("TwwDBLookupCombo");
        public string abrirCombo = ("TBtnWinControl");
        public string comboBoxAgenciaTS = ("TCMDBLookupCombo");
        public string comboBoxGridTs = ("TwwPopupGrid");

        #endregion
    }
}
