namespace Data.DB_Models.Interfaces
{
    public interface IEntity
    {
        long Id { get; set; }
        string Name { get; set; }
        bool Active { get; set; }
    }
}
