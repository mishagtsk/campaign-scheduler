namespace CampaignScheduler.CampaignSender.Processors
{
    public class FileProcessor : IFileProcessor
    {
        public async Task<string?> ReadAllTextAsync(string path, CancellationToken cancellationToken)
        {
            return await File.ReadAllTextAsync(path, cancellationToken);
        }

        public async Task AppendAllTextAsync(string fileToWrite, string content, CancellationToken cancellationToken)
        {
            await File.AppendAllTextAsync(fileToWrite, content, cancellationToken);
        }

        public void CreateDirectory(string directory)
        {
            Directory.CreateDirectory(directory);
        }

        public void CreateFile(string filePath)
        {
            File.Create(filePath).Close();
        }
    }
}
