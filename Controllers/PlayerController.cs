using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NbaApp.Core.Database;
using NbaApp.Core.Database.Queries;
using NbaApp.Models;

public class PlayerController : Controller
{
    private readonly ILogger<PlayerController> _logger;
    private readonly MongoConnector _mongoConnector;
    private readonly PlayerQuery _playerQuery;

    public PlayerController(IConfiguration configuration, ILogger<PlayerController> logger, MongoConnector mongoConnector)
    {
        _logger = logger;
        _mongoConnector = mongoConnector;
        _playerQuery = new PlayerQuery(_mongoConnector, configuration.GetValue<string>("DefaultSeason"));
    }

    [Route("Player/overview/{id}")]
    public IActionResult Index(string id)
    {
        NbaApp.Core.Types.Player player = _playerQuery.GetPlayerById(id);
        ViewData["Title"] = player.LastName + ", " + player.FirstName;
        return View(player);
    }

    public IActionResult Select(List<NbaApp.Core.Types.Player> players) {
        ViewData["Title"] = "Player Search";
        ViewData["players"] = from p in players select p;
        return View();
    }
    
    public IActionResult Search()
    {
        ViewData["Title"] = "Player Search";
        ViewData["Databases"] = _mongoConnector.DatabaseNames;
        return View();
    }

    [HttpPost]
    public IActionResult Search(string fname, string lname, string id, string year) {
        _playerQuery.Database = year;

        if(id != null) {
            return RedirectToAction("Index", "Player", new { id });
        } else if(fname != null && lname != null) {
            List<NbaApp.Core.Types.Player> players = _playerQuery.GetPlayerByName(fname, lname);
            if(players.Count == 1) {
                return RedirectToAction("Index", "Player", new { id = players.First().PlayerId });
            } else {
                return RedirectToAction("Player", "Select", players);
            }
        }

        throw new Exception("Player id or full name must be specified in player search!");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}