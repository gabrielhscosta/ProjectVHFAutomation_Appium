using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VHFAutomation.CommonMethods
{
    public class RealizaConsultas
    {
        public RealizaConsultas()
        {
            select  r.IdReservasFront, r.numreserva, oc.DATA, oc.idTarifa, oc.CODPENSAO, oc.VALOR, oc.VALORTARIFA, oc.VALORMANUAL,
                    oc.VALORCAFE, oc.VALORPENSAO, oc.CodSegmento 
            from reservasfront r, ORCAMENTORESERVA oc 
            where r.idhotel = ****
            and r.numreserva = ****
            and r.idhotel = oc.idhotel 
            and r.idreservasfront = oc.idreservasfront 
            order by data asc
        }

        //Classe para desenvoler as queries a vir usar para validação
    }
}
