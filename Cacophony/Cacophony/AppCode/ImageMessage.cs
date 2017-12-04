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

        public ImageMessage(int userID, byte[] imageData, string fileExtension) : base(userID)
        {
            this.imageData = imageData;
            this.fileExtension = fileExtension;
        }

        //Function to return image.
    }
}
