namespace Entities.Relations
{
    public class RolAuthorization
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdAuthorization { get; set; }
        public bool IsActive { get; set; }
    }
}
