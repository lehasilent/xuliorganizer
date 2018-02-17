using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.Win32;

namespace XuliOrganizzer
{
    public static class cConfig
    {       
        public static MainDataSet dsConfig = new MainDataSet();
        

        public static string ConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                        "\\XuliOrganizzer";
        public static string ConfigFileName = "\\config.xml";        
        private static string ConfigTable = "Settings";
        private static string DefaultFont = "AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABNTeXN0ZW0uRHJhd2luZy5Gb250BAAAAAROYW1lBFNpemUFU3R5bGUEVW5pdAEABAQLGFN5c3RlbS5EcmF3aW5nLkZvbnRTdHlsZQIAAAAbU3lzdGVtLkRyYXdpbmcuR3JhcGhpY3NVbml0AgAAAAIAAAAGAwAAABRNaWNyb3NvZnQgU2FucyBTZXJpZgAABEEF/P///xhTeXN0ZW0uRHJhd2luZy5Gb250U3R5bGUBAAAAB3ZhbHVlX18ACAIAAAAAAAAABfv///8bU3lzdGVtLkRyYXdpbmcuR3JhcGhpY3NVbml0AQAAAAd2YWx1ZV9fAAgCAAAAAwAAAAs=";
        private static string ASKeyName = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static string ASValName = "XuliOrganizzer";

        public static string ConfigErrMessage = "";        

        private static void CreateConfigDir()
        {
            if (!Directory.Exists(ConfigPath)) Directory.CreateDirectory(ConfigPath);
        }

        public static bool SaveConfig()
        {
            try
            {
                CreateConfigDir();
                dsConfig.WriteXml(ConfigPath + ConfigFileName);
                return true;
            }
            catch (Exception ex)
            {
                ConfigErrMessage=ex.Message;
                return false;
            }
        }

        public static bool LoadConfig()
        {
            try
            {
                CreateConfigDir();
                dsConfig.ReadXml(ConfigPath + ConfigFileName);
                return true;
            }
            catch (Exception ex)
            {
                ConfigErrMessage = ex.Message;
                return false;
            }
        }

        
        public static bool SetParameter(string parName, string parValue)
        {
            DataRow dr = dsConfig.Tables[ConfigTable].Rows.Find(parName); //ищем настройку

            if (dr == null) //нет еще, добавляем
            {
                try
                {
                    dsConfig.Tables[ConfigTable].Rows.Add(parName,parValue);
                }
                catch(Exception ex)
                {
                    ConfigErrMessage = ex.Message;
                    return false;
                }
            }
            else //есть, изменяем значение
            {
                try
                {
                    int idx = dsConfig.Tables[ConfigTable].Rows.IndexOf(dr);
                    dsConfig.Tables[ConfigTable].Rows[idx]["SettingValue"] = parValue;
                }
                catch (Exception ex)
                {
                    ConfigErrMessage = ex.Message;
                    return false;
                }
            }

            return true;
        }

        public static string GetParameter(string parName, string DefaultValue)
        {
            DataRow dr = dsConfig.Tables[ConfigTable].Rows.Find(parName); //ищем настройку
            if (dr == null) return DefaultValue;

            int idx = dsConfig.Tables[ConfigTable].Rows.IndexOf(dr);
            string parValue = dsConfig.Tables[ConfigTable].Rows[idx]["SettingValue"].ToString();
            return parValue;
        }
        
        public static string GetParameter(string parName)
        {
            DataRow dr = dsConfig.Tables[ConfigTable].Rows.Find(parName); //ищем настройку
            if (dr == null) return null;

            int idx = dsConfig.Tables[ConfigTable].Rows.IndexOf(dr);
            string parValue = dsConfig.Tables[ConfigTable].Rows[idx]["SettingValue"].ToString();
            return parValue;
        }

        private static string FontToString(System.Drawing.Font Fnt)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            try
            {
                bf.Serialize(ms, Fnt);
                byte[] buf = ms.ToArray();
                return Convert.ToBase64String(buf);
            }
            catch (Exception ex)
            {
                ConfigErrMessage = ex.Message;
                return String.Empty;
            }
        }

        private static System.Drawing.Font StringToFont(string Base64str)
        {            
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            System.Drawing.Font fnt = null;

            try
            {
                byte[] buf = Convert.FromBase64String(Base64str);
                ms.Write(buf, 0, buf.Length);
                ms.Seek(0, SeekOrigin.Begin);

                fnt = (System.Drawing.Font)bf.Deserialize(ms);
            }
            catch (Exception ex)
            {
                ConfigErrMessage = ex.Message;
            }
            
            return fnt;
        }

        public static bool SetFont(string parName,System.Drawing.Font Fnt)
        {
            string FontString = FontToString(Fnt);
            if (FontString == string.Empty) return false;
            return SetParameter(parName, FontString);
        }
        public static System.Drawing.Font GetFont(string parName)
        {
            string FontString = GetParameter(parName, DefaultFont);            
            System.Drawing.Font Fnt = StringToFont(FontString);
            return Fnt;
        }
        public static System.Drawing.Font RestoreDefaultFont()
        {
            return StringToFont(DefaultFont);
        }

        public static bool CheckAutostart()
        {
            string ARVal = "";            
            RegistryKey Key = null;
            try
            {
                //открываем или создаем раздел реестра, поскольку в нормальной винде оно уже есть
                //то оно просто откроется            
                Key = Registry.LocalMachine.CreateSubKey(ASKeyName);                
                ARVal = Key.GetValue(ASValName).ToString(); //получаем значение ключа
            }
            catch
            {
                return false;
            }
            if (ARVal != Application.ExecutablePath) //если там не текущее положение экзешника
            {
                try
                {
                    Key.DeleteValue(ASValName); //удаляем значение
                    Key.Close();
                }
                catch
                {
                    return false;
                }
                return false;
            }
            return true;
        }

        public static bool SwitchAutostart()
        {
            //открываем или создаем раздел реестра, поскольку в нормальной винде оно уже есть
            //то оно просто откроется
            RegistryKey Key = Registry.LocalMachine.CreateSubKey(ASKeyName);
            if (CheckAutostart()) //Если в автозагрузке - удаляемся оттуда
            {
                try
                {
                    Key.DeleteValue(ASValName); //удаляем значение                 
                    Key.Close();
                }
                catch
                {
                    return false;
                }

            }
            else
            {
                try
                {
                    Key.SetValue(ASValName, Application.ExecutablePath); //записываем путь к экзешнику в соотв. переменную реестра                    
                    Key.Close();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

    }
}
