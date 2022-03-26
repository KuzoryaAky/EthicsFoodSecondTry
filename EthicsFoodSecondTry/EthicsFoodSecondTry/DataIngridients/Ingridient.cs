using System;
using EthicsFoodSecondTry.DataFoods;


namespace EthicsFoodSecondTry.DataIngridients
{
    public class Ingridient
    {

        public Food food;
        public float weight { get; set; }
        public string name 
        {
            get
            {
                return food.name;
            }
        }
        public float calories
        {
            get
            {
                return food.calories * weight / 100;
            }
        }
        public float proteins
        {
            get
            {
                return food.proteins * weight / 100;
            }
        }
        public float fats
        {
            get
            {
                return food.fats * weight / 100;
            }
        }
        public float carbohydrates
        {
            get
            {
                return food.carbohydrates * weight / 100;
            }
        }
    }
}
