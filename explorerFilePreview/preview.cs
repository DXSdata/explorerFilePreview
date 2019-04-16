using SharpShell.Attributes;
using SharpShell.Diagnostics;
using SharpShell.SharpPreviewHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace explorerFilePreview
{
    [ComVisible(true)]
    //[COMServerAssociation(AssociationType.ClassOfExtension, ".asdf")]
    //[COMServerAssociation(AssociationType.AllFiles)]
    //[COMServerAssociation(AssociationType.FileExtension, ".asdf")]
    [COMServerAssociation(AssociationType.FileExtension, ".eml")]
    [COMServerAssociation(AssociationType.FileExtension, ".msg")]
    [DisplayName("Icon Preview Handler")]
    [PreviewHandler(SurrogateHostType = SurrogateHostType.Prevhost)]
    public class preview : SharpPreviewHandler
    {

        protected override PreviewHandlerControl DoPreview()
        {
            var handler = new previewForm();

            try
            {
                handler.SetFile(SelectedFilePath);
            }
            catch(Exception ex)
            {
                Logging.Error("Error: " + ex.Message);
            }

            return handler;
        }

    }
}
