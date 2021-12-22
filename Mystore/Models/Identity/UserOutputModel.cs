namespace Mystore.Api.Models
{
    public class UserOutputModel
    {
        public UserOutputModel(string token)
        {
            this.Token = token;
        }

        public UserOutputModel(string token, string userId)
        {
            this.Token = token;
            this.UserId = userId;
        }

        public string Token { get; }
        public string UserId { get; set; }
    }
}
