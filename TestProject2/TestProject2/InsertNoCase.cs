using Data;
using Entities.Entities;
using Logic.Ilogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ejemplo de TDD para testear con "InMemoryDatabase" componenetes que trabajan con dependencias externas, de modo que
// comprobamos métodos que interactúan con la base de datos sin afectar a la base de datos real.

namespace TestProject1
{
    [TestClass]
    public class IngredientItemLogicTest
    {
        // Inyectamos las dependencias que vamos a usar
        private DbContextOptions<ServiceContext> _options;
        private ServiceContext _serviceContext;
        private IIngredientItemLogic _ingredientItemLogic;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ServiceContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _serviceContext = new ServiceContext(options);
            _ingredientItemLogic = new IngredientItemLogic(_serviceContext);
        }

        [TestMethod]
        public void Test_InsertIngredient_AvoidsDuplicatesRegardlessOfCase()
        {
            // Insertamos un ingrediente con nombre en minúsculas
            var ingredient1 = new IngredientItem { Ingredient = "tomate" };
            _ingredientItemLogic.InsertIngredient(ingredient1);

            // Intentamos insertar otro ingrediente con el mismo nombre pero en mayúsculas
            var ingredient2 = new IngredientItem { Ingredient = "TOMATE" };
            _ingredientItemLogic.InsertIngredient(ingredient2);

            // Comprobamos que solo haya un ingrediente en la lista, lo que indica que el segundo no se agregó
            var allIngredients = _ingredientItemLogic.GetIngredients();
            Assert.AreEqual(1, allIngredients.Count);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Limpiamos los datos después de cada test
            if (_serviceContext != null)
            {
                _serviceContext.Database.EnsureDeleted();
            }
        }
    }
}



if (!_serviceContext.Ingredients.Any(i => i.Ingredient.Equals(ingredientItem.Ingredient, StringComparison.OrdinalIgnoreCase)))
{
    _serviceContext.Ingredients.Add(ingredientItem);
    _serviceContext.SaveChanges();
    return ingredientItem.Id;
}

return -1;