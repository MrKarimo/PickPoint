using Microsoft.AspNetCore.Mvc;
using PickPoint.Controllers;
using PickPoint.Models.DTO;
using System.Text.RegularExpressions;

namespace PickPoint.Models
{
    public static class Validate
    {
        public static bool IsBadPostamatNumber(string number)
        {
            string sPattern = "^\\d{4}-\\d{3}$";

            if (!Regex.IsMatch(number, sPattern))
                return true;
            else
                return false;
        }

        public static bool IsBadPhoneNumber(string number)
        {
            string sPattern = "^[+][7]\\d{3}-\\d{3}-\\d{2}-\\d{2}$";

            if (!Regex.IsMatch(number, sPattern))
                return true;
            else
                return false;
        }

        
            
    }
}
