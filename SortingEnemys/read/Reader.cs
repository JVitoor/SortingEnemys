using System;
using System.Collections.Generic;
using System.IO;

namespace SortingEnemys.enemys;

public class Reader
{
    public static List<Enemy> ReadFromFile(string filePath)
    {
        List<Enemy> enemies = new List<Enemy>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 6)
                {
                    string name = parts[0];
                    int level = int.Parse(parts[1]);
                    int health = int.Parse(parts[2]);
                    int attack = int.Parse(parts[3]);
                    int defense = int.Parse(parts[4]);
                    int speed = int.Parse(parts[5]);

                    enemies.Add(new Enemy(name, level, health, attack, defense, speed));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao ler o arquivo: " + ex.Message);
        }

        return enemies;
    }
}
