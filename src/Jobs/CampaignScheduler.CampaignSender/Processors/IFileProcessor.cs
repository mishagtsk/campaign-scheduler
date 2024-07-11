namespace CampaignScheduler.CampaignSender.Processors
{
    public interface IFileProcessor
    {
        Task<string?> ReadAllTextAsync(string path, CancellationToken cancellationToken);
        Task AppendAllTextAsync(string fileToWrite, string content, CancellationToken cancellationToken);
        void CreateDirectory(string directory);
        void CreateFile(string filePath);
    }
}
