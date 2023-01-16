using SQLite;

namespace WashingtonYandun_Hamburguesas.Models
{
    [Table("burger")]
    public class Burger_wy
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        public string Name_wy { get; set; }
        public string Description_wy { get; set; }
        public bool WithExtraCheese_wy { get; set; }
    }
}
