// Батьківський клас, що описує паралелограм по двох сторонах і куту між ними
class Parent
{
    protected double Pole1; // перша сторона
    protected double Pole2; // друга сторона
    protected double Pole3; // кут в градусах
    protected double Pole4; // кут в радіанах

    //Конструктор без параметрів
    public Parent()
    {
    }

    // Конструктор із 3-ма параметрами + обчислення кута в радіанах
    public Parent(double side1, double side2, double angle)
    {
        this.Pole1 = side1;
        this.Pole2 = side2;
        this.Pole3 = angle;
        this.Pole4 = Math.Round(angle * (Math.PI / 180), 2);
    }

    // Метод для виведення значень полів
    public void Print()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\nСторона1 = {0}; Сторона2 = {1}; Кут в градусах = {2}", Pole1, Pole2, Pole3);
    }

    // Метод для знаходження площі паралелограма
    public double Metod1()
    {
        return Math.Round(Pole1 * Pole2 * Math.Sin(Pole4),2);
    }

    // Метод для знаходження двох діагоналей
    public void Metod2(out double diagonal1, out double diagonal2)
    {
        diagonal1 = Math.Round(Math.Sqrt(Pole1 * Pole1 + Pole2 * Pole2 - 2 * Pole1 * Pole2 * Math.Cos(Pole4)),2);
        diagonal2 = Math.Round(Math.Sqrt(Pole1 * Pole1 + Pole2 * Pole2 + 2 * Pole1 * Pole2 * Math.Cos(Pole4)),2);
    }
}

// Дочірній клас Child, що описує ромб 
class Child : Parent
{
    // Конструктор з двома параметрами: сторона ромба, гострий кут
    public Child(double side, double angle1) : base(side, side, angle1)
    {
    }

    // Метод для знаходження площі вписаного кола
    public double Metod3()
    {
        double radius = Math.Round((Pole1 * Math.Sin(Pole4)) / 2, 2);
        return Math.Round(Math.PI * Math.Pow(radius, 2), 2);
    }

    // Метод для знаходження довжини вписаного кола
    public double Metod4()
    {
        double radius = Math.Round((Pole1 * Math.Sin(Pole4)) / 2, 2);
        return Math.Round(2 * Math.PI * radius, 2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random o = new Random();
        double s, diag1, diag2, s_circle, length;
        for (int i = 0; i < 5; i++)
        {
            double side1 = o.Next(1, 4);
            double side2 = o.Next(1, 4);
            double angle = o.Next(1, 90);

            if (side1 != side2)
            {
                Parent p = new Parent(side1, side2, angle);
                p.Print();
                s = p.Metod1();
                p.Metod2(out diag1, out diag2);
                Console.WriteLine("Паралелограм: Площа = {0}; Діагональ1 = {1}; Діагональ2 = {2}", s, diag1, diag2);
            }
            else
            {
                Parent p = new Parent(side1, side2, angle);
                p.Print();
                s = p.Metod1();
                p.Metod2(out diag1, out diag2);
                Console.WriteLine("Ромб: Площа = {0}; Діагональ1 = {1}; Діагональ2 = {2}", s, diag1, diag2);

                Child ch = new Child(side1, angle);
                s_circle = ch.Metod3();
                length = ch.Metod4();
                Console.WriteLine("Площа вписаного кола = {0}; Довжина вписаного кола = {1}", s_circle, length);
            }
        }
    }
}