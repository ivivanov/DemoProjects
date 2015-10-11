/*********************************************************************
 * Developer     : Dennis Fazekas
 * Email Address : dennis_fazekas@shi.com
 * Date          : September 2007
 * Description   : This class is the wrapper which loads the settings
 *                 stored in the shiSettings section in the 
 *                 configuration file. (Web.Config or App.Config)
 *                 Settings returned by this class are based on the
 *                 value of the Codebase setting in the machine.conf
 *                 file. The AppSettings property has been designed
 *                 to mimic Microsoft's AppSettings.
 * Changes
 * --------------------------------------------------------------------
 * Date       | Developer       | Description
 * --------------------------------------------------------------------
 * 09/04/2007 | Dennis Fazekas  | Added these comments
 * 09/12/2007 | Dennis Fazekas  | Changed Namespace
**********************************************************************/
using System;
using SHI.WebTeam.Common.Configuration.Enum;
using System.Collections.Specialized;
using System.Collections;

namespace SHI.WebTeam.Common.Configuration
{
   public class ConfigurationSettings
   {
      private static object sLockingObject = new object();
      private static CodeBases sCodebase = CodeBases.NotSet;
      private static ShiSettingsSection sSettings = null;

      /// <summary>
      /// Gets the SHI.Configuration.AppSettingsSection data based on the 
      /// machine's codebase for the current application's codebase default settings.
      /// In addition gets the System.Configuration.AppSettingSection data for 
      /// the current application's default settings if the setting does not 
      /// exist in the SHI.Configuration.AppSettingsSection.
      /// </summary>
      /// <param name="name">The name of the setting to be retreived.</param>
      /// <returns>Returns the setting specified.</returns>
      [System.Diagnostics.DebuggerNonUserCode()]
      public static NameValueCollection AppSettings
      {
                  get
         {
            lock (sLockingObject)
            {
               if (sSettings == null)
               {
                  sSettings = new ShiSettingsSection();
                  sSettings.GetSettings();
               }
            }
            return (NameValueCollection)sSettings;
         }
      }
      /// <summary>
      /// Gets the Codebase setting in which the application is being executed.
      /// </summary>
      static public CodeBases CodeBase
      {
         get
         {
            if (ConfigurationSettings.sCodebase == CodeBases.NotSet)
            {
               //Get the codebase value from the config file.
               string ConfigCodeBase =
                  System.Configuration.ConfigurationManager.
                  AppSettings["Codebase"].ToLower();

               //Convert the codebase string to the enum value.
               if (ConfigCodeBase == "prod")
                  ConfigurationSettings.sCodebase = CodeBases.Production;
               else if (ConfigCodeBase == "dev")
                  ConfigurationSettings.sCodebase = CodeBases.Development;
               else
                  ConfigurationSettings.sCodebase = CodeBases.Invalid;
            }

            return ConfigurationSettings.sCodebase;
         }
      }

      /// <summary>
      /// Validates the value of the codebase setting. If the value is not
      /// supported an exception is thrown.
      /// 
      /// The codebase settings should be set in the machine.config file usually
      /// located at \WINDOWS\Microsoft.NET\Framework\v2.X.X\Config\Machine.Config.
      /// 
      /// In the appSettings section create a key called "codebase" and a value of
      /// "Prod" or "Dev". Missing values or other values will be concidered
      /// invalid.
      /// <returns>Returns the value of the codebase setting machine.config file.</returns>
      [System.Diagnostics.DebuggerNonUserCode()]
      static private CodeBases validateCodebase()
      {
         if (ConfigurationSettings.CodeBase == CodeBases.NotSet)
         {   //The codebase setting is not configured throw an exception.
            throw new Exception("Missing codebase value in the machine.config " +
                "file under the appSettings. Allowed values are \"prod\" and \"dev\"");
         }
         else if (ConfigurationSettings.CodeBase == CodeBases.Invalid)
         {   //The codebase isn't the expected value throw an exception.
            throw new Exception("Invalid codebase value in the machine.config file " +
                "under the appSettings. Allowed values are \"prod\" and \"dev\"");
         }

         //The codebase was set and value, so return the current machine codebase.
         return ConfigurationSettings.CodeBase;
      }

      #region Private shiSettingsSection Class
      private class ShiSettingsSection : NameValueCollection
      {
         /// <summary>
         /// Populates the collection with the SHI and Application Settings 
         /// based on the current codebase.
         /// </summary>
         [System.Diagnostics.DebuggerNonUserCode()]
         public void GetSettings()
         {
            //If the settings collection is not populated, populate it.
            if (base.Count == 0)
            {
               //Validate the codebase and get the current Codebase.
               CodeBases codebase = validateCodebase();

               //Load the config settings from the .Config file.
               SHI.WebTeam.Common.ConfigurationManager.ShiConfiguration ConfigSettings =
                  SHI.WebTeam.Common.ConfigurationManager.ShiConfiguration.GetConfig();

               //Only populate if the section exists.
               if (ConfigSettings != null)
               {
                  //Add the setting for the current machine's codebase to the 
                  //settings collection. Current Codebases values are "Production"
                  //and "Development". The validateCodebase method inforces this.
                  for (int i = 0; i < ConfigSettings.shiSettings.Count; i++)
                  {
                     if (ConfigurationSettings.CodeBase == CodeBases.Production)
                     {
                        base.Add(ConfigSettings.shiSettings[i].Key,
                            ConfigSettings.shiSettings[i].Prod);
                     }
                     else if (ConfigurationSettings.CodeBase == CodeBases.Development)
                     {
                        base.Add(ConfigSettings.shiSettings[i].Key,
                            ConfigSettings.shiSettings[i].Dev);
                     }
                     else
                     {
                        throw new Exception("The configured codebase value is " +
                           "not currently implemented.");
                     }
                  }
               }

               // Load System.ConfigurationManager.AppSettings for all settings
               // not loaded in the SHI Configuration Setting Section.
               NameValueCollection appSettings = 
                  System.Configuration.ConfigurationManager.AppSettings;
               for (int i = 0; i < appSettings.Count; i++)
               {
                  string key = appSettings.Keys[i];

                  //If the Key does not exist in the SHI settings add it.
                  if (base[key] == null)
                  {
                     base.Add(key, appSettings[i]);
                  }
               }
            }
         }
         #region Overrides
         /// <summary>
         /// This configuration is read only and calling this method will throw an exception.
         /// </summary>
         [System.Diagnostics.DebuggerNonUserCode()]
         public override void Clear()
         {
            throw new Exception("The configuration is read only.");
         }
         /// <summary>
         /// This configuration is read only and calling this method will throw an exception.
         /// </summary>
         [System.Diagnostics.DebuggerNonUserCode()]
         public override void Add(string name, string value)
         {
            throw new Exception("The configuration is read only.");
         }
         /// <summary>
         /// This configuration is read only and calling this method will throw an exception.
         /// </summary>
         [System.Diagnostics.DebuggerNonUserCode()]
         public override void Remove(string name)
         {
            throw new Exception("The configuration is read only.");
         }
         /// <summary>
         /// This configuration is read only and calling this method will throw an exception.
         /// </summary>
         [System.Diagnostics.DebuggerNonUserCode()]
         public override void Set(string name, string value)
         {
            throw new Exception("The configuration is read only.");
         }
         #endregion
      }
      #endregion
   }
}