using System;
using System.Collections.Generic;
using System.IO;

namespace SortingEnemys.enemys;

public class Writer
{
    public static void WriteToFile(string filePath, List<Enemy> enemies)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Enemy enemy in enemies)
                {
                    writer.WriteLine($"{enemy.GetName()},{enemy.GetLevel()},{enemy.GetHealth()},{enemy.GetAttack()},{enemy.GetDefense()},{enemy.GetSpeed()}");
                }
            }

            Console.WriteLine("Arquivo salvo com sucesso em: " + filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao salvar o arquivo: " + ex.Message);
        }
    }
}
