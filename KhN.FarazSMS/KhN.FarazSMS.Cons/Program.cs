

using System;
using System.Collections.Generic;

namespace KhN.FarazSMS.Cons
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ////شماره آقای علیزاده برای ارسال پیامک
            Dictionary<string, string> smsphones = new Dictionary<string, string>();
            smsphones.Add("trackingcode", "123456");


            try
            {
                var zzz = Plugin.FarazSMS.SendPattern(null, "09155027200", "faraz0944686291", "983000505", "09155027200", "lcwlu9k8wt6nlae", smsphones);
            }
            catch (Exception e)
            {
            }

            //var xxxx = Plugin.FarazSMS.AddPhoneBookNumber("", "9155575098", "faraz0946166986", "420784", "xyz", "09155575099").Result;

            //var xyy = Plugin.FarazSMS.AddPhoneBookNumber("", "9155575098", "faraz0946166986", "420784", "xyz", "+9809155575099").Result;
            Console.ReadKey();
        }
    }
}
