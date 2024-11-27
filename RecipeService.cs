using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class RecipeService
    {
        public void CreateNewRecipe(RecipeDbContext db,string description, int authorId)
        {
            var desiredAuthor = db.Authors.SingleOrDefault(author => author.Id == authorId);
            var recipe = new Recipe
            {
                Description = description,
                Author = desiredAuthor,
                Ingridients = db.Ingridients.ToList(),
            };
            db.Recipes.Add(recipe);
            db.SaveChanges();
        }
        public void AddRateToRecipe(RecipeDbContext db, int evaluationValue, int recipeId)
        {
            var desiredRecipe = db.Recipes.SingleOrDefault(recipe => recipe.Id == recipeId);
            var evaluation = new Evaluation();
            evaluation.Rate = evaluationValue;
            desiredRecipe.Evaluations.Add(evaluation);
            db.SaveChanges();
        }
        public void ReportTop3RecipeAndAuthor(RecipeDbContext db)
        {
            // Author logic
            List<double> helperListForTop3Authors = db.Authors
                .SelectMany(author => author.Recipes,
                    (author, recipe) => recipe.Evaluations.Average(r => r.Rate))
                .ToList();

            List<double> helperListForTop3AuthorsSorted = helperListForTop3Authors
                .OrderBy(rate => rate)
                .ToList();

            int firstAuthorIndex = helperListForTop3Authors.IndexOf(helperListForTop3AuthorsSorted[0]);
            int secondAuthorIndex = helperListForTop3Authors.IndexOf(helperListForTop3AuthorsSorted[1]);
            int thirdAuthorIndex = helperListForTop3Authors.IndexOf(helperListForTop3AuthorsSorted[2]);

            List<Author> top3Authors = db.Authors.ToList();
            top3Authors = new List<Author>
            {
                top3Authors[firstAuthorIndex],
                top3Authors[secondAuthorIndex],
                top3Authors[thirdAuthorIndex]
            };

            // Recipe logic
            List<double> helperListForTop3Recipes = db.Recipes
                .Select(recipe => recipe.Evaluations.Average(r => r.Rate))
                .ToList();

            List<double> helperListForTop3RecipesSorted = helperListForTop3Recipes
                .OrderBy(rate => rate)
                .ToList();

            int firstRecipeIndex = helperListForTop3Recipes.IndexOf(helperListForTop3RecipesSorted[0]);
            int secondRecipeIndex = helperListForTop3Recipes.IndexOf(helperListForTop3RecipesSorted[1]);
            int thirdRecipeIndex = helperListForTop3Recipes.IndexOf(helperListForTop3RecipesSorted[2]);

            List<Recipe> top3Recipes = db.Recipes.ToList();
            top3Recipes = new List<Recipe>
            {
                top3Recipes[firstRecipeIndex],
                top3Recipes[secondRecipeIndex],
                top3Recipes[thirdRecipeIndex]
            };
        
        }
    }
}
