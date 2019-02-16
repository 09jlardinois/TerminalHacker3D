using UnityEngine;
using UnityEngine.UI;

public class GameplayCore : MonoBehaviour
{

    private readonly UnityEngine.Random random = new UnityEngine.Random();

    // Game configuration data
    [SerializeField]
    private string currentPassword;
    [SerializeField]
    private string []level1passwords = { "books", "aisle", "shelf", "password", "borrow" };
    [SerializeField]
    private string []level2passwords = { "handcuffs", "radio", "siren", "prison", "badge", "canine" };

    private const string level3Password = "THE RED PILL";

    private Text textShadow;
    private Text textTerminal;

    private enum Screen { MainMenu, Password, Win };
    private Screen currentScreen = Screen.MainMenu;

    [SerializeField]
    private GameObject matrixWinBackground;


    // Game state
    private int currentLevel;

    private void OnUserInput(string input)
    {
        if (input == "menu") ShowMainMenu();
        else if (currentScreen == Screen.MainMenu) ProcessSelectedLevel(input);
        else if (currentScreen == Screen.Password) CheckPassword(input);
        else if (currentScreen == Screen.Win && Input.GetKeyDown(KeyCode.Return)) ShowMainMenu();

    }

    private void CheckPassword(string input)
    {
        string PasswordToCapitals = input.ToUpper();

        if (input == currentPassword || PasswordToCapitals == currentPassword || input == "cheat") DisplayWinScreen();
        else AskForPassword(); //Terminal.WriteLine("Access Denied, Try Again.");
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowWinScreen();
    }

    private void ShowWinScreen()
    {
        switch(currentLevel)
        {
            case 1:
                Terminal.WriteLine("            Late fee cleared!");
                Terminal.WriteLine(@"
                _______
               / -- - /(
              / ---- ///
             /______///
            (_______(/
            ");
                break;
            case 2:
                Terminal.WriteLine("Get out of jail free with this key!");
                Terminal.WriteLine(@"                         
     80o0o0o0o0o08
    8             8
  --HH-         -HH--      /()\
 //===\\       //===\\     \__/
((     ))     ((     ))     ||_
 \\===//       \\===//      ||==
                            \|=
            ");
                break;
            case 3:
                matrixWinBackground.SetActive(true);
                Terminal.WriteLine("YOU HAVE HACKED THE MATRIX\nAND CRACKED THE MASTER CODE");
                Terminal.WriteLine("Master Code: Cheat\nType at any time to instantly win!");
                break;
            default:
                Debug.LogError("Invalid level inputed at ShowWinScreen()");
                break;
            
        }

        Terminal.WriteLine("Press Enter to return to menu.");
    }

    private void ProcessSelectedLevel(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            currentLevel = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textShadow = GameObject.Find("TextShadow").GetComponent<Text>();
        textTerminal = GameObject.Find("Text").GetComponent<Text>();
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        textTerminal.text = textShadow.text;
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();        
        SetRandomPassword();
        if (currentPassword == level3Password)
        {
            Terminal.WriteLine("Enter your password... \n" +
                               "Hint: Get it right or you'll be 'hexed'\n" +
                               "Type menu to go back.\n\n" +
                               "Clue: 0x 54 48 45 20 52 45 44 20 50 49 4c 4c");
        }
        else
            Terminal.WriteLine("Enter your password... Hint: " + currentPassword.Anagram() + "\nOr type menu to go back.");
    }

    private void SetRandomPassword()
    {
        switch (currentLevel)
        {
            case 1:
                currentPassword = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                currentPassword = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                currentPassword = level3Password;
                break;
            default:
                Debug.LogError("Invalid Level Number Entered. Switching to Level 1.");
                currentPassword = "";
                break;
        }      
    }

    private void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hint: type menu at any \ntime to return here.");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 to hack THE M.A.T.R.I.X.");
        Terminal.WriteLine("Enter your selection:");
        matrixWinBackground.SetActive(false);
    }

}
