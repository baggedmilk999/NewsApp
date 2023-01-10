//using Javax.Security.Auth;
using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsPage : ContentPage
{
	public List<Article> ArticlesList { get; set; }
	public List<Category> CategorysList = new List<Category>()
	{
		new Category() {Name = "breaking-news"},
		new Category() {Name = "world"},
		new Category() {Name = "nation"},
		new Category() {Name = "business"},
		new Category() {Name = "technology"},
		new Category() {Name = "entertainment"},
		new Category() {Name = "sports"},
		new Category() {Name = "science"},
		new Category() {Name = "health"},
	};
	public NewsPage()
	{
		InitializeComponent();
		ArticlesList = new List<Article>();
		CvCategories.ItemsSource = CategorysList;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await PassCategory("breaking-news");


	}
	public async Task PassCategory(string categoryName)
	{
		CvNews.ItemsSource = null;
		ArticlesList.Clear();
        ApiService apiService = new ApiService();
		var newsResult = await apiService.GetNews(categoryName);
		foreach (var item in newsResult.Articles)
		{
			ArticlesList.Add(item);
		}
		CvNews.ItemsSource = ArticlesList;
		 async void CvcCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedItem = e.CurrentSelection.FirstOrDefault() as Category;
			await PassCategory(selectedItem.Name);
		}

		 async void CvNews_SelectonChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
			await Navigation.PushAsync(new NewsDetailPage(selectedItem));
		}
	} }