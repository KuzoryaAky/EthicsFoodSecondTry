using System;
using System.Collections.Generic;
using EthicsFoodSecondTry.DataIngridients;

namespace EthicsFoodSecondTry.DataDishes
{
    class Dish
    {
        public List<Ingridient> ingridients;
        public string name { get; set; }
        public float calories 
        {
            get
            {
                float sum_calories = 0;
                foreach (Ingridient ingridient in ingridients)
                    sum_calories += ingridient.calories;

                return sum_calories;
            }
        }
        public float proteins
        {
            get
            {
                float sum_proteins = 0;
                foreach (Ingridient ingridient in ingridients)
                    sum_proteins += ingridient.proteins;

                return sum_proteins;
            }
        }
        public float fats
        {
            get
            {
                float sum_fats = 0;
                foreach (Ingridient ingridient in ingridients)
                    sum_fats += ingridient.fats;

                return sum_fats;
            }
        }
        public float carbohydrates
        {
            get
            {
                float sum_carbohydrates = 0;
                foreach (Ingridient ingridient in ingridients)
                    sum_carbohydrates += ingridient.carbohydrates;

                return sum_carbohydrates;
            }
        }
    }
}
