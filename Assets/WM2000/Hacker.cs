/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;*/
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    string password;
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    // Game state
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello Hackerman. Who would you like to hack today?\n");
        Terminal.WriteLine("Press 1 to hack the library");
        Terminal.WriteLine("Press 2 to hack the police");
        Terminal.WriteLine("Press 3 to hack NASA");
        Terminal.WriteLine("Enter your choice: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            if (level == 1 || level == 2 || level == 3)
            {
                InputPassword(input);
            }
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Invalid input");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // print(Random.Range(0, level1Passwords.Length));
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
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
                UnityEngine.Debug.LogError("Game initialized with invalid level");
                break;
        }
        Terminal.WriteLine("Enter your password. Hint: " + password.Anagram());
    }

    void InputPassword(string input)
    {   
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Incorrect. Try again.");
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
                Terminal.WriteLine("Password is correct, you win.");
                Terminal.WriteLine(@"
    _____
   /    //
  /    //
 /____//
(____(/
");
                break;
            case 2:
                Terminal.WriteLine("Password is correct, you win.");
                Terminal.WriteLine(@"
  o  o
   _\
  \__/
");
                break;
            case 3:
                Terminal.WriteLine("You finished the hard level, well done.");
                break;
            default:
                UnityEngine.Debug.LogError("Invalid level reached");
                break;

        }

        Terminal.WriteLine("Type \"menu\" to return to the menu");
        
    }
}