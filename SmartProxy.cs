namespace PROXY_PATTERN;

public interface IFile
{
    FileStream OpenStream(string path);
}
public class DefaultFile : IFile
{
    public FileStream OpenStream(string path)
    {
        return File.Open(path, FileMode.Open);
    }
}

public class SmartProxyFile : IFile
{
    private Dictionary<string, FileStream> _streams = new();
    public FileStream OpenStream(string path)
    {
        try
        {
            var stream = File.Open(path, FileMode.Open);
            _streams.Add(path, stream);
            return stream;
        }
        catch (Exception ex)
        {
            if (_streams.Keys.Contains(path))
            {
                var stream = _streams.FirstOrDefault(x => x.Key.Equals(path));

                if (stream.Value != null && stream.Value.CanWrite)
                {
                    return stream.Value;
                }
            }

            throw new Exception(ex.Message);
        }
    }
}