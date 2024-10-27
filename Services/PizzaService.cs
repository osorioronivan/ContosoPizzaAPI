using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService{
    /*  This declares a static class called PizzaService. Since the class is static, you don’t need to create an instance of it. All the methods and properties in this class are also static, and they are shared across the entire application.*/
    static List<Pizza> Pizzas {get; }
    /*a static list that stores pizza objects. The get; means that this list can be read from outside the class, but it can only be modified inside the class (no set means it's read-only). */
    static int nextId = 3;
    //keeps track of the next ID for new pizzas. The initial value is set to 3, assuming there are already two pizzas.
    static PizzaService(){
        // This special method runs only once when the class is first accessed. It initializes the Pizzas list with two pre-defined pizzas:
        Pizzas = new List<Pizza>{
            new Pizza{Id = 1, Name="Classic Itallian", IsGlutenFree=true},
            new Pizza{Id = 2, Name="Veggie", IsGlutenFree=true}
            //The pizzas are represented by instances of the Pizza class (which must be defined in ContosoPizza.Models).
        };
    }

    public static List<Pizza> GetAll() => Pizzas;
    //GetAll(): This method returns the entire list of pizzas (Pizzas), allowing other parts of the application to retrieve all pizzas.
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p=> p.Id == id);
    // /Get(int id): This method takes an id as input and returns the pizza with that id. It uses the FirstOrDefault() LINQ method, which returns the first matching pizza or null if no pizza is found with the given ID.
    //The Pizza? return type means it might return null if no pizza matches the id.
    public static void Add(Pizza pizza) {
        //This method passes a new pizza object inlcuding its attributes
        pizza.Id = nextId++;
        //assigning id to the new pizza
        Pizzas.Add(pizza);
        //adding pizza to the list(Pizzas)

    }
    public static void Delete(int id) {
        //This method deletes a pizza wtih specified id 
        var pizza =Get(id);
        //it calls the Get(int id) which gets a pizza using its id
        if (pizza != null){
            return;
            //if pizza is not found or null, the method simply returns without doing anything
        }
        Pizzas.Remove(pizza);
        //removing pizza to the list
    }
    public static void Update(Pizza pizza) {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1) {
            return;
        }
        Pizzas[index] = pizza;

        /* It finds the index of the pizza in the list using FindIndex(), searching for a pizza with the same Id as the one being updated.
        If no pizza is found (index == -1), the method returns without doing anything.
        If the pizza is found, the pizza in the list is replaced with the new pizza.
        */
    }
}