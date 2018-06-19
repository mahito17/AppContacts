using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppContacts.Data
{
    using SQLite;
    using AppContacts.Model;
    using System.Threading.Tasks;
    using System.Collections.ObjectModel;
    using AppContacts.Helpers;

    public class ContacsDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public ContacsDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Contact>().Wait();
        }

        public async Task<List<Contact>> GetItemsAsync()
        {
            var data = await database.Table<Contact>().ToListAsync();
            return data;
        }

        public async Task<Contact> GetItemAsync(int id)
        {
            var data = await database.Table<Contact>()
                                      .Where(c => c.Id == id)
                                      .FirstOrDefaultAsync();

            return data;

        }

        public Task<int> SaveItemAsync(Contact item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Contact item)
        {
            return database.DeleteAsync(item);
        }

        public async Task<ObservableCollection<Grouping<string, Contact>>> GetAllGrouped()
        {
            IList<Contact> contacts = await App.DataBase.GetItemsAsync();
            IEnumerable<Grouping<string, Contact>> sorted = new Grouping<string, Contact>[0];

            if (contacts != null)
            {

                sorted =
                from c in contacts
                orderby c.Nombre
                group c by c.Nombre[0].ToString()
                into theGroup
                select
                new Grouping<string, Contact>
                (theGroup.Key, theGroup);
            }


            return new ObservableCollection<Grouping<string, Contact>>(sorted);

        }
    }

    
}
