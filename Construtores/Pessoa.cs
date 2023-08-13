using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreGenealogica.Construtores
{
    internal class Pessoa
    {

        //Atributos de uma nova Pessoa
        public String nome;
        public Pessoa conjuge;
        public List<Pessoa> filhos;

        //Construtor de uma Pessoa
        public Pessoa(string nome)
        {
            this.nome = nome;
            filhos = new List<Pessoa>();
        }

        //Construtor que adiciona um filho a pessoa referenciada
        public Pessoa(string nome, Pessoa pessoa)
        {
            this.nome = nome;
            filhos = new List<Pessoa>();
            pessoa.AdicionarFilho(this);
        }

        //Adicionar Filho
        public void AdicionarFilho(Pessoa novaPessoa)
        {
            filhos.Add(novaPessoa);
        }

        //Adiciona um Conjuge a uma pessoa e vice versa
        public void Conjuge(Pessoa pessoa)
        {
            conjuge = pessoa;
            pessoa.conjuge = this;
        }

        //Imprime e Árvore Genealógica
        public void ImprimeArvore(int nivelIndentacao = 0)
        {
            string espacos = new string(' ', nivelIndentacao * 3);

            if (conjuge != null && filhos.Count > 0)
            {
                Console.WriteLine($"{espacos}{nome} é casado(a) com {conjuge.nome}, filhos:");
            } else if (conjuge != null)
            {
                Console.WriteLine($"{espacos}{nome} é casado(a) com {conjuge.nome}");
            }
            else
            {
                Console.WriteLine($"{espacos}{nome} é solteiro(a).");
            }

            if (filhos.Count > 0)
            {
                foreach (var filho in filhos)
                {
                    filho.ImprimeArvore(nivelIndentacao + 1);
                }
            }
        }
    }


}
