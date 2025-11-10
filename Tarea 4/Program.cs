using System;
using System.Collections.Generic;

class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public bool IsBestFriend { get; set; }

    public void Display()
    {
        string best = IsBestFriend ? "Yes" : "No";
        Console.WriteLine($"{Id,-5} {FirstName,-12} {LastName,-12} {Address,-15} {Phone,-12} {Email,-18} {Age,-4} {best}");
    }
}

class ContactManager
{
    private Dictionary<int, Contact> contacts = new Dictionary<int, Contact>();

    public void AddContact()
    {
        try
        {
            Console.WriteLine("Enter a unique contact ID (numbers only):");
            int id = Convert.ToInt32(Console.ReadLine());

            if (contacts.ContainsKey(id))
            {
                Console.WriteLine("That ID already exists. Try again.");
                return;
            }

            Contact newContact = new Contact();

            newContact.Id = id;
            Console.WriteLine("Enter the first name:");
            newContact.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the last name:");
            newContact.LastName = Console.ReadLine();

            Console.WriteLine("Enter the address:");
            newContact.Address = Console.ReadLine();

            Console.WriteLine("Enter the phone number:");
            newContact.Phone = Console.ReadLine();

            Console.WriteLine("Enter the email:");
            newContact.Email = Console.ReadLine();

            Console.WriteLine("Enter the age (numbers only):");
            newContact.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Is this person your best friend? (1 = Yes, 2 = No)");
            newContact.IsBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

            contacts.Add(id, newContact);
            Console.WriteLine("Contact added successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter valid data.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    public void ViewContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts to show.");
            return;
        }

        Console.WriteLine("ID   First Name   Last Name   Address         Phone        Email             Age  Best Friend");
        Console.WriteLine("---------------------------------------------------------------------------------------------");

        foreach (var contact in contacts.Values)
            contact.Display();
    }

    public void SearchContact()
    {
        Console.WriteLine("Enter a name to search:");
        string name = Console.ReadLine().ToLower();
        bool found = false;

        foreach (var contact in contacts.Values)
        {
            if (contact.FirstName.ToLower().Contains(name))
            {
                string best = contact.IsBestFriend ? "Yes" : "No";
                Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}, {contact.Age} years, {contact.Phone}, Best Friend: {best}");
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No contact found with that name.");
    }

    public void ModifyContact()
    {
        try
        {
            Console.WriteLine("Enter the contact ID to modify:");
            int id = Convert.ToInt32(Console.ReadLine());

            if (!contacts.ContainsKey(id))
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Contact c = contacts[id];

            Console.WriteLine("Enter new first name (leave empty to keep current):");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) c.FirstName = input;

            Console.WriteLine("Enter new last name (leave empty to keep current):");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) c.LastName = input;

            Console.WriteLine("Enter new address (leave empty to keep current):");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) c.Address = input;

            Console.WriteLine("Enter new phone (leave empty to keep current):");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) c.Phone = input;

            Console.WriteLine("Enter new email (leave empty to keep current):");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) c.Email = input;

            Console.WriteLine("Enter new age (leave empty to keep current):");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) c.Age = Convert.ToInt32(input);

            Console.WriteLine("Is best friend? (1 = Yes, 2 = No, 0 = no change):");
            input = Console.ReadLine();
            if (input == "1") c.IsBestFriend = true;
            else if (input == "2") c.IsBestFriend = false;

            Console.WriteLine("Contact updated successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter valid data.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    public void DeleteContact()
    {
        try
        {
            Console.WriteLine("Enter the contact ID to delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            if (!contacts.ContainsKey(id))
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            contacts.Remove(id);
            Console.WriteLine("Contact deleted successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Contact Manager!");
        ContactManager manager = new ContactManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Add  2. View  3. Search  4. Modify  5. Delete  6. Exit");
            Console.WriteLine("Choose an option:");

            try
            {
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        manager.AddContact();
                        break;
                    case 2:
                        manager.ViewContacts();
                        break;
                    case 3:
                        manager.SearchContact();
                        break;
                    case 4:
                        manager.ModifyContact();
                        break;
                    case 5:
                        manager.DeleteContact();
                        break;
                    case 6:
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
