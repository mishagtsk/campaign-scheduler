using CampaignScheduler.CampaignSender.Processors;
using CampaignScheduler.Data.Repositories;
using CampaignScheduler.Models;
using Moq;

namespace CampaignScheduler.CampaignSender.Tests.Processors
{
    public class CampaignProcessorTests
    {
        private readonly Mock<ICampaignsRepository> _campaignsRepositoryMock = new();
        private readonly Mock<IFileProcessor> _fileProcessorMock = new();

        private readonly CampaignProcessor _processor;

        private readonly string _fileToWrite = @"test/test.txt";
        private readonly Campaign _campaign;

        public CampaignProcessorTests()
        {
            _processor = new CampaignProcessor(_campaignsRepositoryMock.Object, _fileProcessorMock.Object);

            _campaign = new Campaign
            {
                Customer = new Customer()
            };
        }

        [Fact]
        public async Task ProcessAsync_ShouldNotExecute_WhenCampaignIsNull()
        {
            // Arrange

            // Act
            await _processor.ProcessAsync(null, _fileToWrite, CancellationToken.None);

            // Assert
            _fileProcessorMock.VerifyNoOtherCalls();
            _campaignsRepositoryMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ProcessAsync_ShouldProcessCampaign()
        {
            // Arrange
            var expectedFileContent = "content";
            _campaign.IsSent = false;
            _campaign.Customer.CampaignSentDate = null;
            
            _fileProcessorMock.Setup(p => p.ReadAllTextAsync(_fileToWrite, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedFileContent);

            // Act
            await _processor.ProcessAsync(_campaign, _fileToWrite, CancellationToken.None);

            // Assert
            _fileProcessorMock.Verify(
                p => p.AppendAllTextAsync(_fileToWrite, It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);

            _campaignsRepositoryMock.Verify(
                r => r.UpdateCampaign(It.Is<Campaign>(c => c.IsSent == true && c.Customer.CampaignSentDate != null),
                    It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
