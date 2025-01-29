// userList is a list that holds the values entered into the program for the list
List<string> userList = new List<string>();
// userCommand is used to record the user's commands; it's also checked to keep the program running (looping) right until the user indicates a desire to exit the program
string userCommand = "";
// userInput is used to record the user's inputs
string userInput = "";
// returnValue is used to check to ensure that functions aren't ending prematurely
string returnValue = "";
// Keep things looking tidy
Console.Clear();

// Main loop; keeps the code running until the user indicates a desire to exit the code
while (userCommand != "exit")
{
    // Prompt user for and get input
    Console.Write("Please enter command (\"help\" to view commands)\n>> ");
    userCommand = Console.ReadLine();

    // Keep things looking tidy
    Console.Clear();

    // Ensure the user input something
    if (userCommand == "")
    {
        Console.WriteLine("A command must be entered.");
        returnValue = "success";
    }
    //Procede with program if userCommand is not empty
    else
    {
        // Run function corresponding with input; functions should return confirmation of successful execution as strings and the return can be checked to be sure
        switch (userCommand.Trim().ToLower())
        {
            // Calls function to display command list; saves return value to be checked
            case "help":
                returnValue = help();
                break;
            // Calls function to view list; saves return value to be checked
            case "view":
                returnValue = view();
                break;
            // Calls function to add item to a specified spot in the list; saves return value to be checked
            case "add":
                returnValue = add();
                break;
            // Calls function to remove an item from any position in the list; saves return value to be checked
            case "remove":
                returnValue = remove();
                break;
            // Calls function to clear the entire list; saves return value to be checked
            case "clear":
                returnValue = clear();
                break;
            // Ends main loop
            case "exit":
                Console.WriteLine("Thank you for using the list program.");
                // Simulate successful function execution so execution check doesn't think something's wrong
                returnValue = "success";
                break;
            // Lets the user know their command in invalid
            default:
                // Simulate successful function execution so execution check doesn't think something's wrong
                returnValue = "success";
                Console.WriteLine("Invalid command.");
                break;
        }
    }
    // Execution check
    if (returnValue != "success")
    {
        Console.WriteLine("An error may just have occured.");
    }
    // Reset check
    returnValue = "";
}

// Called in response to the user "help" command; 
string help()
{
    // Output list of valid commands and their purposes
    Console.WriteLine("   help: displays these commands\n   view: view list\n   add: add item to a specified spot in the list\n   remove: remove item from specified position in list\n   clear: clears list\n   exit: exits program (does not save list)");
    return "success";
}

// Called in response to the user "view" command; 
string view()
{
    // In case of empty list
    if (userList.Count == 0)
    {
        Console.WriteLine("   The list is empty.");
        return "success";
    }
    // Outputs list one item at a time
    for (int itemCount = 0; itemCount < userList.Count(); itemCount++)
    {
        // Prints the list item number (one greater than the index) followed by the corresponding list item
        Console.WriteLine($"   {itemCount + 1}. {userList[itemCount]}");
    }
    return "success";
}

// Called in response to the user "add" command; 
string add()
{
    // Generate list of text equivalents of valid inputs; used to ensure valid and non-error inducing input
    List<string> validInputs = new List<string>();
    for (int number = 1; number <= userList.Count() + 1; number++)
    {
        validInputs.Add(number.ToString());
    }

    // Get list position for insert
    Console.Write("Which item would you like this to be? (Enter a whole number)\n>> ");
    userInput = Console.ReadLine();
    // Ensure the user input something
    if (userInput == "")
    {
        Console.WriteLine("An item number must be entered.");
        return "success";
    }
    // Check if input is not in the validInputs list; deal with invalid input
    if (!validInputs.Contains(userInput.Trim()))
    {
        Console.WriteLine("Invalid input. Must be the number of an item already in the list or the next possible number.");
        return "success";
    }
    // Save and convert item number to index
    int insertIndex = int.Parse(userInput) - 1;

    // Get text to insert
    Console.Write($"Enter text to add to the list at position {insertIndex + 1}\n>> ");
    userInput = Console.ReadLine();
    // Ensure the user input something
    if (userInput == "")
    {
        Console.WriteLine("Entries to the list must contain text.");
        return "success";
    }

    // Insert text
    userList.Insert(insertIndex, userInput);
    Console.WriteLine("The item was added to the list.");
    return "success";
}

// Called in response to the user "remove" command; 
string remove()
{
    // Generate list of text equivalents of valid inputs; used to ensure valid and non-error inducing input
    List<string> validInputs = new List<string>();
    for (int number = 1; number <= userList.Count(); number++)
    {
        validInputs.Add(number.ToString());
    }

    // Get list position for insert
    Console.Write("Which item would you like to remove? (Enter a whole number)\n>> ");
    userInput = Console.ReadLine();
    // Ensure the user input something
    if (userInput == "")
    {
        Console.WriteLine("An item number must be entered.");
        return "success";
    }
    // Check if input is not in the validInputs list; deal with invalid input
    if (!validInputs.Contains(userInput.Trim()))
    {
        Console.WriteLine("Invalid input. Must be the number of an item already in the list.");
        return "success";
    }
    // Save and convert item number to index
    int removeIndex = int.Parse(userInput) - 1;

    // Remove item
    userList.RemoveAt(removeIndex);
    Console.WriteLine($"Item {removeIndex + 1} has been removed.");
    return "success";
}

// Called in response to the user "clear" command; 
string clear()
{
    // Check if there's nothing to clear
    if (userList.Count() == 0)
    {
        // Inform the user that there's nothing to clear
        Console.WriteLine("The list is already empty.");
        return "success";
    }

    // Get user confirmation
    Console.Write("Are you sure you want to reset to an empty list? (Enter \"y\" or \"yes\" to clear the list)\n>> ");
    userInput = Console.ReadLine().Trim().ToLower();
    // Check user confirmation
    if (userInput == "yes" || userInput == "y")
    {
        // Reset list
        userList.Clear();
        Console.WriteLine("The list has been cleared.");
        return "success";
    }
    else
    {
        Console.WriteLine("Confirmation not detected; the list was not cleared.");
        return "success";
    }
}

