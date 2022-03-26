using System;
using System.Collections.Generic;
using System.Windows;
using EthicsFoodSecondTry.DataFoods;
using EthicsFoodSecondTry.DataIngridients;
using Microsoft.Win32;

namespace EthicsFoodSecondTry.DataDishes
{
    /// <summary>
    /// Логика взаимодействия для CreateDish.xaml
    /// </summary>
    public partial class CreateDish : Window
    {
        Ingridient ingridient = new();
        Dish dish = new();

        Foods foods;
        Ingridients ingridients;
        Dishes dishes;

        public CreateDish(Foods foods)
        {
            InitializeComponent();
            ingridients = new(foods);
            dishes = new();

            foreach (Dish dish in Dishes.dishes)
                dish_list.Items.Add(dish.name);
        }
        private void Add_Ingridient_Click(object sender, RoutedEventArgs e)
        {
            if (ingridients_ComboBox.SelectedItem == null)
                MessageBox.Show("Сначала введите данные");

            else
            {
                Ingridient ingridient = new()
                {
                    food = foods[ingridients_ComboBox.SelectedIndex],
                    weight = ingridient_weight.Text == "" ? 0 : float.Parse(ingridient_weight.Text.ToString())
                };

                ingridients.ingridients.Add(ingridient);
                ingridients_list.Items.Add(ingridients_ComboBox.Text.ToString());
            }
        }
        private void ComboBox_Ingridients_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Food food in Foods.foods)
                ingridients_ComboBox.Items.Add(food.name);
        }
        private void ingridient_del_Click(object sender, RoutedEventArgs e)
        {
            if (ingridients_list.SelectedItem == null)
                MessageBox.Show("Вы не выбрали элемент");

            else
            {
                ingridient = new();
                ingridients.RemoveIngridients(ingridients_list.SelectedIndex);

                for (int i = 0; i < ingridients_list.Items.Count; i++)
                    if (i == ingridients_list.SelectedIndex)
                        ingridients_list.Items.RemoveAt(i);
            }
        }
        private void ingridients_list_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ingridient = ingridients_list.SelectedItem == null ? ingridient : ingridients[ingridients_list.SelectedIndex];
            if (ingridient.food == null)
                ingridient.food = new();

            calories.Text = ingridient.calories.ToString();
            proteins.Text = ingridient.proteins.ToString();
            fats.Text = ingridient.fats.ToString();
            carbohydrates.Text = ingridient.carbohydrates.ToString();
        }
        private void dish_create_Click(object sender, RoutedEventArgs e)
        {
            List<Ingridient> ingridients = new();
            foreach (var link_ingridient in ingridients_list.Items)
                ingridients.Add(this.ingridients[link_ingridient.ToString()]);

            Dish dish = new()
            {
                ingridients = ingridients,
                name = dish_name.Text
            };

            Dishes.dishes.Add(dish);
            dish_list.Items.Add(dish_name.Text);
            ingridients_list.Items.Clear();
        }
        private void dish_del_Click(object sender, RoutedEventArgs e)
        {
            if (dish_list.SelectedItem == null)
                MessageBox.Show("Вы не выбрали элемент");

            else
            {
                dish = new();
                ingridients = new(foods);
                dishes.DelDish(dish_list.SelectedIndex);

                for (int i = 0; i < dish_list.Items.Count; i++)
                    if (i == dish_list.SelectedIndex)
                        dish_list.Items.RemoveAt(i);
            }
        }
        private void dish_list_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            dish = dish_list.SelectedItem == null ? dish : dishes[dish_list.SelectedItem.ToString()];
            if (dish == null)
                dish = new();

            if (dish.ingridients == null)
                dish.ingridients = new();

            calories.Text = dish.calories.ToString();
            proteins.Text = dish.proteins.ToString();
            fats.Text = dish.fats.ToString();
            carbohydrates.Text = dish.carbohydrates.ToString();

            if (dish_list.SelectedItem == null)
            {
                dish = new();
                dish_ingridients_list.Items.Clear();
            }
            else
            {
                dish_ingridients_list.Items.Clear();
                dish_ingridients_list_SelectionChanged(sender, e);
            }
        }
        private void dish_ingridients_list_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dish_list.SelectedItem != null && dish_ingridients_list.Items.IsEmpty != false)
                    foreach (Ingridient ingridient in dishes[dish_list.SelectedItem.ToString()].ingridients)
                        dish_ingridients_list.Items.Add(ingridient.name);
        }

        private void dish_save_Click(object sender, RoutedEventArgs e) => dishes.SaveDish();
        private void dish_load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new();

            if ((bool)openFile.ShowDialog())
            {
                Dishes.dishes = dishes.OpenDish(openFile.FileName);
                foreach (Dish dish in Dishes.dishes)
                     dish_list.Items.Add(dish.name);
            }
        }
    }
}
