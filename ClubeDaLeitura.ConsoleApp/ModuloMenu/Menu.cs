using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Menu
    {
        public CadastroCaixa cadastroCaixa = null;
        public CadastroAmigo cadastroAmigo = null;
        public TelaAmigo telaAmigo = null;
        public TelaEmprestimo telaEmprestimo = null;
        public TelaCaixa telaCaixa = null;
        public TelaRevista telaRevista = null;

        public void ExecutarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("(1) Gerenciar Emprestimo");
                Console.WriteLine("(2) Gerenciar Amigos");
                Console.WriteLine("(3) Gerenciar Caixas");
                Console.WriteLine("(4) Gerenciar Revistas");
                Console.WriteLine("(S) Sair");
                Console.WriteLine("-------------------------------");

                string opcao = Console.ReadLine().ToUpper();

                switch (opcao)
                {
                    case "1": MenuEmprestimo(); break;
                    case "2": MenuAmigos(); break;
                    case "3": MenuCaixas(); break;
                    case "4": MenuRevistas(); break;
                    case "S": Finalizar(); return;
                }
            }
        }
        public void MenuEmprestimo()
        {
            while (true)
            {
                string opcao = telaEmprestimo.ApresentarMenu();
                telaEmprestimo.SelecionarOpcaoEmprestimo(opcao);
                break;
            }
        }
        public void MenuAmigos()
        {
            while (true)
            {
                string opcao = telaAmigo.ApresentarMenu();
                telaAmigo.SelecionarOpcao(opcao);
                break;
            }
        }
        public void MenuCaixas()
        {
            while (true)
            {
                string opcao = telaCaixa.ApresentarMenu();
                telaCaixa.SelecionarOpcaoCaixa(opcao);
                break;
            }
        }
        public void MenuRevistas()
        {
            while (true)
            {
                string opcao = telaRevista.ApresentarMenu();
                telaRevista.SelecionarOpcaoRevista(opcao);
                break;
            }
        }
        public static void VoltarAoMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-------------");
            Console.WriteLine("|Voltando...|");
            Console.WriteLine("-------------");
            Console.ResetColor();
        }
        private static void Finalizar()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------");
            Console.WriteLine("|Encerrando o PROGRAMA...|");
            Console.WriteLine("--------------------------");
            Console.ResetColor();
            return;
        }
    }
}
