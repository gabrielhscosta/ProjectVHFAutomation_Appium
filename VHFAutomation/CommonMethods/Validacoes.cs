using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHF.DadosYaml;
using static VHFAutomation.CommonMethods.RealizaConsultas;

namespace VHFAutomation.CommonMethods
{
    public class Validacoes
    {

        public Validacoes()
        {

        }

        RealizaConsultas realizaConsultas = new RealizaConsultas();

        public void ValidaOrcamento(string UH, int qtdPax)
        {
            List<TarifaConsulta> lista = realizaConsultas.SelectValidarValorOrcamento();

            DeserializedObject dadosYaml = ImportaYaml.Deserialize(@"..\..\DadosYaml\tarifa.yml");

            foreach (TarifaConsulta t in lista)
            {
                Assert.AreEqual(dadosYaml.tarifa[2].descricao, t.Descricao);
                Assert.AreEqual(dadosYaml.tarifa[2].valorUHs[0].valorUmPax, t.Valor);
                Assert.AreEqual(dadosYaml.tarifa[2].valorUHs[0].valorUmPax, t.ValorTarifa);
            }

            Console.WriteLine("\nValor da tarifa para 1 pax na categoria STDN: {0}\r\nValor do orçamento no banco de dados: {1}", dadosYaml.tarifa[2].valorUHs[0].valorUmPax, lista[2].Valor);
        }


        public void ValidaOrcamento1(string UH, int qtdPaxAdulto, int qtdPaxCriancaUm, int qtdPaxCriancaDois, string tarifa = "BALCAO 2021-60")
        {
            List<TarifaConsulta> lista = realizaConsultas.SelectValidarValorOrcamento();

            DeserializedObject dadosYaml = ImportaYaml.Deserialize(@"..\..\DadosYaml\tarifa.yml");

            int indice = dadosYaml.tarifa.FindIndex(tmp => tmp.descricao.Equals(tarifa));

            float soma = 0;
            switch (qtdPaxAdulto)
            {
                case 1:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorUmPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 2:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorDoisPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 3:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorTresPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 4:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorQuatroPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
                case 5:
                    soma += dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorCincoPax).ElementAt(0);
                    soma = soma + (qtdPaxCriancaUm * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri1).ElementAt(0)) + (qtdPaxCriancaDois * dadosYaml.tarifa[indice].valorUHs.Where(valorUh => valorUh.uh.Equals(UH)).Select(valorUh => valorUh.valorFixoCri2).ElementAt(0));
                    break;
            }

            foreach (TarifaConsulta t in lista)
            {
                Assert.AreEqual(dadosYaml.tarifa[indice].descricao, t.Descricao);
                Assert.AreEqual(soma, t.Valor);
                Assert.AreEqual(soma, t.ValorTarifa);
            }

        }

        public void ValidaStatusReservaGrp(int status)
        {
            int statusResGrp = realizaConsultas.SelectValidarStatusResGrupo(status);
            Assert.AreEqual(status, statusResGrp);
        }

    }
}
