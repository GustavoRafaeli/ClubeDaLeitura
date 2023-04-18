using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class TelaRevista
    {
        public CadastroCaixa cadastroCaixa = null;
        public CadastroRevista cadastroRevista = null;

        public string ApresentarMenuRevista()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(1) Criar Revista");
                Console.WriteLine("(2) Editar Revista");
                Console.WriteLine("(3) Deletar Revista");
                Console.WriteLine("(4) Listar Revista");
                Console.WriteLine("(S) Voltar ao Menu Principal");

                string opcao = Console.ReadLine().ToUpper();

                return opcao;
            }
        }
        public void SelecionarOpcaoRevista(string opcao)
        {
            switch (opcao)
            {
                case "1": InserirNovaRevista(); break;
                case "2": EditarRevista(); break;
                case "3": DeletarRevista(); break;
                case "4": ListarRevista(); break;
                case "S": Menu.VoltarAoMenu(); break;
            }
        }
        public void InserirNovaRevista()
        {
            Revista novaRevista = ObterRevista();

            cadastroRevista.Criar(novaRevista);

            Mensagem.ApresentarMensagem("Revista criada com sucesso!", ConsoleColor.Green);
        }

        public void EditarRevista()
        {
            int idSelecionado = ReceberIdRevista();

            foreach (Revista revista in cadastroRevista.Cadastros)
            {
                if (revista.Id == idSelecionado)
                {
                    foreach (Caixa caixa in cadastroCaixa.Cadastros)
                    {
                        if (revista.CaixaOndeEstaGuardada.Id == caixa.Id)
                        {
                            caixa.RevistasNaCaixa.Remove(revista);
                        }
                    }
                }
            }

            Revista revistaAtualizada = ObterRevista();

            cadastroRevista.Editar(idSelecionado, revistaAtualizada);

            Mensagem.ApresentarMensagem("Revista editada com sucesso!", ConsoleColor.Green);
        }
        public void ListarRevista()
        {
            ArrayList listaRevistas = cadastroRevista.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ID   |   COLECAO   |     ANO     |   CAIXA   |");
            Console.WriteLine("----------------------------------------------");

            if (listaRevistas.Count == 0)
            {
                Mensagem.ApresentarMensagem("Nenhuma revista cadastrada!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Revista revista in listaRevistas)
            {
                Console.WriteLine("{0,-5}|{1,-13}|{2,-13}|{3,-11}|", revista.Id, revista.TipoColecao, revista.AnoDaRevista, revista.CaixaOndeEstaGuardada.Id);
            }

            Console.ReadKey();
        }

        public void DeletarRevista()
        {
            int idSelecionado = ReceberIdRevista();

            foreach (Revista revista in cadastroRevista.Cadastros)
            {
                if (revista.Id == idSelecionado)
                {
                    foreach (Caixa caixa in cadastroCaixa.Cadastros)
                    {
                        if (revista.CaixaOndeEstaGuardada.Id == caixa.Id)
                        {
                            caixa.RevistasNaCaixa.Remove(revista);
                        }
                    }
                }
            }

            cadastroRevista.Deletar(idSelecionado);
            Mensagem.ApresentarMensagem("Revista excluída com sucesso!", ConsoleColor.Green);
        }

        public int ReceberIdRevista()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id da revista: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = cadastroRevista.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Mensagem.ApresentarMensagem("id Inválido, tente novamente", ConsoleColor.Red);
                }
            } while (idInvalido);

            return id;
        }
        public Revista ObterRevista()
        {
            Console.WriteLine("Digite a coleção: ");
            string colecao = Console.ReadLine();

            Console.WriteLine("Digite o numero da Edição: ");
            string numeroDaEdicao = Console.ReadLine();

            Console.WriteLine("Digite o ano da revista: ");
            string anoDaRevista = Console.ReadLine();

            Console.WriteLine("Digite o id da caixa que a revista pertence: ");
            int idDaCaixa = int.Parse(Console.ReadLine());

            Caixa caixa = null;

            foreach (Caixa c in cadastroCaixa.Cadastros)
            {
                if (idDaCaixa == c.Id)
                {
                    caixa = c;
                }
            }
            while (caixa == null)
            {
                Mensagem.ApresentarMensagem("Caixa inexistente!", ConsoleColor.Red);
                Console.WriteLine("Digite o id da caixa que a revista pertence: ");
                idDaCaixa = int.Parse(Console.ReadLine());

                foreach (Caixa c in cadastroCaixa.Cadastros)
                {
                    if (idDaCaixa == c.Id)
                    {
                        caixa = c;
                    }
                }
            }

            Revista revista = new Revista(cadastroRevista.ContadorId, colecao, numeroDaEdicao, anoDaRevista, caixa);

            return revista;
        }
    }
}
