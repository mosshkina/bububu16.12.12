using System;
namespace Project11
{
    [DeveloperAndOrganization("Masha", Organization = "PolarSip Kazan")]
    class Building
    {
        private static int uniq_num = 1;
        private int number;
        private int height;
        private int count_floors;
        private int count_apartments;
        private int count_entrances;
        public int Number { get { return number; } set { number = value; } }
        public int Height { get { return height; } set { height = value; } }

        public int Count_floors { get { return count_floors; } set { count_floors = value; } }
        public int Count_apartments { get { return count_apartments; } set { count_apartments = value; } }
        public int Count_entrances { get { return count_entrances; } set { count_entrances = value; } }
        public double HeightFloor(double height, double count_floors)
        {
            double height_floor;
            if (count_floors != 0)
            {
                height_floor = height / count_floors;
            }
            else
            {
                height_floor = height;
            }
            return height_floor;
        }
        public int CountApartmentsInEntrance(int count_apartments, int count_entrsnces)
        {
            int apart_entrance;
            if (count_entrsnces != 0)
            {
                apart_entrance = count_apartments / count_entrsnces;
            }
            else
            {
                apart_entrance = count_apartments;
            }
            return apart_entrance;
        }
        public int CountApartmentsOnFloor(int count_apartments, int count_floors)
        {
            int apat_floor;
            if (count_floors != 0)
            {
                apat_floor = count_apartments / count_floors;
            }
            else
            {
                apat_floor = count_apartments;
            }
            return apat_floor;
        }
        public void PrintValues()
        {
            Console.WriteLine($"Номер здания: {number}");
            Console.WriteLine($"Высота здания: {height}");
            Console.WriteLine($"Кол-во этажей в здании: {count_floors}");
            Console.WriteLine($"Кол-во квартир в здании: {count_apartments}");
            Console.WriteLine($"Кол-во подъездов в здании: {count_entrances}");
            Console.WriteLine($"Высота одного этажа: {HeightFloor(height, count_floors)}");
            Console.WriteLine($"Кол-во квартир в подъезде: {CountApartmentsInEntrance(count_apartments, count_entrances)}");
            Console.WriteLine($"Кол-во квартир на этаже: {CountApartmentsOnFloor(count_apartments, count_floors)}");
        }
    }
}