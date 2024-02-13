using MathApi.Services.Interfaces;

namespace MathApi.Services;

public class MathService : IMathService
{
    public ValueTask<long> AddAsync(long a, long b, CancellationToken cancellationToken = default)
    {
        var result = checked(a + b);
        return ValueTask.FromResult(result);
    }
}