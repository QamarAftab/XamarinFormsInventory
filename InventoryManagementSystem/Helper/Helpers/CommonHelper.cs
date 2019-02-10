using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Helper.Helpers
{
    public static class CommonHelper
    {

        public static byte[] ReadFully(Stream input)
        {

            byte[] result;

            using (var streamReader = new MemoryStream())
            {
                input.CopyTo(streamReader);
                input.Dispose();
                result = streamReader.ToArray();

            }
            return result;
        }

        public static bool CheckIsNull(string query)
        {
            return query == null || string.IsNullOrEmpty(query.Trim());
        }

        public static string ClassToJson(object o)
        {
            try
            {
                if (o != null)
                {
                    return JsonConvert.SerializeObject(o);
                }
            }
            catch (Exception e)
            { }
            return "";
        }

        public static string CheckIsNullAndReplace(string query, string replace)
        {
            return CheckIsNull(query) ? replace : query;
        }

        public static bool MatchString(string one, string two)
        {
            return one.Trim().ToLower() == two.Trim().ToLower();
        }

        public static bool EmailValidate(string query)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(query);
            return match.Success;
        }

        public static string RemoveSpecialCharacter(string query)
        {
            return Regex.Replace(query, @"[^0-9a-zA-Z]+", " ");
        }

        public static string RemoveSpecificCharacter(string query, char[] remove)
        {
            return String.Join("", query.Split(remove));
        }

        public static bool NumberValidate(string query)
        {
            if (CheckIsNull(query))
            {
                return true;
            }
            Regex regex = new Regex(@"^[0-9]+$");
            Match match = regex.Match(query);
            return match.Success;
        }

        public static bool DecimalValidate(string query)
        {
            if (CheckIsNull(query))
            {
                return true;
            }
            Regex regex = new Regex(@"[\d]{1,4}([.,][\d]{1,2})?");
            Match match = regex.Match(query);
            return match.Success;
        }

        public static string CurrencyFormat(decimal query)
        {
            return query.ToString("#,##0");
        }

        public static string ResizeImage(string path, string Options = "")
        {

            if (!CheckIsNull(path))
            {
                path = path.Replace("/image/upload/", "/image/upload/l_icon/" + Options);
            }
            return path;
        }

        public static string SubString(string query, int length)
        {
            if (query == null)
            {
                return "";
            }
            if (query.Length > length)
            {
                return query.Substring(0, length) + "...";
            }
            return query.Substring(0, query.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ImageName">Required</param>
        /// <param name="FolderName">Optional</param>
        /// <param name="Options">Optional</param>
        /// <returns></returns>
        public static string GetImagePath(string ImageName, string FolderName = "", string Options = "")
        {
            return Configuration.CloudinayUrl.Replace("{options}", Options) + "/" + FolderName + "/" + ImageName;
        }

        public static int SaveInt(string o, int defaultReturn = 0)
        {
            if (CheckIsNull(o))
            {
                return defaultReturn;
            }
            else
            {
                try
                {
                    var convert = Convert.ToInt32(o);
                    return convert == 0 ? 1 : convert;
                }
                catch (Exception e)
                { }
            }
            return defaultReturn;
        }

        public static long SaveLong(string o)
        {
            try
            {
                return Convert.ToInt64(CheckIsNullAndReplace(o, "0"));
            }
            catch (Exception e)
            {}
            return 0;
        }

        public static string DefaultDateTimeFormat(DateTime? date, TimeSpan? time = null)
        {
            if (time != null)
            {
                return Convert.ToDateTime(date).Add((TimeSpan)time).ToString("MMMM dd, yyyy HH:mm");
            }
            return Convert.ToDateTime(date).ToString("MMMM dd, yyyy HH:mm");
        }
    }
}
