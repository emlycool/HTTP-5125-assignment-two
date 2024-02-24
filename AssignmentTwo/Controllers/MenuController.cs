using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AssignmentTwo.Models;

namespace AssignmentTwo.Controllers
{
    /**
     * <summary>
     * Controller for handling menu-related operations.
     * </summary>
     */
    public class MenuController : ApiController
    {
        /**
         * <summary>
         *  Calculate the total calories based on the selected items from the menu
         * </summary>
         * <param name="burger">The choice of the burger</param>
         * <param name="drink">The choice of drink</param>
         * <param name="side">The choice of side</param>
         * <param name="dessert">The choice of dessert</param>
         * <returns>The total calories of the selected itiems</returns>
         * <example>
         *  Get:localhost:xx/api/J1/Menu/4/4/4/4 => Your total calorie count is 0
         * </example>
         * <example>
         *  Get:localhost:xx/api/J1/Menu/1/2/3/4 => Your total calorie count is 691
         * </example>
         * /
        /*http://localhost/api/J1/Menu/{burger}/{drink}/{side}/{dessert} */
        [HttpGet]
        [Route("api/j1/menu/{burger}/{drink}/{side}/{dessert}")]
        public string CalculteCalories(int burger, int drink, int side, int dessert)
        {
            MenuItem burgerChoice = this.getMenuItemChoice(this.getBurgers(), burger);
            MenuItem drinkChoice = this.getMenuItemChoice(this.getDrinks(), drink);
            MenuItem sideChoice = this.getMenuItemChoice(this.getSides(), side);
            MenuItem dessertChoice = this.getMenuItemChoice(this.getDeserts(), dessert);

            int totalCalories = burgerChoice.Calories + drinkChoice.Calories + sideChoice.Calories + dessertChoice.Calories;
            return "Your total calorie count is " + totalCalories;
        }

        /// <summary>
        /// Retrieves the MenuItem object corresponding to the given choice from the provided list of menu items.
        /// </summary>
        /// <param name="menuItems">The list of menu items.</param>
        /// <param name="choice">The choice made by the user.</param>
        /// <returns>The MenuItem object corresponding to the given choice.</returns>
        private MenuItem getMenuItemChoice(List<MenuItem> menuItems, int choice)
        {
            return menuItems.Find(item => item.Choice == choice);
        }

        /// <summary>
        /// Retrieves a list of available burger options.
        /// </summary>
        /// <returns>A list of MenuItem objects representing burger options.</returns>
        private List<MenuItem> getBurgers()
        {
            return new List<MenuItem>
            {
                new MenuItem {Name = "Cheeseburger", Calories = 461, Choice = 1},
                new MenuItem {Name = "Fish Burger", Calories = 431, Choice = 2},
                new MenuItem {Name = "Veggie Burger", Calories = 420, Choice = 3},
                new MenuItem {Name = "no burger", Calories = 0, Choice = 4}
            };
        }

        /// <summary>
        /// Retrieves a list of available drink options.
        /// </summary>
        /// <returns>A list of MenuItem objects representing drink options.</returns>
        private List<MenuItem> getDrinks()
        {
            return new List<MenuItem>
            {
                new MenuItem {Name = "Soft Drinks", Calories = 130, Choice = 1},
                new MenuItem {Name = "Orange Juice", Calories = 160, Choice = 2},
                new MenuItem {Name = "Milk", Calories = 118, Choice = 3},
                new MenuItem {Name = "no drink", Calories = 0, Choice = 4}
            };
        }

        /// <summary>
        /// Retrieves a list of available side order options.
        /// </summary>
        /// <returns>A list of MenuItem objects representing side order options.</returns>
        private List<MenuItem> getSides()
        {
            return new List<MenuItem>
            {
                new MenuItem {Name = "Fries", Calories = 100, Choice = 1},
                new MenuItem {Name = "Baked Potato", Calories = 57, Choice = 2},
                new MenuItem {Name = "Chef Salad", Calories = 70, Choice = 3},
                new MenuItem {Name = "no side order", Calories = 0, Choice = 4}
            };
        }

        /// <summary>
        /// Retrieves a list of available dessert options.
        /// </summary>
        /// <returns>A list of MenuItem objects representing dessert options.</returns>
        private List<MenuItem> getDeserts()
        {
            return new List<MenuItem>
            {
                new MenuItem {Name = "Apple Pie", Calories = 167, Choice = 1},
                new MenuItem {Name = "Sundae", Calories = 266, Choice = 2},
                new MenuItem {Name = "Fruit Cup", Calories = 75, Choice = 3},
                new MenuItem {Name = "No Dessert", Calories = 0, Choice = 4}
            };
        }
    }
}
