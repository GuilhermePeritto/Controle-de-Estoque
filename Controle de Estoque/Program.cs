using System.Globalization;
using System;
using System.Windows;


namespace Controle_Estoque {
    class Program {
        static async Task Main(string[] args) {
            Random numAleatorio = new Random();
            int[] id_produto = new int[100];
            int[] qtd_estoque = new int[100];
            int[] id_cliente = new int[100];
            string[] nome_cliente = new string[100];
            int qtd_usuarios = 0, qtd_produto=0;

            while(qtd_produto<=10) { //geracao de estoque
                id_produto[qtd_produto+1] = qtd_produto + 1;
                qtd_estoque[qtd_produto] = numAleatorio.Next(0, 100);
                qtd_produto++;
            }

            int cod_produto, cod_cliente, opcao, qtd_compra, validacao_produto = 0, validacao_cliente = 0;
            while (1 == 1) {

                Console.WriteLine("\n\n1 - Cadastrar nova venda\n\n2 - Cadastrar Produtos\n\n3 - Cadastrar cliente\n\n4 - Mostrar cliente\n\n5 - Mostrar estoque\n\n\n\n\n\n9 - Sair\n\nInforme oque você deseja fazer: ");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao) {
                    case 1:
                        Console.Clear();

                        for (int i = 1; i <= qtd_usuarios; i++) {
                            Console.WriteLine("\n                                              Cod Cliente: " + id_cliente[i] + " Nome Cliente: " + nome_cliente[i]);
                        }
                        Console.WriteLine("\nInforme o codigo do cliente: ");
                        cod_cliente = int.Parse(Console.ReadLine());
                        for (int i = 0; i < 10; i++) {
                            if (cod_cliente == id_cliente[i]) {
                                validacao_cliente = i;
                            }
                        }
                        if (validacao_cliente > 0) {
                            Console.WriteLine("\nInforme o codigo do produto: ");
                            cod_produto = int.Parse(Console.ReadLine());
                            for (int i = 0; i < 10; i++) {
                                if (cod_produto == id_produto[i]) {
                                    validacao_produto = i;
                                }
                            }
                            if (validacao_produto > 0) {
                                Console.WriteLine("\nInforme a quantide que voce deseja comprar: ");
                                qtd_compra = int.Parse(Console.ReadLine());
                                if (qtd_estoque[validacao_produto] >= qtd_compra) {
                                    Console.WriteLine("\nPedido atendido, obrigado e volte sempre!");
                                    qtd_estoque[validacao_produto] = qtd_estoque[validacao_produto] - qtd_compra;
                                    await Task.Delay(2000);
                                    Console.Clear();
                                    break;
                                }
                                else if (qtd_estoque[validacao_produto] < qtd_compra) {
                                    Console.WriteLine("\nNão temos estoque suficiente dessa mercadoria!");
                                    await Task.Delay(2000);
                                    Console.Clear();
                                    break;
                                }
                            }
                            else {
                                Console.WriteLine("\nCodigo inexistente");
                                await Task.Delay(2000);
                                Console.Clear();
                                break;
                            }

                        }
                        else {
                            Console.WriteLine("Por favor, informe um cliente valido!!");
                            await Task.Delay(2000);
                            Console.Clear();
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Informe o id do produto:");
                        qtd_produto++;
                        id_produto[qtd_produto] = int.Parse(Console.ReadLine());
                        id_produto[qtd_produto] = qtd_produto;
                        Console.WriteLine("Informe valor do estoque:");
                        qtd_estoque[qtd_produto] = int.Parse(Console.ReadLine());
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Informe o nome do cliente:");
                        qtd_usuarios++;
                        nome_cliente[qtd_usuarios] = Console.ReadLine();
                        id_cliente[qtd_usuarios] = qtd_usuarios;
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        if (qtd_usuarios > 0) {
                            for (int i = 1; i <= qtd_usuarios; i++) {
                                Console.WriteLine("\n                                              Cod Cliente: " + id_cliente[i] + " Nome Cliente: " + nome_cliente[i]);
                            }
                        }
                        else {
                            Console.WriteLine("Ainda nao temos Cliente Cadastrado, por favor volte no menu e cadastre um!");
                            await Task.Delay(3000);
                            Console.Clear();
                        }
                        break;

                    case 5:
                        Console.Clear();
                        for (int i = 1; i <= qtd_produto; i++) {
                            if (id_produto[i]>0) {
                                Console.WriteLine("\n                                              Cod Produto: " + id_produto[i] + " Estoque: " + qtd_estoque[i]);
                            }
                        }
                        string saida;
                        Console.WriteLine("\n\nPrecione qualquer tecla para voltar ao menu: ");
                        saida = Console.ReadLine();
                        Console.Clear();
                        break;

                    case 9:
                        return;

                    default:
                        Console.WriteLine("\nOpção Inválida, por favor insira uma opção valida!!");
                        await Task.Delay(2000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}