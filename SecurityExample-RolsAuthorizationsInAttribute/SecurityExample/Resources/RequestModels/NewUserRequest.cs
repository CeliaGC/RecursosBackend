using Entities.Entities;

namespace Resources.RequestModels
{
    public class NewUserRequest
    {
        public int IdRol { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserItem ToUserItem()
        {
            var userItem = new UserItem();

            userItem.IdRol = IdRol;
            userItem.UserName = UserName;
            userItem.InsertDate = DateTime.Now;
            userItem.UpdateDate = DateTime.Now;
            userItem.IsActive = true;

            return userItem;
        }
    }
}