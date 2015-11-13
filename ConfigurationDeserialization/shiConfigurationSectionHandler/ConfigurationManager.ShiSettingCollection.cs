/*********************************************************************
 * Developer     : Dennis Fazekas
 * Email Address : dennis_fazekas@shi.com
 * Date          : September 2007
 * Description   : This class is the collection of settings loaded
 *                 from the WebConfig.Conf or App.Conf.
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
   public class ShiSettingCollection : 
      System.Configuration.ConfigurationElementCollection
   {
      public ShiSettingElements this[int index]
      {
         get
         {
            return base.BaseGet(index) as ShiSettingElements;
         }
         set
         {
            if (base.BaseGet(index) != null)
            {
               base.BaseRemoveAt(index);
            }
            this.BaseAdd(index, value);
         }
      }

      protected override System.Configuration.ConfigurationElement CreateNewElement()
      {
         return new ShiSettingElements();
      }

      protected override object GetElementKey(System.Configuration.ConfigurationElement element)
      {
         return ((ShiSettingElements)element).Key;
      }
   }
}