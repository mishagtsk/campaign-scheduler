﻿using CampaignScheduler.Data.Repositories;
using CampaignScheduler.Models;
using System.Reflection;

namespace CampaignScheduler.CampaignSender.Processors
{
    public class CampaignProcessor : ICampaignProcessor
    {
        private readonly string _templatesDirectory;

        private readonly ICampaignsRepository _campaignsRepository;
        private readonly IFileProcessor _fileProcessor;

        public CampaignProcessor(ICampaignsRepository campaignsRepository, IFileProcessor fileProcessor)
        {
            _campaignsRepository = campaignsRepository;
            _fileProcessor = fileProcessor;
            _templatesDirectory = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)}/Templates";
        }

        public async Task ProcessAsync(Campaign? campaign, string fileToWrite, CancellationToken cancellationToken)
        {
            if (campaign == null)
            {
                return;
            }

            var content = await _fileProcessor.ReadAllTextAsync(BuildTemplateFilePath(campaign.Template), cancellationToken);
            await _fileProcessor.AppendAllTextAsync(fileToWrite, GetCustomerInfo(campaign) + content + Environment.NewLine,
                cancellationToken);
            
            campaign.IsSent = true;
            campaign.Customer.CampaignSentDate = DateTime.Now;

            await _campaignsRepository.UpdateCampaign(campaign, cancellationToken);
        }

        private string BuildTemplateFilePath(string templateName)
        {
            return $"{_templatesDirectory}/{templateName}.html";
        }

        private string GetCustomerInfo(Campaign campaign)
        {
            return $"Customer Id {campaign.Customer.Id}";
        }
    }
}
