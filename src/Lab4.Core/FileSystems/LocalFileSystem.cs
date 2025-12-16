using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public FileSystemResultType Delete(string fileName)
    {
        File.Delete(fileName);
        return new FileSystemResultType.Succes();
    }

    public FileSystemResultType Move(string sourceFile, string destinationFile)
    {
        File.Move(sourceFile, destinationFile);
        return new FileSystemResultType.Succes();
    }

    public FileSystemResultType Copy(string sourceFile, string destinationFile)
    {
        File.Copy(sourceFile, destinationFile);
        return new FileSystemResultType.Succes();
    }

    public FileSystemResultType Rename(string path, string name)
    {
        string? parentDir = Path.GetDirectoryName(path);
        string targetPath = Path.Combine(parentDir ?? string.Empty, name);

        File.Move(path, targetPath);
        return new FileSystemResultType.Succes();
    }

    public string GetFileText(string path)
    {
        return File.ReadAllText(path);
    }

    public bool IsExist(string fileName)
    {
        return Directory.Exists(fileName);
    }

    public string ResolvePath(string path, string currentPath)
    {
        var inputPathSegments = new List<string>(path.Split(Path.DirectorySeparatorChar));
        var currentPathSegments = new List<string>(currentPath.Split(Path.DirectorySeparatorChar));

        foreach (string segment in inputPathSegments)
        {
            if (segment == "..")
            {
                if (currentPathSegments.Count > 0) currentPath.Remove(currentPath.Last());
                break;
            }

            if (segment != "." && segment != "..")
            {
                currentPathSegments.Add(segment);
            }
        }

        return "/" + string.Join("/", currentPathSegments);
    }

    public bool IsAbsolutePath(string path)
    {
        return Path.IsPathFullyQualified(path);
    }

    public string Combine(string absolutePath, string inputPath)
    {
        return Path.Combine(absolutePath, inputPath);
    }

    public IComponentsIterator GetIterator(string root)
    {
        return new LocalFileSystemComponentsIterator(root);
    }

    public bool IsName(string name)
    {
        if (name.Contains('/', StringComparison.Ordinal) || name.Contains('.', StringComparison.Ordinal)) return false;
        return true;
    }

    private class LocalFileSystemComponentsIterator : IComponentsIterator
    {
        private readonly string _rootPath;
        private readonly IEnumerator<IFileSystemComponent> _enumerator;

        public int Depth { get; private set; } = 0;

        public LocalFileSystemComponentsIterator(string rootPath)
        {
            _rootPath = rootPath;
            _enumerator = GetComponentsEnumerator().GetEnumerator();
        }

        public bool HasNextcomponent()
        {
            return _enumerator.MoveNext();
        }

        public IFileSystemComponent GetNextComponent()
        {
            return _enumerator.Current;
        }

        private IEnumerable<IFileSystemComponent> GetComponentsEnumerator()
        {
            var rootDir = new DirectoryInfo(_rootPath);
            yield return CreateComponent(rootDir);

            var stack = new Stack<DirectoryInfo>();
            stack.Push(rootDir);
            while (stack.Count > 0)
            {
                ++Depth;
                DirectoryInfo currentDir = stack.Pop();

                foreach (FileInfo file in currentDir.GetFiles())
                {
                    yield return CreateComponent(file);
                }

                foreach (DirectoryInfo subDir in currentDir.GetDirectories())
                {
                    yield return CreateComponent(subDir);
                    stack.Push(subDir);
                }
            }
        }

        private IFileSystemComponent CreateComponent(FileSystemInfo item)
        {
            if (item is DirectoryInfo)
            {
                return new DirectoryFileSystemComponent(item.Name, this);
            }
            else
            {
                return new FileFileSystemComponent(item.Name);
            }
        }
    }
}