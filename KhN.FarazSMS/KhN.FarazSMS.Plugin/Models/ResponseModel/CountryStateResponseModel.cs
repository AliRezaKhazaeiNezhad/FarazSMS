
using System.Collections.Generic;

namespace KhN.FarazSMS.Plugin
{
    public class CountryStateResponseModel
    {
        public CountryStateResponseModel()
        {

        }

        public StatusResponseModel status { get; set; }
        public List<DataResponseModel> data { get; set; }
    }
}
