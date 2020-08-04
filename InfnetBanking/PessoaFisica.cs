﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InfnetBanking
{
    public class PessoaFisica
    {
        private string cpf;

        public string Cpf
        {
            get => cpf;

            set
            {
                if (ValidarCpf(value))
                {
                    cpf = value;
                }
            }
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco {get; set;}


        public bool ValidarCpf(string cpf)
        {

            // TODO: Programar regra de validação de CPF;
            return true;
        }

        public override string ToString()
        {
            return $"CPF: {Cpf}\nNome: {Nome} {Sobrenome}.";
        }
    }
}
