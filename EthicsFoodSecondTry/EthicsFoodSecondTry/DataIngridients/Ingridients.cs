using System;
using System.Collections.Generic;
using EthicsFoodSecondTry.DataFoods;

namespace EthicsFoodSecondTry.DataIngridients
{
    public class Ingridients
    {
        public List<Ingridient> ingridients;
        public Foods foods;

        public Ingridient this[string name]
        {
            get
            {
                foreach (Ingridient ingridient in ingridients)
                    if (ingridient.name == name)
                        return ingridient;

                return null;
            }
        }
        public Ingridient this[int i] => ingridients[i];
        public Ingridients(Foods foods)
        {
            this.foods = foods;
            ingridients = new();
        }
        public void AddIngridients(string name, float weight) => AddIngridients(foods[name], weight);
        public void AddIngridients(Food food, float weight)
        {
            ingridients.Add(new Ingridient
            {
                food = food,
                weight = weight
            });
        }
        public void RemoveIngridients(int index) => ingridients.RemoveAt(index);
    }
}

