/*********************************************************************
 * Developer     : Dennis Fazekas
 * Email Address : dennis_fazekas@shi.com
 * Date          : September 2007
 * Description   : This class maps the attributes elements in the 
 *                 configuration file.
 * 
 * Changes
 * --------------------------------------------------------------------
 * Date       | Developer       | Description
 * --------------------------------------------------------------------
 * 09/04/2007 | Dennis Fazekas  | Added these comments
 * 09/12/2007 | Dennis Fazekas  | Changed Namespace
**********************************************************************/
using System;

namespace SHI.WebTeam.Common.ConfigurationManager
{
   /// <summary>
   /// This class represents the structure of the SHI settings structure 
   /// in the WebConfig.Conf or App.Conf. These are the attributes.
   /// </summary>
   public class ShiSettingElements : System.Configuration.ConfigurationElement
   {
      /// <summary>
      /// Returns the key value.
      /// </summary>
      [System.Configuration.ConfigurationProperty("key", IsRequired = true)]
      public string Key
      {
         get
         {
            return this["key"] as string;
         }
      }
      /// <summary>
      /// Returns the setting value for the production environment.
      /// </summary>
      [System.Configuration.ConfigurationProperty("prod", IsRequired = true)]
      public string Prod
      {
         get
         {
            return this["prod"] as string;
         }
      }
      /// <summary>
      /// Returns the setting value for the development environment.
      /// </summary>
      [System.Configuration.ConfigurationProperty("dev", IsRequired = true)]
      public string Dev
      {
         get
         {
            return this["dev"] as string;
         }
      }
      /// <summary>
      /// Returns the setting description.
      /// </summary>
      [System.Configuration.ConfigurationProperty("desc", IsRequired = false)]
      public string Desc
      {
         get
         {
            return this["desc"] as string;
         }
      }
   }
}