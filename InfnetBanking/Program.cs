using System;
using System.Collections.Generic;

namespace InfnetBanking
{
    class Program
    {
        static void Main(string[] args)
        {
            Aula20200813();
        }

        static void Aula20200813()
        {
            Pessoa titular = new PessoaFisica
            {
                CadastroPessoa = "00000000000",
                Nome = "Fulano",
                Sobrenome = "Beltrano",
                DataNascimento = new DateTime(1970, 1, 1),
                Enderecos = new List<Endereco>() // Criando uma lista (sem o new dará erro)
            };

            titular.Enderecos.Add(new Endereco { TipoLogradouro = "Rua", Logradouro = "São José", Numero = "90" });
            titular.Enderecos.Add(new Endereco { TipoLogradouro = "Rua", Logradouro = "Do Rosário", Numero = "134" });

            ContaBancaria contaBancaria = new ContaBancaria(3652, 20839, titular);
            Console.WriteLine(contaBancaria.ToString());
        }
    }
}