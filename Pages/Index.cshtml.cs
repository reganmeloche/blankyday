using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Code.Libs;
using Code.Objects;
using Code.Helpers;

namespace blankday.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly IFetchObj<Word> _wordFetcher;
    private readonly IFetchObj<Fact> _factFetcher;
    private readonly IFetchObj<Joke> _jokeFetcher;
    private readonly IFetchObj<Photo> _photoFetcher;
    private readonly IFetchObj<Exercise> _exerciseFetcher;
    private readonly IFetchObj<Calvin> _calvinFetcher;
    private readonly IFetchObj<Riddle> _riddleFetcher;
    private readonly IFetchObj<Country> _countryFetcher;
    private readonly IFetchObj<HistoricalEvent> _historicalEventFetcher;
    private readonly IFetchObj<Quote> _quoteFetcher;



    public Word Word { get; set; }
    public Fact Fact { get; set; }
    public Joke Joke { get; set; }
    public Exercise Exercise { get; set; }
    public Photo Photo { get; set; }
    public Calvin Calvin { get; set; }
    public Riddle Riddle { get; set; }
    public HistoricalEvent HistoricalEvent { get; set; }
    public Quote Quote { get; set; }
    public Country Country { get; set; }

    public IndexModel(
        ILogger<IndexModel> logger,
        IFetchObj<Word> wordFetcher,
        IFetchObj<Joke> jokeFetcher,
        IFetchObj<Fact> factFetcher,
        IFetchObj<Photo> photoFetcher,
        IFetchObj<Exercise> exerciseFetcher,
        IFetchObj<Calvin> calvinFetcher,
        IFetchObj<Country> countryFetcher,
        IFetchObj<Riddle> riddleFetcher,
        IFetchObj<HistoricalEvent> historicalEventFetcher,
        IFetchObj<Quote> quoteFetcher
        )
    {
        _logger = logger;
        _wordFetcher = wordFetcher;
        _jokeFetcher = jokeFetcher;
        _factFetcher = factFetcher;
        _photoFetcher = photoFetcher;
        _exerciseFetcher = exerciseFetcher;
        _calvinFetcher = calvinFetcher;
        _countryFetcher = countryFetcher;
        _historicalEventFetcher = historicalEventFetcher;
        _riddleFetcher = riddleFetcher;
        _quoteFetcher = quoteFetcher;


    }

    public async Task OnGet(bool refresh=false)
    {
        try {
            Word = await _wordFetcher.Fetch(refresh);
            Fact = await _factFetcher.Fetch(refresh);
            Joke = await _jokeFetcher.Fetch(refresh);
            Exercise = await _exerciseFetcher.Fetch(refresh);
            Photo = await _photoFetcher.Fetch(refresh);
            Calvin = await _calvinFetcher.Fetch(refresh);
            Country = await _countryFetcher.Fetch(refresh);
            Riddle = await _riddleFetcher.Fetch(refresh);
            HistoricalEvent = await _historicalEventFetcher.Fetch(refresh);
            Quote = await _quoteFetcher.Fetch(refresh);
        } catch(Exception e) {
            Console.WriteLine(e.Message);
        }
        
    }
}
