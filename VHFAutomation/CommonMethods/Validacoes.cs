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
                Assert.AreEqual(dadosYaml.tarifa[0].descricao, t.Descricao);
                Assert.AreEqual(dadosYaml.tarifa[0].valorUHs[0].valorUmPax, t.Valor);
                Assert.AreEqual(dadosYaml.tarifa[0].valorUHs[0].valorUmPax, t.ValorTarifa);
            }

            Console.WriteLine("\nValor da tarifa para 1 pax na categoria STDN: {0}\r\nValor do orçamento no banco de dados: {1}", dadosYaml.tarifa[0].valorUHs[0].valorUmPax, lista[0].Valor);
        }

    }
}
