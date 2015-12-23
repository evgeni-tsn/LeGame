namespace LeGame.Handlers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class FileHandler
    {
        private static readonly string[] FoldersToAvoid = { "bin", "obj", "Maps", "Font" };

        // Recursively get the files in Content.
        public static void GetFilenames(string sourceDir, IList<string> fileNames)
        {
            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                if (!FoldersToAvoid.Any(dir.Contains))
                {
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        fileNames.Add(file);
                    }
                }

                GetFilenames(dir, fileNames);
            }
        }

        public static List<string> ReadMapFile(string textFilePath)
        {
            if (!File.Exists(textFilePath))
            {
                throw new FileNotFoundException(
                    "The supplied file path \"{0}\" for the tile builder is invalid.", 
                    textFilePath);
            }

            return File.ReadAllLines(textFilePath).ToList();
        }
    }
}