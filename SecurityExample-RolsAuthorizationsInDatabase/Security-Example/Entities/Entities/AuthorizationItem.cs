namespace Entities.Entities
{
    public class AuthorizationItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string HTTPMethodType { get; set; } 
        public DateTime InsertDate { get; set; }
    }
}
