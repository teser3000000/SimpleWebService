namespace ProductStore.Web.Contracts
{
    public record ProductsRequest(
        string Name,
        string Description,
        decimal Price,
        int CategoryId
    );
}
