using Canvas.CLI.Models;
using System;
using System.Collections.Generic;

namespace Canvas
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            //Create client List and Project List to access data
            List<Client> clientList = new List<Client>();
            List<Project> projectList = new List<Project>();
            //While loop fr menu options, true until Quit option
            while (true)
            {
                Console.WriteLine("P. Enter Projects Menu.");
                Console.WriteLine("C. Enter Client Menu.");
                Console.WriteLine("Q. Quit");

                var choice = Console.ReadLine() ?? string.Empty;
                //Enter Projects Menu
                if(choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    projectMenu(projectList, clientList);
                }
                //Enter Client Menu
                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    clientMenu(clientList, projectList);
                }
                //Quit option
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
                //Basic CRUD for client options
                Console.WriteLine("C. Create a new Client.");
                Console.WriteLine("R. List current Client.");
                Console.WriteLine("U. Update current Client list.");
                Console.WriteLine("D. Delete current Client list.");
                Console.WriteLine("Q. Quit");
                //get Client input
                var clientChoice = Console.ReadLine() ?? string.Empty;

                if (clientChoice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    //enter client ID
                    Console.WriteLine("ID: ");
                    //if none provided, set to 0
                    var ID = int.Parse(Console.ReadLine() ?? "0");
                    //Enter client name
                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();
                    //Enter notes about client
                    Console.WriteLine("Notes: ");
                    var notes = Console.ReadLine();

                    //Ask for client open date
                    Console.WriteLine("When did this account first open? yyyy-mm-dd");
                    string openDateInput = Console.ReadLine();
                    //get input date
                    DateTime openDate = DateTime.Parse(openDateInput);

                    //Ask If account is active, it is set to minimum possible date, if not, ask for close date
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
                    //add client info
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
                //List client info
                else if (clientChoice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    clientList.ForEach(Console.WriteLine);

                }
                //update client info
                else if (clientChoice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Get client id to update
                    Console.WriteLine("Enter client ID to update");
                    clientList.ForEach(Console.WriteLine);
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    //Get id input and use first of default to find customer by id
                    var clientToUpdate = clientList.FirstOrDefault(s => s.ID == updateChoice);
                    if (clientToUpdate != null)
                    {
                        //allow user to update name, note, date, and activity
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

                        //If account is active, set close date to min value, if not get close date
                        if (clientToUpdate.isActive)
                        {
                            clientToUpdate.closedDate = DateTime.MinValue;
                        }
                        else
                        {
                            Console.WriteLine("Enter Updated Close Date");
                            string closeDateUpdated = Console.ReadLine();
                            clientToUpdate.closedDate = DateTime.Parse(closeDateUpdated);
                        }
                    }
                }
                //delete client option
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
                //Quit option, takes user back to project and client menu
                else if (clientChoice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                //if invalid choice is made
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
                //Basic CRUD for Project class
                Console.WriteLine("C. Create a new Project.");
                Console.WriteLine("R. List current Project.");
                Console.WriteLine("U. Update current Project list.");
                Console.WriteLine("D. Delete current Project list.");
                //Quit option takes user back to project/client menu
                Console.WriteLine("Q. Quit");

                var projChoice = Console.ReadLine() ?? string.Empty;
                //Allows users to create a new project 
                if (projChoice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    //ID automatically set to 0 if no input
                    Console.WriteLine("ID: ");
                    var ID = int.Parse(Console.ReadLine() ?? "0");
                    //User can input short name
                    Console.WriteLine("Short Name: ");
                    var shortName = Console.ReadLine();
                    //User can input long name
                    Console.WriteLine("Long Name: ");
                    var longName = Console.ReadLine();

                    //Allow users to input when account first opened
                    Console.WriteLine("When did this account first open? yyyy-mm-dd");
                    string openDateInput = Console.ReadLine();
                    DateTime openDate = DateTime.Parse(openDateInput);

                    //If account is not active, ask for close date, if it is, set to minimum possible date
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

                    //Link Project to Client, client must be entered prior to linkage
                    Console.WriteLine("If this Project has an associated client please enter their ID: ");
                    var clientID = int.Parse(Console.ReadLine() ?? "0");
                    var associatedClient = clientList.FirstOrDefault(c => c.ID == clientID);

                    //Add to new project class
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
                //List all current projects
                else if (projChoice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    projectList.ForEach(Console.WriteLine);

                }
                //Allow users to update project list
                else if (projChoice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Search for project by ID
                    Console.WriteLine("Enter project ID to update");
                    projectList.ForEach(Console.WriteLine);
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var projectToUpdate = projectList.FirstOrDefault(s => s.ID == updateChoice);
                    if (projectToUpdate != null)
                    {
                        //Allow user to input short name
                        Console.WriteLine("Enter Updated Short Name");
                        projectToUpdate.ShortName = Console.ReadLine() ?? "No Short Name Provided";

                        //allow user to input long name
                        Console.WriteLine("Enter Updated Long Name");
                        projectToUpdate.LongName = Console.ReadLine() ?? "No Long Name Provided";

                        //update open date, close date only if account is not active anymore
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
                        //Allow project to link to a new client 
                        Console.WriteLine("Updated client ID: ");
                        var updatedClientID = int.Parse(Console.ReadLine() ?? "0");
                        projectToUpdate.ClientID = clientList.FirstOrDefault(c => c.ID == updatedClientID);
                    }
                }
                else if (projChoice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                { 
                    //allow users to delete projects, does not delete clients
                    Console.WriteLine("Enter project ID to delete");
                    projectList.ForEach(Console.WriteLine);
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var clientToDelete = projectList.FirstOrDefault(s => s.ID == deleteChoice);
                    if (clientToDelete != null)
                    {
                        projectList.Remove(clientToDelete);
                    }
                }
                //Quit back to project/client menu
                else if (projChoice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                //If invalid input
                else
                {
                    Console.WriteLine("Cant do that");
                }
            }
            
        }
    }
}
    

