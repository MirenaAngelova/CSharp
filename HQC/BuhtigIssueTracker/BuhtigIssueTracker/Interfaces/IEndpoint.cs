using System.Collections.Generic;

namespace BuhtigIssueTracker.Interfaces
{
    public interface IEndpoint
    {
        string ActionName { get; }

        IDictionary<string, string> Parameters { get; }
    }
}