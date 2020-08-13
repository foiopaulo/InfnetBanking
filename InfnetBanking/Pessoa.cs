using System;
using System.Collections.Generic;

namespace InfnetBanking
{
    public abstract class Pessoa
    {
        public string cadastroPessoa;

        public string CadastroPessoa
        {
            get => cadastroPessoa;

            set
            {
                if (ValidarCadastroPessoa(value))
                {
                    cadastroPessoa = value;
                }
            }
        }

        public List<Endereco> Enderecos { get; set; }
        public DateTime DataNascimento { get; set; }

        public abstract bool ValidarCadastroPessoa(string value);
    }
}