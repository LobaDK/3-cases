using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;

namespace _3_cases
{
    internal class Password : Passwordvalidate
    {
        static void Main()
        {
            bool debug = Debugcheck();
            do
            {
                if (!debug)
                {
                    Console.Clear();
                    Console.WriteLine("Velkommen til!");
                    Console.WriteLine("Tryk L for at logge ind.\nTryk O for at oprette en bruger, hvis ingen eksisterer. Debug mode kan tilgås ved at lave en fil kaldet 'debug': ");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Velkommen til!");
                    System.Diagnostics.Debug.WriteLine("Tryk L for at logge ind.\nTryk O for at oprette en bruger, hvis ingen eksisterer: ");
                }
                string mm = Console.ReadLine().ToUpper();
                if (mm == "L")
                {
                    Login(debug);
                }
                else if (mm == "O")
                {
                    Createcheck(debug);
                }
                else
                {
                    if (!debug)
                    {
                        Console.WriteLine("{0} er ikke en mulighed", mm);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("{0} er ikke en mulighed", mm);
                    }
                    Thread.Sleep(2000);
                    continue;
                }
            }while (true);
            
        }
        static void Create(bool debug) //opret Create metode
        {
            string passwordinput; //opret passwordinput string variable
            string brugernavn; //opret brugernavn string variable
            do
            {
                if (!debug)
                {
                    Console.Clear();
                    Console.WriteLine("Ingen bruger fundet, venlist opret en.");
                    Console.Write("\nbrugernavn: "); //spørg om brugerens brugernavn
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Ingen bruger fundet, venlist opret en.");
                    System.Diagnostics.Debug.Write("\nbrugernavn: "); //spørg om brugerens brugernavn
                }
                brugernavn = Console.ReadLine().ToLower(); //gem brugernavn i lowercase så det er nemmere at sammenligne
                if (string.IsNullOrWhiteSpace(brugernavn)) //tjekker om brugernavn er tomt
                {
                    if (!debug)
                    {
                        Console.WriteLine("\nBrugernavn kan ikke være tomt");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("\nBrugernavn kan ikke være tomt");
                    }
                    Thread.Sleep(3000);
                    continue;
                }
                else
                {
                    do
                    {
                        if (!debug)
                        {
                            Console.Write("\nSkriv venligts et nyt kodeord. Det skal mindste være 12 tegn, anvende både store og små, mindst et tal og specialtegn, ikke starte eller slutte med tal, ingen mellemrum og ikke matche brugernavnet: "); //spørg brugeren om et password
                        }
                        else
                        {
                            System.Diagnostics.Debug.Write("\nSkriv venligts et nyt kodeord. Det skal mindste være 12 tegn, anvende både store og små, mindst et tal og specialtegn, ikke starte eller slutte med tal, ingen mellemrum og ikke matche brugernavnet: "); //spørg brugeren om et password
                        }
                        passwordinput = Console.ReadLine();

                        if (!PasswdCheck(passwordinput, brugernavn, debug)) //brug opretet PasswdCheck metode fra Password klasse til at validere password
                        {
                            continue;
                        }
                        else
                        {
                            string[] login = { brugernavn, passwordinput }; //opret string array der heder login, med brugernavn og passwordinput variabler
                            try
                            {
                                File.WriteAllLines(Path.Combine(Directory.GetCurrentDirectory(), "password.txt"), login); //prøver at skrive indeholdet af array til password.txt fil
                                File.AppendAllText(Path.Combine(Directory.GetCurrentDirectory(), "passwdhistory.txt"), passwordinput); //prøver at skrive password til historik fil
                            }
                            catch (Exception e)
                            {
                                if (!debug)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine(e.Message);
                                }
                                Thread.Sleep(3000);
                                if (!debug)
                                {
                                    Console.Clear();
                                }
                                continue;
                            }
                            if (!debug)
                            {
                                Console.WriteLine("\nPassword gemt!");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("\nPassword gemt!");
                            }
                            Thread.Sleep(3000);
                            if (!debug)
                            {
                                Console.Clear();
                            }
                            return;

                        }

                    } while (true);

                }
            } while (true);
        }
        static void Login(bool debug)
        {
            do
            {
                string passwordinput; //opret string variabler brugernavn og passwordlogin
                List<string> skrevetlogin = new List<string>(); //opret string list variable skrevetlogin
                string[] gemtlogin = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "password.txt")); //læs og gem hvert linje i tekstfil fra array
                if (!debug)
                {
                    Console.WriteLine("\nSkriv dit brugernavn og password for at logge ind.");
                    Console.Write("\nBrugernavn: ");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("\nSkriv dit brugernavn og password for at logge ind.");
                    System.Diagnostics.Debug.Write("\nBrugernavn: ");
                }
                string brugernavn = Console.ReadLine().ToLower(); //gem brugernavn i lowercase så det er nemmere at sammenligne
                if (!debug)
                {
                    Console.Write("\nPassword: ");
                }
                else
                {
                    System.Diagnostics.Debug.Write("\nPassword: ");
                }
                string passwordlogin = Console.ReadLine();
                skrevetlogin.Add(brugernavn); //tilføj brugernavn til list
                skrevetlogin.Add(passwordlogin); //tilføj password til list
                if (gemtlogin.SequenceEqual(skrevetlogin.ToArray())) //konverter list til array og sammenlign dem
                {
                    do
                    {
                        string appmenu;
                        if (!debug)
                        {
                            Console.Clear();
                            Console.WriteLine("\nWelkommen ind!");
                            Console.Write("Tryk 1 for at starte Danser programmet\nTryk 2 for at starte Fodbold programmet\nTryk 3 for at ændre dit password\nTryk 4 for at afslutte programmet: ");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("\nWelkommen ind!");
                            System.Diagnostics.Debug.Write("Tryk 1 for at starte Danser programmet\nTryk 2 for at starte Fodbold programmet\nTryk 3 for at ændre dit password\nTryk 4 for at afslutte programmet: ");
                        }
                        appmenu = Console.ReadLine();
                        if (appmenu == "1") //starter Danse programmet
                        {
                            Danse_konkurrence.Start(debug);
                            continue;
                        }
                        else if (appmenu == "2") //starter Fodbold programmet
                        {
                            Fodbold.Start(debug);
                            continue;
                        }
                        else if (appmenu == "3") //starter password ændring
                        {
                            if (!debug)
                            {
                                Console.Write("\nSkriv dit nye password: ");
                            }
                            else
                            {
                                System.Diagnostics.Debug.Write("\nSkriv dit nye password: ");
                            }
                            passwordinput = Console.ReadLine();
                            if (!PasswdCheck(passwordinput, brugernavn, debug)) //brug opretet PasswdCheck metode fra Password klasse til at validere password
                            {
                                continue; //går tilbage hvis password ikke er valid
                            }
                            else if (File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "passwdhistory.txt")).Contains(passwordinput)) //tjek om password er i passwdhistory fil
                            {
                                if (!debug)
                                {
                                    Console.WriteLine("\nPassword må ikke matche tidligere brugte passwords");
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine("\nPassword må ikke matche tidligere brugte passwords");
                                }
                                Thread.Sleep(2000);
                                if (!debug)
                                {
                                    Console.Clear();
                                }
                                continue;
                            }
                            else
                            {
                                string[] login = { brugernavn, passwordinput }; //lav string array der heder login, med brugernavn og passwordinput variabler
                                try
                                {
                                    File.WriteAllLines(Path.Combine(Directory.GetCurrentDirectory(), "password.txt"), login); //prøver at skrive indeholdet af array til password.txt fil
                                    File.AppendAllText(Path.Combine(Directory.GetCurrentDirectory(), "passwdhistory.txt"), Environment.NewLine + passwordinput); //prøver at skrive password til historik fil
                                    if (!debug)
                                    {
                                        Console.WriteLine("\nPassword ændret! Du bliver nu logget ud...");
                                    }
                                    else
                                    {
                                        System.Diagnostics.Debug.WriteLine("\nPassword ændret! Du bliver nu logget ud...");
                                    }
                                    Thread.Sleep(3000);
                                    if (!debug)
                                    {
                                        Console.Clear();
                                    }
                                    break;
                                }
                                catch (Exception e)
                                {
                                    if (!debug)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    else
                                    {
                                        System.Diagnostics.Debug.WriteLine(e.Message);
                                    }
                                    Thread.Sleep(3000);
                                    if (!debug)
                                    {
                                        Console.Clear();
                                    }
                                    continue;
                                }
                            }

                        }
                        else if (appmenu == "4")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            if (!debug)
                            {
                                Console.WriteLine("{0} er ikke en mulighed", appmenu);
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("{0} er ikke en mulighed", appmenu);
                            }
                            Thread.Sleep(2000);
                            continue;
                        }
                    } while (true);
                }
                else
                {

                    if (!debug)
                    {
                        Console.WriteLine("\nBrugernavn eller password forkert");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("\nBrugernavn eller password forkert");
                    }
                    Thread.Sleep(2000);
                    if (!debug)
                    {
                        Console.Clear();
                    }   
                    continue;
                }
            } while (true);
        }
        static bool PasswdCheck(string passwordinput, string brugernavn, bool debug) //opret PasswdCheck metode der retunere false eller true boolean
        {
            char lastchar = passwordinput.Last(); //gem sidste tegn fra password i char variable
            Passwordvalidate passwordvalidate = new Passwordvalidate(); //opret en ny instance af Passwordvalidate som passwordvalidate
            if (passwordvalidate.IsEmpty(passwordinput, debug))
            {
                return false; //hvis password er tomt
            }
            if (passwordvalidate.MatchUsername(brugernavn, passwordinput, debug))
            {
                return false; //hvis password matcher brugernavnet
            }
            else if (passwordvalidate.IsOver12(passwordinput, debug))
            {
                return false; //hvis password er under 12 tegn
            }
            else if (passwordvalidate.IsLowerAndUpper(passwordinput, debug))
            {
                return false; //hvis password mangler store eller små bogstaver
            }
            else if (passwordvalidate.HasSpecialCharAndNumber(passwordinput, debug))
            {
                return false; //hvis password mangler specielle tegn
            }
            else if (passwordvalidate.StartOrEndWithNumber(passwordinput, lastchar, debug))
            {
                return false; //hvis password starter eller slutter med tal
            }
            else if (passwordvalidate.HasSpace(passwordinput, debug))
            {
                return false; //hvis password har mellemrum
            }
            else return true;
        }
        static bool Debugcheck()
        {
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "debug")))
            {
                return true;
            }
            else return false;
        }
        static void Createcheck(bool debug)
        {
            do
            {
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "password.txt")))
                {
                    try //prøv at hente filens størelse
                    {
                        if (new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "password.txt")).Length != 0) //tjekker om password filen er tom
                        {
                            //kald login funktion hvis filen ikke er tom
                            if (!debug)
                            {
                                Console.WriteLine("\nEn bruger eksisterer allerede! Flytter til login...");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("\nEn bruger eksisterer allerede! Flytter til login...");
                            }
                            Login(debug);
                        }
                        else
                        {
                            //kald password create funktion hvis filen er tom
                            Create(debug);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!debug)
                        {
                            Console.WriteLine(ex);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine(ex);
                        }
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                }
                else
                {
                    //kald password create funktion hvis filen ikke eksisterer
                    Create(debug);
                }
            } while (true);
        }
            
    }
    class Passwordvalidate //opret klasse Passwordvalidate
    {
        public bool IsEmpty(string passwordinput, bool debug) //opret bool IsEmpty metode
        {
            if (string.IsNullOrWhiteSpace(passwordinput)) //tjek om password er tomt eller kun whitespaces
            {
                if (!debug)
                {
                    Console.WriteLine("\nPassword kan ikke være tomt");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("\nPassword kan ikke være tomt");
                }
                Thread.Sleep(3000);
                if (!debug)
                {
                    Console.Clear();
                }
                return true;
            }
            else return false;
        }
        public bool MatchUsername(string brugernavn, string passwordinput, bool debug) //opret bool MatchUsername metode
        {
            if (brugernavn.ToLower() == passwordinput.ToLower()) //tjek om password matcher brugernavn
            {
                if (!debug)
                {
                    Console.WriteLine("\nPassword må ikke matche brugernavn");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("\nPassword må ikke matche brugernavn");
                }
                Thread.Sleep(3000);
                if (!debug)
                {
                    Console.Clear();
                }
                return true;
            }
            else return false;
        }
        public bool IsOver12(string passwordinput, bool debug) //opret bool IsOver12 metode
        {
            if (passwordinput.Length < 12) //tjek om password er under 12 tegn
            {
                if (!debug)
                {
                    Console.WriteLine("\nPassword skal minimum være 12 tegn langt");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("\nPassword skal minimum være 12 tegn langt");
                }
                Thread.Sleep(3000);
                if (!debug)
                {
                    Console.Clear();
                }
                return true;
            }
            else return false;
        }
        public bool IsLowerAndUpper(string passwordinput, bool debug) //opret bool IsLowerandUpper metode
        {
            if (!passwordinput.Any(char.IsUpper) | !passwordinput.Any(char.IsLower)) //tjek om password ikke har store og små tegn
            {
                if (!debug)
                {
                    Console.WriteLine("\nPassword skal have både store og små tegn");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("\nPassword skal have både store og små tegn");
                }
                Thread.Sleep(3000);
                if (!debug)
                {
                    Console.Clear();
                }
                return true;
            }
            else return false;
        }
        public bool HasSpecialCharAndNumber(string passwordinput, bool debug) //opret bool HasSpecialCharAndNumber metode
        {
            if (passwordinput.All(char.IsLetterOrDigit) | !passwordinput.Any(char.IsNumber)) //tjek om password kun har normale tegn
            {
                if (!debug)
                {
                    Console.WriteLine("\nPassword skal have mindst et special tegn og tal");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("\nPassword skal have mindst et special tegn og tal");
                }
                Thread.Sleep(3000);
                if (!debug)
                {
                    Console.Clear();
                }

                return true;
            }
            else return false;
        }
        public bool StartOrEndWithNumber(string passwordinput, char lastchar, bool debug) //opret bool StartOrEndWithNumber metode
        {
            if (char.IsDigit(passwordinput[0]) | char.IsDigit(lastchar)) //tjek om password starter eller slutter med et tal
            {
                if (!debug)
                {
                    Console.WriteLine("\nPassword må ikke starte eller slutte med et tal");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("\nPassword må ikke starte eller slutte med et tal");
                }
                Thread.Sleep(3000);
                if (!debug)
                {
                    Console.Clear();
                }
                return true;
            }
            else return false;
        }
        public bool HasSpace(string passwordinput, bool debug) //opret bool HasSpace metode
        {
            if (passwordinput.Any(char.IsWhiteSpace)) //tjek om password has et mellemrum/whitespace
            {
                if (!debug)
                {
                    Console.WriteLine("\nDer må ikke være mellemrum i passwordet");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("\nDer må ikke være mellemrum i passwordet");
                }
                Thread.Sleep(3000);
                if (!debug)
                {
                    Console.Clear();
                }
                return true;
            }
            else return false;
        }
    }
}
