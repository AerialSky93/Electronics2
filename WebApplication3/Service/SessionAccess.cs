using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



//    public static class SessionHelper
//    {
//        public static void SetObjectAsJson(this ISession session, string key, object value)
//        {
//            session.SetString(key, JsonConvert.SerializeObject(value));
//        }

//        public static T GetObjectFromJson<T>(this ISession session, string key)
//        {
//            var value = session.GetString(key);
//            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
//        }
//}

//using Newtonsoft.Json;

namespace WebApplication3.Infrastructure
{

    public static class SessionExtensions
    {

        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
                ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}