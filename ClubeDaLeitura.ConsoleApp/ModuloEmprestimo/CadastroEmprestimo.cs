using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class CadastroEmprestimo : Cadastro
    {
        public List<Emprestimo> Emprestimos = new List<Emprestimo>();


        public string StatusAtual = "EM ABERTO";

        public void CadastrarEmprestimo(Emprestimo emprestimo)
        {
            Emprestimos.Add(emprestimo);
        }

        public void Criar(Emprestimo emprestimo)
        {
            CadastrarEmprestimo(emprestimo);
            ContadorId++;
        }
        public void Editar(int idEditar, Emprestimo emprestimoAtualizado)
        {
            Emprestimo emprestimo = SelecionarEmprestimoPorId(idEditar);

            emprestimo.AmigoQuePegouARevista = emprestimoAtualizado.AmigoQuePegouARevista;
            emprestimo.RevistaEmprestada = emprestimoAtualizado.RevistaEmprestada;
            emprestimo.DataDoEmprestimo = emprestimoAtualizado.DataDoEmprestimo;
            emprestimo.DataDeDevolucao = emprestimoAtualizado.DataDoEmprestimo;
        }

        public void Deletar(int id)
        {
            Emprestimo emprestimo = SelecionarEmprestimoPorId(id);
            Emprestimos.Remove(emprestimo);
        }
        public List<Emprestimo> SelecionarTodos()
        {
            return Emprestimos;
        }
        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            Emprestimo emprestimo = null;

            foreach (Emprestimo e in Emprestimos)
            {
                if (e.Id == id)
                {
                    emprestimo = e;
                    break;
                }
            }

            return emprestimo;
        }
        public void FecharStatus(Emprestimo emprestimo)
        {
            emprestimo.Status = "FECHADO";
        }
    }
}
