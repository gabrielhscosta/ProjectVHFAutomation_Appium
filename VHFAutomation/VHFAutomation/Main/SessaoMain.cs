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
        [TestMethod]
        public void CN001_ValidaLogin_VHF()
        {
            CN001LoginVHF vloginvhf = new CN001LoginVHF();
            vloginvhf.ValidaLoginVHF();
            vloginvhf.ConferenciaTelaPrincipalVHF();
            vloginvhf.CN001TearDown();
        }

        #endregion

        #region Valida Login VHFCaixa
        [TestMethod]
        public void CN002_ValidaLogin_VHFCaixa()
        {
            CN002LoginVHFCaixa vloginvhfcaixa = new CN002LoginVHFCaixa();
            vloginvhfcaixa.ValidaLoginVHFCaixa();
            vloginvhfcaixa.ConferenciaTelaPrincipalVHFCaixa();
            vloginvhfcaixa.CN002TearDown();
        }

        #endregion

        #region Valida Login Central de Reservas
        [TestMethod]
        public void CN003_ValidaLogin_CentralReservas()
        {
            CN003LoginCentralReservas vlogincr = new CN003LoginCentralReservas();
            vlogincr.ValidaLoginCentralReservas();
            vlogincr.ConferenciaTelaPrincipalCentralReservas();
            vlogincr.CN003TearDown();
        }

        #endregion

        #region Valida Login Evento
        [TestMethod]
        public void CN004_ValidaLogin_Evento()
        {
            CN004LoginEvento vloginev = new CN004LoginEvento();
            vloginev.ValidaLoginEvento();
            vloginev.ConferenciaTelaPrincipalEvento();
            vloginev.CN004TearDown();
        }

        #endregion

        #region Valida Login FrontTurismo
        [TestMethod]
        public void CN005_ValidaLogin_FrontTurismo()
        {
            CN005LoginFrontTurismo vloginft = new CN005LoginFrontTurismo();
            vloginft.ValidaLoginFrontTurismo();
            vloginft.ConferenciaTelaPrincipalFrontTurismo();
            vloginft.CN005TearDown();
        }

        #endregion

        #region Valida Login GlobalCM
        [TestMethod]
        public void CN006_ValidaLogin_GlobalCM()
        {
            CN006LoginGlobal vloginglobal = new CN006LoginGlobal();
            vloginglobal.ValidaLoginGlobal();
            vloginglobal.ConferenciaTelaPrincipalGlobal();
            vloginglobal.CN006TearDown();
        }

        #endregion

        #region Valida Login SPA
        [TestMethod]
        public void CN007_ValidaLogin_SPA()
        {
            CN007LoginSpa vloginspa = new CN007LoginSpa();
            vloginspa.ValidaLoginSpa();
            vloginspa.ConferenciaTelaPrincipalSpa();
            vloginspa.CN007TearDown();
        }

        #endregion

        #region Valida Login SSD
        [TestMethod]
        public void CN008_ValidaLogin_SSD()
        {
            CN008LoginSSD vloginssd = new CN008LoginSSD();
            vloginssd.ValidaLoginSsd();
            vloginssd.ConferenciaTelaPrincipalSsd();
            vloginssd.CN008TearDown();
        }

        #endregion

        #region Valida Login Telefonia
        [TestMethod]
        public void CN009_ValidaLogin_Telefonia()
        {
            CN009LoginTelefonia vlogintel = new CN009LoginTelefonia();
            vlogintel.ValidaLoginTelefonia();
            vlogintel.ConferenciaTelaPrincipalTelefonia();
            vlogintel.CN009TearDown();
        }

        #endregion

        #region Valida Login TimeSharing
        [TestMethod]
        public void CN010_ValidaLogin_TimeSharing()
        {
            CN010LoginTimeSharing vlogints = new CN010LoginTimeSharing();
            vlogints.ValidaLoginTimeSharing();
            vlogints.ConferenciaTelaPrincipalTimeSharing();
        }


        #endregion


        #endregion



        #region ST01_Reserva Individual
        
        #region Inserir uma reserva com 01 Hospede novo sem histórico/empresa (Validar FRNH)
        [TestMethod]
        public void CN0101_ReservaIndividual()
        {
            try
            {
                CN0101InserirReservaCom01HospedeNovoSemHistoricoeEmpresa cn0101 = new CN0101InserirReservaCom01HospedeNovoSemHistoricoeEmpresa();
                cn0101.InserirReservaCom01HospedeNovoSemHistoricoeEmpresa();
            }
            catch
            {

                CN001LoginVHF vloginvhf = new CN001LoginVHF();
                vloginvhf.ValidaLoginVHF();
                CN0101InserirReservaCom01HospedeNovoSemHistoricoeEmpresa cn0101 = new CN0101InserirReservaCom01HospedeNovoSemHistoricoeEmpresa();
                cn0101.InserirReservaCom01HospedeNovoSemHistoricoeEmpresa();
            }
        }

        #endregion




        #endregion
    }
}