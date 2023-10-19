namespace DotnetAngular.Dto
{
    [Serializable]
    public class FileUploadDto
    {
        public string Default { get; set; }
        public bool Uploaded { get; set; }
        public string Url { get; set; }
    }
}
