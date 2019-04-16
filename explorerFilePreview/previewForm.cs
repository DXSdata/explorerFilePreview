using MimeKit;
using MsgReader;
using MsgReader.Outlook;
using SharpShell.Diagnostics;
using SharpShell.SharpPreviewHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace explorerFilePreview
{
    public partial class previewForm : PreviewHandlerControl
    {

        HtmlPanel htmlPanel;

        public previewForm()
        {
            InitializeComponent();

            htmlPanel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            htmlPanel.Location = new Point(0, labelAttachments.Location.Y + 25);
            htmlPanel.Width = Width;
            htmlPanel.Height = Height;
            htmlPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            Controls.Add(htmlPanel);
        }

        public void SetFile(String file)
        {
            
            if (string.IsNullOrWhiteSpace(file))
            {
                Logging.Error("No filename given.");
                return;
            }

            
            Logging.Log("File name: " + file);

            htmlPanel.Text = "";

            
            if (file.ToLower().EndsWith(".msg"))
            {                
                using (var msg = new Storage.Message(file))
                {
                    labelDate.Text = msg.SentOn.ToString();
                    labelFrom.Text = (msg.Sender != null ? msg.Sender.DisplayName + " <" + msg.Sender.Email + ">" : "");
                    labelTo.Text = msg.GetEmailRecipients(Storage.Recipient.RecipientType.To, false, false);
                    //labelTo.Text += " | " + msg.GetEmailRecipients(Storage.Recipient.RecipientType.Cc, false, false);
                    labelSubject.Text = msg.Subject;
                    labelAttachments.Text = msg.Attachments.Count.ToString();
                    htmlPanel.Text = (string.IsNullOrWhiteSpace(msg.BodyHtml) ? msg.BodyText : msg.BodyHtml);                    
                }               
            }
            if (file.ToLower().EndsWith(".eml"))
            {
                var msg = MimeMessage.Load(file);
                labelDate.Text = msg.Date.ToLocalTime().ToString();
                labelFrom.Text = (msg.From != null ? msg.From.ToString() : "");
                labelTo.Text = (msg.To != null ? msg.To.ToString() : "");
                //labelTo.Text += " | " + msg.Cc.ToString();
                labelSubject.Text = msg.Subject;
                labelAttachments.Text = msg.Attachments.Count().ToString();
                htmlPanel.Text = (string.IsNullOrWhiteSpace(msg.HtmlBody) ? (string.IsNullOrWhiteSpace(msg.TextBody) ? "" : msg.TextBody) : msg.HtmlBody);
            }


        }


        private String getLine(String text, String key)
        {
            foreach(String line in text.Split(Environment.NewLine.ToCharArray()))
            {
                String lineConv = Encoding.UTF8.GetString(Encoding.Default.GetBytes(line));
                if (lineConv.ToLower().StartsWith(key.ToLower()))
                    return lineConv.Substring(key.Length - 1).Trim();
            }
            return "";
        }

    }
}
