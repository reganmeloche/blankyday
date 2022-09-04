using Code.Libs;
using Code.Helpers;
using Code.Objects;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// DI

// Main Apis
builder.Services.AddScoped<IObjLib<Fact>, FactLib>();
builder.Services.AddScoped<IObjLib<Word>, WordLib>();
builder.Services.AddScoped<IObjLib<Joke>, JokeLib>();
builder.Services.AddScoped<IObjLib<Exercise>, ExerciseLib>();
builder.Services.AddScoped<IObjLib<Photo>, PhotoLib>();
builder.Services.AddScoped<IObjLib<Calvin>, CalvinLib>();
builder.Services.AddScoped<IObjLib<Quote>, QuoteLib>();
builder.Services.AddScoped<IObjLib<Riddle>, RiddleLib>();
builder.Services.AddScoped<IObjLib<Country>, CountryLib>();
builder.Services.AddScoped<IObjLib<HistoricalEvent>, HistoricalEventLib>();

// Fetchers
builder.Services.AddScoped<IFetchObj<Fact>, Fetcher<Fact>>();
builder.Services.AddScoped<IFetchObj<Word>, Fetcher<Word>>();
builder.Services.AddScoped<IFetchObj<Joke>, Fetcher<Joke>>();
builder.Services.AddScoped<IFetchObj<Photo>, Fetcher<Photo>>();
builder.Services.AddScoped<IFetchObj<Exercise>, Fetcher<Exercise>>();
builder.Services.AddScoped<IFetchObj<Calvin>, Fetcher<Calvin>>();
builder.Services.AddScoped<IFetchObj<Quote>, Fetcher<Quote>>();
builder.Services.AddScoped<IFetchObj<Riddle>, Fetcher<Riddle>>();
builder.Services.AddScoped<IFetchObj<Country>, Fetcher<Country>>();
builder.Services.AddScoped<IFetchObj<HistoricalEvent>, Fetcher<HistoricalEvent>>();

// Helpers
builder.Services.AddScoped<IGetRandomWord, RandomWordLib>();
builder.Services.AddScoped<IInnerCalvinApi, CalvinApi>();
builder.Services.AddScoped<IChooseUnsplashPhoto, PhotoChooser>();
builder.Services.AddScoped<IInnerApi, InnerApi>();
builder.Services.AddScoped<IInnerPhotoApi, UnsplashApi>();
builder.Services.Configure<InnerApiOptions>(opts => builder.Configuration.GetSection("InnerApiOptions").Bind(opts));
builder.Services.Configure<UnsplashApiOptions>(opts => builder.Configuration.GetSection("UnsplashApiOptions").Bind(opts));
builder.Services.Configure<CalvinApiOptions>(opts => builder.Configuration.GetSection("CalvinApiOptions").Bind(opts));
// END DI


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
