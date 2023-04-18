using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CadastroCaixa cadastroCaixa = new CadastroCaixa();
            CadastroAmigo cadastroAmigo = new CadastroAmigo();
            CadastroEmprestimo cadastroEmprestimo = new CadastroEmprestimo();
            CadastroRevista cadastroRevista = new CadastroRevista();

            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            TelaAmigo telaAmigo = new TelaAmigo();
            TelaCaixa telaCaixa = new TelaCaixa();
            TelaRevista telaRevista = new TelaRevista();

            Menu menu = new Menu();

            telaCaixa.cadastroCaixa = cadastroCaixa;
            telaEmprestimo.cadastroEmprestimo = cadastroEmprestimo;
            telaEmprestimo.cadastroAmigo = cadastroAmigo;
            telaAmigo.cadastroAmigo = cadastroAmigo;
            telaRevista.cadastroRevista = cadastroRevista;
            telaRevista.cadastroCaixa = cadastroCaixa;
            telaEmprestimo.cadastroRevista = cadastroRevista;

            menu.cadastroCaixa = cadastroCaixa;
            menu.cadastroAmigo = cadastroAmigo;
            menu.telaAmigo = telaAmigo;
            menu.telaEmprestimo = telaEmprestimo;
            menu.telaCaixa = telaCaixa;
            menu.telaRevista = telaRevista;


            //ADICIONANDO CAIXAS
            //-------------------------------------------------------------------------------------
            Caixa caixa0 = new Caixa(0, "Verde", "Ação", 0);
            cadastroCaixa.Cadastros.Add(caixa0);
            cadastroCaixa.Cadastros.Add(new Caixa(1, "Preto", "Aventura", 1));
            cadastroCaixa.Cadastros.Add(new Caixa(2, "Branco", "Filosofia", 2));
            cadastroCaixa.Cadastros.Add(new Caixa(3, "Vermelho", "Quadrinhos", 3));
            //-------------------------------------------------------------------------------------
            //ADICIONANDO AMGOS
            //-------------------------------------------------------------------------------------
            Amigo amigo0 = new Amigo(0, "João", "José", "99999999", "88555880");
            Amigo amigo1 = new Amigo(1, "Maria", "Hikaru", "88888888", "11139730");
            Amigo amigo2 = new Amigo(2, "Felipe", "Alvin", "99955779", "22234560");
            Amigo amigo3 = new Amigo(3, "Jhonny", "Kleberson", "00992599", "33264330");
            cadastroAmigo.Cadastros.Add(amigo0);
            cadastroAmigo.Cadastros.Add(amigo1);
            cadastroAmigo.Cadastros.Add(amigo2);
            cadastroAmigo.Cadastros.Add(amigo3);
            //-------------------------------------------------------------------------------------
            //ADICIONANDO REVISTAS
            //-------------------------------------------------------------------------------------
            Revista revista0 = new Revista(0, "Marvel", "347", "2018", caixa0);
            Revista revista1 = new Revista(1, "DC", "454", "2019", caixa0);
            Revista revista2 = new Revista(2, "AVENTURES", "222", "2015", caixa0);
            Revista revista3 = new Revista(3, "Fighters", "789", "2017", caixa0);
            cadastroRevista.Cadastros.Add(revista0);
            cadastroRevista.Cadastros.Add(revista1);
            cadastroRevista.Cadastros.Add(revista2);
            cadastroRevista.Cadastros.Add(revista3);
            //-------------------------------------------------------------------------------------
            //ADICIONANDO EMPRESTIMOS
            //-------------------------------------------------------------------------------------
            cadastroEmprestimo.Cadastros.Add(new Emprestimo(0, amigo0, revista0, "14/04", "24/04", "EM ABERTO"));
            cadastroEmprestimo.Cadastros.Add(new Emprestimo(1, amigo1, revista0, "14/04", "24/04", "EM ABERTO"));
            cadastroEmprestimo.Cadastros.Add(new Emprestimo(2, amigo2, revista0, "14/04", "24/04", "EM ABERTO"));
            cadastroEmprestimo.Cadastros.Add(new Emprestimo(3, amigo3, revista0, "14/04", "24/04", "EM ABERTO"));
            //-------------------------------------------------------------------------------------

            menu.ExecutarMenuPrincipal();

        }
    }
}