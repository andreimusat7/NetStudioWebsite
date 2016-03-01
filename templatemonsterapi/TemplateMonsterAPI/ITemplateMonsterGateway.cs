using TemplateMonsterAPI.Descriptors;

namespace TemplateMonsterAPI
{
	public interface ITemplateMonsterGateway
	{
		ScreenshotsDescriptor GetScreenshots();
		CurrencyDescriptor GetCurrencies();
		FeaturedDescriptor GetFeatured();
		TemplateCategoryDescriptor GetTemplateWithCategory();
		AuthorsDescriptor GetAuthors();
		CategoriesDescriptor GetCategories();
		SourcesDescriptor GetSources();
		StylesDescriptor GetStyles();
		TemplateStyleDescriptor GetTemplateWithStyles();
		TemplateTypesDescriptor GetTemplateTypes();
	}
}