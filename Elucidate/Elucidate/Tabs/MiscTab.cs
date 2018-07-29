using System;
using System.Text;
using System.Windows.Forms;

namespace GUIUtils
{
   public partial class MiscTab : UserControl
   {

      public MiscTab()
      {
         InitializeComponent();
      }

      public Elucidate.Elucidate Elucidate { get; set; }


      public void EnableIfValid(bool enabled)
      {
         btnScrub.Enabled = enabled;
         btnFix.Enabled = enabled;
         btnDupFinder.Enabled = enabled;
         btnUndelete.Enabled = enabled;
      }

      private void btnScrub_Click(object sender, EventArgs e)
      {
         StringBuilder command = new StringBuilder(@"scrub ");
         command.Append(!string.IsNullOrWhiteSpace(txtAddCommands.Text) ? txtAddCommands.Text : @"-p100 -o0");
         Elucidate.StartSnapRaidProcess(command.ToString());
      }



      private void btnFix_Click(object sender, EventArgs e)
      {
         StringBuilder command = new StringBuilder(@"fix ");
         command.Append(!string.IsNullOrWhiteSpace(txtAddCommands.Text) ? txtAddCommands.Text : @"-e");
         Elucidate.StartSnapRaidProcess(command.ToString());
      }

      private void btnDupFinder_Click(object sender, EventArgs e)
      {
         Elucidate.StartSnapRaidProcess(@"dup");
      }

      private void btnUndelete_Click(object sender, EventArgs e)
      {
         StringBuilder command = new StringBuilder(@"fix ");
         command.Append(!string.IsNullOrWhiteSpace(txtAddCommands.Text) ? txtAddCommands.Text : @"-m");
         Elucidate.StartSnapRaidProcess(command.ToString());
      }
   }
}
