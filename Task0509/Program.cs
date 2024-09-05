﻿// See https://aka.ms/new-console-template for more information


using System.Reflection.Metadata;
using System.Text.Json;
using Task0509;
internal class Program
{
    async static Task Main(string[] args)
    {

        //get all tree nodes
        TreeNode[] Nodes = ReadFromJsonAsync<TreeNode[]>("../../../defenceStrategiesBalanced.json");

        //insert the tree nodes into the tree
        DefenceStrategiesBST myTree = new DefenceStrategiesBST();
        foreach (var node in Nodes)
        {
            myTree.insert(node);
        }


        //print the tree
        myTree.PreOrderPrint();

        //get all threats
        Threats[] threats = ReadFromJsonAsync<Threats[]>("../../../threats.json");

        //for all threat find the defence
        foreach (var threat in threats)
        {
            //calculate the severity
            int Severity = threat.Volume * threat.Sophistication + threat.TargetValue;

            //find the defence
            TreeNode node = myTree.FindSeverityPreOrder(Severity);

            //print the defence
            if (node == null)
            {
                Console.WriteLine("No suitable defence was found! Brace for impact.");
                Console.WriteLine();
            }
            else if (node.MinSeverity > Severity)
            {
                Console.WriteLine("Attack severity is below the threshold. Attack is ignored.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Defence: ");
                foreach (var defense in node.Defenses)
                {
                    await Task.Delay(2000);
                    Console.WriteLine("  " + defense);
                }
                Console.WriteLine();
            }
        }
    }

    //function to read the json file
    static T? ReadFromJsonAsync<T>(string filePath, JsonSerializerOptions options = null)
{
    try
    {
        options ??= new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        T? data = JsonSerializer.Deserialize<T>(
            File.OpenRead(filePath),
            options
        );
        return data;
    }
    catch (Exception ex)
    {
        return default;
    }
}
}



