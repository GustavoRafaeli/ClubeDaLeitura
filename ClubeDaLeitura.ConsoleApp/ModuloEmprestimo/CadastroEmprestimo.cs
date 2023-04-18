using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class CadastroEmprestimo : Cadastro 
    {
        public string StatusAtual = "EM ABERTO";   

        //public void Cadastrar(Emprestimo emprestimo)
        //{
        //    Cadastros.Add(emprestimo);
        //}

        //public void Criar(Emprestimo emprestimo)
        //{
        //    Cadastrar(emprestimo);
        //    ContadorId++;
        //}
        //public void Editar(int idEditar, Emprestimo emprestimoAtualizado)
        //{
        //    Emprestimo emprestimo = SelecionarEmprestimoPorId(idEditar);
        //    emprestimo.Atualizar(emprestimoAtualizado);
        //}

        //public void Deletar(int id)
        //{
        //    Emprestimo emprestimo = SelecionarEmprestimoPorId(id);
        //    Cadastros.Remove(emprestimo);
        //}
        //public ArrayList SelecionarTodos()
        //{
        //    return Cadastros;
        //}
        //public Emprestimo SelecionarPorId(int id)
        //{
        //    Emprestimo emprestimo = null;

        //    foreach (Emprestimo e in Cadastros)
        //    {
        //        if (e.Id == id)
        //        {
        //            emprestimo = e;
        //            break;
        //        }
        //    }

        //    return emprestimo;
        //}     
        public void FecharStatus(Emprestimo emprestimo)
        {
            emprestimo.Status = "FECHADO";
        }
    }
}
