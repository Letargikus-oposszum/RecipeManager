//Mai feladat: recept nyilvántartó programot készítsünk. Minden receptnek van leírása, és van egy szerzője. 
//Egy szerzőnek viszont több receptje is lehet. Minden receptnek lehet több értékelése. Minden receptnek 
//több hozzávalója is van (Név, Mennyiség). Hozzávalókat és szerzőket Seed-eljük bele az adatbázisba. 
//Menü kell, hogy ezekből tudjunk új recepteket létrehozni. A meglévő receptekhez tudjunk értékeléseket adni. 
//Riportolni tudjuk a TOP 3 értékelt receptet és a TOP 3 értékelt szerzőt.
using RecipeManager;
RecipeService recipeService = new RecipeService();
RecipeDbContext db = new RecipeDbContext();

while (true)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("0 - Exit");
    Console.WriteLine("1 - Create New Recipe");
    Console.WriteLine("2 - Add Rate to Recipe");
    Console.WriteLine("3 - Add Rate to Author");
    Console.WriteLine("4 - Report Top 3 Recipes and Authors");

    int choice = Convert.ToInt32(Console.ReadLine());

    RecipeEnum selectedOption = (RecipeEnum)choice;

    switch (selectedOption)
    {
        case RecipeEnum.Exit:
            Environment.Exit(0);
            break;

        case RecipeEnum.CreateNewRecipe:
            Console.WriteLine("Please add a description for the recipe: ");
            string description = Console.ReadLine();
            Console.WriteLine("Give me the id of the desired author: ");
            int authorId = Convert.ToInt32(Console.ReadLine());
            recipeService.CreateNewRecipe(db,description,authorId);
            break;

        case RecipeEnum.AddRateToRecipe:
            Console.WriteLine("Please add an evaluationValue for the recipe: ");
            int evaluationValue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Give me the id of the desired recipe: ");
            int recipeId = Convert.ToInt32(Console.ReadLine());
            recipeService.AddRateToRecipe(db,evaluationValue,recipeId);
            break;
        case RecipeEnum.ReportTop3RecipeAndAuthor:
            recipeService.ReportTop3RecipeAndAuthor(db);
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}