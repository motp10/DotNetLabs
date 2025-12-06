using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public CommandResultType Delete(string fileName)
    {
        File.Delete(fileName);
        return new CommandResultType.Succes();
    }

    public CommandResultType Move(string sourceFile, string destinationFile)
    {
        File.Move(sourceFile, destinationFile);
        return new CommandResultType.Succes();
    }

    public CommandResultType Copy(string sourceFile, string destinationFile)
    {
        File.Copy(sourceFile, destinationFile);
        return new CommandResultType.Succes();
    }

    public CommandResultType Rename(string path, string name)
    {
        string? parentDir = Path.GetDirectoryName(path);
        string targetPath = Path.Combine(parentDir ?? string.Empty, name);

        File.Move(path, targetPath);
        return new CommandResultType.Succes();
    }

    public string GetFileText(string path)
    {
        throw new NotImplementedException();
    }

    public bool IsExist(string fileName)
    {
        return File.Exists(fileName);
    }

    public bool IsInRoot(string path, string absolutePath)
    {
        var validator = new Validator();
        return validator.IsValidPath(path, absolutePath);
    }

    public string ResolvePath(string path, string currentPath)
    {
        var resolver = new Resolver();
        return resolver.Resolve(path, currentPath);
    }

    public bool IsAbsolutePath(string path)
    {
        return path[0] == '/';
    }

    public string Combine(string absolutePath, string inputPath)
    {
        return Path.Combine(absolutePath, inputPath);
    }

    public IComponentsIterator GetIterator(string root)
    {
        return new LocalFileSystemComponentsIterator(root);
    }

    private sealed class Validator
    {
        public bool IsValidPath(string path, string currentDirectory)
        {
            string fullPath = Path.GetFullPath(path);
            string fullRoot = Path.GetFullPath(currentDirectory);

            string[] pathParts = fullPath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .Where(p => p.Length > 0)
                .ToArray();
            string[] rootParts = fullRoot.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .Where(p => p.Length > 0)
                .ToArray();

            if (rootParts.Length > pathParts.Length)
                return false;

            for (int i = 0; i < rootParts.Length; i++)
            {
                if (rootParts[i] != pathParts[i])
                    return false;
            }

            return true;
        }
    }

    private sealed class Resolver
    {
        public string Resolve(string inputPath, string localPath)
        {
            string result = ConcatWithCurrentPath(localPath, inputPath);
            return Path.GetFullPath(result);
        }

        private string ConcatWithCurrentPath(string currentPath, string inputPath)
        {
            var inputPathSegments = new List<string>(inputPath.Split(Path.DirectorySeparatorChar));
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
    }

    private class LocalFileSystemComponentsIterator : IComponentsIterator
    {
        private readonly string _rootPath;
        private readonly IEnumerator<IFileSystemComponent> _enumerator;

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