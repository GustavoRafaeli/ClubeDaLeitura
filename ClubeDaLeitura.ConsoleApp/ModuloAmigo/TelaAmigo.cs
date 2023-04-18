using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo : Tela
    {
        public CadastroAmigo cadastroAmigo = null;

        public string ApresentarMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(1) Criar Amigo");
                Console.WriteLine("(2) Editar Amigo");
                Console.WriteLine("(3) Deletar Amigo");
                Console.WriteLine("(4) Listar Amigos");
                Console.WriteLine("(S) Voltar ao Menu Principal");

                string opcao = Console.ReadLine().ToUpper();

                return opcao;
            }
        }
        public void SelecionarOpcao(string opcao)
        {
            switch (opcao)
            {
                case "1": Inserir(); break;
                case "2": Editar(); break;
                case "3": Deletar(); break;
                case "4": Listar(); break;
                case "S": Menu.VoltarAoMenu(); break;
            }
        }
        public void Inserir()
        {
            Listar();
            Amigo novoAmigo = ObterAmigo();

            cadastroAmigo.Criar(novoAmigo);

            ApresentarMensagem("Amigo criado com sucesso!", ConsoleColor.Green);
        }
        public void Editar()
        {
            Listar();
            int idSelecionado = ReceberIdAmigo();
            Amigo amigoAtualizado = ObterAmigo();

            cadastroAmigo.Editar(idSelecionado, amigoAtualizado);

           ApresentarMensagem("Amigo editado com sucesso!", ConsoleColor.Green);
        }
        public void Listar()
        {
            ArrayList listaAmigos = cadastroAmigo.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("ID   |    NOME    | RESPONSÁVEL | TELEFONE |  ENDEREÇO  |");
            Console.WriteLine("---------------------------------------------------------");

            if (listaAmigos.Count == 0)
            {
                ApresentarMensagem("Nenhum amigo cadastrado!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Amigo amigo in listaAmigos)
            {
                Console.WriteLine("{0,-5}|{1,-12}|{2,-13}|{3,-10}|{4,-12}|", amigo.Id, amigo.Nome, amigo.NomeDoResponsavel, amigo.Telefone, amigo.Endereco);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public void Deletar()
        {
            Listar();
            int idSelecionado = ReceberIdAmigo();
            cadastroAmigo.Deletar(idSelecionado);
            ApresentarMensagem("Amigo excluído com sucesso!", ConsoleColor.Green);
        }
        public int ReceberIdAmigo()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do amigo: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = cadastroAmigo.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }
        public Amigo ObterAmigo()
        {
            Console.WriteLine("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.WriteLine("Digite o número do telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o endereço do amigo: ");
            string endereço = Console.ReadLine();


            Amigo amigo = new Amigo(cadastroAmigo.ContadorId, nome, nomeResponsavel, telefone, endereço);

            return amigo;
        }
    }
}
