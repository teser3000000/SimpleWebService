namespace Task.Contracts
{
    public record ProductsResponse(
        int Id,
        string Name,
        string Description,
        decimal Price,
        int CategoryId
    );
}
