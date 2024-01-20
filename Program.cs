namespace carRacer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int speed = 0, distance = 0, pass = 0, Point = 0;
            Random random = new Random();
            bool first = false;
            Console.WriteLine("Enter type of car.");
            string car = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(car);
            Console.WriteLine();


            intializeValues(ref speed, ref distance, random);
            while (speed > 0 && distance > 0 && first == false)
            {
                pass = passing();

                if (pass == 0)
                   decision(random.Next(0, 3), ref speed, ref distance);
                else  
                    decision(random.Next(3, 6), ref speed, ref distance);
                
                postResults(ref Point, ref speed, ref distance, ref first);
            }

            if (first)
                Console.WriteLine("You have won the race!!!");
            else if (speed <= 0)
                Console.WriteLine("You have stopped your vehicle.");
            else if (distance <= 0)
                Console.WriteLine("You are not going forward.");
            else
                Console.WriteLine("You had a pit stop.");

         }

        private static void postResults(ref int point, ref int speed, ref int distance, ref bool first)
        {
            
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~ Point " + (++point) + " ~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Speed: " + speed + " Distance: " + distance);
            if (distance >= 500) first = true;
        }

        private static void decision(int v, ref int speed, ref int distance)
        {
            switch (v) 
            { 
                case 0:
                    Console.WriteLine("You have accelerated.");
                    Console.WriteLine("You have increased speed 20 mph");
                    speed += 20;
                    distance += 20;
                    break;
                    
                case 1:
                    Console.WriteLine("You have passed a car.");
                    Console.WriteLine("You have increased your speed 50 mph");
                    speed += 50;
                    distance += 50;
                    break;

                case 2:
                    Console.WriteLine("You have crashed.");
                    Console.WriteLine("Your speed is -200");
                    speed -= 200;
                    distance -= distance;
                    break;

                case 3:
                    Console.WriteLine("You were rear ended.");
                    Console.WriteLine("Your speed went down 50 mph");
                    speed -= 50;
                    distance = ((distance / 50) + distance);
                    break;

                case 4:
                    Console.WriteLine("You have successfully slowed down.");
                    Console.WriteLine("You decelerated 20 mph");
                    speed -= 20;
                    distance = ((distance/10) + distance);
                    break;

                    case 5:
                    Console.WriteLine("You have really slowed down.");
                    Console.WriteLine("You decelerated 35 mph");
                    speed -= 35;
                    distance = (distance/15) + distance;
                    break;

                default:
                    Console.WriteLine("You are staying at your regular speeed.");
                    Console.WriteLine("You are on cruise setting");
                    speed += 0;
                    distance += 5;
                    break;



            }
        }

        private static int passing()
        {
            Console.WriteLine("You are in the race. Enter {0} to 'Pass' and {1} to 'slow down.'");
            int pass = int.Parse(Console.ReadLine());

            while (pass != 0 && pass != 1) 
            {
                Console.WriteLine("You entered the wrong number. Pleas try again.");
                pass = int.Parse(Console.ReadLine());

            }
            return pass;
        }

        private static void intializeValues(ref int speed, ref int distance, Random random)
        {
            speed = random.Next(200) + 1;
            distance = random.Next(500) + 1;
        }
    }
}
