using System;
namespace _3_cases
{
    public class Fodbold
    {
        public static void Start(bool debug)
        {
            do
            {
                if (!debug)
                {
                    Console.Clear();
                    Console.WriteLine("Welkommen til Fodbold programmet!\n");
                    Console.Write("Tryk 1 for at fortsætte\nTryk 2 for at gå tilbage\n: ");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Welkommen til Fodbold programmet!\n");
                    System.Diagnostics.Debug.Write("Tryk 1 for at fortsætte\nTryk 2 for at gå tilbage\n: ");
                }
                int menu = Convert.ToInt32(Console.ReadLine());
                if (menu == 2) break;

                if (!debug)
                {
                    Console.Clear();
                }
                int afleveringer; //opret int variable
                string mål, hf = "High five", ju = "Jubel!!!", hu = "Huh!", sh = "Shh", ol = "Olé olé olé"; //opret 6 string variabler
                do
                {
                    try //prøv at konvertere input til 32 bit integer
                    {
                        if (!debug)
                        {
                            Console.Write("\nAntal aflerveringer: ");
                        }
                        else
                        {
                            System.Diagnostics.Debug.Write("\nAntal aflerveringer: ");
                        }
                        afleveringer = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (FormatException) //catch hvis input ikke er tal
                    {
                        if (!debug)
                        {
                            Console.WriteLine("input må kun være et tal");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("input må kun være et tal");
                        }
                        continue;
                    }
                    catch (Exception ex) //catch generel fejl
                    {
                        if (!debug)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                        continue;
                    }
                } while (true);
                if (!debug)
                {
                    Console.Write("Skriv 'mål' hvis der er mål: ");
                }
                else
                {
                    System.Diagnostics.Debug.Write("Skriv 'mål' hvis der er mål: ");
                }
                mål = Console.ReadLine().ToLower();

                if (mål == "mål")
                {
                    if (!debug)
                    {
                        Console.WriteLine("\n{0}", ol); //skriv Olé olé olé hvis brugeren har skrevet mål
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("\n{0}", ol); //skriv Olé olé olé hvis brugeren har skrevet mål
                    }
                    Console.ReadKey();
                    continue;
                }
                else if (afleveringer == 0)
                {
                    if (!debug)
                    {
                        Console.WriteLine("\n{0}", sh); //skriv Shh hvis brugeren har angivet 0 afleveringer
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("\n{0}", sh); //skriv Shh hvis brugeren har angivet 0 afleveringer
                    }
                    Console.ReadKey();
                    continue;
                }
                else if (afleveringer <= 10)
                {
                    if (!debug)
                    {
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("\n");
                    }
                    for (int i = 0; i < afleveringer; i++) //loop de antal gange brugeren har skrevet i afleveringer
                    {
                        if (!debug)
                        {
                            Console.Write("{0} ", hu); //skriv Huh!
                        }
                        else
                        {
                            System.Diagnostics.Debug.Write("{0} ", hu); //skriv Huh!
                        }
                    }
                    if (!debug)
                    {
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("\n");
                    }
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    if (!debug)
                    {
                        Console.WriteLine($"\n{hf} - {ju}"); //skriv High five og Jubel!!! hvis brugeren har angivet over 10 afleveringer
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"\n{hf} - {ju}"); //skriv High five og Jubel!!! hvis brugeren har angivet over 10 afleveringer
                    }
                    Console.ReadKey();
                    continue;
                }
            } while (true);

        }
    }
}
