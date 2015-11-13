/*********************************************************************
 * Developer     : Dennis Fazekas
 * Email Address : dennis_fazekas@shi.com
 * Date          : September 2007
 * Description   : 
 * 
 * Changes
 * --------------------------------------------------------------------
 * Date       | Developer       | Description
 * --------------------------------------------------------------------
 * 09/04/2007 | Dennis Fazekas  | Added these comments
 * 09/12/2007 | Dennis Fazekas  | Changed Namespace
**********************************************************************/


namespace SHI.WebTeam.Common.ConfigurationManager
{
    /// <summary>
    /// This class is actually what loads the custom settings.
    /// </summary>
    public class ShiConfiguration : System.Configuration.ConfigurationSection
    {
        private static string sConfigurationSectionConst = "shiConfiguration";

        /// <summary>
        /// Returns an shiConfiguration instance
        /// </summary>
        public static ShiConfiguration GetConfig()
        {

            return (ShiConfiguration)System.Configuration.ConfigurationManager.
               GetSection(ShiConfiguration.sConfigurationSectionConst) ??
               new ShiConfiguration();

        }
        [System.Configuration.ConfigurationProperty("shiSettings")]
        public ShiSettingCollection shiSettings
        {
            get
            {
                return (ShiSettingCollection)this["shiSettings"] ??
                   new ShiSettingCollection();
            }
        }
    }
}