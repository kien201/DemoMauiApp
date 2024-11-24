using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DocumentApp.Models;
using DocumentApp.Pages;
using DocumentApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DocumentApp.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        readonly NavigationService navigationService;
        readonly DocumentService documentService;

        public ObservableCollection<Document> Documents { get; set; } = new ObservableCollection<Document>();

        [ObservableProperty]
        private string currentPath = "/";

        [RelayCommand]
        private async Task AddDocument()
        {
            var mainPage = Application.Current?.MainPage;
            string action = await mainPage.DisplayActionSheet("What do you want to add?", "Cancel", null, "Folder", "File");
            if (string.IsNullOrEmpty(action) || action.Equals("Cancel")) return;

            string name = await mainPage.DisplayPromptAsync($"Add {action}", $"{action} name:");
            if (string.IsNullOrEmpty(name)) return;

            FileResult? file = null;
            if (action.Equals("File")) file = await FilePicker.Default.PickAsync();

            await documentService.AddDocument(new Document()
            {
                IsFolder = action.Equals("Folder"),
                Name = name,
                Path = CurrentPath,
            }, file);
            UpdateDocuments();
        }

        [RelayCommand]
        private void DeleteDocument(int id)
        {
            documentService.DeleteDocument(id);
            UpdateDocuments();
        }

        [RelayCommand]
        private void MoveToFolder(string folderPath)
        {
            folderPath = ConvertPath(folderPath);
            CurrentPath = folderPath;
            UpdateDocuments();
        }

        [RelayCommand]
        private async Task NavigateToDetail(int id)
        {
            var document = Documents.FirstOrDefault(x => x.Id == id);
            if (document == null) return;

            await navigationService.NavigateToPage<DetailPage>(document);
        }

        public MainPageViewModel(NavigationService navigationService, DocumentService documentService)
        {
            this.navigationService = navigationService;
            this.documentService = documentService;
            UpdateDocuments();
        }

        private void UpdateDocuments()
        {
            //Documents.Clear();
            //foreach (var item in documentService.GetDocumentsByPath(CurrentPath))
            //{
            //    Documents.Add(item);
            //}
            Documents = new ObservableCollection<Document>(documentService.GetDocumentsByPath(CurrentPath));
            OnPropertyChanged(nameof(Documents));
        }

        string ConvertPath(string path)
        {
            if (path.Equals("/")) return path;
            return path.Replace("//", "/").TrimEnd('/');
        }
    }
}
