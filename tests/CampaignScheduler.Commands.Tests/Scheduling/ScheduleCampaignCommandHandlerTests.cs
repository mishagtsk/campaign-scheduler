using CampaignScheduler.Commands.Scheduling;
using CampaignScheduler.Contracts.Scheduling;
using CampaignScheduler.Data.Repositories;
using CampaignScheduler.Models;
using CampaignScheduler.Tests.Common.Fakers;
using Moq;

namespace CampaignScheduler.Commands.Tests.Scheduling
{
    public class ScheduleCampaignCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock = new();
        private readonly Mock<ICampaignsRepository> _campaignsRepositoryMock = new();

        private readonly ScheduleCampaignCommandHandler _handler;
        public ScheduleCampaignCommandHandlerTests()
        {
            _handler = new ScheduleCampaignCommandHandler(_customerRepositoryMock.Object,
                _campaignsRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldSaveCampaign()
        {
            // Arrange
            var expectedCampaignContract = ContractsCampaignDtoFaker.Default.Generate();
            var expectedCustomers = new List<Customer> { new() };

            var expectedCampaign = new Campaign
            {
                IsSent = false,
                Customer = expectedCustomers.First(),
                Priority = expectedCampaignContract.Priority,
                TimeToSend = expectedCampaignContract.TimeToSend,
                Template = expectedCampaignContract.Template
            };
            
            var request = new ScheduleCampaignCommand
            {
                Campaigns = new List<CampaignDto> { expectedCampaignContract }
            };

            _customerRepositoryMock.Setup(r => r.FilterCustomers(
                    expectedCampaignContract.CustomerOptions!.Gender,
                    expectedCampaignContract.CustomerOptions.MinimalAge,
                    expectedCampaignContract.CustomerOptions.City,
                    expectedCampaignContract.CustomerOptions.MinimalDeposit,
                    expectedCampaignContract.CustomerOptions.IsNemCustomer, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedCustomers);

            // Act
            await _handler.Handle(request, CancellationToken.None);

            // Assert
            _campaignsRepositoryMock.Verify(
                r => r.AddCampaigns(
                    It.Is<ICollection<Campaign>>(c => VerifyCampaigns(c.Single(), expectedCampaign)),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        private bool VerifyCampaigns(Campaign incoming, Campaign expected)
        {
            return incoming.IsSent == expected.IsSent
                   && incoming.Priority == expected.Priority
                   && incoming.TimeToSend == expected.TimeToSend
                   && incoming.Template == expected.Template;
        }
    }
}
