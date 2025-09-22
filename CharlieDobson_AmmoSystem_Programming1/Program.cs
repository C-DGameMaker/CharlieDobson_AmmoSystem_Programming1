using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_AmmoSystem_Programming1
{
    internal class Program
    {
        static string[] weapons = { "Bow", "Crossbow", "Pistol", "Shotgun", "Rocket Launcher"};
        static int[] curAmmo = { 12, 6, 50, 50, 10 };
        static int[] maxLoadAmmo = {1, 1, 10, 2, 1};
        static int[] curLoadAmmo = {1, 1, 10, 2, 1 };

        static bool reload = false;


        static string charName = "";
        static int indexOfWeapon = 0;
        static int max = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Insert your name here: ");

            charName = Console.ReadLine();
            Console.Clear();
            ShowHUD();
            Console.ReadKey();
            Console.Clear();

            Shoot("Bow");
            Console.ReadKey();
            Console.Clear();
            
            Shoot("Pistol");
            

            curAmmo[2] = 1;
            curLoadAmmo[2] = 1;
            ShowHUD();
            Console.ReadKey();
            Console.Clear();

            Shoot("Pistol");
        }

        
        static void ShowHUD()
        {
            Console.WriteLine($"Character Name: {charName}");
            AddSpace();
            Console.WriteLine($"CURRENT WEAPONS:");
            Console.WriteLine($"{weapons[0]}: {curAmmo[0]}");
            Console.WriteLine($"{weapons[1]}: {curAmmo[1]}");
            Console.WriteLine($"{weapons[2]}: {curAmmo[2]}");
            Console.WriteLine($"{weapons[3]}: {curAmmo[3]}");
            Console.WriteLine($"{weapons[4]}: {curAmmo[4]}");
            AddSpace();
            Console.WriteLine($"CURRENT LOADED:");
            CurrentLoaded();
        }

        static void CurrentLoaded()
        {
            Console.WriteLine($"{weapons[0]}: {curLoadAmmo[0]}/{maxLoadAmmo[0]}");
            Console.WriteLine($"{weapons[1]}: {curLoadAmmo[1]}/{maxLoadAmmo[1]}");
            Console.WriteLine($"{weapons[2]}: {curLoadAmmo[2]}/{maxLoadAmmo[2]}");
            Console.WriteLine($"{weapons[3]}: {curLoadAmmo[3]}/{maxLoadAmmo[3]}");
            Console.WriteLine($"{weapons[4]}: {curLoadAmmo[4]}/{maxLoadAmmo[4]}");
        }

        static void Shoot(string weapon)
        {
            indexOfWeapon = Array.IndexOf(weapons, weapon);

            if (indexOfWeapon == 0 || indexOfWeapon == 1 || indexOfWeapon == 4)
            {
                curLoadAmmo[indexOfWeapon] -= 1;
                ShowHUD();
                Console.ReadKey(true);
                Console.Clear();
                if (curLoadAmmo[indexOfWeapon] == 0)
                {
                    Reload();
                }
                return;
            }
            else if (indexOfWeapon == 2)
            {
                curLoadAmmo[indexOfWeapon] -= 1;
                ShowHUD();
                Console.ReadKey(true);
                Console.Clear();
                if (curLoadAmmo[indexOfWeapon] == 0)
                {
                    Reload();
                }
                return;
            }
            else
            {
                curLoadAmmo[indexOfWeapon] -= 1;
                ShowHUD();
                Console.ReadKey(true);
                Console.Clear();
                if (curLoadAmmo[indexOfWeapon] == 0)
                {
                    Reload();
                }
                return;
            }
        }
        //I tried to make a way to reload by yourself. But it was too complicated so I just made it so you can only reload when youre out of ammo
        //There is a check to make sure you can reload as long as you have enough ammo. 
        static void Reload()
        {
            if (indexOfWeapon == 0 || indexOfWeapon == 1 || indexOfWeapon == 4)
            {
                if (ReloadCheck() == true)
                {
                    Console.WriteLine($"You reloaded your {weapons[indexOfWeapon]}");
                    curLoadAmmo[indexOfWeapon] = 1;
                    curAmmo[indexOfWeapon] -= 1;
                    ShowHUD();
                    return;
                }
                Console.WriteLine($"Not Enough Ammo for {weapons[indexOfWeapon]}");
                return;
            }
            else if (indexOfWeapon == 2)
            {
                if (ReloadCheck() == true)
                {
                    Console.WriteLine($"You reloaded your {weapons[indexOfWeapon]}");
                    curLoadAmmo[indexOfWeapon] = 10;
                    curAmmo[indexOfWeapon] -= 10;
                    ShowHUD();
                    return;
                }
                Console.WriteLine($"Not Enough Ammo for {weapons[indexOfWeapon]}");
                return;
            }
            else
            {
                if (ReloadCheck() == true)
                {
                    Console.WriteLine($"You reloaded your {weapons[indexOfWeapon]}");
                    curLoadAmmo[indexOfWeapon] = 2;
                    curAmmo[indexOfWeapon] -= 2;
                    ShowHUD();
                    return;
                }
                Console.WriteLine($"Not Enough Ammo for {weapons[indexOfWeapon]}");
                return;
            }
        }

        static bool ReloadCheck()
        {
            if (curAmmo[indexOfWeapon] < maxLoadAmmo[indexOfWeapon])
            {
                return false;
            }
            return true;
        }
        
        static void AddSpace()
        {
            Console.WriteLine(" ");
        }
    }
}
