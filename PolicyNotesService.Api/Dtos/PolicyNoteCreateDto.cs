namespace PolicyNotesService.Api.Dtos
{
    public class PolicyNoteCreateDto
    {
        public string PolicyNumber { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}
