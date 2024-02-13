namespace MathApi.Services.Interfaces;

public interface IMathService
{
    ValueTask<long> AddAsync(long a, long b, CancellationToken cancellationToken = default);
}