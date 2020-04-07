using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game configuration
    string[] level1Passwords = { "Imagination", "Histoire", "Livre", "Table", "Classeur" };
    string[] level2Passwords = { "Abandon", "Acceptation", "Corporels", "Défense", "Patrimoine" };
    string[] level3Passwords = { "Année-lumière", "Aberration", "Bissextile", "Chromosphère", "Crépuscule" };

    // Game state
    int level;
    string password;

    enum Screen { MainMenu, Password, Win };

    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello Console");
        ShowMainMenu();

    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Bonjour et bienvenue dans notre Terminal Hacker ;-) ");
        Terminal.WriteLine("Que voulez vous hacker ?");
        Terminal.WriteLine("Appuiez 1 pour la lla bibliothèque municipale");
        Terminal.WriteLine("Appuiez 2 pour le palais de justice");
        Terminal.WriteLine("Appuiez 3 pour la NASA");
        Terminal.WriteLine("votre choix est  : ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        }
        else if (input == "quitter")
        {
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckingPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1" || input == "2" || input == "3")
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Hello Mr Bond ");
        }
        else
        {
            Terminal.WriteLine("invalid input");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Entrez votre mot de passe");
        Terminal.WriteLine("indice : " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("invalid");
                break;
        }
    }

    void CheckingPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {

        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
    __________            
   /         //
  /         //
 / _______ //
(_________(/
                ");
                Terminal.WriteLine("vous avez hacké la bibliothèque !!!");
                break;
            case 2:
                Terminal.WriteLine(@"
    __________            
   /         //
  /         //
 / _______ //
(_________(/
                ");
                Terminal.WriteLine("vous avez hacké la police  !!!");
                break;
            case 3:
                Terminal.WriteLine(@"
    __________            
   /         //
  /         //
 / _______ //
(_________(/
                ");
                Terminal.WriteLine("vous avez hacké NASA !!!");
                break;
        }
        Terminal.WriteLine("Félicitation !!!");
        Terminal.WriteLine("écrivez (menu) afin de retourner ");
        Terminal.WriteLine("au menu principal");
    }
}
