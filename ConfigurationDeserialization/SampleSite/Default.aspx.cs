using System.Collections.Specialized;
using System.Text;
using System.Web;
using SHI.WebTeam.Common.Configuration;
using SHI.WebTeam.Common.ConfigurationManager;

public partial class _Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, System.EventArgs e)
   {
      StringBuilder html = new StringBuilder();

      html.Append("<table border=\"1\">" + 
         "<tr><td colspan=\"4\"><b>SHI Configuration Settings</b></td></tr>" +
         "<tr ><td><b>Key</b></td><td><b>Development</b></td><td><b>Production</b>" +
         "</td><td><b>Description</b></td></tr>"
         );

      // This is an example of how to retrieve the shiConfiguration directly.
      ShiConfiguration config = ShiConfiguration.GetConfig();
      for (int i = 0; i < config.shiSettings.Count; i++)
      {
         html.Append("<tr>");
         html.Append("<td>" + config.shiSettings[i].Key + "</td>");
         html.Append("<td>" + config.shiSettings[i].Dev + "</td>");
         html.Append("<td>" + config.shiSettings[i].Prod + "</td>");
         html.Append("<td>" + config.shiSettings[i].Desc + "</td>");
         html.Append("</tr>");
      }
      html.Append("</table><br><hr>");

      html.Append("<table border=\"1\">" +
         "<tr><td colspan=\"2\"><b>SHI Configuration Settings for " +
         "<b>" + ConfigurationSettings.CodeBase.ToString() + 
         "</b></td></tr>" +
         "<tr ><td><b>Key</b></td><td><b>Value</b></td></tr>"
         );

      // This is an example of how to retrieve all settings 
      // in the SHI.WebTeam.Common.Configuration.ConfigurationSettings.AppSettings collection.
      NameValueCollection appSettingCollection = 
         ConfigurationSettings.AppSettings;

      for (int i = 0; i < appSettingCollection.Count; i++)
      {
         html.Append("<tr>");
         html.Append("<td>" + appSettingCollection.GetKey(i) + "</td>");
         html.Append("<td>" + appSettingCollection[i] + "</td>");
         html.Append("</tr>");
      }
      html.Append("</table><br><hr>");

      html.Append("<table border=\"1\">" +
      "<tr><td colspan=\"2\"><b>AppSettings Configuration Settings</b></td></tr>" +
      "<tr ><td><b>Key</b></td><td><b>Value</b></td></tr>"
      );

      // This is an example of how to retrieve all AppSettings
      appSettingCollection = System.Configuration.ConfigurationManager.AppSettings;
      for (int i = 0; i < appSettingCollection.Count; i++)
      {
         html.Append("<tr>");
         html.Append("<td>" + appSettingCollection.GetKey(i) + "</td>");
         html.Append("<td>" + appSettingCollection[i] + "</td>");
         html.Append("</tr>");
      }
      html.Append("</table><br><hr>");
      
      //This is an example of how to retrieve a specific setting
      //using the shi configuration implimentation.
      html.Append("For the current codebase the setting for \"Testing\" is \"" +
         ConfigurationSettings.AppSettings["testing"] + "\".");

      //Check current codebase and execute code if in development codebase.
      if (ConfigurationSettings.CodeBase ==
         SHI.WebTeam.Common.Configuration.Enum.CodeBases.Development)
      { 
         /// Place special code for execution 
         /// if in the development codebase.
      }

      lblInfo.Text = html.ToString();
      lblInfo.Visible = true;
   }
}