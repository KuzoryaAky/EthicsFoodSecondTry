using System;
using System.Windows;
using EthicsFoodSecondTry.DataFoods;
using EthicsFoodSecondTry.DataDishes;
using System.Collections.Generic;

namespace EthicsFoodSecondTry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Foods foods;
        Dishes dishes;
        public MainWindow()
        {
            InitializeComponent();
            foods = new();
            dishes = new();
        }

        private void Food_Click(object sender, RoutedEventArgs e)
        {
            FoodData foodData = new();
            foodData.Owner = this;
            foodData.ShowDialog();
        }

        private void Dish_Click(object sender, RoutedEventArgs e)
        {
            CreateDish createDish = new(foods);
            createDish.Owner = this;
            createDish.ShowDialog();
        }
    }
}
