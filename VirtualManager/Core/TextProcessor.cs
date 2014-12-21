using System;

namespace VirtualManager.Core {
    public static class TextProcessor {

        /// <summary>
        /// Create image name with extension.
        /// </summary>
        /// <param name="fileName">Filename without ext. Only filename</param>
        /// <param name="imgType">Image type extension</param>
        /// <returns>Image name with extension</returns>
        public static string CreateImageName(string fileName, ImageType imgType) {
            try {
                string extension = string.Empty;
                ConvertEnumExtToString(imgType, out extension);
                return String.Concat(fileName, extension);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }                     
        }

        /// <summary>
        /// Generate file name with datetime and guid
        /// </summary>
        /// <param name="context">Original file name</param>
        /// <returns></returns>
        public static string GenerateFileName(string context, ImageType imgType) {
            string ext = string.Empty;
            Core.TextProcessor.ConvertEnumExtToString(imgType, out ext);
            return context.ToUpper() + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N") + ext.ToLower();
        }

        /// <summary>
        /// Convert enum to string extension
        /// </summary>
        /// <param name="imgType">Img type ext</param>
        /// <param name="ext">Out param extension</param>
        public static void ConvertEnumExtToString(ImageType imgType, out string ext) {            
            switch (imgType) {
                case ImageType.JPEG:
                    ext = ".jpg";
                    break;
                case ImageType.PNG:
                    ext = ".png";
                    break;
                case ImageType.TIF:
                    ext = ".tif";
                    break;
                case ImageType.GIF:
                    ext = ".gif";
                    break;
                case ImageType.PDF:
                    ext = ".pdf";
                    break;
                case ImageType.IMG:
                    ext = ".img";
                    break;
                default:
                    ext = ".unknown";
                    break;
            }
        }

        /// <summary>
        /// Get Image type enum from string value
        /// </summary>
        /// <param name="extension">Extension file</param>
        /// <returns>Return imagetype as enum type for image extension</returns>
        public static ImageType ConvertStringToEnum(string extension) {
            ImageType iType;
            string ext = extension.ToLower().Trim().Replace("*", "").Replace(".", "");
            switch (ext) {
                case "jpg":
                    iType = ImageType.JPEG;
                    break;
                case "png":
                    iType = ImageType.PNG;
                    break;
                case "tif":
                    iType = ImageType.TIF;
                    break;
                case "gif":
                    iType = ImageType.GIF;
                    break;
                case "pdf":
                    iType = ImageType.PDF;
                    break;
                case "img":
                    iType = ImageType.IMG;
                    break;
                default:
                    iType = ImageType.unknown;
                    break;
            }
            return iType;
        }
    }
}