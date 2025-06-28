using SortingEnemys.enemys;
using SortingEnemys.estruturas;
using System;
using System.Collections.Generic;
using System.IO;

namespace SortingEnemys
{
    class Program
    {
        public static void Main(string[] args)
        {
            string file = "enemys/enemys.txt";
            string caminhoAbsoluto = Path.GetFullPath(file);
            List<Enemy> enemiesList = Reader.ReadFromFile(caminhoAbsoluto);
            DynamicList dynamicEnemiesList = new DynamicList();
            foreach (var enemy in enemiesList)
            {
                dynamicEnemiesList.InsertAtEnd(enemy);
            }

            Console.WriteLine("==============================================");
            Console.WriteLine("Trabalho Prático I - Estrutura de Dados");
            Console.WriteLine("==============================================");
            Console.WriteLine($"\nInimigos carregados do arquivo: {caminhoAbsoluto}");
            dynamicEnemiesList.Print();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- MENU PRINCIPAL ---");
                Console.WriteLine("1. Ordenar Inimigos (Vetor)");
                Console.WriteLine("2. Testar Estruturas Estáticas");
                Console.WriteLine("3. Testar Estruturas Dinâmicas");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        SortEnemies(new List<Enemy>(enemiesList)); // Passa uma cópia para não alterar a original
                        break;
                    case 2:
                        TestStaticStructures(enemiesList);
                        break;
                    case 3:
                        TestDynamicStructures(dynamicEnemiesList);
                        break;
                    case 4:
                        running = false;
                        Console.WriteLine("Encerrando o programa.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void PrintEnemies(List<Enemy> enemies, string title)
        {
            Console.WriteLine($"\n{title}");
            foreach (Enemy e in enemies)
            {
                Console.WriteLine($"{e.GetName()}, Nível {e.GetLevel()}, Vida {e.GetHealth()}, Ataque {e.GetAttack()}, Defesa {e.GetDefense()}, Velocidade {e.GetSpeed()}");
            }
        }

        static void SortEnemies(List<Enemy> enemies)
        {
            Console.WriteLine("\n--- Ordenação de Vetor ---");
            Console.WriteLine("Escolha o tipo de ordenação:");
            Console.WriteLine("1 - Bubble Sort");
            Console.WriteLine("2 - Selection Sort");
            Console.WriteLine("3 - Insertion Sort");
            Console.WriteLine("4 - Shell Sort");
            Console.WriteLine("5 - Quick Sort");
            Console.WriteLine("6 - Merge Sort");
            Console.WriteLine("7 - Heap Sort");
            int tipo = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEscolha o atributo para ordenação:");
            Console.WriteLine("1 - Nome | 2 - Level | 3 - Health | 4 - Attack | 5 - Defense | 6 - Speed");
            int atributo = int.Parse(Console.ReadLine());

            var attr = (Sorter.SortAttribute)(atributo - 1);

            Console.WriteLine("\nVetor antes da ordenação:");
            PrintEnemies(enemies, "Lista Original:");

            switch (tipo)
            {
                case 1: Sorter.BubbleSort(enemies, attr); break;
                case 2: Sorter.SelectionSort(enemies, attr); break;
                case 3: Sorter.InsertionSort(enemies, attr); break;
                case 4: Sorter.ShellSort(enemies, attr); break;
                case 5: Sorter.QuickSort(enemies, attr); break;
                case 6: Sorter.MergeSort(enemies, attr); break;
                case 7: Sorter.HeapSort(enemies, attr); break;
                default: Console.WriteLine("Tipo inválido"); return;
            }

            PrintEnemies(enemies, "Lista ordenada:");

            string algoritmoNome = tipo switch
            {
                1 => "bolha",
                2 => "selecao",
                3 => "insercao",
                4 => "shell",
                5 => "quick",
                6 => "merge",
                7 => "heap",
                _ => "desconhecido"
            };

            Console.WriteLine("\nDeseja salvar a lista ordenada em um arquivo? (s/n)");
            if (Console.ReadLine().ToLower() == "s")
            {
                string outputFile = $"enemys-vetor-{algoritmoNome}.txt";
                Directory.CreateDirectory("enemys");
                Writer.WriteToFile(outputFile, enemies);
                Console.WriteLine($"Arquivo salvo como: {outputFile}");
            }
        }

        static void TestStaticStructures(List<Enemy> enemies)
        {
            Console.WriteLine("\n--- Teste de Estruturas Estáticas ---");

            // Pilha Estática
            StaticStack pilha = new StaticStack(10);
            pilha.Push(enemies[0]);
            pilha.Push(enemies[1]);
            Console.WriteLine("\n[PILHA ESTÁTICA]");
            pilha.Print();
            Console.WriteLine($"Busca por 'Orc': {(pilha.SearchByName("Orc") != null ? "Encontrado" : "Não Encontrado")}");
            pilha.Pop();
            Console.WriteLine("Pilha após Pop():");
            pilha.Print();

            // Fila Estática
            StaticQueue fila = new StaticQueue(10);
            fila.Enqueue(enemies[0]);
            fila.Enqueue(enemies[1]);
            Console.WriteLine("\n[FILA ESTÁTICA]");
            fila.Print();
            Console.WriteLine($"Busca por 'Goblin': {(fila.SearchByName("Goblin") != null ? "Encontrado" : "Não Encontrado")}");
            fila.Dequeue();
            Console.WriteLine("Fila após Dequeue():");
            fila.Print();

            // Lista Estática
            StaticList lista = new StaticList(10);
            lista.InsertAt(0, enemies[0]);
            lista.InsertAt(1, enemies[1]);
            Console.WriteLine("\n[LISTA ESTÁTICA]");
            lista.Print();
            Console.WriteLine($"Busca por 'Orc': {(lista.SearchByName("Orc") != null ? "Encontrado" : "Não Encontrado")}");
            lista.RemoveAt(0);
            Console.WriteLine("Lista após remover da posição 0:");
            lista.Print();
        }

        static void TestDynamicStructures(DynamicList dynamicEnemiesList)
        {
            Console.WriteLine("\n--- Teste de Estruturas Dinâmicas ---");
            Console.WriteLine("1. Testar Lista Dinâmica e Ordenação");
            Console.WriteLine("2. Testar Pilha Dinâmica");
            Console.WriteLine("3. Testar Fila Dinâmica");
            Console.WriteLine("4. Testar Pesquisa Binária (em Lista Dinâmica)");
            Console.WriteLine("5. Testar Árvore Binária de Busca");
            Console.WriteLine("6. Testar Tabela Hash");
            Console.Write("Escolha uma opção: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    TestDynamicListSorting(dynamicEnemiesList);
                    break;
                case 2:
                    TestDynamicStack(dynamicEnemiesList);
                    break;
                case 3:
                    TestDynamicQueue(dynamicEnemiesList);
                    break;
                case 4:
                    TestBinarySearch(dynamicEnemiesList);
                    break;
                case 5:
                    TestBinaryTree(dynamicEnemiesList);
                    break;
                case 6:
                    TestHashTable(dynamicEnemiesList);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        static void TestDynamicListSorting(DynamicList list)
        {
            Console.WriteLine("\n--- Ordenação de Lista Dinâmica ---");
            list.Print();

            Console.WriteLine("\nEscolha o atributo para ordenação:");
            Console.WriteLine("1-Nome | 2-Level | 3-Health | 4-Attack | 5-Defense | 6-Speed");
            int atributo = int.Parse(Console.ReadLine());
            var attr = (Sorter.SortAttribute)(atributo - 1);

            // Usando o Insertion Sort como exemplo para a lista dinâmica
            DynamicListSorter.InsertionSort(list, attr);

            Console.WriteLine("\nLista dinâmica ordenada com Insertion Sort:");
            list.Print();
        }

        static void TestDynamicStack(DynamicList enemies)
        {
            Console.WriteLine("\n[TESTE - PILHA DINÂMICA]");
            DynamicStack pilha = new DynamicStack();
            pilha.Push(enemies.GetHead().Data);
            pilha.Push(enemies.GetHead().Next.Data);
            pilha.Print();
            Console.WriteLine($"Busca por 'Orc': {(pilha.SearchByName("Orc") != null ? "Encontrado" : "Não Encontrado")}");
            Enemy removido = pilha.Pop();
            Console.WriteLine($"\nRemovido da pilha: {removido.GetName()}");
            pilha.Print();
        }

        static void TestDynamicQueue(DynamicList enemies)
        {
            Console.WriteLine("\n[TESTE - FILA DINÂMICA]");
            DynamicQueue fila = new DynamicQueue();
            fila.Enqueue(enemies.GetHead().Data);
            fila.Enqueue(enemies.GetHead().Next.Data);
            fila.Print();
            Console.WriteLine($"Busca por 'Goblin': {(fila.SearchByName("Goblin") != null ? "Encontrado" : "Não Encontrado")}");
            Enemy removido = fila.Dequeue();
            Console.WriteLine($"\nRemovido da fila: {removido.GetName()}");
            fila.Print();
        }

        static void TestBinarySearch(DynamicList list)
        {
            Console.WriteLine("\n[TESTE - PESQUISA BINÁRIA]");
            Console.Write("Digite o nome do inimigo para buscar: ");
            string name = Console.ReadLine();

            Enemy found = BinarySearch.Search(list, name);
            if (found != null)
            {
                Console.WriteLine($"Inimigo '{name}' encontrado! Nível: {found.GetLevel()}");
            }
            else
            {
                Console.WriteLine($"Inimigo '{name}' não encontrado.");
            }
        }

        static void TestBinaryTree(DynamicList list)
        {
            Console.WriteLine("\n[TESTE - ÁRVORE BINÁRIA DE BUSCA]");
            BinarySearchTree tree = new BinarySearchTree();
            DynamicListNode current = list.GetHead();
            while (current != null)
            {
                tree.Insert(current.Data);
                current = current.Next;
            }

            Console.WriteLine("Árvore em ordem (por nome):");
            tree.InOrderTraversal();

            Console.Write("\nDigite o nome do inimigo para buscar na árvore: ");
            string name = Console.ReadLine();
            Enemy found = tree.Search(name);
            Console.WriteLine(found != null ? $"Encontrado: {found.GetName()}, Nível {found.GetLevel()}" : "Não encontrado.");
        }

        static void TestHashTable(DynamicList list)
        {
            Console.WriteLine("\n[TESTE - TABELA HASH]");
            HashTable hashTable = new HashTable(10);
            DynamicListNode current = list.GetHead();
            while (current != null)
            {
                hashTable.Add(current.Data.GetName(), current.Data);
                current = current.Next;
            }

            Console.WriteLine("Tabela Hash criada.");

            Console.Write("\nDigite o nome do inimigo para buscar na tabela: ");
            string name = Console.ReadLine();
            Enemy found = hashTable.Get(name);
            Console.WriteLine(found != null ? $"Encontrado: {found.GetName()}, Nível {found.GetLevel()}" : "Não encontrado.");

            Console.Write("\nDigite o nome do inimigo para remover da tabela: ");
            name = Console.ReadLine();
            hashTable.Remove(name);
            found = hashTable.Get(name);
            Console.WriteLine(found == null ? $"'{name}' removido com sucesso." : $"Falha ao remover '{name}'.");
        }
    }
}