using System;
namespace JogoDaVelha
{
    class JogoDaVelha
    {
        private bool fimJogo;

        private char[] posicoes;

        private char vez;

        private int quantidade;

        public JogoDaVelha()
        {
            fimJogo = false;
            posicoes = new[]
            {
                '1','2','3','4','5','6','7','8','9'
            };
            vez = 'X';
            quantidade = 0;

        }

        public void Iniciar()
        {
            while (!fimJogo)
            {
                renderTabela();
                escolhaUsuario();
                renderTabela();
                VerificarFimJogo();
                mudarVez();


            }
        }

        private void VerificarFimJogo()
        {
            if (quantidade < 5)
            {
                return;
            }

            if (VitoriaHorizontal() || VitoriaVertical() || VitoriaDiagonal())
            {
                fimJogo = true;
                Console.WriteLine($"Fim de jogo! Vitoria do: {vez}");
                return;
            }
            if (quantidade is 9)
            {
                fimJogo = true;
                Console.WriteLine("Empate");
            }
        }

        private bool VitoriaHorizontal()
        {
            bool linha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool linha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool linha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return linha1 || linha2 || linha3;
        }
        private bool VitoriaVertical()
        {
            bool linha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool linha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool linha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return linha1 || linha2 || linha3;
        }
        private bool VitoriaDiagonal()
        {
            bool linha1 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];
            bool linha2 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];


            return linha1 || linha2;
        }

        private void mudarVez()
        {
            if (vez == 'X')
            {
                vez = 'O';
            }
            else
                vez = 'X';
        }

        private void escolhaUsuario()
        {
            Console.WriteLine($"Agora é a vez de {vez} , entre uma posição disponivel na tabela");

            bool validar = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);

            while (!validar || !ValidarEscolhaUs(posicaoEscolhida))
            {
                Console.WriteLine("Digite um numero valido de 1 a 9 por favor.");
                validar = int.TryParse(Console.ReadLine(), out posicaoEscolhida);   
            }

            PreencherEscolha(posicaoEscolhida);
        }
        private void PreencherEscolha(int posicaoEscolhida)
        {
            int i = posicaoEscolhida - 1;
            posicoes[i] = vez;
            quantidade++;
        }

        private bool ValidarEscolhaUs(int posicaoEscolhida)
        {
            int i = posicaoEscolhida - 1;
            return posicoes[i] != 'O' && posicoes[i] != 'X';
        }

      
        private void renderTabela()
        {
            Console.Clear();
            Console.WriteLine(Tabela());
        }

        private string Tabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"__{posicoes[6]}__|__{posicoes[7]}__|__{posicoes[8]}__\n";

        }
    }
}
