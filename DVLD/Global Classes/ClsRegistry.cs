using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Global_Classes
{
    public class ClsRegistry
    {
        public static string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD\LoginInfo";

        const string UserNameValueName = "UserName";
        const string PasswordValueName = "Password";
        public static string ReadString(string valueName)
        {

            try
            {
                // Read the value to the Registry
                return (string) Registry.GetValue(keyPath , valueName , "");
                
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return "";
            }
        }
        public static string ReadUserName( )
        {
          return ReadString(UserNameValueName);
        }

        public static string ReadPassword( )
        {
          return ReadString(PasswordValueName);
        }

        public static void WriteUserName(string valueData)
        {
            WriteString(UserNameValueName , valueData);
        }
        public static void WritePassword(string valueData)
        {
            WriteString(PasswordValueName , valueData);
        }

        public static void WriteString(string valueName,string valueData)
        {
            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath , valueName , valueData , RegistryValueKind.String);


                Console.WriteLine($"Value {valueName} successfully written to the Registry.");
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
