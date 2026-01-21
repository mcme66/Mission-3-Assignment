
using Mission_3_Assignment;

List<FoodItem> inventory = new List<FoodItem>();
bool running = true;

while (running)
{
    // Always prints the main menu options
    Console.WriteLine("\nFood Bank Inventory System");
    Console.WriteLine("1. Add Food Item");
    Console.WriteLine("2. Delete Food Item");
    Console.WriteLine("3. Print Current Food Items");
    Console.WriteLine("4. Exit");
    Console.Write("Select an option (1-4): ");

    string choice = Console.ReadLine();

    // Main choices with small error handling
    switch (choice)
    {
        case "1":
            AddFoodItem(inventory); // Custom function to add a food item
            break;

        case "2":
            DeleteFoodItem(inventory); // Custom function to delete a food item
            break;

        case "3":
            PrintInventory(inventory); // Custom function to print the inventory
            break;

        case "4":
            running = false;
            Console.WriteLine("Exiting program. Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid choice. Please select a number between 1 and 4.");
            break;
    }
}

static void AddFoodItem(List<FoodItem> inventory)
{
    Console.Write("Enter food name: ");
    string name = Console.ReadLine();

    Console.Write("Enter category: ");
    string category = Console.ReadLine();

    int quantity;
    while (true) // Loop until a valid quantity is entered
    {
        Console.Write("Enter quantity: ");
        if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
        {
            break;
        }
        Console.WriteLine("Quantity must be a positive number.");
    }

    DateTime expirationDate;
    while (true) // Loop until a valid date is entered
    {
        Console.Write("Enter expiration date (MM/DD/YYYY): ");
        if (DateTime.TryParse(Console.ReadLine(), out expirationDate))
        {
            break;
        }
        Console.WriteLine("Invalid date format. Try again.");
    }

    FoodItem item = new FoodItem(name, category, quantity, expirationDate);
    inventory.Add(item);

    Console.WriteLine("Food item added successfully.");
}

static void DeleteFoodItem(List<FoodItem> inventory)
{
    if (inventory.Count == 0) // This is to stop the program from crashing if there are no items to delete
    {
        Console.WriteLine("Inventory is empty. Nothing to delete.");
        return;
    }

    PrintInventory(inventory);

    int index;
    while (true) // Loop until a valid index is entered
    {
        Console.Write("Enter the number of the item to delete: ");
        if (int.TryParse(Console.ReadLine(), out index) &&
            index >= 1 && index <= inventory.Count)
        {
            break;
        }
        Console.WriteLine("Invalid selection. Try again.");
    }

    inventory.RemoveAt(index - 1);
    Console.WriteLine("Food item deleted successfully.");
}

static void PrintInventory(List<FoodItem> inventory)
{
    if (inventory.Count == 0) // This is to stop the program from crashing if there are no items to delete
    {
        Console.WriteLine("Inventory is empty.");
        return;
    }

    Console.WriteLine("\nCurrent Food Inventory:");
    for (int i = 0; i < inventory.Count; i++)
    {
        FoodItem item = inventory[i];
        Console.WriteLine(
            $"{i + 1}. {item.Name} | Category: {item.Category} | Quantity: {item.quantity} | Expiration: {item.ExpirationDate.ToShortDateString()}"
        );
    }
}


