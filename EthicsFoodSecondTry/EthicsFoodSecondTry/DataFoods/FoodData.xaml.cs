using System.Windows;
using EthicsFoodSecondTry.DataFoods;
using Microsoft.Win32;

namespace EthicsFoodSecondTry
{
    /// <summary>
    /// Логика взаимодействия для FoodData.xaml
    /// </summary>
    public partial class FoodData : Window
    {
        Foods foods;
        public FoodData()
        {
            InitializeComponent();
            foods = new();
            foreach (Food food in Foods.foods)
                foods_list.Items.Add(food.name);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (foods_name.Text == "" || foods_calories.Text == "" || foods_proteins.Text == "" || foods_fats.Text == "" || foods_carbohydrates.Text == "")
                MessageBox.Show("Сначала введите данные");
            else
            {
                Food food = new()
                {
                    name = foods_name.Text,
                    calories = float.Parse(foods_calories.Text),
                    proteins = float.Parse(foods_proteins.Text),
                    fats = float.Parse(foods_fats.Text),
                    carbohydrates = float.Parse(foods_carbohydrates.Text)
                };

                foods.Add(food);
                foods_list.Items.Add(food.name);
            }
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            if (foods_list.SelectedItem == null)
                MessageBox.Show("Вы не выбрали элемент");
            else
            {
                index = foods_list.SelectedIndex;
                foods.Del(index);
                foods_list.Items.RemoveAt(index);
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e) => foods.SaveFood();
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new();

            if ((bool)openFile.ShowDialog())
            {
                Foods.foods = foods.OpenFood(openFile.FileName);
                foreach (Food food in Foods.foods)
                    foods_list.Items.Add(food.name);
            }
        }
        private void foods_list_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Food food = foods_list.SelectedItem != null ? foods[foods_list.SelectedItem.ToString()] : food = new();     

            foods_name.Text = food.name;
            foods_calories.Text = food.calories.ToString();
            foods_proteins.Text = food.proteins.ToString();
            foods_fats.Text = food.fats.ToString();
            foods_carbohydrates.Text = food.carbohydrates.ToString();
        }
    }
}
