using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GestorCMD
{
    [System.Serializable]
    internal class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair };

        static void Main(string[] args)
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("Gestor Estoque\nSelecione a opção desejada:");
                Console.WriteLine("1 - Listar, 2 - Adicionar, 3 - Remover, 4 - Entrada, 5 - Saída, 6 - Sair");

                string escolhaString = Console.ReadLine();
                int escolhaMenuInt = int.Parse(escolhaString);
                Menu escolha = (Menu)escolhaMenuInt;

                switch (escolha)
                {
                    case Menu.Listar:
                        Listagem();
                        break;
                    case Menu.Adicionar:
                        Cadastro();
                        break;
                    case Menu.Remover:
                        break;
                    case Menu.Entrada:
                        break;
                    case Menu.Saida:
                        break;
                    case Menu.Sair:
                        sair = true;
                        break;
                }
                Console.Clear();
            }
        }

        static void Listagem()
        {
            Console.WriteLine("Lista de Produtos");
            foreach(IEstoque produtos in produtos)
            {
                produtos.Exibir();
            }
        }

        enum MenuCadastro { ProdutoFisico = 1, Ebook, Curso }
        static void Cadastro()
        {
            Console.WriteLine("Cadastrar!\nSelecione uma opção:");
            Console.WriteLine("1 - Produto Fisico | 2 - Ebook | 3 - Curso");
            string escolhaString = Console.ReadLine();
            int escolhaInt = int.Parse(escolhaString);
            MenuCadastro escolha = (MenuCadastro)escolhaInt;

            switch (escolha)
            {
                case MenuCadastro.ProdutoFisico:
                    CadastroPF();
                    break;
                case MenuCadastro.Ebook:
                    CadastroEbook();
                    break;
                case MenuCadastro.Curso:
                    CadastroCurso();
                    break;
            }
        }


        static void CadastroPF()
        {
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("frete:");
            float frete = float.Parse(Console.ReadLine());

            Console.WriteLine("Preço:");
            float preco = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, frete, preco);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastroEbook()
        {
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Autor:");
            string autor = Console.ReadLine();

            Console.WriteLine("Preço:");
            float preco = float.Parse(Console.ReadLine());

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }

        static void CadastroCurso()
        {
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Autor:");
            string autor = Console.ReadLine();

            Console.WriteLine("Preço:");
            float preco = float.Parse(Console.ReadLine());

            Curso cb = new Curso(nome, autor, preco);
            produtos.Add(cb);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtor.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }

        static void Carregar()
        {

            FileStream stream=new FileStream("produtos.dat",FileMode.OpenOrCreate);
            BinaryFormatter encoder=new BinaryFormatter();
            try
           {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);
                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
           }
                
            catch(Exception e)
            {
                Console.WriteLine("Erro");
                produtos = new List<IEstoque>();
                Console.ReadLine();
                
            }
            stream.Close();
        }
    }
}
