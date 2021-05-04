using SQLite;

namespace Lab7B
{
    class Lab7BItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TheFact { get; set; }
        public string ShortFact { get; set; }
        public string ImageFile { get; set; }
    }
}
