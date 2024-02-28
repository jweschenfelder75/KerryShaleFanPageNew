using System;

namespace de.jweschenfelder.KSFP.Shared.Objects
{
    [Serializable]
    public class GalleryItemDto
    {
        public string? ImageSrc { get; set; }

        public string? ImageAltEn { get; set; }

        public string? ImageAltDe { get; set; }

        public string? ImageCredits { get; set; }
    }
}
