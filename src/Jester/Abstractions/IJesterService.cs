using System.IO.Pipelines;

namespace Jester.Abstractions;

public interface IJesterService
{
    Task IngestAsync(
        //TODO: Maybe make this a stream, but load it into a pipe reader.
        PipeReader pipeReader,
        CancellationToken cancellationToken);
}