using SQLite;
using WashingtonYandun_Hamburguesas.Models;

namespace WashingtonYandun_Hamburguesas.Data
{
    public class BurgerDatabase_wy
    {
        string _dbPath;
        private SQLiteConnection conn_wy;

        public BurgerDatabase_wy(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn_wy != null)
            {
                return;
            }
            conn_wy = new SQLiteConnection(_dbPath);
            conn_wy.CreateTable<Burger_wy>();
        }

        public int AddNewBurger(Burger_wy burger)
        {
            Init();
            try
            {
                int res = conn_wy.Insert(burger);
                return res;
            }
            catch (Exception ex)
            {
                return 404;
            }

        }

        public List<Burger_wy> GetAllBurgers()
        {
            Init();
            List<Burger_wy> burgers = conn_wy.Table<Burger_wy>().ToList();
            return burgers;
        }

        public List<Burger_wy> GetBurgersByName(string Exp)
        {
            Init();
            TableQuery<Burger_wy> burgers = conn_wy.Table<Burger_wy>()
                .Where(b => b.Name_wy
                .Contains(Exp));

            return burgers.ToList();
        }

        public Burger_wy GetBurgerById(int Id)
        {
            Init();
            Burger_wy burger = conn_wy.Table<Burger_wy>()
                .SingleOrDefault(b => b.Id == Id);

            return burger;
        }

        public void UpdateBurger(int Id, string Name, string Desc, bool Extra)
        {
            Init();
            Burger_wy newBurger = conn_wy.Table<Burger_wy>()
                .Where(r => r.Id == Id)
                .FirstOrDefault();

            if (newBurger != null)
            {
                newBurger.Name_wy = Name;
                newBurger.Description_wy = Desc;
                newBurger.WithExtraCheese_wy = Extra;

                conn_wy.Update(newBurger);
            }
        }

        public void DeleteBurger(int Id)
        {
            Burger_wy deletedBurger = conn_wy.Table<Burger_wy>()
                .Where(r => r.Id == Id)
                .FirstOrDefault();

            if (deletedBurger != null)
            {
                conn_wy.Delete(deletedBurger);
            }
        }

        public void EmptyList()
        {
            conn_wy.DeleteAll<Burger_wy>();
            conn_wy.Table<Burger_wy>().Delete(b => true);
            conn_wy.Execute("DELETE FROM sqlite_sequence WHERE name = 'burger'");
        }
    }
}
