using System;
using System.Collections.Generic;

class Contacts
{
    static void Main()
    {
        Console.WriteLine("Welcome to my contact list!");

        bool running = true;
        List<int> ids = new List<int>();
        Dictionary<int, string> names = new Dictionary<int, string>();
        Dictionary<int, string> lastnames = new Dictionary<int, string>();
        Dictionary<int, string> addresses = new Dictionary<int, string>();
        Dictionary<int, string> telephones = new Dictionary<int, string>();
        Dictionary<int, string> emails = new Dictionary<int, string>();
        Dictionary<int, int> ages = new Dictionary<int, int>();
        Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

        while (running)
        {
            Console.WriteLine("1.Add 2.View 3.Search 4.Modify 5.Delete 6.Exit");
            Console.WriteLine("Enter the option number:");

            try
            {
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter a unique contact ID (numbers only):");
                            int id = Convert.ToInt32(Console.ReadLine());

                            if (ids.Contains(id))
                            {
                                Console.WriteLine("That ID already exists. Try again.");
                                break;
                            }

                            Console.WriteLine("Enter the first name:");
                            string name = Console.ReadLine();

                            Console.WriteLine("Enter the last name:");
                            string lastname = Console.ReadLine();

                            Console.WriteLine("Enter the address:");
                            string address = Console.ReadLine();

                            Console.WriteLine("Enter the phone number:");
                            string phone = Console.ReadLine();

                            Console.WriteLine("Enter the email:");
                            string email = Console.ReadLine();

                            Console.WriteLine("Enter the age (numbers only):");
                            int age = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Is this person your best friend? (1 = Yes, 2 = No)");
                            bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

                            ids.Add(id);
                            names.Add(id, name);
                            lastnames.Add(id, lastname);
                            addresses.Add(id, address);
                            telephones.Add(id, phone);
                            emails.Add(id, email);
                            ages.Add(id, age);
                            bestFriends.Add(id, isBestFriend);

                            Console.WriteLine("Contact added successfully!");
                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine("ID   First Name   Last Name   Address   Phone   Email   Age   Best Friend?");
                            Console.WriteLine("_________________________________________________________________________________");

                            foreach (var id in ids)
                            {
                                string best = bestFriends[id] ? "Yes" : "No";
                                Console.WriteLine($"{id}   {names[id]}   {lastnames[id]}   {addresses[id]}   {telephones[id]}   {emails[id]}   {ages[id]}   {best}");
                            }
                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine("Enter the name to search:");
                            string searchName = Console.ReadLine().ToLower();
                            bool found = false;

                            foreach (var id in ids)
                            {
                                if (names[id].ToLower().Contains(searchName))
                                {
                                    string best = bestFriends[id] ? "Yes" : "No";
                                    Console.WriteLine($"{id}: {names[id]} {lastnames[id]}, {ages[id]} years old, {telephones[id]}, Best friend: {best}");
                                    found = true;
                                }
                            }

                            if (!found)
                                Console.WriteLine("No contact found with that name.");
                        }
                        break;

                    case 4:
                        {
                            Console.WriteLine("Enter the ID of the contact to modify:");
                            int id = Convert.ToInt32(Console.ReadLine());

                            if (!ids.Contains(id))
                            {
                                Console.WriteLine("Contact not found.");
                                break;
                            }

                            Console.WriteLine("Enter new first name (leave empty to keep current):");
                            string newName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newName)) names[id] = newName;

                            Console.WriteLine("Enter new last name (leave empty to keep current):");
                            string newLast = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newLast)) lastnames[id] = newLast;

                            Console.WriteLine("Enter new address (leave empty to keep current):");
                            string newAddress = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newAddress)) addresses[id] = newAddress;

                            Console.WriteLine("Enter new phone (leave empty to keep current):");
                            string newPhone = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newPhone)) telephones[id] = newPhone;

                            Console.WriteLine("Enter new email (leave empty to keep current):");
                            string newEmail = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newEmail)) emails[id] = newEmail;

                            Console.WriteLine("Enter new age (leave empty to keep current):");
                            string ageInput = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(ageInput)) ages[id] = Convert.ToInt32(ageInput);

                            Console.WriteLine("Is best friend? (1 = Yes, 2 = No, 0 = no change):");
                            string bestInput = Console.ReadLine();
                            if (bestInput == "1") bestFriends[id] = true;
                            else if (bestInput == "2") bestFriends[id] = false;

                            Console.WriteLine("Contact updated successfully!");
                        }
                        break;

                    case 5:
                        {
                            Console.WriteLine("Enter the ID of the contact to delete:");
                            int id = Convert.ToInt32(Console.ReadLine());

                            if (!ids.Contains(id))
                            {
                                Console.WriteLine("Contact not found.");
                                break;
                            }

                            ids.Remove(id);
                            names.Remove(id);
                            lastnames.Remove(id);
                            addresses.Remove(id);
                            telephones.Remove(id);
                            emails.Remove(id);
                            ages.Remove(id);
                            bestFriends.Remove(id);

                            Console.WriteLine("Contact deleted successfully!");
                        }
                        break;

                    case 6:
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
