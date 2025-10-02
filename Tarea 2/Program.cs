namespace ITLA

//Jesus Matos Matricula:20241767
{
    class Program
    {
        static void Main()
        {
            bool WhileEstructure = true;

            while (WhileEstructure)
            {


                try
                {
                    DateTime dateTime = DateTime.Now;
                    Console.WriteLine(dateTime);

                    int Number1;
                    int value;

                    Console.WriteLine("write the number");
                    Number1 = int.Parse(Console.ReadLine());

                    value = Number1 % 2;

                    if (value == 0)
                    {

                        Console.WriteLine(" your number is even");
                    }
                    else
                    {
                        Console.WriteLine("your number is odd");

                    }

                    Console.WriteLine("Do you want to run the code again? (s/n)");
                    string response = Console.ReadLine().ToLower();
                    if (response != "s")
                    {
                        WhileEstructure = false;
                    }
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }

                Console.ReadKey();
            }
        }
    }
}