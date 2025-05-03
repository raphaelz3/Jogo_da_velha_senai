using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace velha_do_jogo
{
   public class JogoDaVelha
    {
        private bool fimDoJogo;
        private char[] posicoes;
        private char vez;
        private int quantidadePreenchida;

        public JogoDaVelha()
        {
            fimDoJogo = false;
            posicoes = new [] {'1', '2', '3', '4', '5', '6' , '7', '8', '9' };
            vez = 'X';
            quantidadePreenchida = 0;
        }
       

        public bool iniciar()
        {
            while (!fimDoJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimDoJogo();
                MudarVez();
            }
            return fimDoJogo;
        }

        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';

            /* O codigo acima representa o codigo abaixo de forma ternaria

            if (vez == 'X')
                 vez = 'O';
             else
                 vez = 'X';*/
        }

        private void VerificarFimDoJogo()
        {
            if (quantidadePreenchida < 5)
                return;
            if (ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal())
            {
                Console.WriteLine($"Fim de Jogo!!! \n Vitoria do {vez}");
                fimDoJogo = true;
                return;
            }

            if (quantidadePreenchida is 9)
            {
                Console.WriteLine("DEU VELHA!!!");
                fimDoJogo = true;
            }
        }

        private bool ExisteVitoriaHorizontal()
        {
            bool vitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[2] == posicoes[0];
            bool vitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[4] == posicoes[5];
            bool vitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[7] == posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool vitoriacoluna1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool vitoriacoluna2 = posicoes[1] == posicoes[4] && posicoes[4] == posicoes[7];
            bool vitoriacoluna3 = posicoes[2] == posicoes[5] && posicoes[5] == posicoes[8];

            return vitoriacoluna1 || vitoriacoluna2 || vitoriacoluna3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool vitoriadiagonal1 = posicoes[0] == posicoes[4] && posicoes[4] == posicoes[8];
            bool vitoriadiagonal2 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];

            return vitoriadiagonal1 || vitoriadiagonal2;
        }


        private void LerEscolhaDoUsuario()
        {
            Console.WriteLine($"Agora é a vez do Jogador {vez}, Digite a posicao disponivel que deseja jogar (Entre 1 e 9)");
            Console.Write("_ > ");

            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);
            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo Escolhido é invalido! Digite uma posicao disponivel entre 1 e 9");
                Console.Write("_ > ");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }
            PreencherEscolha(posicaoEscolhida);
        }

        private bool ValidarEscolhaUsuario(int posicao)
        {
            if (posicao < 1 || posicao > 9)
                return false;
            return posicoes[posicao - 1] != 'X' && posicoes[posicao - 1] != 'O';            
        }

        private void PreencherEscolha(int posicao)
        {
            posicoes[posicao - 1] = vez;
            quantidadePreenchida++;
        }

        public void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        public string ObterTabela()
        {
            return $@"        Jogo da Velha

         |         |         
    {posicoes[0]}    |    {posicoes[1]}    |    {posicoes[2]}    
_________|_________|________
         |         |         
    {posicoes[3]}    |    {posicoes[4]}    |    {posicoes[5]}    
_________|_________|________
         |         |         
    {posicoes[6]}    |    {posicoes[7]}    |    {posicoes[8]}
         |         |         

";
        }
    }
}
