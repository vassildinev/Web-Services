namespace StringUtilities.Library
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringService
    {
        [OperationContract]
        int GetOccurrences(string template, string text);
    }
}
