namespace Design_Patterns.Factory_Method
{
    
    // first create the interface have abstract method 

    // The Product interface declares the operations that all concrete products
    // must implement

    public interface IProduct
    {
        string Operation();
    }


    // Concret Products provied implementation of the Prosuct
    // interface

    public class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }

    public class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct2}";
        }
    }


    // the Creator class declars the factory method that is supposed to return
    // an object of a Product class. The Creaotr's subclasses usually Provide
    // the implementation of this method
    public abstract class Creator
    {
        // Note that the Craetor also provide some default implementation of
        // the factory method.
        public abstract IProduct FactoryMethod();


        public string SomeOperation()
        {
            // Call the factory method to create a product object.
            var product = FactoryMethod();
            // now use the product
            var result = "Creator: The Same Creator's code has just worked with " + product.Operation();

            return result;
        }
    }


    // Concrete Creators override the factory method in order to change the 
    // resulting product's type
    public class ConcreteCreators1 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    public class ConcreteCreators2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }
 

    public class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Lenched with the ConcreteCreator1");
            ClientCode(new ConcreteCreators1());

            Console.WriteLine(" ");

            Console.WriteLine("App: Lenched with the ConcreteCreator2");
            ClientCode(new ConcreteCreators2());
            
        }

        public void ClientCode(Creator creator)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
        }


        class Program
        {
            public static void Main(String[] args)
            {
                new Client().Main();
            }
        }
    }
}