using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixSubAlignment
{
    public class FixSub : SelectedFolder
    {
        public static string? subFile = null;
        public static void ChangeFileAlignment()
        {
            SelectFolder();
            if(subFile != null)
            {
                string text = File.ReadAllText(subFile);
                if (text.Contains("align:start"))
                {
                    text = text.Replace("align:start", "align:center");
                    File.WriteAllText(subFile, text);
                    MessageBox.Show("Done!",
                        "Success!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.ServiceNotification); // Gives focus to the message.
                }
                else
                {
                    MessageBox.Show("This subtitle file has already been modified.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }
            else
            {
                return;
            }
        }
    }
}
