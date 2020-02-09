using System;

namespace Farm
{
    //REQ: Four classes of animals that can receive a name, make noise, eat, and produce something
    class Animal
    {
        private static int numberOfAnimals = 0;
        public int CountAnimals => numberOfAnimals;
        //public class Goat : Animal
        //{
        //    public string type = "Goat";
        //    public string animalname;
        //    private int count = 0;
        //    public Goat()
        //    {
        //        animalname = type + count;
        //        count++;
        //        numberOfAnimals++;
        //    }
        //    public Goat(string name)
        //    {
        //        animalname = name;
        //        count++;
        //        numberOfAnimals++;
        //    }
        //    public string Speak() => "Baaa";
        //    public string Eat() => "Grass";
        //    public string Product() => "Cheese";
        //}


        class Dog
        {
            public string sound = "bark";
            public string dogname;
            public bool hasballs = false;
            public int legs = 4;
            public Dog(string name)
            {
                dogname = name;
            }
            public Dog()
            {
                dogname = "Lassie";
            }
            public string makenoise() => "woof";

        }
    
        //public class Chicken
        //{
        //    public string type = "Chicken";
        //    public string animalname;
        //    private int count = 0;
        //    public Chicken()
        //    {
        //        animalname = type + count;
        //        count++;
        //        numberOfAnimals++;
        //    }
        //    public Chicken(string name)
        //    {
        //        animalname = name;
        //        count++;
        //        numberOfAnimals++;
        //    }
        //    public string Speak() => "cluck";
        //    public string Eat() => "Seeds";
        //    public string Product() => "Wings";
        //}
        //public class Cow
        //{
        //    public string type = "Cow";
        //    public string animalname;
        //    private int count = 0;
        //    public Cow()
        //    {
        //        animalname = type + count;
        //        count++;
        //        numberOfAnimals++;
        //    }
        //    public Cow(string name)
        //    {
        //        animalname = name;
        //        count++;
        //        numberOfAnimals++;
        //    }
        //    public string Speak() => "Mooo";
        //    public string Eat() => "Hayyyyy";
        //    public string Product() => "Milk";
        //}
        //public class Rabbit
        //{
        //    public string type = "Rabbit";
        //    public string animalname;
        //    public int count = 0;
        //    public Rabbit()
        //    {
        //        animalname = type + count;
        //        count++;
        //        numberOfAnimals++;
        //    }
        //    public Rabbit(string name)
        //    {
        //        animalname = name;
        //        count++;
        //        numberOfAnimals++;
        //    }
        //    public string Speak() => "*EATS CARROTS*";
        //    public string Eat() => "Carrots";
        //    public string Product() => "Lucky charms";
        //}
        static void Main(string[] args)
        {
            try
            {
                Animal.Dog doggo = new Animal.Dog("Fido");
                Console.WriteLine($"{doggo.dogname} says {doggo.makenoise()} and has ");
                //Animal.Goat g1 = new Animal.Goat("Mr. Ed");
                //Console.WriteLine($"Hello, my name is {g1.animalname}, and I am a {g1.type}. I say {g1.Speak()}. I eat {g1.Eat()}. I produce {g1.Product()}");
                //Animal.Goat g2 = new Animal.Goat();
                //Console.WriteLine($"Hello, my name is {g2.animalname}, and I am a {g2.type}. I say {g2.Speak()}. I eat {g2.Eat()}. I produce {g2.Product()}");
                //Animal.Cow c1 = new Animal.Cow("Mr. Ted");
                //Console.WriteLine($"Hello, my name is {c1.animalname}, and I am a {c1.type}. I say {c1.Speak()}. I eat {c1.Eat()}. I produce {c1.Product()}");
                //Animal.Cow c2 = new Animal.Cow("Mr. Ned");
                //Console.WriteLine($"Hello, my name is {c2.animalname}, and I am a {c2.type}. I say {c2.Speak()}. I eat {c2.Eat()}. I produce {c2.Product()}");
                //Animal.Rabbit r1 = new Animal.Rabbit("Tupac");
                //Console.WriteLine($"Hello, my name is {r1.animalname}, and I am a {r1.type}. I say {r1.Speak()}. I eat {r1.Eat()}. I produce {r1.Product()}");
                //Animal.Rabbit r2 = new Animal.Rabbit("Biggie");
                //Console.WriteLine($"Hello, my name is {r2.animalname}, and I am a {r2.type}. I say {r2.Speak()}. I eat {r2.Eat()}. I produce {r2.Product()}");
                //Console.WriteLine($"There are {Animal.numberOfAnimals} animals.");
            }
            catch 
            {
                throw new Exception("These particular classes and methods have not been implemented.");
            }
        }
    }
}
