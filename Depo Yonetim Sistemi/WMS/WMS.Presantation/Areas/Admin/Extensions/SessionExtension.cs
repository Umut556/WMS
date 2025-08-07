using System.Text.Json;

namespace WMS.MvcUI.Areas.Admin.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object data)
        {
            session.SetString(key, JsonSerializer.Serialize(data));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var sessionJsonData = session.GetString(key);
            if (sessionJsonData != null)
            {
                return JsonSerializer.Deserialize<T>(sessionJsonData);
            }
            else
            {
                // sessionJsonData null ise, uygun bir işlem yapılabilir.
                // Örneğin, varsayılan bir değer döndürebilir veya hata fırlatabiliriz.
                throw new ArgumentNullException(nameof(sessionJsonData), "Session data is null for the specified key.");
                // veya
                // return default(T); // Varsayılan değeri döndür
            }
        }

    }
}
