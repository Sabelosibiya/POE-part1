using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear Recipe");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        recipe.AddRecipe();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        recipe.ScaleRecipe();
                        break;
                    case 4:
                        recipe.ResetQuantities();
                        break;
                    case 5:
                        recipe.ClearRecipe();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }

    class Recipe
    {
        private string[] ingredients;
        private decimal[] quantities;
        private string[] units;
        private string[] steps;
        private int numIngredients;
        private int numSteps;

        public Recipe()
        {
            ingredients = new string[100];
            quantities = new decimal[100];
            units = new string[100];
            steps = new string[100];
            numIngredients = 0;
            numSteps = 0;
        }

        public void AddRecipe()
        {
            Console.Write("Enter the number of ingredients: ");
            numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter the name of ingredient #{0}: ", i + 1);
                ingredients[i] = Console.ReadLine();

                Console.Write("Enter the quantity of ingredient #{0}: ", i + 1);
                quantities[i] = decimal.Parse(Console.ReadLine());

                Console.Write("Enter the unit of measurement for ingredient #{0}: ", i + 1);
                units[i] = Console.ReadLine();
            }

            Console.Write("Enter the number of steps: ");
            numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write("Enter step #{0}: ", i + 1);
                steps[i] = Console.ReadLine();
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("{0}. {1} {2}", i + 1, quantities[i], units[i]);
            }

            Console.WriteLine("Steps:");

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, steps[i]);
            }
        }

        public void ScaleRecipe()
        {
            Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
            decimal factor = decimal.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                quantities[i] *= factor;
            }
        }

        public void ResetQuantities()
        {
            // Simply clear the quantity values already entered
            Array.Clear(quantities, 0, quantities.Length);
        }

        public void ClearRecipe()
        {
            // Clear all recipe data
            Array.Clear(ingredients, 0, ingredients.Length);
            Array.Clear(quantities, 0, quantities.Length);
            Array.Clear(units, 0, units.Length);
            Array.Clear(steps, 0, steps.Length);
            numIngredients = 0;
            numSteps = 0;
        }
    }
}