
namespace VirtualManager.Core.Image {
    using System.IO;
    using System.Linq;

    public class ImageProcessor<T> where T: ImageModel {

        public string ImageRepositoryPath{ get; set; }
        public string ImageFullName { get; set; }
        
        /// <summary>
        /// Save object to repository (physically file, NOT DATABASE)
        /// </summary>
        /// <param name="obj">Object</param>
        public void Save(T obj){
            this.CheckRepository();
            ImageFullName = TextProcessor.CreateImageName(obj.ImageName, obj.ImgType);          
        }

        /// <summary>
        /// Get saved file from phisical disk.
        /// </summary>
        /// <param name="uniqueImageName">Unique name as guid name etc. 342343-4234-234-23-423</param>
        /// <param name="imgType">Image extension type</param>
        /// <returns>Returns FileInfo object</returns>
        public FileInfo Get(string uniqueImageName, ImageType imgType) {
            this.CheckRepository();
            var dir = new DirectoryInfo(ImageRepositoryPath);
            var fFile = dir.GetFiles(uniqueImageName, SearchOption.TopDirectoryOnly).FirstOrDefault(f => f.Name == TextProcessor.CreateImageName(uniqueImageName, imgType));         
            return fFile;
        }

        /// <summary>
        /// Delete image file from disk.
        /// </summary>
        /// <param name="uniqueImageName">Unique name as guid name</param>
        /// <param name="imgType">Image extension type</param>
        public void Delete(string uniqueImageName, ImageType imgType) {
            Get(uniqueImageName, imgType).Delete();
        }

        /// <summary>
        /// Check if repository exists.
        /// </summary>
        /// <returns>Return true if exist</returns>
        private bool CheckRepository() {
            var exist = false;
            if (Directory.Exists(ImageRepositoryPath)) {
                exist = true;
            }
            else {
                Directory.CreateDirectory(ImageRepositoryPath);
            }
            return exist;
        }   
    }
}