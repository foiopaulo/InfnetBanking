using System;

namespace InfnetBanking
{
    public class ContaBancaria
    {

        // Um construtor que recebe como parâmetros, agência, número da conta e titular:
        public ContaBancaria(int agencia, int numero, Pessoa titular)
        {
            Agencia = agencia;
            Numero = numero;
            Titular = titular;
            this.saldo = 0.0;
        }

        // Um construtor que recebe como parâmetros, agência, número da conta, saldo e titular
        // Este construtor remete ao construtor anterior e, dentro do seu escopo, apenas "completa" e instância com a atribuição 
        public ContaBancaria(int agencia, int numero, double saldo, Pessoa titular) : this(agencia, numero, titular)
        {
            this.saldo = saldo;
        }


        /* A partir do momento que se explicita um construtor diferente do construtor padrão (sem parâmetros),
         * este deixa de existir. Para que ele seja novamente reconhecido, torna-se necessário explicitá-lo */
        public ContaBancaria() { }


        // Classes possuem membros. 
        // Membros podem ser campos/propriedades ou métodos.
        private double saldo; // campo privado: apenas a própria classe consegue acessar.
        private int agencia;

        // Propriedade (C#).
        // Propriedades serão, em geral, públicas.
        public double Saldo
        {
            get
            {
                return saldo;
            }
        }

        // Poderíamos ter criado Saldo com uma autopropriedade apenas com get.
        // public double Saldo { get; }

        // Autopropriedade (C# 3.0 ou superior)
        // Padrão da linguagem: nomes de campos com minúscula; nomes de propriedades com maiúscula
        //public int Agencia { get; set; }

        public int Agencia
        {
            get => agencia;
            set
            {
                if (value < 1 || value > 9999)
                {
                    throw new ArgumentOutOfRangeException("O número da agência deve ser entre 1 e 9999.");
                }
                agencia = value;
            }
        }

        public int Numero { get; set; }
        public Pessoa Titular { get; set; }

        // E para escrever o saldo?
        // Vamos utilizar métodos que contenham as regras de negócio para manipular o saldo.

        // Os métodos, em geral, serão públicos (Haverá exceções)
        public void Depositar(double valor)
        {
            if (valor >= 0)
            {
                saldo += valor;
            }
            else
            {
                Console.WriteLine("Não é possível depositar valores engativos.");
            }
        }

        public void Sacar(double valor)
        {
            if (saldo >= valor && valor >= 0)
            {
                saldo -= valor;
                Console.WriteLine($"Saque finalizado. O novo saldo é de R${saldo}.");
            }
            else
            {
                Console.WriteLine("Não foi possível efetuar o saque. Seu saldo é insuficiente.");
            }
        }

        public virtual void Transferir(double valor, ContaBancaria conta)
        {
            if (valor >= 0 && valor <= saldo)
            {
                Sacar(valor);
                conta.Depositar(valor);
            }
        }

        public override string ToString()
        {
            return $"Agência: {Agencia}\nConta: {Numero}\nTitular: {Titular.ToString()}\nSaldo: R${Saldo}";
        }
    }
}
