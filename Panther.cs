using Canvas.CLI.Models;
using System;
using System.Collections.Generic;

namespace Canvas
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            List<Client> clientList = new List<Client>();
            List<Project> projectList = new List<Project>();
            while (true)
            {
                Console.WriteLine("P. Enter Projects Menu.");
                Console.WriteLine("C. Enter Client Menu.");
                Console.WriteLine("Q. Quit");

                var choice = Console.ReadLine() ?? string.Empty;

                if(choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    projectMenu(projectList, clientList);
                }
                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    clientMenu(clientList, projectList);
                }
                if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
            }
        }
        static void clientMenu(List<Client> clientList, List<Project> projectList)
        {
            while (true)
            {
                Console.WriteLine("C. Create a new Client.");
                Console.WriteLine("R. List current Client.");
                Console.WriteLine("U. Update current Client list.");
                Console.WriteLine("D. Delete current Client list.");
                Console.WriteLine("Q. Quit");

                var clientChoice = Console.ReadLine() ?? string.Empty;

                if (clientChoice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("ID: ");
                    var ID = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Notes: ");
                    var notes = Console.ReadLine();

                    Console.WriteLine("When did this account first open? yyyy-mm-dd");
                    string openDateInput = Console.ReadLine();

                    DateTime openDate = DateTime.Parse(openDateInput);

                    Console.WriteLine("Is Account Active? Y/N");
                    var accountActivityInput = Console.ReadLine();
                    bool accountActivity = accountActivityInput != null && accountActivityInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase);

                    DateTime closedDate;
                    if (accountActivity) {
                        closedDate = DateTime.MinValue;
                 
                    }else { 
                        Console.WriteLine("When did this account close? yyyy-mm-dd");
                        string closeDateInput = Console.ReadLine();
                        closedDate = DateTime.Parse(closeDateInput);
                    }

                    clientList.Add(
                        new Client
                        {
                            ID = ID,
                            Name = name ?? "None Provided",
                            isActive = accountActivity,
                            Note = notes ?? "None Provided",
                            openDate = openDate,
                            closedDate = closedDate,
                        }
                        );
                }
                else if (clientChoice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    clientList.ForEach(Console.WriteLine);

                }
                else if (clientChoice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter client ID to update");
                    clientList.ForEach(Console.WriteLine);
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToUpdate = clientList.FirstOrDefault(s => s.ID == updateChoice);
                    if (clientToUpdate != null)
                    {
                        Console.WriteLine("Enter Updated Name");
                        clientToUpdate.Name = Console.ReadLine() ?? "No Name Provided";

                        Console.WriteLine("Enter Updated Note");
                        clientToUpdate.Note = Console.ReadLine() ?? "No Not Provided";
                        Console.WriteLine("Enter Updated Open Date");
                        string openDateUpdated = Console.ReadLine() ;
                        clientToUpdate.openDate = DateTime.Parse(openDateUpdated);
                        
                        Console.WriteLine("Is Account Still Active?");
                        var accountActivityUpdated = Console.ReadLine() ;
                        clientToUpdate.isActive = accountActivityUpdated != null && accountActivityUpdated.Equals("Y", StringComparison.InvariantCultureIgnoreCase);

                        if (clientToUpdate.isActive)
                        {
                            clientToUpdate.closedDate = DateTime.Parse("0000-00-00");
                        }
                        else
                        {
                            Console.WriteLine("Enter Updated Close Date");
                            string closeDateUpdated = Console.ReadLine();
                            clientToUpdate.closedDate = DateTime.Parse(closeDateUpdated);
                        }
                    }
                }
                else if (clientChoice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter client ID to delete");
                    clientList.ForEach(Console.WriteLine);
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToDelete = clientList.FirstOrDefault(s => s.ID == deleteChoice);
                    if (clientToDelete != null)
                    {
                        clientList.Remove(clientToDelete);
                    }
                }

                else if (clientChoice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Cant do that");
                }
            }
            
        }
        static void projectMenu(List<Project> projectList, List<Client> clientList)
        {
            while (true)
            {
                Console.WriteLine("C. Create a new Project.");
                Console.WriteLine("R. List current Project.");
                Console.WriteLine("U. Update current Project list.");
                Console.WriteLine("D. Delete current Project list.");

                Console.WriteLine("Q. Quit");

                var projChoice = Console.ReadLine() ?? string.Empty;

                if (projChoice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("ID: ");
                    var ID = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Short Name: ");
                    var shortName = Console.ReadLine();
                    Console.WriteLine("Long Name: ");
                    var longName = Console.ReadLine();

                    Console.WriteLine("When did this account first open? yyyy-mm-dd");
                    string openDateInput = Console.ReadLine();
                    DateTime openDate = DateTime.Parse(openDateInput);

                    Console.WriteLine("Is Account Active? Y/N");
                    var projectActivityInput = Console.ReadLine();
                    bool projectActivity = projectActivityInput != null && projectActivityInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase);
                    
                    DateTime closedDate;
                    if (projectActivity)
                    {
                        closedDate = DateTime.MinValue;

                    }
                    else
                    {
                        Console.WriteLine("When did this account close? yyyy-mm-dd");
                        string closeDateInput = Console.ReadLine();
                        closedDate = DateTime.Parse(closeDateInput);
                    }

                    Console.WriteLine("If this Project has an associated client please enter their ID: ");
                    var clientID = int.Parse(Console.ReadLine() ?? "0");
                    var associatedClient = clientList.FirstOrDefault(c => c.ID == clientID);

                    projectList.Add(
                        new Project
                        {
                            ID = ID,
                            ShortName = shortName ?? "None Provided",
                            LongName = longName ?? "None Provided",
                            OpenDate = openDate,
                            isActive = associatedClient != null,
                            ClosedDate = closedDate,
                            ClientID = associatedClient
                        }
                        );
                }
                else if (projChoice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    projectList.ForEach(Console.WriteLine);

                }
                else if (projChoice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter client ID to update");
                    projectList.ForEach(Console.WriteLine);
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var projectToUpdate = projectList.FirstOrDefault(s => s.ID == updateChoice);
                    if (projectToUpdate != null)
                    {
                        Console.WriteLine("Enter Updated Short Name");
                        projectToUpdate.ShortName = Console.ReadLine() ?? "No Short Name Provided";

                        Console.WriteLine("Enter Updated Long Name");
                        projectToUpdate.LongName = Console.ReadLine() ?? "No Long Name Provided";

                        Console.WriteLine("Enter Updated Open Date");
                        string openDateUpdated = Console.ReadLine();
                        projectToUpdate.OpenDate = DateTime.Parse(openDateUpdated);

                        Console.WriteLine("Is Account Still Active?");
                        var accountActivityUpdated = Console.ReadLine();
                        projectToUpdate.isActive = accountActivityUpdated != null && accountActivityUpdated.Equals("Y", StringComparison.InvariantCultureIgnoreCase);

                        if (projectToUpdate.isActive)
                        {
                            projectToUpdate.ClosedDate = DateTime.MinValue;
                        }
                        else
                        {
                            Console.WriteLine("Enter Updated Close Date");
                            string closeDateUpdated = Console.ReadLine();
                            projectToUpdate.ClosedDate = DateTime.Parse(closeDateUpdated);
                        }
                    }
                }
                else if (projChoice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                { 
                    Console.WriteLine("Enter client ID to delete");
                    projectList.ForEach(Console.WriteLine);
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToDelete = projectList.FirstOrDefault(s => s.ID == deleteChoice);
                    if (clientToDelete != null)
                    {
                        projectList.Remove(clientToDelete);
                    }
                }
                else if (projChoice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
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
    

