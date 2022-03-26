using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthicsFoodSecondTry.DataFoods
{
    public class Foods
    {
        static public List<Food> foods = new();

        public Food this[string name]
        {
            get
            {
                foreach (Food food in foods)
                    if (food.name == name)
                        return food;

                return null;
            }
        }
        public Food this[int i] => foods[i];
        public void Add(string name, float calories, float proteins, float fats, float carbohydrates)
        {
            Add(new Food()
            {
                name = name,
                calories = calories,
                proteins = proteins,
                fats = fats,
                carbohydrates = carbohydrates
            });
        }
        public void Add(Food food)
        {
            foods.Add(food);
        }
        public void Del(int index) => foods.RemoveAt(index);
        public void Del(string name) => foods.Remove(this[name]);
        public void SaveFood()
        {
            SaveFileDialog saveFile = new();
            List<string> food = new();

            if ((bool)saveFile.ShowDialog())
                foreach (Food item in foods)
                    food.Add($"{item.name};{item.calories};{item.proteins};{item.fats};{item.carbohydrates}");

            File.WriteAllLines(saveFile.FileName, food);
        }
        public List<Food> OpenFood(string link)
        {
            if (link == null) return foods;

            string[] data = File.ReadAllLines(link);
            foods.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                string[] food = data[i].Split(';');

                foods.Add(new()
                {
                    name = food[0].ToString(),
                    calories = float.Parse(food[1]),
                    proteins = float.Parse(food[2]),
                    fats = float.Parse(food[3]),
                    carbohydrates = float.Parse(food[4])
                });
            }
            return foods;
        }
    }
}
