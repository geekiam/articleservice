namespace Strategies;

public interface IStrategy<in TRequest, TResult> 
    where TResult : class
    where TRequest : class

{
    Task<TResult> Execute(TRequest request, CancellationToken cancellationToken);
}