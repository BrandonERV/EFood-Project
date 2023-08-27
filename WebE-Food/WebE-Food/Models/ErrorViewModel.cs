namespace WebE_Food.Models
{
    public class ErrorViewModel
    {
        //Mariano
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}