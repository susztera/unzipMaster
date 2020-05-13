using System;
using System.Linq;
using System.IO.Compression;
using System.IO;

namespace unzipMasterGUId
{
    static class ZipFileWithProgress
    {
        public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, IProgress<double> progress)
        {
            using (ZipArchive archive = ZipFile.OpenRead(sourceArchiveFileName))
            {
                double totalBytes = archive.Entries.Sum(e => e.Length);
                long currentBytes = 0;

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (string.IsNullOrEmpty(entry.Name)) { 
                        string dirName = Path.Combine(destinationDirectoryName, entry.FullName.TrimEnd('/'));
                        if (Directory.Exists(dirName)) 
                            Directory.CreateDirectory(dirName);
                        continue; }
                    string fileName = Path.Combine(destinationDirectoryName, entry.FullName);

                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                    using (Stream inputStream = entry.Open())
                    using (Stream outputStream = File.OpenWrite(fileName))
                    {
                        Stream progressStream = new StreamWithProgress(outputStream, null,
                            new BasicProgress<int>(i =>
                            {
                                currentBytes += i;
                                progress.Report(currentBytes / totalBytes);
                            }));

                        inputStream.CopyTo(progressStream);
                    }

                    File.SetLastWriteTime(fileName, entry.LastWriteTime.LocalDateTime);
                }
            }
        }
    }
}
