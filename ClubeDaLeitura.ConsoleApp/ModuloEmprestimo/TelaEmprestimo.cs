using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaEmprestimo
    {
        public CadastroAmigo cadastroAmigo = null;
        public CadastroEmprestimo cadastroEmprestimo = null;
        public CadastroRevista cadastroRevista = null;

        public string ApresentarMenuEmprestimo()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(1) Criar Emprestimo");
                Console.WriteLine("(2) Editar Emprestimo");
                Console.WriteLine("(3) Deletar Emprestimo");
                Console.WriteLine("(4) Listar Emprestimo");
                Console.WriteLine("(5) Fechar Emprestimo");
                Console.WriteLine("(S) Voltar ao Menu Principal");

                string opcao = Console.ReadLine().ToUpper();

                return opcao;
            }
        }
        public void SelecionarOpcaoEmprestimo(string opcao)
        {
            switch (opcao)
            {
                case "1": InserirNovoEmprestimo(); break;
                case "2": EditarEmprestimo(); break;
                case "3": DeletarEmprestimo(); break;
                case "4": ListarEmprestimo(); break;
                case "5": AlterarStatus(); break;
                case "S": Menu.VoltarAoMenu(); break;
            }
        }
        public void InserirNovoEmprestimo()
        {
            Emprestimo novoEmprestimo = ObterEmprestimo();

            cadastroEmprestimo.Criar(novoEmprestimo);

            Mensagem.ApresentarMensagem("Emprestimo criado com sucesso!", ConsoleColor.Green);
        }
        public void EditarEmprestimo()
        {
            int idSelecionado = ReceberIdEmprestimo();
            Emprestimo emprestimoAtualizado = ObterEmprestimo();

            cadastroEmprestimo.Editar(idSelecionado, emprestimoAtualizado);

            Mensagem.ApresentarMensagem("Emprestimo editado com sucesso!", ConsoleColor.Green);
        }
        public void ListarEmprestimo()
        {
            List<Emprestimo> listaEmprestimo = cadastroEmprestimo.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("ID   |   AMIGO   |  REVISTA  | DATA DO EMPRESTIMO |  DATA DEVOLUÇÃO  |  STATUS  |");
            Console.WriteLine("---------------------------------------------------------------------------------");

            if (listaEmprestimo.Count == 0)
            {
                Mensagem.ApresentarMensagem("Nenhum emprestimo cadastrado!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (var emprestimo in listaEmprestimo)
            {
                Console.WriteLine("{0,-5}|{1,-11}|{2,-11}|{3,-20}|{4,-18}|{5,-10}|", emprestimo.Id, emprestimo.AmigoQuePegouARevista.Nome, emprestimo.RevistaEmprestada.TipoColecao, emprestimo.DataDoEmprestimo, emprestimo.DataDeDevolucao, emprestimo.Status);
            }

            Console.ReadKey();
        }
        public void DeletarEmprestimo()
        {
            int idSelecionado = ReceberIdEmprestimo();
            cadastroEmprestimo.Deletar(idSelecionado);
            Mensagem.ApresentarMensagem("Emprestimo excluído com sucesso!", ConsoleColor.Green);
        }
        public int ReceberIdEmprestimo()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do emnprestimo: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = cadastroAmigo.SelecionarAmigoPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }
        public Emprestimo ObterEmprestimo()
        {
            Console.WriteLine("Digite o id amigo que pegou a revista: ");
            int idAmigo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ID da revista emprestada: ");
            int idRevistaEmprestada = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de emprestimo: ");
            string dataDeEmprestimo = Console.ReadLine();

            Console.WriteLine("Digite a data de devolução: ");
            string dataDeDevolucao = Console.ReadLine();


            Amigo amigo = null;
            Revista revista = null;

            foreach (Amigo a in cadastroAmigo.Amigos)
            {
                if (idAmigo == a.Id)
                {
                    amigo = a;
                }
            }
            foreach (Revista r in cadastroRevista.Revistas)
            {
                if (idRevistaEmprestada == r.Id)
                {
                    revista = r;
                }
            }

            Emprestimo emprestimo = new Emprestimo(cadastroEmprestimo.ContadorId, amigo, revista, dataDeEmprestimo, dataDeDevolucao, cadastroEmprestimo.StatusAtual);

            return emprestimo;
        }
        public void AlterarStatus()
        {
            int idFechar = ReceberIdEmprestimo();

            Emprestimo emprestimo = null;

            foreach (Emprestimo e in cadastroEmprestimo.Emprestimos)
            {
                if (idFechar == e.Id)
                {
                    emprestimo = e;
                }
            }
            cadastroEmprestimo.FecharStatus(emprestimo);
            Mensagem.ApresentarMensagem("Ëmprestimo Fechado com Sucesso !", ConsoleColor.Green);
        }
    }
}
