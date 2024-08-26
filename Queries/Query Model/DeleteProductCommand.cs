namespace MicroService.Queries.Query_Model
{
    public class DeleteProductCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
