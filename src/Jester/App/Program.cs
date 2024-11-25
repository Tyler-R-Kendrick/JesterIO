
using System.Diagnostics;
using System.IO.Pipelines;
using CommunityToolkit.Diagnostics;
using Jester.Abstractions;
using MassTransit;

class JesterListener(IBus busControl) : IJesterService
{
    public async Task<Jester.Abstractions.Response> IngestAsync(
        PipeReader pipeReader,
        CancellationToken cancellationToken)
    {
        ActivitySource activitySource = new("JesterListener");
        using var activity = activitySource.StartActivity("IngestAsync");
        Guard.IsNotNull(activity, nameof(activity));
        Guard.IsNotNull(activity.Id, nameof(activity.Id));

        pipeReader.AdvanceTo(await pipeReader.ReadAsync(cancellationToken));
        busControl.Publish()

        return new(activity.Id);
    }
}

// Expose ingestion endpoint.
// Use endpoint function to coordinate routing slip.
// State should be updated after each step.
// steps are broadcast with scatter-gather.

// Step listeners conform to specific interface.
// Step listeners either transform the message or persist it.
// All step listeners implement an acknowledgement pattern.
