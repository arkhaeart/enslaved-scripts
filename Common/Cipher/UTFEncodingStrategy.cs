using System;
using System.Text;
namespace Persistence.Systems
{
    public class UTFEncodingStrategy:ICipherStrategy
    {
        public string Encode(string data)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(plainTextBytes);
        }

        public string Decode(string encodedData)
        {
            var encodedJsonBytes = Convert.FromBase64String(encodedData);
            return Encoding.UTF8.GetString(encodedJsonBytes);
        }
        
    }
}