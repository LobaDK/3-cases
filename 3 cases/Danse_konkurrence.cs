using System;
namespace _3_cases
{
    public class Danse_konkurrence
    {
        public static void Start(bool debug)
        {
            do
            {
                string danser1, danser2; //opret 2 string variabler
                int danserpoint1, danserpoint2; //opret 2 int variabler

                if (!debug)
                {
                    Console.Clear();
                    Console.WriteLine("Welkommen til Danser programmet!\n");
                    Console.Write("Tryk 1 for at fortsætte\nTryk 2 for at gå tilbage\n: ");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Welkommen til Danser programmet!\n");
                    System.Diagnostics.Debug.Write("Tryk 1 for at fortsætte\nTryk 2 for at gå tilbage\n: ");
                }
                int menu = Convert.ToInt32(Console.ReadLine());
                if (menu == 2) break;

                if (!debug)
                {
                    Console.Clear();
                    Console.Write("Skriv danser 1's navn: ");
                }
                else
                {
                    System.Diagnostics.Debug.Write("Skriv danser 1's navn: ");
                }
                danser1 = Console.ReadLine();
                if (!debug)
                {
                    Console.Write("\nSkriv danser 2's navn: ");
                }
                else
                {
                    System.Diagnostics.Debug.Write("\nSkriv danser 2's navn: ");
                }
                danser2 = Console.ReadLine();
                do
                {
                    try
                    {
                        if (!debug)
                        {
                            Console.Write("\nSkriv danser 1's points: ");
                        }
                        else
                        {
                            System.Diagnostics.Debug.Write("\nSkriv danser 1's points: ");
                        }
                        danserpoint1 = Convert.ToInt32(Console.ReadLine());
                        if (!debug)
                        {
                            Console.Write("\nSkriv danser 2's points: ");
                        }
                        else
                        {
                            System.Diagnostics.Debug.Write("\nSkriv danser 2's points: ");
                        }
                        danserpoint2 = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (FormatException) //catch hvis brugeren skriver andet end tal
                    {
                        if (!debug)
                        {
                            Console.WriteLine("Points skal være i tal");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Points skal være i tal");
                        }
                        continue;
                    }
                    catch (Exception ex) //catch hvis det er en anden fejl
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
                DancerPoints dancer1 = new DancerPoints(danser1, danserpoint1); //opret instance af DancerPoints, der heder dancer1 og bruger danser1 og danserpoint1
                DancerPoints dancer2 = new DancerPoints(danser2, danserpoint2); //opret instance af DancerPoints, der heder dancer2 og bruger danser2 og danserpoint2
                DancerPoints dansertotal = dancer1 + dancer2;

                if (!debug)
                {
                    Console.WriteLine($"\n{dansertotal.navn}'s totale points er: {dansertotal.points}\n");
                    Console.WriteLine("Tryk enter for at fortsætte");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"\n{dansertotal.navn}'s totale points er: {dansertotal.points}\n");
                    System.Diagnostics.Debug.WriteLine("Tryk enter for at fortsætte");
                }
                Console.ReadKey();
            } while (true);
        }
    }
}
