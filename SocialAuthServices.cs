using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EShop.AppStart
{
    public class SocialAuthServices
    {
        private SocialConfig socialConfig { get; set; }

        public SocialAuthServices(SocialConfig socialConfig)
        {
            this.socialConfig = socialConfig;
        }

        public Me VerifyTokenAsync(ExternalToken exteralToken)
        {
            switch (exteralToken.Provider)
            {
                case "Facebook":
                    return VerifyFacebookToken(exteralToken.Token);
                case "Google":
                    return VerifyGoogleToken(exteralToken.Token);
                default:
                    return null;
            }
        }

        public Me VerifyFacebookToken(string token)
        {
            Me me = new Me();
            WebClient client = new WebClient();
            string verifyTokenEndPoint = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name,picture", token);
            string verifyAppEndpoint = string.Format("https://graph.facebook.com/app?access_token={0}", token);
            Uri uri = new Uri(verifyTokenEndPoint);
            try
            { 
                string content = client.DownloadString(uri);
                dynamic userObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                uri = new Uri(verifyAppEndpoint);
                content = client.DownloadString(uri);
                dynamic appObj = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                if (appObj["id"] == socialConfig.Facebook.AppId)
                {
                    //token is from our App
                    me.Id = userObj["id"];
                    me.Email = userObj["email"];
                    me.Name = userObj["name"];
                    me.UrlAvatar = userObj["picture"]["data"]["url"];
                    me.IsVerified = true;
                }
                return me;
            }
            catch(Exception ex)
            {

            }
            return me;
        }

        public Me VerifyGoogleToken(string token)
        {
            Me me = new Me();
            WebClient client = new WebClient();
            string verifyTokenEndPoint = string.Format("https://www.googleapis.com/plus/v1/people/me?access_token={0}", token);
            string verifyAppEndpoint = string.Format("https://www.googleapis.com/oauth2/v3/tokeninfo?access_token={0}", token);
            Uri uri = new Uri(verifyTokenEndPoint);
            try
            {
                string content = client.DownloadString(uri);
                dynamic userObj = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                uri = new Uri(verifyAppEndpoint);
                content = client.DownloadString(uri);
                dynamic appObj = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                if (appObj["azp"] == socialConfig.Google.AppId)
                {
                    me.Id = userObj["id"];
                    var emails = userObj["emails"];
                    foreach (var email in emails)
                    {
                        if (email["type"] == "account")
                        {
                            me.Email = email["value"];
                            break;
                        }
                    }
                    me.Name = userObj["displayName"];
                    me.UrlAvatar = userObj["image"]["url"];
                    me.IsVerified = true;
                }
                return me;
            }
            catch (Exception ex)
            {

            }
            return me;
        }
    }

    public class SocialConfig
    {
        public SocialApp Facebook { get; set; }
        public SocialApp Google { get; set; }
    }

    public class SocialApp
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }

    public class ExternalToken
    {
        public string Provider { get; set; }
        public string Token { get; set; }
    }

    public class Me
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public string Name { get; set; }
        public string UrlAvatar { get; set; }
        public Me()
        {
            IsVerified = false;
        }
    }
}
