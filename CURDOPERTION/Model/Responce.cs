namespace CURDOPERTION.Model
{
    public class Responce
    {

        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public HOSPITAL HOSPITAL { get; set; }

        public List<HOSPITAL> HOSPITALList;
    }
}
