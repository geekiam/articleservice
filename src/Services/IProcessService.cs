namespace Services;

public interface IProcessService<TDomain, TSource> where TDomain : class where TSource: class
{
    Task Process(List<TDomain> items, TSource sourceId);
}