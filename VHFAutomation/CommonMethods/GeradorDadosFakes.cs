﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions.Brazil;

namespace VHFAutomation.CommonMethods
{
    public class GeradorDadosFakes
    {        
        public static PessoaFake ListaDadosFakerPessoa()
        {
            var dadosFaker = new Faker<PessoaFake>("pt_BR").StrictMode(true)

                .RuleFor(p => p.CPFFaker,        f => f.Person.Cpf())
                .RuleFor(p => p.NomeFaker,       f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(p => p.SobrenomeFaker,  f => f.Name.LastName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(p => p.EmailFaker,      f => f.Internet.Email(f.Person.FirstName, f.Person.LastName).ToLower())
                .RuleFor(p => p.TratamentoHosp,  f => "Senhora")
                .RuleFor(p => p.DtNascFaker,     f => "24031989")
                .RuleFor(p => p.CEPFaker,        f => "57062422")
                .RuleFor(p => p.CidadeFaker,     f => "Maceio");
            
            var pessoa = dadosFaker.Generate();

            return pessoa;
            
        }
        
    }
}