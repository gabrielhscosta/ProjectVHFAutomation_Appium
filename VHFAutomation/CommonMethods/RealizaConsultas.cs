using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using VHFAutomation.PageObjects;
using VHFAutomation.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace VHFAutomation.CommonMethods
{
    public class RealizaConsultas
    {

        ConexaoBD conexaoBd = new ConexaoBD();
        

        AppObjects appObject = new AppObjects();

        public string SelectValidarReservaGerada()
        {
            SqlCommand cmd = new SqlCommand();

            string getReserva = null;

            cmd.CommandText = "select numReserva" +
                " from RESERVASFRONT" +
                " where statusReserva = 1" +
                " and idHotel = " + appObject.idHotel +
                " and numReserva = " + FuncComuns.numRes.Text +
                " order by numReserva desc";

            try
            {
                cmd.Connection = conexaoBd.conectar();
                getReserva = (cmd.ExecuteScalar()).ToString();
                conexaoBd.desconectar();
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            if (getReserva != null)
            {
                Assert.AreEqual(getReserva, FuncComuns.numRes.Text + ",00");

                Console.WriteLine("\nReserva " + FuncComuns.numRes.Text + " validada no BD com sucesso");
            }

            return getReserva;
        }

        /*
        public int SelectValidarNumeroLinhasOrcamento()
        {
            SqlCommand cmd1 = new SqlCommand();

            int lineOrc = 0;

            /*
            cmd1.CommandText = "select r.IdReservasFront, r.numreserva, oc.DATA, oc.idTarifa, oc.CODPENSAO, oc.VALOR, oc.VALORTARIFA, oc.VALORMANUAL," +
                " oc.VALORCAFE, oc.VALORPENSAO, oc.CodSegmento" +
                " from reservasfront r, ORCAMENTORESERVA oc" +
                " where r.idhotel = " + appObject.idHotel +
                " and r.numreserva = " + FuncComuns.numRes.Text +
                " and r.idhotel = oc.idhotel" +
                " and r.idreservasfront = oc.idreservasfront" +
                " order by data asc ";
            

            cmd1.CommandText = "select COUNT(*) from reservasfront r, ORCAMENTORESERVA oc where r.idhotel = 1 and r.numreserva = " + FuncComuns.numRes.Text + " and r.idhotel = oc.idhotel and r.idreservasfront = oc.idreservasfront";

            try
            {
                cmd1.Connection = conexaoBd.conectar();
                lineOrc = (int)(cmd1.ExecuteScalar());
                conexaoBd.desconectar();
            }
                        
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            if (lineOrc = )
            {
                Console.WriteLine("Orçamento gerado de acordo com a quantidade de Pernoites da Reserva");
            }

            else
            {
                Console.WriteLine("Erro na formação do Orçamento Reserva.");
            }

            return lineOrc;
        }
        */

        public int SelectValidarNumeroLinhasOrcamento(int qtdNoites)
        {
            SqlCommand cmd1 = new SqlCommand();

            int lineOrc = 0;

            cmd1.CommandText = "select COUNT(*) from reservasfront r, ORCAMENTORESERVA oc where r.idhotel = 1 and r.numreserva = " + FuncComuns.numRes.Text + " and r.idhotel = oc.idhotel and r.idreservasfront = oc.idreservasfront";

            try
            {
                cmd1.Connection = conexaoBd.conectar();
                lineOrc = (int)(cmd1.ExecuteScalar());
                conexaoBd.desconectar();
            }

            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            if (lineOrc == qtdNoites)
            {
                Console.WriteLine("\nOrçamento gerado de acordo com a quantidade de Pernoites da Reserva");
            }

            else
            {
                throw new AccessViolationException("\nErro na formação do Orçamento Reserva.");
            }

            return lineOrc;
        }

        public string ValidarFnrhMovimentoHospede()
        {
            SqlCommand cmd2 = new SqlCommand();

            string movHosp = null;

            cmd2.CommandText = "select m.IdReservasFront, r.numreserva, m.IdHospede, p.Nome" +
                " from movimentohospedes m, reservasfront r, pessoa p" +
                " where m.IdHotel = " + appObject.idHotel +
                " and r.NumReserva = " + FuncComuns.numRes.Text +
                " and m.idhotel = r.idhotel" +
                " and m.IdReservasFront = r.IdReservasFront" +
                " and m.IdHospede = p.idpessoa";

            try
            {
                cmd2.Connection = conexaoBd.conectar();
                movHosp = cmd2.BeginExecuteNonQuery().ToString();
                //cmd2.EndExecuteReader().GetValues();
                conexaoBd.desconectar();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            if (movHosp != null)
            {
                
            }

            return movHosp;
        }

        public List<TarifaConsulta> SelectValidarValorOrcamento()
        {
            SqlCommand cmd1 = new SqlCommand();

            SqlDataReader reader = null;

            List<TarifaConsulta> lista = null;

            cmd1.CommandText = "select t.Descricao, oc.VALOR, oc.VALORTARIFA from RESERVASFRONT r, ORCAMENTORESERVA oc, TARIFAHOTEL t where r.idhotel = 1 and r.numreserva = " + FuncComuns.numRes.Text + " and r.idhotel = oc.idhotel and r.idreservasfront = oc.idreservasfront and oc.IdHotel = t.IdHotel and oc.idTarifa = t.idTarifa order by data asc";

            try
            {
                cmd1.Connection = conexaoBd.conectar();
                reader = (cmd1.ExecuteReader());
                lista = new List<TarifaConsulta>();


                while (reader.Read())
                {
                    var tmp = new TarifaConsulta();
                    tmp.Descricao = reader["Descricao"].ToString();
                    tmp.Valor = Convert.ToInt32(reader["VALOR"]);
                    tmp.ValorTarifa = Convert.ToInt32(reader["VALORTARIFA"]);
                    lista.Add(tmp);

                }
                conexaoBd.desconectar();

            }

            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            return lista;
        }

        public int SelectValidarStatusResGrupo(int status)
        {
            SqlCommand cmd = new SqlCommand();

            int statusResGrp = 0;

            cmd.CommandText = "select STATUSRESERVA" +
                " from RESERVAGRUPO " +
                " where IdReservaGrupo = " + FuncComuns.numResGrp.Text +
                " and idhotel = 1";

            try
            {
                cmd.Connection = conexaoBd.conectar();
                statusResGrp = (int)(cmd.ExecuteScalar());
                conexaoBd.desconectar();
            }

            catch (SqlException ex)
            {
                ex.Message.ToString();
            }

            if (statusResGrp == status)
            {
                Console.WriteLine("\nStatus da reserva é Cancelada.");
            }

            else
            {
                throw new AccessViolationException("\nErro na formação do Orçamento Reserva.");
            }

            return statusResGrp;
        }

        public class TarifaConsulta
        {
            public string Descricao { get; set; }
            public int Valor { get; set; }
            public int ValorTarifa { get; set; }
        }
    }
}
