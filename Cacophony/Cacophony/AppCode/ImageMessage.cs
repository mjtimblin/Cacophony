using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacophony.AppCode
{
    [Serializable]
    public class ImageMessage : Message
    {
        private byte[] imageData;

        private string fileExtension;

        private string label;

        public ImageMessage(int userID, byte[] imageData, string fileExtension, string label) : base(userID)
        {
            this.imageData = imageData;
            this.fileExtension = fileExtension;
            this.label = label;
        }

        //Function to return image.
    }
}
