using System.IO.Pipelines;

namespace Jester.Abstractions;

public record Response(
    string Id
);
public interface IJesterService
{
    Task<Response> IngestAsync(
        FileStream fileStream,
        CancellationToken cancellationToken)
    {
        var pipeReader = PipeReader.Create(fileStream);
        return IngestAsync(pipeReader, cancellationToken);
    }

    Task<Response> IngestAsync(
        //TODO: Maybe make this a stream, but load it into a pipe reader.
        PipeReader pipeReader,
        CancellationToken cancellationToken);
}