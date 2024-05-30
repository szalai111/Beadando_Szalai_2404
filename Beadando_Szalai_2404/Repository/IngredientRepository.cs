using Beadando_Szalai_2404.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Szalai_2404.Repository
{
    class IngredientRepository
    {
        private RestaurantContext RestaurantContext;

        //Methods

        public IngredientRepository(RestaurantContext Context)
        {
            this.RestaurantContext = Context;
        }

        public List<Ingredient> GetIngredient()
        {
            return RestaurantContext.Ingredients.ToList();
        }

        public Ingredient GetIngredientsById(int id)
        {
            return RestaurantContext.Ingredients.Find(id);
        }

        public void InsertIngredient(Ingredient ingredient)
        {
            RestaurantContext.Ingredients.Add(ingredient);
        }

        public void DeleteIngredients(int IngredientId)
        {
            Ingredient ingredient = RestaurantContext.Ingredients.Find(IngredientId);
            RestaurantContext.Ingredients.Remove(ingredient);
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            RestaurantContext.Ingredients.Find(ingredient.Id).Id = ingredient.Id;
            RestaurantContext.Ingredients.Find(ingredient.Id).IngredientName = ingredient.IngredientName;
            RestaurantContext.Ingredients.Find(ingredient.Id).Amount = ingredient.Amount;
        }

        public void Save()
        {
            RestaurantContext.SaveChanges();
        }

        public void Dispose()
        {
            RestaurantContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
