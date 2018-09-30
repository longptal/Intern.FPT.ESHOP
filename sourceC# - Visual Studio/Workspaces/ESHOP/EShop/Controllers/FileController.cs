using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    [Route("api/Files")]
    public class FileController : Controller
    {
        [HttpPost, Route("Upload")]
        public bool Upload([FromBody] FileEntity FileEntity)
        {
            if (!FileEntity.Path.StartsWith("/Files"))
                throw new BadRequestException("File path needs start with \"Files\"");
            byte[] stream = Convert.FromBase64String(FileEntity.Content);
            var file = Path.Combine(Directory.GetCurrentDirectory() + FileEntity.Path, FileEntity.FileName);
            System.IO.File.WriteAllBytes(file, stream);
            return true;
        }

        [HttpPost, Route("Delete")]
        public bool Delete([FromBody] FileEntity FileEntity)
        {
            if (!FileEntity.Path.StartsWith("/Files"))
                throw new BadRequestException("File path needs start with \"Files\"");
            string file = Path.Combine(Directory.GetCurrentDirectory(), FileEntity.Path, FileEntity.FileName);
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);
            else
                throw new BadRequestException("File didn't existed");
            return true;
        }
    }

    public class FileEntity
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }
    }

    [Route("api/Directories")]
    public class DirectoryController : Controller
    {
        [HttpPost, Route("Create")]
        public bool Create([FromBody] DirectoryEntity DirectoryEntity)
        {
            if (!DirectoryEntity.Path.StartsWith("/Files"))
                throw new BadRequestException("Directory path needs start with \"Files\"");
            string folder = Path.Combine(Directory.GetCurrentDirectory() + DirectoryEntity.Path);
            if (System.IO.Directory.Exists(folder))
                throw new BadRequestException("Directory existed");
            else
                System.IO.Directory.CreateDirectory(folder);
            return true;
        }

        [HttpPost, Route("Rename")]
        public bool Rename([FromBody] DirectoryEntity DirectoryEntity)
        {
            if (!DirectoryEntity.SourcePath.StartsWith("/Files"))
                throw new BadRequestException("Directory path needs start with \"Files\"");
            if (!DirectoryEntity.DestinationPath.StartsWith("/Files"))
                throw new BadRequestException("Directory path needs start with \"Files\"");
            string sourceDirectory = Path.Combine(Directory.GetCurrentDirectory() + DirectoryEntity.SourcePath);
            string destinationDirectory = Path.Combine(Directory.GetCurrentDirectory() + DirectoryEntity.DestinationPath);
            if (!System.IO.Directory.Exists(sourceDirectory))
                throw new BadRequestException("Source Directory didn't exist");
            if (System.IO.Directory.Exists(destinationDirectory))
                throw new BadRequestException("Destination Directory existed");

            System.IO.Directory.Move(sourceDirectory, destinationDirectory);
            return true;
        }

        [HttpPost, Route("Delete")]
        public bool Delete([FromBody] DirectoryEntity DirectoryEntity)
        {
            if (!DirectoryEntity.Path.StartsWith("/Files"))
                throw new BadRequestException("Directory path needs start with \"Files\"");
            string folder = Path.Combine(Directory.GetCurrentDirectory() + DirectoryEntity.Path);
            if (System.IO.Directory.Exists(folder))
            {
                clearFolder(folder);
                if (Directory.GetFiles(folder).Length + Directory.GetDirectories(folder).Length > 0)
                    throw new BadRequestException("Directory didn't empty");
                System.IO.Directory.Delete(folder);
            }
            else
                throw new BadRequestException("Directory didn't existed");
            return true;
        }

        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }
    }

    public class DirectoryEntity
    {
        public string Path { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
    }
}