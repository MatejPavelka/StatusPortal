namespace StatusPortal.Shared.Dto
{
    public class StatusDto
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
        public bool Sent { get; set; }
        public bool Received { get; set; }
        public LineDto LineDto { get; set; }
        public int LineId { get; set; }
    }
}
