using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using VHFAutomation.TestCase;
using VHFAutomation.CommonMethods;


namespace VHFAutomation.Main
{
    [TestClass]
    public class SessaoMain : RegistroBase
    {
        #region Atributos de teste adicionais

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        protected const string winAppDriverUrl = "http://127.0.0.1:4723";
        protected const string dirAplicacaoVHF = @"C:\Totvs\Hoteis\VHF.exe";
        protected const string dirAplicacaoVHFCaixa = @"C:\Totvs\Hoteis\VHFCaixa.exe";
        protected const string dirAplicacaoCentralReservas = @"C:\Totvs\Hoteis\CentralReservas.exe";
        protected const string dirAplicacaoEvento = @"C:\Totvs\Hoteis\Evento.exe";
        protected const string dirAplicacaoFrontTurismo = @"C:\Totvs\Hoteis\FrontTurismo.exe";
        protected const string dirAplicacaoGlobal = @"C:\Totvs\Hoteis\GlobalCM.exe";
        protected const string dirAplicacaoSpa = @"C:\Totvs\Hoteis\SPA.exe";
        protected const string dirAplicacaoSsd = @"C:\Totvs\Hoteis\SSD.exe";
        protected const string dirAplicacaoTelefonia = @"C:\Totvs\Hoteis\Telefonia.exe";
        protected const string dirAplicacaoTimeSharing = @"C:\Totvs\Hoteis\TimeSharing.exe";
        //protected const string caminhoLogService = @"C:\Users\gabriel.dacosta\Source\Repos\VHFAutomation\VHFAutomation\Logs\TestLog.txt";

        public static WindowsDriver<WindowsElement> acessarModulo;

        [ClassInitialize]
        public static void Setup(TestContext Testcontext)
        {
            RegistraBaseHomologacaoVhf("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");
            RegistraBaseHomologacaoVhfCaixa("QA_FRONT", "MSSQL", "RJOSRVDBODEV001");



            // *** Inicialização do módulo ***

            if (acessarModulo == null)
            {
                AppiumOptions session1 = new AppiumOptions();
                session1.AddAdditionalCapability("app", dirAplicacaoVHF);

                acessarModulo = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), session1);

            }

        }

        [ClassCleanup]
        public static void TearDown()
        {
            if (acessarModulo != null)
            {
                //acessarModulo.Close();
                //acessarModulo.Quit();
                //acessarModulo = null;
            }

        }

        #endregion


        #region ST00_ValidaLoginModulos


        #region Valida Login VHF
        [TestMethod, TestCategory("ST00 - ValidarLoginModulos")]
        public void CN001_ValidaLogin_VHF()
        {
            CN001LoginVHF vloginvhf = new CN001LoginVHF();
            vloginvhf.ValidaLoginVHF();
            vloginvhf.ConferenciaTelaPrincipalVHF();
            vloginvhf.CN001TearDown();
        }

        #endregion

        #region Valida Login VHFCaixa
        [TestMethod, TestCategory("ST00 - ValidarLoginModulos")]
        public void CN002_ValidaLogin_VHFCaixa()
        {
            CN002LoginVHFCaixa vloginvhfcaixa = new CN002LoginVHFCaixa();
            vloginvhfcaixa.ValidaLoginVHFCaixa();
            vloginvhfcaixa.ConferenciaTelaPrincipalVHFCaixa();
            vloginvhfcaixa.CN002TearDown();
        }

        #endregion

        #region Valida Login Central de Reservas
        [TestMethod, TestCategory("ST00 - ValidarLoginModulos")]
        public void CN003_ValidaLogin_CentralReservas()
        {
            CN003LoginCentralReservas vlogincr = new CN003LoginCentralReservas();
            vlogincr.ValidaLoginCentralReservas();
            vlogincr.ConferenciaTelaPrincipalCentralReservas();
            vlogincr.CN003TearDown();
        }

        #endregion

        #region Valida Login Evento
        [TestMethod, TestCategory("ST00 - ValidarLoginModulos")]
        public void CN004_ValidaLogin_Evento()
        {
            CN004LoginEvento vloginev = new CN004LoginEvento();
            vloginev.ValidaLoginEvento();
            vloginev.ConferenciaTelaPrincipalEvento();
            vloginev.CN004TearDown();
        }

        #endregion

        #region Valida Login FrontTurismo
        [TestMethod, TestCategory("ST00 - ValidarLoginModulos")]
        public void CN005_ValidaLogin_FrontTurismo()
        {
            CN005LoginFrontTurismo vloginft = new CN005LoginFrontTurismo();
            vloginft.ValidaLoginFrontTurismo();
            vloginft.ConferenciaTelaPrincipalFrontTurismo();
            vloginft.CN005TearDown();
        }

        #endregion

        #region Valida Login GlobalCM
        [TestMethod, TestCategory("ST00 - ValidarLoginModulos")]
        public void CN006_ValidaLogin_GlobalCM()
        {
            CN006LoginGlobal vloginglobal = new CN006LoginGlobal();
            vloginglobal.ValidaLoginGlobal();
            vloginglobal.ConferenciaTelaPrincipalGlobal();
            vloginglobal.CN006TearDown();
        }

        #endregion

        #region Valida Login SPA
        [TestMethod, TestCategory("ST00 - ValidarLoginModulos")]
        public void CN007_ValidaLogin_SPA()
        {
            CN007LoginSpa vloginspa = new CN007LoginSpa();
            vloginspa.ValidaLoginSpa();
            vloginspa.ConferenciaTelaPrincipalSpa();
            vloginspa.CN007TearDown();
        }

        #endregion

        #region Valida Login SSD
        [TestMethod, TestCategory("ST00 - ValidarLoginModulos")]
        public void CN008_ValidaLogin_SSD()
        {
            CN008LoginSSD vloginssd = new CN008LoginSSD();
            vloginssd.ValidaLoginSsd();
            vloginssd.ConferenciaTelaPrincipalSsd();
            vloginssd.CN008TearDown();
        }

        #endregion

        #region Valida Login Telefonia
        [TestMethod, TestCategory("ST00 - ValidarLoginModulos")]
        public void CN009_ValidaLogin_Telefonia()
        {
            CN009LoginTelefonia vlogintel = new CN009LoginTelefonia();
            vlogintel.ValidaLoginTelefonia();
            vlogintel.ConferenciaTelaPrincipalTelefonia();
            vlogintel.CN009TearDown();
        }

        #endregion

        #region Valida Login TimeSharing
        [TestMethod, TestCategory("ST00 - ValidarLoginModulos")]
        public void CN010_ValidaLogin_TimeSharing()
        {
            CN010LoginTimeSharing vlogints = new CN010LoginTimeSharing();
            vlogints.ValidaLoginTimeSharing();
            vlogints.ConferenciaTelaPrincipalTimeSharing();
        }


        #endregion


        #endregion



        #region ST01_Reserva Individual
        
        #region Inserir uma reserva com um hóspede novo sem histórico/empresa (Validar orçamento)
        [TestMethod, TestCategory("ST01 - Reserva Individual")]
        public void CN0101_ReservaIndividual()
        {
            try
            {
                CN0101InserirReservaComUmHospedeNovoSemHistoricoeEmpresa cn0101 = new CN0101InserirReservaComUmHospedeNovoSemHistoricoeEmpresa();
                cn0101.InserirReservaComUmHospedeNovoSemHistoricoeEmpresa();
            }
            catch
            {

                CN001LoginVHF vloginvhf = new CN001LoginVHF();
                vloginvhf.ValidaLoginVHF();
                vloginvhf.ConferenciaTelaPrincipalVHF();
                CN0101InserirReservaComUmHospedeNovoSemHistoricoeEmpresa cn0101 = new CN0101InserirReservaComUmHospedeNovoSemHistoricoeEmpresa();
                cn0101.InserirReservaComUmHospedeNovoSemHistoricoeEmpresa();
            }
        }

        #endregion

        #region Inserir uma reserva com um hóspede novo sem histórico e sem empresa (Validar FNRH)
        [TestMethod, TestCategory("ST01 - Reserva Individual")]
        public void CN0102_ReservaIndividual()
        {
            try
            {
                CN0102InserirReservaComUmHospedeNovoEComEmpresaSemContrato cn0102 = new CN0102InserirReservaComUmHospedeNovoEComEmpresaSemContrato();
                cn0102.InserirReservaComUmHospedeNovoEComEmpresaSemContrato();
            }
            catch
            {

                CN001LoginVHF vloginvhf = new CN001LoginVHF();
                vloginvhf.ValidaLoginVHF();
                CN0102InserirReservaComUmHospedeNovoEComEmpresaSemContrato cn0102 = new CN0102InserirReservaComUmHospedeNovoEComEmpresaSemContrato();
                cn0102.InserirReservaComUmHospedeNovoEComEmpresaSemContrato();
            }
        }

        #endregion

        #region Inserir reserva com um pax com histórico de hóspede e com cliente/empresa e contrato (Validar orçamento)
        [TestMethod, TestCategory("ST01 - Reserva Individual")]
        public void CN0103_ReservaIndividual()
        {
            try
            {
                CN0103InserirReservaComUmPaxComHistoricoDeHospedeEComEmpresaEContrato cn0103 = new CN0103InserirReservaComUmPaxComHistoricoDeHospedeEComEmpresaEContrato();
                cn0103.InserirReservaComUmPaxComHistoricoDeHospedeEComEmpresaEContrato();
            }
            catch
            {

                CN001LoginVHF vloginvhf = new CN001LoginVHF();
                vloginvhf.ValidaLoginVHF();
                CN0103InserirReservaComUmPaxComHistoricoDeHospedeEComEmpresaEContrato cn0103 = new CN0103InserirReservaComUmPaxComHistoricoDeHospedeEComEmpresaEContrato();
                cn0103.InserirReservaComUmPaxComHistoricoDeHospedeEComEmpresaEContrato();
            }
        }

        #endregion

        #region Fazer Reserva pelo Grid de Disponibilidade
        [TestMethod, TestCategory("ST01 - Reserva Individual")]
        public void CN0107_ReservaIndividual()
        {
            try
            {
                CN0107FazerReservaPeloGridDeDisponibilidade cn0107 = new CN0107FazerReservaPeloGridDeDisponibilidade();
                cn0107.FazerReservaPeloGridDeDisponibilidade();
            }
            catch
            {

                CN001LoginVHF vloginvhf = new CN001LoginVHF();
                vloginvhf.ValidaLoginVHF();
                CN0107FazerReservaPeloGridDeDisponibilidade cn0107 = new CN0107FazerReservaPeloGridDeDisponibilidade();
                cn0107.FazerReservaPeloGridDeDisponibilidade();
            }
        }

        #endregion

        #endregion


        #region ST03_Reserva De Grupo

        #region Validar anexo na reserva de grupo
        [TestMethod, TestCategory("ST03 - Reserva De Grupo")]
        public void CN0302_ValidarAnexoNaReservaDeGrupo()
        {
            CN001LoginVHF vloginvhf = new CN001LoginVHF();
            vloginvhf.ValidaLoginVHF();
            CN0302ValidarAnexoNaReservaDeGrupo cn0302 = new CN0302ValidarAnexoNaReservaDeGrupo();
            cn0302.ValidarAnexoNaReservaDeGrupo();
        }

        #endregion

        #endregion
    }
}