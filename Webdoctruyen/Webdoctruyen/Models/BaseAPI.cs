namespace Webdoctruyen.Models
{
    public class BaseAPI
    {
        public BaseAPI(string controller)
        {
            baseURL = "https://localhost:7061/api/"+controller;
        }
        private string baseURL;
        public string getURL() => baseURL;

    }
}
