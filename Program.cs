namespace Recipe_App1 
{
    class Program
{
    static void Main(string[] args)
    {
        //A new Recipe object is created 
        Recipe recipe = new Recipe();
        bool continueEntering = true;

        while (continueEntering)
        {
            Console.WriteLine("***********************************  Welcome to My Recipe App *************************************** ");
            //get recipe details from the user 
            recipe.RecipeDetails();

            Console.WriteLine("\n All the ingredient :");
            //Display all ingredients and steps
            recipe.Display();

            Console.WriteLine("\nEnter 'Measurement' to adjust the recipe's scale, 'restart' to reset quantities, 'delete' to clear all data, or ' out:' to exit the page  ");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "Measurement":
                    Console.WriteLine("Enter the Measurement factor (0.5 , 2 , 3 ):");
                    double factor = double.Parse(Console.ReadLine());
                    recipe.Measurement(factor);
                    Console.WriteLine("\n Measurement Recipe:");
                    //Display the adjusted recipe
                    recipe.Display();

                    break;
                case "restart":
                    //Reset all the ingredients quantities to their original values
                    recipe.ResetValues();
                    Console.WriteLine("\nQuantities reset to original values.");
                    break;
                case "delete":
                    recipe.Clear();
                    Console.WriteLine("\nAll data cleared.");
                    break;
                case "out ":

                    continueEntering = false;

                    break;
                default:
                    Console.WriteLine(" You have entered a wrong item .");
                    break;
            }
        }
    }
}

class Recipe
{
    private string[] Ingredients;
    private string[] steps;
//Get recipe deatils from the user
    public void RecipeDetails()
    {
        Console.WriteLine("How many  ingredients do  you want to enter ? :");
        int numIngredients = int.Parse(Console.ReadLine());
        Ingredients = new string[numIngredients];

        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"Enter the name, quantity, and unit of measurement for  the ingredient {i + 1}:");
            Ingredients[i] = Console.ReadLine();
        }

        Console.WriteLine(" Enter the number of steps:");
        int numSteps = int.Parse(Console.ReadLine());
        steps = new string[numSteps];

        for (int i = 0; i < numSteps; i++)
        {
            Console.WriteLine($"Enter step {i + 1}:");
            steps[i] = Console.ReadLine();
        }
    }
    //Display all the ingredients and steps in the recipe
    public void Display()
    {
        Console.WriteLine("\nIngredients:");
        foreach (string ingredient in Ingredients)
        {
            Console.WriteLine("- " + ingredient);
        }

        Console.WriteLine("\nStep:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }
    }
    //Adjust ingredients  quantities based on a given factor 
    public void Measurement(double factor)
    {
        for (int i = 0; i < Ingredients.Length; i++)
        {
            string[] parts = Ingredients[i].Split(' ');
            double quantity = double.Parse(parts[0]);
            quantity *= factor;
            Ingredients[i] = $"{quantity} {parts[1]} {parts[2]}";
        }
    }

    public void ResetValues()
    {
        // Return the  amounts to their starting points.
        //Assuming that after entering the recipe specifics, the previous values remain unchanged
    }
    //clear the Recipe data 
    public void Clear()
    {

        Ingredients = null;
        steps = null;
    }
}
}


