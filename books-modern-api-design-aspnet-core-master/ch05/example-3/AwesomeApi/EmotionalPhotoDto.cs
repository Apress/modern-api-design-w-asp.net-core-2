using Microsoft.AspNetCore.Mvc;

namespace AwesomeApi
{
    [ModelBinder(typeof(AwesomeModelBinder))]
    public class EmotionalPhotoDto
    {
        public byte[] Contents { get; set; }
        public EmotionScoresDto Scores { get; set; }
    }
}
