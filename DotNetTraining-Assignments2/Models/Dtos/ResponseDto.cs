namespace DotNetTraining_Assignments2.Models.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
