
using System;
using RestSharp;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KhN.FarazSMS.Plugin
{
    public static class FarazSMS
    {
        /// <summary>
        /// ارسال پیامک بدون عبور از بلک لیست
        /// </summary>
        /// <param name="url">آدرس مقصد</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="passWord">گذرواژه</param>
        /// <param name="fromNumber">از شماره</param>
        /// <param name="toNumbers">به شماره های</param>
        /// <param name="message">متن پیامک</param>
        /// <returns>کدهای هر پیامک</returns>
        public static async Task<int> SendToList(string url, string userName, string passWord, string fromNumber, List<string> toNumbers, string message)
        {
            string numbers = "";

            #region تبدیل لیست اعداد به رشته ای درفمت آرایه

            if (toNumbers.Count() == 1)
            {
                numbers = "\"" + toNumbers.First().ToString() + "\"";
            }
            else if (toNumbers.Count() > 0)
            {
                for (int i = 0; i < toNumbers.Count; i++)
                {
                    if (i == 0)
                    {
                        numbers = "\"" + toNumbers.FirstOrDefault() + "\"";
                    }
                    else if (i == toNumbers.Count - 1)
                    {
                        numbers = numbers + ",\"" + toNumbers[i] + "\"";
                    }
                    else
                    {
                        numbers = numbers + ",\"" + toNumbers[i] + "\"";
                    }
                }
            }

            #endregion

            #region ارسال سمت سرور

            url = string.IsNullOrEmpty(url) ? "http://188.0.240.110/api/select" : url;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"send\"" +
                ",\"uname\" : \"" + userName + "\"" +
                ",\"pass\":  \"" + passWord + "\"" +
                ",\"message\" : \"" + message + "\"" +
                ",\"from\": \"" + fromNumber + "\"" +
                ",\"to\" : [" + numbers + "]}"
                , ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            List<int> result = JsonConvert.DeserializeObject<List<int>>(response.Content);

            #endregion

            return await Task.Run(() => result[1]);
        }


        /// <summary>
        /// ارسال پیامک بدون عبور از بلک لیست
        /// </summary>
        /// <param name="url">آدرس مقصد</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="passWord">گذرواژه</param>
        /// <param name="fromNumber">از شماره</param>
        /// <param name="toNumber">به شماره</param>
        /// <param name="message">متن پیامک</param>
        /// <returns>کدهای هر پیامک</returns>
        public static async Task<int> Send(string url, string userName, string passWord, string fromNumber, string toNumber, string message)
        {

            #region ارسال سمت سرور

            url = string.IsNullOrEmpty(url) ? "http://188.0.240.110/api/select" : url;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"send\"" +
                ",\"uname\" : \"" + userName + "\"" +
                ",\"pass\":  \"" + passWord + "\"" +
                ",\"message\" : \"" + message + "\"" +
                ",\"from\": \"" + fromNumber + "\"" +
                ",\"to\" : [\"" + toNumber + "\"]}"
                , ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            List<int> result = JsonConvert.DeserializeObject<List<int>>(response.Content);

            #endregion

            return await Task.Run(() => result[1]);
        }


        /// <summary>
        /// مانده حساب را بدست میاورد (برحسب ریال)
        /// </summary>
        /// <param name="url">آدرس مقصد</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="passWord">گذرواژه</param>
        /// <returns></returns>
        public static async Task<decimal> GetCredit(string url, string userName, string passWord)
        {

            #region ارسال سمت سرور

            url = string.IsNullOrEmpty(url) ? "http://188.0.240.110/api/select" : url;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"credit\"" +
                ",\"uname\" : \"" + userName + "\"" +
                ",\"pass\":  \"" + passWord + "\"}"
                , ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<string> result = JsonConvert.DeserializeObject<List<string>>(response.Content);
            #endregion

            return await Task.Run(() => Convert.ToDecimal(result[1]));
        }


        /// <summary>
        /// وضعیت ارسال
        /// </summary>
        /// <param name="url">آدرس مقصد</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="passWord">گذرواژه</param>
        /// <param name="uniqId">کد یونیک پیامک ارسال شده</param>
        /// <returns></returns>
        public static async Task<List<string>> GetDeliver(string url, string userName, string passWord, string uniqId)
        {

            #region ارسال سمت سرور

            url = string.IsNullOrEmpty(url) ? "http://188.0.240.110/api/select" : url;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"delivery\"" +
                ",\"uname\" : \"" + userName + "\"" +
                ",\"pass\":  \"" + passWord + "\"" +
                ",\"uniqid\": \"" + uniqId + "\"}"
                , ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<string> result = JsonConvert.DeserializeObject<List<string>>(response.Content);
            #endregion

            string data = string.IsNullOrEmpty(result[1]) ? result[1] : result[1].Replace("[", string.Empty).Replace("]", string.Empty);

            List<string> res = data.ToString().Split(',').ToList();

            return await Task.Run(() => res);
        }


        /// <summary>
        /// شماره خطوط را برمیگرداند
        /// </summary>
        /// <param name="url">آدرس مقصد</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="passWord">گذرواژه</param>
        /// <returns></returns>
        public static async Task<List<string>> GetLines(string url, string userName, string passWord)
        {

            #region ارسال سمت سرور

            url = string.IsNullOrEmpty(url) ? "http://188.0.240.110/api/select" : url;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"lines\"" +
                ",\"uname\" : \"" + userName + "\"" +
                ",\"pass\":  \"" + passWord + "\"}"
                , ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<string> result = JsonConvert.DeserializeObject<List<string>>(response.Content);
            #endregion

            string data = string.IsNullOrEmpty(result[1]) ? result[1] : result[1].Replace("[", string.Empty).Replace("]", string.Empty)
                .Replace("{", string.Empty)
                .Replace("number", string.Empty)
                .Replace("}", string.Empty)
                .Replace("\"1", string.Empty)
                .Replace("\"0", string.Empty)
                .Replace("\"", string.Empty)
                .Replace("\\", string.Empty)
                .Replace("send", string.Empty)
                .Replace("gets", string.Empty)
                .Replace(":", string.Empty)
                .Trim(new Char[] { ' ', '*', '.' });

            List<string> res = data.ToString().Split(',').ToList();

            res = res.Where(x => x.StartsWith("+")).ToList();

            return await Task.Run(() => res);
        }


        /// <summary>
        /// لیست مراکز استان ها (نام شهر ها)
        /// </summary>
        /// <param name="url">آدرس مقصد</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="passWord">گذرواژه</param>
        /// <returns></returns>
        public static async Task<CountryStateResponseModel> GetCountryState(string url, string userName, string passWord)
        {

            #region ارسال سمت سرور

            url = string.IsNullOrEmpty(url) ? "http://188.0.240.110/api/select" : url;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"countrystateV2\"" +
                ",\"uname\" : \"" + userName + "\"" +
                ",\"pass\":  \"" + passWord + "\"}"
                , ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            CountryStateResponseModel result = JsonConvert.DeserializeObject<CountryStateResponseModel>(response.Content);
            #endregion

  
            return await Task.Run(() => result);
        }


        /// <summary>
        /// وضعیت پیامک
        /// </summary>
        /// <param name="url">آدرس مقصد</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="passWord">گذرواژه</param>
        /// <param name="uniqId">کد یونیک پیامک ارسال شده</param>
        /// <returns></returns>
        public static async Task<MessageStateResponseModel> GetMessageState(string url, string userName, string passWord, string uniqId)
        {

            #region ارسال سمت سرور

            url = string.IsNullOrEmpty(url) ? "http://188.0.240.110/api/select" : url;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"checkmessage\"" +
                ",\"uname\" : \"" + userName + "\"" +
                ",\"pass\":  \"" + passWord + "\"" +
                ",\"messageid\": \"" + uniqId + "\"}"
                , ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            MessageStateResponseModel result = JsonConvert.DeserializeObject<MessageStateResponseModel> (response.Content);
            #endregion


            return await Task.Run(() => result);
        }


        /// <summary>
        /// ارسال براساس پترن (عبور از بلک لیست)
        /// </summary>
        /// <param name="url">آدرس مقصد</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="passWord">گذرواژه</param>
        /// <param name="fromNumber">ازشماره</param>
        /// <param name="toNumber">به شماره</param>
        /// <param name="patternCode">کد الگو</param>
        /// <param name="parameters">پارامترها</param>
        /// <returns></returns>
        public static async Task<string> SendPattern(string url, string userName, string passWord, string fromNumber, string toNumber,string patternCode, Dictionary<string, string> parameters)
        {

            string inputData = "";
            int counter = 1;
            foreach (var item in parameters)
            {
                if (counter == 1 || counter == parameters.Count() / 2)
                {
                    inputData = inputData + "\"" + item.Key + "\": \"" + item.Value + "\"";
                }
                else
                {
                    inputData = inputData + ",\"" + item.Key + "\": \"" + item.Value + "\"";
                }

                counter++;
            }

            #region ارسال سمت سرور

            url = string.IsNullOrEmpty(url) ? "http://188.0.240.110/api/select" : url;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"pattern\"" +
                ",\"user\" : \"" + userName + "\"" +
                ",\"pass\":  \"" + passWord + "\"" +
                ",\"fromNum\" : \"" + fromNumber + "\"" +
                ",\"toNum\": \"" + toNumber + "\"" +
                ",\"patternCode\": \"" + patternCode + "\"" +
                ",\"inputData\" : [{" + inputData + "}]}"
                , ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            string result = JsonConvert.DeserializeObject<string>(response.Content);

            #endregion

            return await Task.Run(() => result);
        }


        /// <summary>
        /// دفترچه تلفن ها را برمیگرداند
        /// </summary>
        /// <param name="url">آدرس مقصد</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="passWord">گذرواژه</param>
        /// <returns></returns>
        public static async Task<PhoneBookStateResponseModel> GetPhoneBooks(string url, string userName, string passWord)
        {

            #region ارسال سمت سرور

            url = string.IsNullOrEmpty(url) ? "http://188.0.240.110/api/select" : url;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"booklistV2\"" +
                ",\"uname\" : \"" + userName + "\"" +
                ",\"pass\" : \"" + passWord + "\"" +
                ",\"page\":  \"1\"}"
                , ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            PhoneBookStateResponseModel result = JsonConvert.DeserializeObject<PhoneBookStateResponseModel>(response.Content);
            #endregion


            return await Task.Run(() => result);
        }
    }
}
