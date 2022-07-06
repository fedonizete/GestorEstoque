using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCMD
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        public int vagas;

        public Curso(string nome, string autor, float preco)
        {
            this.nome = nome;
            this.autor = autor;
            this.preco = preco; 
            
        }

        public void AdicionarEntrada()
        {
        }

        public void AdicionarSaida()
        {
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas Restantes: {vagas}");
        }
    }
}
