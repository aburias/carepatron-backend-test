using application.Abstractions;

namespace infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IEmailRepository emailRepo;
        private readonly IDocumentRepository docuRepo;

        public ClientService(IEmailRepository emailRepo, IDocumentRepository docuRepo)
        {
            this.emailRepo = emailRepo;
            this.docuRepo = docuRepo;
        }
        public async Task NotifyClient(string email)
        {
            // TODO: this could be send in Service bus as SQS to retry when failing...
            await this.emailRepo.Send(email, "Hi there - welcome to my Carepatron portal.");
            await this.docuRepo.SyncDocumentsFromExternalSource(email);
        }
    }
}
