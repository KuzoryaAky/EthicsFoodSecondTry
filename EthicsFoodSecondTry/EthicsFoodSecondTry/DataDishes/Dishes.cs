using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthicsFoodSecondTry.DataFoods;
using EthicsFoodSecondTry.DataIngridients;
using Microsoft.Win32;

namespace EthicsFoodSecondTry.DataDishes
{
    class Dishes 
    {
        public static List<Dish> dishes = new();

        public Dish this[string name]
        {
            get
            {
                foreach (Dish dish in dishes)
                    if (dish.name == name)
                        return dish;

                return null;
            }
        }
        public Dish this[int i] => dishes[i];


        public void DelDish(int index) => dishes.RemoveAt(index);
        public void SaveDish()
        {
            SaveFileDialog saveFile = new();
            List<string> _ingridient = new();

            if ((bool)saveFile.ShowDialog())
                foreach (Dish dish in dishes)
                    foreach (Ingridient ingridient in dish.ingridients)
                        _ingridient.Add($"{dish.name};" +
                                        $"{ingridient.name};{ingridient.weight};" +
                                        $"{ingridient.calories};{ingridient.proteins};{ingridient.fats};{ingridient.carbohydrates}");

            File.WriteAllLines(saveFile.FileName, _ingridient);
        }
        public List<Dish> OpenDish(string link)
        {
            if (link == null) return dishes;

            string[] data = File.ReadAllLines(link);
            dishes.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                List<Ingridient> ingridients = new();
                List<Food> foods = new();

                string[] line = data[i].Split(';');
                string temp = line[0];
                int index = -1;

                for (int j = 0; j < data.Length; j++)
                    
                    if (data[j].Contains(temp))
                    {
                        string[] line_second = data[j].Split(';');
                        index++;
                        foods.Add(new()
                        {
                            name = line_second[1],
                            calories = float.Parse(line_second[3]) * 100 / float.Parse(line_second[2]),
                            proteins = float.Parse(line_second[4]) * 100 / float.Parse(line_second[2]),
                            fats = float.Parse(line_second[5]) * 100 / float.Parse(line_second[2]),
                            carbohydrates = float.Parse(line_second[6]) * 100 / float.Parse(line_second[2]),
                        });
                        ingridients.Add(new() { food = foods[index], weight = float.Parse(line_second[2]) });
                    }
                    dishes.Add(new() { name = temp, ingridients = ingridients });
            }
            return dishes.Distinct(new DishesBase()).ToList();
        }
    }
}

