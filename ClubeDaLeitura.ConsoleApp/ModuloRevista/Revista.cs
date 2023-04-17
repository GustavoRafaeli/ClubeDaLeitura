using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : Entidade
    {
        public string TipoColecao;
        public string NumeroDaEdicao;
        public string AnoDaRevista;
        public Caixa CaixaOndeEstaGuardada;

        public Revista(int id ,string tipoColecao, string numeroDaEdicao, string anoDaRevista, Caixa caixaOndeEstaGuardada)
        {
            Id = id;
            TipoColecao = tipoColecao;
            NumeroDaEdicao = numeroDaEdicao;
            AnoDaRevista = anoDaRevista;
            CaixaOndeEstaGuardada = caixaOndeEstaGuardada;
        }
    }
}
