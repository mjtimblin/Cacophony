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

        public ImageMessage(int userID, string userAlias, byte[] imageData, string fileExtension) : base(userID, userAlias)
        {
            this.imageData = imageData;
            this.fileExtension = fileExtension;
        }

        public ImageMessage(int userID, string userAlias, int imageID, DateTime postDate, byte[] imageData, string fileExtension) : base(userID, userAlias, imageID, postDate)
        {
            this.imageData = imageData;
            this.fileExtension = fileExtension;
        }

        public byte[] ImageData
        {
            get
            {
                return imageData;
            }
            set
            {
                imageData = value;
            }
        }

        public string FileExtension
        {
            get
            {
                return fileExtension;
            }
            set
            {
                fileExtension = value;
            }
        }

        //Function to return image.
    }
}
