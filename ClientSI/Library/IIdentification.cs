using ClientSI.Requests;
using ClientSI.Responses;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ClientSI.Library
{
    public interface IIdentification
    {
        Task<ConcurrentDictionary<string, IdentificationResponse>> IdentifyAsync(IdentificationRequest request);
    }
}
