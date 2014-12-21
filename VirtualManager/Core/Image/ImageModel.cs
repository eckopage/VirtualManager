using System;

namespace VirtualManager.Core.Image {
    public class ImageModel {

        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public int Size { get; set; }
        public ImageType ImgType { get; set; }
        public DateTime Created { get; set; }
    }
}