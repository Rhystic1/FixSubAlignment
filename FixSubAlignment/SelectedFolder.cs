using System;
using System.IO;
using System.Windows.Forms;

namespace FixSubAlignment
{
    public class SelectedFolder
    {
        public static void SelectFolder()
        {
            FixSub.subFile = default; // We reset the subFile argument every time to avoid an automatic else. Probably not the best way to do this but it works...
            try
            {
                string text = File.ReadAllText(FixSub.subFile);
            }
            catch (ArgumentNullException)
            {
                OpenFileDialog b = new OpenFileDialog(); // We prompt the user for the correct folder and rerun the logic
                b.Filter = "Subtitle File (*.vtt)|*.vtt";
                if (b.ShowDialog() == DialogResult.OK)
                {
                    FixSub.subFile = b.FileName;
                    return;
                }
                else if (b.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("You need to specify a valid subtitle file to continue.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }
        }
    }
}