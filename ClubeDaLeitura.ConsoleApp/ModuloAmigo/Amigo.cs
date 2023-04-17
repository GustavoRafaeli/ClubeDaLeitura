using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class Amigo : Entidade
    {
        public string Nome;
        public string NomeDoResponsavel;
        public string Telefone;
        public string Endereco;

        public Amigo(int id, string nome, string nomeDoResponsável, string telefone, string endereço)
        {
            Id = id;
            Nome = nome;
            NomeDoResponsavel = nomeDoResponsável;
            Telefone = telefone;
            Endereco = endereço;
        }
    }
}
