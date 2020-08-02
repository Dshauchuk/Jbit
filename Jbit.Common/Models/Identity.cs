using System;

namespace Jbit.Common.Models
{
    public class Identity : IIdentifiable
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public string Device { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime UpdateTimestamp { get; set; }

        public Identity()
        {

        }

        public Identity(Guid id, Guid deviceId, string device, User user, 
            string accessToken, string refreshToken)
        {
            Id = id;
            DeviceId = deviceId;
            Device = device;
            UserId = user?.Id ?? Guid.Empty;
            User = user;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
