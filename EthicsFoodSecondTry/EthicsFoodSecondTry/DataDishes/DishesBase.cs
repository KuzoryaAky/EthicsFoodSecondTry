using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EthicsFoodSecondTry.DataDishes
{
    internal class DishesBase : EqualityComparer<Dish>
    {
        public override bool Equals(Dish obj, Dish obj1) => obj.name == obj1.name;
        public override int GetHashCode(Dish obj) => obj.name.GetHashCode();
    }
}