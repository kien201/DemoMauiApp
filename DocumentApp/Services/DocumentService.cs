using DocumentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentApp.Services
{
    public class DocumentService
    {
        readonly DocumentDbContext documentDbContext;
        public DocumentService(DocumentDbContext context)
        {
            documentDbContext = context;
        }

        public List<Document> GetDocumentsByPath(string path)
        {
            return documentDbContext.Documents
                .Where(x => x.Path.Equals(path))
                .OrderByDescending(x => x.IsFolder)
                .ToList();
        }

        public async Task<Document?> AddDocument(Document document, FileResult? file)
        {
            var isDocumentExist = await documentDbContext.Documents.AnyAsync(x => 
                x.Path.Equals(document.Path) && 
                x.Name.Equals(document.Name));
            if (isDocumentExist)
            {
                var mainPage = Application.Current?.MainPage;
                await mainPage.DisplayAlert("Cant create document", "Document already exists", "Cancel");
                return null;
            }

            await SaveFile(file, document.Path, document.Name);
            document.CreatedDate = DateTime.Now;
            document.UpdatedDate = DateTime.Now;
            await documentDbContext.Documents.AddAsync(document);
            await documentDbContext.SaveChangesAsync();
            return document;
        }

        public void DeleteDocument(int id)
        {
            var document = documentDbContext.Documents.Find(id);
            if (document != null)
            {
                documentDbContext.Documents.Remove(document);
                documentDbContext.SaveChanges();
            }
        }

        public async Task SaveFile(FileResult? file, string path, string name)
        {
            if (file != null)
            {
                using var fileStream = await file.OpenReadAsync();
                string targetPath = Path.Combine(FileSystem.AppDataDirectory, path.Trim('/'));
                if (!Directory.Exists(targetPath)) Directory.CreateDirectory(targetPath);

                string targetFile = Path.Combine(targetPath, name);
                using var targetStream = File.Create(targetFile);
                fileStream.CopyTo(targetStream);
            }
        }
    }
}
