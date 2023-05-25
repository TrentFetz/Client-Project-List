using Canvas.CLI.Models;
using System;

namespace Canvas
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            List<Client> clientList = new List<Client>();
            clientMenu(clientList);
        }
        static void clientMenu(List<Client> clientList)
        {
            while(true)
            {
                Console.WriteLine("C. Create a new client.");
                Console.WriteLine("R. List current clients.");
                Console.WriteLine("U. Update current client list.");
                Console.WriteLine("D. Delete current client list.");
                Console.WriteLine("Q. Quit");

                var choice = Console.ReadLine() ?? string.Empty;

                if(choice.Equals("C",StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("ID: ");
                    var ID = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();

                    clientList.Add(
                        new Client
                        {
                            ID = ID,
                            name = name ?? "None Provided",
                        }
                        );
                }else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    clientList.ForEach(Console.WriteLine);

                }else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter client ID to update");
                    clientList.ForEach(Console.WriteLine);
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToUpdate = clientList.FirstOrDefault(s => s.ID == updateChoice);
                    if(clientToUpdate != null)
                    {
                        Console.WriteLine("Enter Updated Name");
                        clientToUpdate.name = Console.ReadLine() ?? "No Name Provided";
                    }
                }else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter client ID to delete");
                    clientList.ForEach(Console.WriteLine);
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToDelete = clientList.FirstOrDefault(s => s.ID == deleteChoice);
                    if (clientToDelete != null)
                    {
                        clientList.Remove(clientToDelete);
                    }
                }else if(choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Cant do that");
                }
            }
        }
    }
}
