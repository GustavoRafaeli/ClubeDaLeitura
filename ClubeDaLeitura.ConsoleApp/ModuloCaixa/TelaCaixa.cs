using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCaixa
    {
        public CadastroCaixa cadastroCaixa = null;

        public string ApresentarMenuCaixa()
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(1) Criar Caixa");
                Console.WriteLine("(2) Editar Caixa");
                Console.WriteLine("(3) Deletar Caixa");
                Console.WriteLine("(4) Listar Caixa");
                Console.WriteLine("(S) Voltar ao Menu Principal");

                string opcao = Console.ReadLine().ToUpper();

                return opcao;
            }
        }
        public void SelecionarOpcaoCaixa(string opcao)
        {
            switch (opcao)
            {
                case "1": InserirNovaCaixa(); break;
                case "2": EditarCaixa(); break;
                case "3": DeletarCaixa(); break;
                case "4": ListarCaixa(); break;
                case "S": Menu.VoltarAoMenu(); break;
            }
        }
        public void InserirNovaCaixa()
        {
            ListarCaixa();
            Caixa novaCaixa = ObterCaixa();

            cadastroCaixa.Criar(novaCaixa);

            Mensagem.ApresentarMensagem("Caixa criada com sucesso!", ConsoleColor.Green);
        }
        public void EditarCaixa()
        {
            ListarCaixa();
            int idSelecionado = ReceberIdCaixa();
            Caixa caixaAtualizada = ObterCaixa();


            cadastroCaixa.Editar(idSelecionado, caixaAtualizada);

            Mensagem.ApresentarMensagem("Caixa editada com sucesso!", ConsoleColor.Green);
        }
        public void ListarCaixa()
        {
            ArrayList listaCaixas = cadastroCaixa.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("ID     |  ETIQUETA  |    COR    |  NUMERO  |");
            Console.WriteLine("--------------------------------------------");

            if (listaCaixas.Count == 0)
            {
                Mensagem.ApresentarMensagem("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
                return;
            }

            foreach (Caixa caixa in listaCaixas)
            {
                Console.WriteLine("{0,-7}|{1,-12}|{2,-11}|{3,-10}|", caixa.Id, caixa.Etiqueta, caixa.Cor, caixa.Numero);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        public void DeletarCaixa()
        {
            ListarCaixa();
            int numeroSelecionado = ReceberIdCaixa();
            cadastroCaixa.Deletar(numeroSelecionado);
            Mensagem.ApresentarMensagem("Caixa excluída com sucesso!", ConsoleColor.Green);
        }
        public int ReceberIdCaixa()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id da caixa: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = cadastroCaixa.SelecionarPorId(id) == null;

                if (idInvalido)
                {
                    Mensagem.ApresentarMensagem("Id Inválido, tente novamente", ConsoleColor.Red);
                }
            } while (idInvalido);

            return id;
        }
        public Caixa ObterCaixa()
        {
            Console.WriteLine("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.WriteLine("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Console.WriteLine("Digite o numero da caixa: ");
            int numero = int.Parse(Console.ReadLine());

            Caixa caixa = new Caixa(cadastroCaixa.ContadorId, cor, etiqueta, numero);

            return caixa;
        }
    }
}
