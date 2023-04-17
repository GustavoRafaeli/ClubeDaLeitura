using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class CadastroRevista : Cadastro
    {
        public List<Revista> Revistas = new List<Revista>();


        public void CadastrarRevista(Revista revista)
        {
            Revistas.Add(revista);
        }

        public void Criar(Revista revista)
        {
            CadastrarRevista(revista);
            ContadorId++;
        }
        public void Editar(int idEditar, Revista revistaAtualiada)
        {
            Revista revista = SelecionarRevistaPorId(idEditar);


            revista.TipoColecao = revistaAtualiada.TipoColecao;
            revista.NumeroDaEdicao = revistaAtualiada.NumeroDaEdicao;
            revista.AnoDaRevista = revistaAtualiada.AnoDaRevista;
            revista.CaixaOndeEstaGuardada = revistaAtualiada.CaixaOndeEstaGuardada;
        }

        public void Deletar(int id)
        {
            Revista revista = SelecionarRevistaPorId(id);
            Revistas.Remove(revista);
        }
        public List<Revista> SelecionarTodos()
        {
            return Revistas;
        }
        public Revista SelecionarRevistaPorId(int id)
        {
            Revista revista = null;

            foreach (Revista r in Revistas)
            {
                if (r.Id == id)
                {
                    revista = r;
                    break;
                }
            }

            return revista;
        }
    }
}
