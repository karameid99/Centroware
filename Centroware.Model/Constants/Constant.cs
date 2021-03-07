using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.Constants
{
   public static class Constant
    {
        public static string AddSuccessfully = "Item has been Added successfully";
        public static string UpdateSettings = "Item has been updated successfully";
        public static string AddSuccessResult()
        {
            return JsonConvert.SerializeObject(new { status = 1, msg = "s: Item successfully added", close = 1 });
        }
        public static string AddFuilerResult()
        {
            return JsonConvert.SerializeObject(new { status = 1, msg = "s: Item Not added", close = 1 });
        }
        public static string EditSuccessResult()
        {
            return JsonConvert.SerializeObject(new { status = 1, msg = "s: Item has been updated successfully ", close = 1 });
        }
        public static string DeleteSuccessResult()
        {
            return JsonConvert.SerializeObject(new { status = 1, msg = "s: Item has been deleted successfully", close = 1 });
        }
        public static string DeleteFailedResult()
        {
            return JsonConvert.SerializeObject(new { status = 1, msg = "s: Item has been Failed deleted", close = 1 });
        }
    }
}
