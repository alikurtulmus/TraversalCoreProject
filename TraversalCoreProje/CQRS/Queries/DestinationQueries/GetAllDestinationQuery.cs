namespace TraversalCoreProje.CQRS.Queries.DestinationQueries

{
    public class GetAllDestinationQuery
    {
        public int id { get; set; }
        public string city { get; set; }
        public string daynight { get; set; }
        public double price { get; set; }
        public int capacity { get; set; }
    }
}
