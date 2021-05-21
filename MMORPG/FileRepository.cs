using System;
using System.Threading.Tasks;

namespace MMORPG {
    /// <summary>
    /// The purpose of the class is to persist and manipulate the Player objects in a text file.
    /// The text file name should be game-dev.txt.
    /// </summary>
    public class FileRepository : IRepository{
        
         /*Create a class called FileRepository which implements the interface.
         * One possible solution is to serialize the players as JSON to the text file.
         * You can use, for example, File.ReadAllTextAsync and File.WriteAllTextAsync methods for the implementation.*/
         
        public Task<Player> Get(Guid id) {
            throw new NotImplementedException();
        }

        public Task<Player[]> GetAll() {
            throw new NotImplementedException();
        }

        public Task<Player> Create(Player player) {
            throw new NotImplementedException();
        }

        public Task<Player> Modify(Guid id, ModifiedPlayer player) {
            throw new NotImplementedException();
        }

        public Task<Player> Delete(Guid id) {
            throw new NotImplementedException();
        }
    }
}