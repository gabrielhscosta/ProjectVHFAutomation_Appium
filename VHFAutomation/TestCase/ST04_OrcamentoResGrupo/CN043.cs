using VHFAutomation.Main;
using VHFAutomation.CommonMethods;
using VHFAutomation.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace VHF.TestCase.ST04_OrcamentoReservaGrupo
{
    public class CN043 : SessaoMain
    {
        public CN043()
        {

        }

        public void AlterarQuantidadeHospedesNaAcomodacaoReservaGrupo()
        {
            FuncComuns funcComuns = new FuncComuns();
            Validacoes validacoes = new Validacoes();

            funcComuns.ChamarAtalho("e", "g", "i");

            funcComuns.InserirNomeGrupo();

            funcComuns.InserirNumNoitesResGrupo("4");

            funcComuns.SelecionarEmpresaResGrupo();

            funcComuns.SelecionarContratoResGrupo();

            funcComuns.InserirDocConfirmacaoResGrupo();

            funcComuns.SelecionarAbreMasterResGrupo();

            funcComuns.InserirAcomodacoes();

            funcComuns.ValidarSituacaoResGrupo();

            /*
            validacoes.ValidaReservaGrpGerada();

            validacoes.ValidaContaMasterReservaGrp("S");

            validacoes.ValidaNumeroLinhaAcomodacaoGrp(1);

            validacoes.ValidaQtdHospedesAcomodacaoGrp(1, 0, 0);

            validacoes.ValidaNumeroLinhaDoOrcGrp(4);

            validacoes.ValidaOrcamentoGrp("stnd", 1, 0, 0, "AUTO ACORDO 2022-60");

            funcComuns.ValidarTelaPrincipalVhf();

            funcComuns.ChamarAtalho("e", "g", "a");

            funcComuns.AlterarReservaGrupo();

            funcComuns.AlterarQtdHospedesAcomodacoesGrupo("3");

            funcComuns.ValidarSituacaoResGrupo();

            validacoes.ValidaQtdHospedesAcomodacaoGrp(3, 0, 0);

            funcComuns.SairTela();
            */

            funcComuns.ValidarTelaPrincipalVhf();
        }
    }
}