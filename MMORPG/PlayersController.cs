namespace MMORPG {
    /// <summary>
    /// The first responsibility of the controller is to define the routes for the API.
    /// Define the routes using attributes. There is [HttpPost], [HttpPut] and a few more.
    /// The second responsibility is to handle the business logic. Business logic is a term for the core of your application.
    /// Everything that creates transactions that change your data / model.
    /// This can include things such as generating IDs when creating a player, and deciding which properties to change when modifying a player.
    /// </summary>
    public class PlayersController {
        
        /* Create a class called PlayersController. Add and implement the following methods:
         * PlayersController should get IRepository through its constructor.
         * We will learn later, how we can provide this information through Dependency Injection (the DI-Container)*/
        
        IRepository repository;
        
        public PlayersController(IRepository repository) {
            this.repository = repository;
        }
    }
}