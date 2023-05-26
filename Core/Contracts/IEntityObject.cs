namespace Core.Contracts
{
    public interface IEntityObject
    {
        int Id { get; set; }
        byte[]? RowVersion { get; set; }
    }
}
