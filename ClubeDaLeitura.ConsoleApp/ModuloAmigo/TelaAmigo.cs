using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo
    {
        public CadastroAmigo cadastroAmigo = null;

        public string ApresentarMenuAmigo()
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
        public void SelecionarOpcaoAmigo(string opcao)
        {
            switch (opcao)
            {
                case "1": InserirNovoAmigo(); break;
                case "2": EditarAmigo(); break;
                case "3": DeletarAmigo(); break;
                case "4": ListarAmigo(); break;
                case "S": Menu.VoltarAoMenu(); break;
            }
        }
        public void InserirNovoAmigo()
        {
            ListarAmigo();
            Amigo novoAmigo = ObterAmigo();

            cadastroAmigo.Criar(novoAmigo);

            Mensagem.ApresentarMensagem("Amigo criado com sucesso!", ConsoleColor.Green);
        }
        public void EditarAmigo()
        {
            ListarAmigo();
            int idSelecionado = ReceberIdAmigo();
            Amigo amigoAtualizado = ObterAmigo();

            cadastroAmigo.Editar(idSelecionado, amigoAtualizado);

            Mensagem.ApresentarMensagem("Amigo editado com sucesso!", ConsoleColor.Green);
        }
        public void ListarAmigo()
        {
            ArrayList listaAmigos = cadastroAmigo.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("ID   |    NOME    | RESPONSÁVEL | TELEFONE |  ENDEREÇO  |");
            Console.WriteLine("---------------------------------------------------------");

            if (listaAmigos.Count == 0)
            {
                Mensagem.ApresentarMensagem("Nenhum amigo cadastrado!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Amigo amigo in listaAmigos)
            {
                Console.WriteLine("{0,-5}|{1,-12}|{2,-13}|{3,-10}|{4,-12}|", amigo.Id, amigo.Nome, amigo.NomeDoResponsavel, amigo.Telefone, amigo.Endereco);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public void DeletarAmigo()
        {
            ListarAmigo();
            int idSelecionado = ReceberIdAmigo();
            cadastroAmigo.Deletar(idSelecionado);
            Mensagem.ApresentarMensagem("Amigo excluído com sucesso!", ConsoleColor.Green);
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
