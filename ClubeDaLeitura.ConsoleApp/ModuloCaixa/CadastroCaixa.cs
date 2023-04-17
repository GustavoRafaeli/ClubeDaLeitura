using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class CadastroCaixa : Cadastro
    {
        public List<Caixa> Caixas = new List<Caixa>();

        public void CadastrarCaixa(Caixa caixa)
        {
            Caixas.Add(caixa);
        }

        public void Criar(Caixa caixa)
        {
            CadastrarCaixa(caixa);
            ContadorId++;
        }
        public void Editar(int idEditar, Caixa caixaAtualizada)
        {
            Caixa caixa = SelecionarCaixaPorId(idEditar);

            caixa.Cor = caixaAtualizada.Cor;
            caixa.Etiqueta = caixaAtualizada.Etiqueta;
            caixa.Numero = caixaAtualizada.Numero;
        }

        public void Deletar(int id)
        {
            Caixa caixa = SelecionarCaixaPorId(id);
            Caixas.Remove(caixa);
        }
        public List<Caixa> SelecionarTodos()
        {
            return Caixas;
        }
        public Caixa SelecionarCaixaPorId(int id)
        {
            Caixa caixa = null;

            foreach (Caixa a in Caixas)
            {
                if (a.Id == id)
                {
                    caixa = a;
                    break;
                }
            }

            return caixa;
        }
    }
}

