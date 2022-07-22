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
        return kgNeeded;
    }
    public void increaseCaloriesNeeded(int amountCalories)
    {
        caloriesNeeded+=amountCalories;
    }

}


class testZoo
{
    static int amountofdays()
    {
        Console.WriteLine("Введите цифру месяца: \n 1)Январь \n 2)Февраль \n 3)Март \n 4)Апрель \n 5)Май \n 6)Июнь \n 7)Июль\n 8)Август \n 9)Сентябрь \n 10)Октябрь \n 11)Ноябрь \n 12)Декабрь");
        int month;
        int days;
        month = Convert.ToInt16(Console.ReadLine());
        if (month == 4 || month == 6 || month == 9 || month == 11)
            days = 30;
        else if (month == 2)
            days = 28;
        else
            days = 31;
        return days;
    }
    static void calcFood(List<Food> food,int days)
    {
        foreach (Food theFood in food)
        {
            Console.WriteLine("Надо " +Math.Round(theFood.kgFood()*days,1)+ " килограмм "+theFood.getName());
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
        int days = amountofdays();
        calcFood(Foods,days);
    }
}