abstract class Animal
{
    protected String name;
    protected short amount;
    protected short calories;
    protected Animal(string name, short amount, short calories)
    {
        this.name=name;
        this.amount=amount;
        this.calories=calories;
    }

    virtual public String getName() { return name; }
    virtual public short getAmount() { return amount; }
    virtual public short getCalories() { return calories; }
}
class Predator : Animal
{
    public Predator(string name, short amount, short calories, Food food) : base(name, amount, calories)
    {
        food.increaseCaloriesNeeded(amount*calories);
    }

    public override short getAmount() { return amount; }
    public override short getCalories() { return calories; }

}
class Herbivore : Animal
{

    public Herbivore(string name, short amount, short calories, Food food) : base(name, amount, calories)
    {
        food.increaseCaloriesNeeded(amount*calories);
    }

}
class Omnivorous : Animal
{

    public Omnivorous(string name, short amount, short calories, Food meat, Food plant) : base(name, amount, calories)
    {
        meat.increaseCaloriesNeeded(amount*calories/2);
        plant.increaseCaloriesNeeded(amount*calories/2);
    }
}
class Food
{
    private String name;
    private short calories;
    private float kgNeeded;
    public int caloriesNeeded;
    public String getName() { return name; }
    public short getCalories() { return calories; }

    public Food(string name, short calories)
    {
        this.name=name;
        this.calories=calories;
    }
    public Food()
    {
        this.name="undefined";
        this.calories=1;
    }

    public float kgFood()
    {
        kgNeeded= (float)caloriesNeeded/calories;
        return (float)Math.Round(kgNeeded, 1);
    }
    public void increaseCaloriesNeeded(int amountCalories)
    {
        caloriesNeeded+=amountCalories;
    }

}


class testZoo
{
    static void calcFood(List<Food> food)
    {
        foreach (Food theFood in food)
        {
            Console.WriteLine("Надо " +theFood.kgFood()+ " килограмм "+theFood.getName());
        }
    }
    static void Main()
    {
        List<Food> Foods = new List<Food>();
        Food banana = new("Банан", 960);
        Food meat = new("Мясо", 2400);
        Food cabbage = new("Капуста", 300);
        Foods.Add(banana); Foods.Add(cabbage); Foods.Add(meat);
        Predator lion = new Predator("Лев", 1, 10000, meat);
        Omnivorous bear = new Omnivorous("Медведь", 1, 15000, meat, banana);
        Herbivore monkey = new Herbivore("Обезьяна", 1, 1000, banana);
        Herbivore goat = new Herbivore("Козел", 1, 3000, cabbage);
        calcFood(Foods);
    }
}